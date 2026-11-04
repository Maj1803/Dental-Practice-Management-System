using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace MTKhan_Dentist
{
    public partial class MyAppointments : System.Web.UI.Page
    {
        private const string StatusScheduled = "Scheduled";
        private const string StatusCancelRequested = "Cancel Request";   // shorten if the column is narrow

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["PatientId"] == null)
            {
                Response.Redirect("~/Account/Login");
                return;
            }
            if (!Session["Role"].ToString().Equals("Patient", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/PrivatePages/StaffDashboard.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadAppointments();
            }
        }

        private static bool IsActive(string status)
        {
            return status == "Scheduled" || status == "Requested" || status == StatusCancelRequested;
        }

        private void LoadAppointments()
        {
            int patientId = Convert.ToInt32(Session["PatientId"]);

            using (var db = new DSEntity())
            {
                var today = DateTime.Today;

                var allAppointments = db.Appointments
                    .Where(a => a.Patient_ID == patientId)
                    .Select(a => new
                    {
                        a.Appointment_ID,
                        a.Appointment_Date,
                        a.Timeslot.Slot_Start_Time,
                        Dentist = "Dr. " + a.Employee.Employee_Last_Name,
                        TreatmentName = a.PatientTreatments
                            .Select(pt => pt.Treatment.TreatmentName)
                            .FirstOrDefault(),
                        a.Appointment_Status
                    })
                    .ToList();

                var upcoming = allAppointments
                    .Where(a => IsActive(a.Appointment_Status) && a.Appointment_Date >= today)
                    .OrderBy(a => a.Appointment_Date)
                    .ThenBy(a => a.Slot_Start_Time)
                    .Select(a => new
                    {
                        a.Appointment_ID,
                        a.Appointment_Date,
                        Time = a.Slot_Start_Time.ToString(@"hh\:mm"),
                        a.Dentist,
                        TreatmentName = a.TreatmentName ?? "Appointment",
                        a.Appointment_Status,
                        StatusBadgeClass = GetStatusBadgeClass(a.Appointment_Status)
                    })
                    .ToList();

                var past = allAppointments
                    .Where(a => !(IsActive(a.Appointment_Status) && a.Appointment_Date >= today))
                    .OrderByDescending(a => a.Appointment_Date)
                    .ThenByDescending(a => a.Slot_Start_Time)
                    .Select(a => new
                    {
                        a.Appointment_ID,
                        a.Appointment_Date,
                        Time = a.Slot_Start_Time.ToString(@"hh\:mm"),
                        a.Dentist,
                        TreatmentName = a.TreatmentName ?? "N/A",
                        a.Appointment_Status,
                        StatusBadgeClass = GetStatusBadgeClass(a.Appointment_Status)
                    })
                    .ToList();

                rptUpcoming.DataSource = upcoming;
                rptUpcoming.DataBind();
                pnlNoUpcoming.Visible = upcoming.Count == 0;

                rptPast.DataSource = past;
                rptPast.DataBind();
                pnlNoPast.Visible = past.Count == 0;
            }
        }

        // Used by the Request Cancellation button's Visible= expression
        protected bool CanRequestCancel(object status)
        {
            return Convert.ToString(status) == StatusScheduled;
        }

        protected void rptUpcoming_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "RequestCancel") return;
            if (Session["PatientId"] == null) { Response.Redirect("~/Account/Login"); return; }

            int patientId = Convert.ToInt32(Session["PatientId"]);
            int apptId = Convert.ToInt32(e.CommandArgument);

            using (var db = new DSEntity())
            {
                // Patient_ID in the filter stops a patient cancelling someone else's appointment
                var appt = db.Appointments
                    .FirstOrDefault(a => a.Appointment_ID == apptId && a.Patient_ID == patientId);

                if (appt == null || appt.Appointment_Status != StatusScheduled)
                {
                    lblCancelStatus.Text = "That appointment can't be cancelled.";
                    lblCancelStatus.CssClass = "alert alert-danger d-block";
                    LoadAppointments();
                    return;
                }

                appt.Appointment_Status = StatusCancelRequested;

                db.SystemLinks.Add(new SystemLink
                {
                    Source_App = "Website",
                    Target_App = "FES",
                    Patient_ID = patientId,
                    Appointment_ID = apptId,
                    Message_Type = "CancellationRequested",   // 21 chars, fits varchar(30)
                    Message_Text = "Patient requested cancellation of appointment #" + apptId
                   + " on " + appt.Appointment_Date.ToString("dd MMM yyyy"),
                    Is_Read = false,
                    Created_At = DateTime.Now
                });

                var patient = db.Patients.First(p => p.Patient_ID == patientId);

                db.SystemLinks.Add(new SystemLink
                {
                    Source_App = "Website",
                    Target_App = "FES",
                    Reference_No = "CAN-" + apptId.ToString("D6"),     // e.g. CAN-005054, 10 chars
                    Patient_ID = patientId,
                    Appointment_ID = apptId,
                    Message_Type = "Cancellation Requested",
                    Message_Text = "Cancellation request for " + patient.Patient_First_Name + " "
                                   + patient.Patient_Last_Name + " (" + patient.Patient_Phone_Number + ") on "
                                   + appt.Appointment_Date.ToString("dd MMM yyyy"),
                    Is_Read = false,
                    Created_At = DateTime.Now
                });

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    var msg = string.Join(" | ", ex.EntityValidationErrors
                        .SelectMany(v => v.ValidationErrors)
                        .Select(v => v.PropertyName + ": " + v.ErrorMessage));
                    System.Diagnostics.Debug.WriteLine(msg);
                    lblCancelStatus.Text = msg;          // temporary, remove after debugging
                    lblCancelStatus.CssClass = "alert alert-danger d-block";
                    LoadAppointments();
                    return;
                }

                lblCancelStatus.Text = "Cancellation request sent to reception.";
                lblCancelStatus.CssClass = "alert alert-success d-block";
                LoadAppointments();
            }
        }

        private string GetStatusBadgeClass(string status)
        {
            switch (status)
            {
                case "Scheduled": return "bg-success";
                case "Completed": return "bg-secondary";
                case "Cancelled": return "bg-danger";
                case "Requested": return "bg-warning text-dark";
                case "Declined": return "bg-danger";
                case StatusCancelRequested: return "bg-secondary";
                default: return "bg-info";

            }
        }
    }
}