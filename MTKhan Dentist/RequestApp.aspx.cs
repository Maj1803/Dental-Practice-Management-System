using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Data.Entity;

namespace MTKhan_Dentist
{
    public partial class RequestApp : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Nothing needed here — keep as-is
        }

        protected void btnSubmitAppt_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string datePref = txtDatePref.Text.Trim();
            string timePref = ddlTimePref.SelectedValue;
            string concern = ddlConcern.SelectedValue;
            string notes = string.IsNullOrWhiteSpace(txtNotes.Text)
                              ? "None provided."
                              : txtNotes.Text.Trim();

            // ---------- Build a DateTime ----------
            DateTime preferred;
            if (!DateTime.TryParse(datePref + " " + timePref, out preferred))
            {
                if (!DateTime.TryParse(datePref, out preferred))
                {
                    ShowError("Please enter a valid preferred date.");
                    return;
                }
            }

            if (preferred <= DateTime.Now)
            {
                ShowError("Please pick a date and time in the future.");
                return;
            }

            string referenceNo = "REQ-" + DateTime.Now.ToString("HHmmss");

            try
            {
                using (var db = new DSEntity())
                {
                    // ---------- 1. Find or create the patient ----------
                    var patient = db.Patients
                        .FirstOrDefault(p => p.Patient_Phone_Number == phone);

                    if (patient == null)
                    {
                        string[] parts = name.Split(new[] { ' ' }, 2);
                        string first = parts[0];
                        string last = parts.Length > 1 ? parts[1] : "";

                        patient = new Patient
                        {
                            Patient_First_Name = first,
                            Patient_Last_Name = last,
                            Patient_Phone_Number = phone,
                            Patient_Street = "Not provided",
                            Patient_Suburb = "Not provided",
                            Patient_City = "Durban",
                            Patient_Code = "4001",
                            Patient_Email = string.IsNullOrWhiteSpace(email)
                                                  ? null : email,
                            Patient_Allergies = null,
                            Patient_DOB = new DateTime(1900, 1, 1)
                        };

                        db.Patients.Add(patient);
                        db.SaveChanges();
                    }

                    // ---------- 2. Placeholder dentist + timeslot ----------
                    int placeholderDentist = db.Employees
                        .Where(em => em.Employee_Role == "Dentist")
                        .Select(em => em.Employee_ID)
                        .FirstOrDefault();

                    int placeholderSlot = db.Timeslots
                        .Where(t => t.Is_Active == true)
                        .Select(t => t.Timeslot_ID)
                        .FirstOrDefault();

                    if (placeholderDentist == 0 || placeholderSlot == 0)
                    {
                        ShowError("No dentist or timeslot configured. " +
                                  "Please call the practice directly.");
                        return;
                    }

                    // ---------- 3. Insert the Appointment ----------
                    var newAppointment = new Appointment
                    {
                        Patient_ID = patient.Patient_ID,
                        Employee_ID = placeholderDentist,
                        Timeslot_ID = placeholderSlot,
                        Appointment_Date = preferred,
                        Appointment_Notes = "Patient requested: " + concern +
                                             " — " + notes,
                        Appointment_Status = "Requested"
                    };

                    db.Appointments.Add(newAppointment);
                    db.SaveChanges();

                    // ---------- 4. Insert the SystemLink row for the FES ----------
                    string patientName = patient.Patient_First_Name + " " +
                                         patient.Patient_Last_Name;

                    string messageText =
                        $"New appointment request for {patientName} ({phone}) " +
                        $"on {preferred:dd MMM yyyy HH:mm}. " +
                        $"Concern: {concern}. Notes: {notes}";

                    var link = new SystemLink
                    {
                        Source_App = "Website",
                        Target_App = "FES",
                        Reference_No = referenceNo,
                        Patient_ID = patient.Patient_ID,
                        Appointment_ID = newAppointment.Appointment_ID,
                        Message_Type = "AppointmentRequested",
                        Message_Text = messageText,
                        Created_At = DateTime.Now,
                        Is_Read = false
                    };

                    db.SystemLinks.Add(link);
                    db.SaveChanges();
                }

                // ---------- Optional email ----------
                try
                {
                    SendAppointmentEmail(name, phone, email,
                                         datePref, timePref, concern, notes);
                }
                catch { /* email failure should not block */ }

                // ---------- Success message ----------
                pnlFeedback.Visible = true;
                pnlFeedback.CssClass = "alert alert-success alert-dismissible fade show";
                litFeedback.Text =
                    $"<strong>Thank you, {Server.HtmlEncode(name)}!</strong> " +
                    $"Your appointment request has been received. " +
                    $"Your reference number is <b>{referenceNo}</b>. " +
                    $"Our reception team will contact you at " +
                    $"<strong>{Server.HtmlEncode(phone)}</strong> to confirm your booking.";

                // ---------- Reset ----------
                txtName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDatePref.Text = string.Empty;
                txtNotes.Text = string.Empty;
                ddlTimePref.SelectedIndex = 0;
                ddlConcern.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                pnlFeedback.Visible = true;
                pnlFeedback.CssClass = "alert alert-danger alert-dismissible fade show";
                litFeedback.Text =
                    "We could not submit your request online right now. " +
                    "Please call our Port Shepstone rooms directly on " +
                    "<strong>(039) 682 0000</strong>.<br/>" +
                    "<small>Details: " + Server.HtmlEncode(ex.Message) + "</small>";
            }
        }

        private void ShowError(string message)
        {
            pnlFeedback.Visible = true;
            pnlFeedback.CssClass = "alert alert-danger alert-dismissible fade show";
            litFeedback.Text = Server.HtmlEncode(message);
        }

        // ---------- Existing email method (unchanged) ----------
        private void SendAppointmentEmail(string name, string phone, string email,
                                           string datePref, string timePref,
                                           string concern, string notes)
        {
            string emailBody = $@"
                New Appointment Request - Dr MT Khan Dental Practice

                Patient Details:
                ----------------
                Name: {name}
                Phone: {phone}
                Email: {email}

                Appointment Preferences:
                ------------------------
                Target Date: {datePref}
                Time Preference: {timePref}
                Primary Concern: {concern}

                Additional Notes / Symptoms:
                ----------------------------
                {notes}
                ";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("noreply@yourdomain.co.za",
                                            "Dr MT Khan Dental Practice");
                mail.To.Add("appointments@yourdomain.co.za");
                mail.Subject = $"Appointment Request: {name} ({datePref})";
                mail.Body = emailBody;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient("smtp.yourhost.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(
                        "your-smtp-username", "your-smtp-password");
                    smtp.EnableSsl = true;
                    // smtp.Send(mail); // Uncomment once SMTP is configured
                }
            }
        }
    }
}