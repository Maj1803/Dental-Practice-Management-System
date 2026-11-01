using System;
using System.Linq;
using System.Web.UI;
using System.Data.Entity;

namespace MTKhan_Dentist
{
    public partial class PatientDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Check 
            if (Session["Role"] == null || Session["PatientId"] == null)
            {
                Response.Redirect("~/Account/Login");
                return;
            }

            // 2. ROLE CHECk
            string role = Session["Role"].ToString();
            if (!role.Equals("Patient", StringComparison.OrdinalIgnoreCase))
            {
                // If they are staff, send them to the staff dashboard
                Response.Redirect("~/PrivatePages/StaffDashboard.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadDashboard();
                LoadMessages();
            }
        }

        private void LoadDashboard()
        {
            int patientId = Convert.ToInt32(Session["PatientId"]);

            using (var db = new DSEntity())
            {
                var patient = db.Patients
                    .FirstOrDefault(p => p.Patient_ID == patientId);

                if (patient == null)
                {
                    Session.Remove("PatientId");
                    Response.Redirect("~/Account/Login");
                    return;
                }

                lblPatientName.Text = patient.Patient_First_Name + " " + patient.Patient_Last_Name;
                lblWelcomeName.Text = patient.Patient_First_Name;

                var nextAppointment = db.Appointments
                    .Where(a => a.Patient_ID == patientId
                             && a.Appointment_Status == "Scheduled"
                             && a.Appointment_Date >= DbFunctions.TruncateTime(DateTime.Now))
                    .OrderBy(a => a.Appointment_Date)
                    .ThenBy(a => a.Timeslot.Slot_Start_Time)
                    .Select(a => new
                    {
                        a.Appointment_Date,
                        a.Timeslot.Slot_Start_Time,
                        DentistLastName = a.Employee.Employee_Last_Name,
                        TreatmentName = a.PatientTreatments
                            .Select(pt => pt.Treatment.TreatmentName)
                            .FirstOrDefault(),
                        a.Appointment_Status
                    })
                    .FirstOrDefault();

                if (nextAppointment != null)
                {
                    lblNextApptDate.Text = nextAppointment.Appointment_Date.ToString("dd MMM yyyy") + ", " + nextAppointment.Slot_Start_Time.ToString(@"hh\:mm");
                    lblNextApptDetails.Text = "Dr. " + nextAppointment.DentistLastName + " — " + (nextAppointment.TreatmentName ?? "Appointment");
                    lblNextApptStatus.Text = nextAppointment.Appointment_Status;
                    pnlNextAppointment.Visible = true;
                    pnlNoAppointment.Visible = false;
                }
                else
                {
                    pnlNextAppointment.Visible = false;
                    pnlNoAppointment.Visible = true;
                }
            }
        }

        private void LoadMessages()
        {
            int patientId = Convert.ToInt32(Session["PatientId"]);

            try
            {
                using (var db = new DSEntity())
                {
                    var messages = db.SystemLinks
                        .Where(sl => sl.Target_App == "Website" && sl.Patient_ID == patientId && sl.Is_Read == false)
                        .OrderByDescending(sl => sl.Created_At)
                        .Select(sl => new
                        {
                            sl.Message_Type,
                            sl.Message_Text,
                            sl.Created_At
                        })
                        .ToList();

                    if (messages.Count > 0)
                    {
                        rptMessages.DataSource = messages;
                        rptMessages.DataBind();
                        pnlMessages.Visible = true;

                        var toMark = db.SystemLinks
                            .Where(sl => sl.Target_App == "Website" && sl.Patient_ID == patientId && sl.Is_Read == false)
                            .ToList();

                        foreach (var row in toMark) { row.Is_Read = true; }
                        db.SaveChanges();
                    }
                    else
                    {
                        pnlMessages.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                pnlMessages.Visible = false;
            }
        }
    }
}