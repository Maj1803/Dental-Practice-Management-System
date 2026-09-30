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

        //cancel req form
        protected void btnShowRequestForm_Click(object sender, EventArgs e)
        {
            pnlRequestForm.Visible = true;
            lblRequestResult.Text = "";
        }

        protected void btnCancelRequest_Click(object sender, EventArgs e)
        {
            pnlRequestForm.Visible = false;
            txtPreferredDate.Text = "";
            txtPreferredTime.Text = "";
            txtReason.Text = "";
            lblRequestResult.Text = "";
        }

        //submit req 
        protected void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            int patientId = (int)Session["PatientId"];

            if (string.IsNullOrWhiteSpace(txtPreferredDate.Text) ||
                string.IsNullOrWhiteSpace(txtPreferredTime.Text))
            {
                lblRequestResult.ForeColor = System.Drawing.Color.Red;
                lblRequestResult.Text = "Please choose a preferred date and time.";
                return;
            }

            DateTime preferred;
            if (!DateTime.TryParse(
                    txtPreferredDate.Text + " " + txtPreferredTime.Text, out preferred))
            {
                lblRequestResult.ForeColor = System.Drawing.Color.Red;
                lblRequestResult.Text = "Invalid date or time.";
                return;
            }
            if (preferred <= DateTime.Now)
            {
                lblRequestResult.ForeColor = System.Drawing.Color.Red;
                lblRequestResult.Text = "Please pick a date in the future.";
                return;
            }

            string referenceNo = "REQ-" + DateTime.Now.ToString("HHmmss");

            try
            {
                using (var db = new DSEntity())
                {
                    // 1. Fetch patient details via EF
                    var patient = db.Patients
                        .Where(p => p.Patient_ID == patientId)
                        .Select(p => new
                        {
                            Name = p.Patient_First_Name + " " + p.Patient_Last_Name,
                            Phone = p.Patient_Phone_Number
                        }).FirstOrDefault();

                    if (patient == null)
                    {
                        lblRequestResult.ForeColor = System.Drawing.Color.Red;
                        lblRequestResult.Text = "Patient record not found.";
                        return;
                    }

                    // 2. Create a placeholder Appointment with status 'Requested'
                    var newAppointment = new Appointment
                    {
                        Patient_ID = patientId,
                        Employee_ID = 1,
                        Timeslot_ID = 1,
                        Appointment_Date = preferred,
                        Appointment_Notes = "Patient requested: " + txtReason.Text,
                        Appointment_Status = "Requested"
                    };

                    db.Appointments.Add(newAppointment);
                    db.SaveChanges();

                    // 3. Write the SystemLink message for the FES
                    string messageText =
                        $"New appointment request for {patient.Name} ({patient.Phone}) " +
                        $"on {preferred:dd MMM yyyy HH:mm}. Reason: {txtReason.Text}";

                    var link = new SystemLink
                    {
                        Source_App = "Website",
                        Target_App = "FES",
                        Reference_No = referenceNo,
                        Patient_ID = patientId,
                        Appointment_ID = newAppointment.Appointment_ID,
                        Message_Type = "AppointmentRequested",
                        Message_Text = messageText,
                        Created_At = DateTime.Now,
                        Is_Read = false
                    };

                    db.SystemLinks.Add(link);
                    db.SaveChanges();
                }
                lblRequestResult.ForeColor = System.Drawing.Color.Green;
                lblRequestResult.Text =
                    $"✔ Request submitted! Reference <strong>{referenceNo}</strong>. " +
                    $"The receptionist will confirm shortly.";

                txtPreferredDate.Text = "";
                txtPreferredTime.Text = "";
                txtReason.Text = "";

                LoadDashboard();
            }
            catch (Exception ex)
            {
                lblRequestResult.ForeColor = System.Drawing.Color.Red;
                lblRequestResult.Text = "Error: " + ex.Message;
            }
        }
        //load messages 
        private void LoadMessages()
        {
            int patientId = (int)Session["PatientId"];

            try
            {
                using (var db = new DSEntity())
                {
                    var messages = db.SystemLinks
                        .Where(sl => sl.Target_App == "Website"
                                  && sl.Patient_ID == patientId
                                  && sl.Is_Read == false)
                        .OrderByDescending(sl => sl.Created_At)
                        .Select(sl => new
                        {
                            sl.Message_Type,
                            sl.Message_Text,
                            sl.Created_At
                        }).ToList();

                    if (messages.Count > 0)
                    {
                        rptMessages.DataSource = messages;
                        rptMessages.DataBind();
                        pnlMessages.Visible = true;

                        // Mark as read using EF
                        var toMark = db.SystemLinks
                            .Where(sl => sl.Target_App == "Website"
                                      && sl.Patient_ID == patientId
                                      && sl.Is_Read == false)
                            .ToList();

                        foreach (var row in toMark)
                            row.Is_Read = true;

                        db.SaveChanges();
                    }
                    else
                    {
                        pnlMessages.Visible = false;
                    }
                }
            }
            catch
            {
                pnlMessages.Visible = false;
            }
        }

    }
}