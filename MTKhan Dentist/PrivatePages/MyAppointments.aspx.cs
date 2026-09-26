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
        protected void Page_Load(object sender, EventArgs e)
        {
            // TEMP: replace with real value once login sets Session["PatientId"]
            if (Session["PatientId"] == null)
            {
                Session["PatientId"] = 1;
            }

            if (!IsPostBack)
            {
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            int patientId = (int)Session["PatientId"];

            using (var db = new DSEntity()) // replace with your actual context class name
            {
                var today = DateTime.Today;

                var allAppointments = db.Appointments
                    .Where(a => a.Patient_ID == patientId)
                    .Select(a => new
                    {
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
                    .Where(a => a.Appointment_Status == "Scheduled" && a.Appointment_Date >= today)
                    .OrderBy(a => a.Appointment_Date)
                    .ThenBy(a => a.Slot_Start_Time)
                    .Select(a => new
                    {
                        a.Appointment_Date,
                        Time = a.Slot_Start_Time.ToString(@"hh\:mm"),
                        a.Dentist,
                        TreatmentName = a.TreatmentName ?? "Appointment",
                        a.Appointment_Status,
                        StatusBadgeClass = GetStatusBadgeClass(a.Appointment_Status)
                    })
                    .ToList();

                var past = allAppointments
                    .Where(a => a.Appointment_Status != "Scheduled" || a.Appointment_Date < today)
                    .OrderByDescending(a => a.Appointment_Date)
                    .ThenByDescending(a => a.Slot_Start_Time)
                    .Select(a => new
                    {
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

        private string GetStatusBadgeClass(string status)
        {
            switch (status)
            {
                case "Scheduled":
                    return "bg-success";
                case "Completed":
                    return "bg-secondary";
                case "Cancelled":
                    return "bg-danger";
                default:
                    return "bg-info";
            }
        }
    }
}