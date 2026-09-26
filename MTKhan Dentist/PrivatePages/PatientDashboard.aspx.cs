using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace MTKhan_Dentist
{
    public partial class PatientDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TEMP: replace with real value once login sets Session["PatientId"]
            if (Session["PatientId"] == null)
            {
                Session["PatientId"] = 2014;
            }

            if (!IsPostBack)
            {
                LoadDashboard();
            }
        }

        private void LoadDashboard()
        {
            int patientId = (int)Session["PatientId"];

            using (var db = new DSEntity())
            {
                var patient = db.Patients.FirstOrDefault(p => p.Patient_ID == patientId);

                if (patient == null)
                {
                    Response.Redirect("~/Login.aspx");
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
                    lblNextApptDate.Text = nextAppointment.Appointment_Date.ToString("dd MMM yyyy")
                        + ", " + nextAppointment.Slot_Start_Time.ToString(@"hh\:mm");
                    lblNextApptDetails.Text = "Dr. " + nextAppointment.DentistLastName
                        + " — " + (nextAppointment.TreatmentName ?? "Appointment");
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
    }
}