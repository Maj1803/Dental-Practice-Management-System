using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MTKhan_Dentist
{
    public partial class RequestApp : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitAppt_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string datePref = txtDatePref.Text.Trim();
            string timePref = ddlTimePref.SelectedValue;
            string concern = ddlConcern.SelectedValue;
            string notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? "None provided." : txtNotes.Text.Trim();

            try
            {
                // Send the email request to Dr MT Khan's reception
                SendAppointmentEmail(name, phone, email, datePref, timePref, concern, notes);

                // Show confirmation message
                pnlFeedback.Visible = true;
                pnlFeedback.CssClass = "alert alert-success alert-dismissible fade show";
                litFeedback.Text = $"<strong>Thank you, {Server.HtmlEncode(name)}!</strong> Your appointment request has been received. Our reception team will contact you at <strong>{Server.HtmlEncode(phone)}</strong> to confirm your booking.";

                // Reset fields
                txtName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDatePref.Text = string.Empty;
                txtNotes.Text = string.Empty;
                ddlTimePref.SelectedIndex = 0;
                ddlConcern.SelectedIndex = 0;
            }
            catch (Exception)
            {
                pnlFeedback.Visible = true;
                pnlFeedback.CssClass = "alert alert-danger alert-dismissible fade show";
                litFeedback.Text = "We could not submit your request online right now. Please call our Port Shepstone rooms directly on <strong>(039) 682 0000</strong>.";
            }
        }

        private void SendAppointmentEmail(string name, string phone, string email, string datePref, string timePref, string concern, string notes)
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
                mail.From = new MailAddress("noreply@yourdomain.co.za", "Dr MT Khan Dental Practice");
                mail.To.Add("appointments@yourdomain.co.za"); // Replace with reception's email
                mail.Subject = $"Appointment Request: {name} ({datePref})";
                mail.Body = emailBody;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient("smtp.yourhost.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("your-smtp-username", "your-smtp-password");
                    smtp.EnableSsl = true;
                    // smtp.Send(mail); // Uncomment once your SMTP server is configured
                }
            }
        }
    }
}
