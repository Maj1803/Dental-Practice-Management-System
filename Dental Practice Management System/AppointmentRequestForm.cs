using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class AppointmentRequestForm : Form
    {
        private readonly string _referenceNo;
        private int _appointmentId = -1;
        private int _patientId = -1;
        private string _patientName = "";
        private string _patientEmail = "";

        public AppointmentRequestForm(string referenceNo)
        {
            InitializeComponent();
            _referenceNo = referenceNo;
            lblRef.Text = referenceNo;
        }

        private void AppointmentRequestForm_Load(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void LoadDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(
                    Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    string sql = @"
                        SELECT sl.Appointment_ID, sl.Patient_ID,
                               p.Patient_First_Name, p.Patient_Last_Name,
                               p.Patient_Email,
                               a.Appointment_Date, a.Appointment_Notes
                        FROM SystemLink sl
                        INNER JOIN Patient     p ON sl.Patient_ID     = p.Patient_ID
                        INNER JOIN Appointment a ON sl.Appointment_ID = a.Appointment_ID
                        WHERE sl.Reference_No = @ref";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", _referenceNo);

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                _appointmentId = Convert.ToInt32(r["Appointment_ID"]);
                                _patientId = Convert.ToInt32(r["Patient_ID"]);
                                _patientName = r["Patient_First_Name"] + " " +
                                                 r["Patient_Last_Name"];
                                _patientEmail = r["Patient_Email"]?.ToString() ?? "";

                                lblPatient.Text = _patientName;
                                lblRequested.Text =
                                    Convert.ToDateTime(r["Appointment_Date"])
                                        .ToString("dddd, dd MMMM yyyy HH:mm");
                                lblReason.Text = r["Appointment_Notes"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Request not found.");
                                Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load request: " + ex.Message);
                Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(
                    Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    // 1. Set the appointment to Scheduled
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Appointment SET Appointment_Status = 'Scheduled' " +
                        "WHERE Appointment_ID = @aid", conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Write confirmation back to SystemLink for the website
                    string confirmMsg =
                        $"Your appointment on {lblRequested.Text} has been CONFIRMED. " +
                        $"Please arrive 10 minutes early.";

                    using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO SystemLink
                            (Source_App, Target_App, Reference_No,
                             Patient_ID, Appointment_ID,
                             Message_Type, Message_Text)
                        VALUES
                            ('FES', 'Website', @ref,
                             @pid, @aid,
                             'AppointmentConfirmed', @msg)", conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", _referenceNo);
                        cmd.Parameters.AddWithValue("@pid", _patientId);
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        cmd.Parameters.AddWithValue("@msg", confirmMsg);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Mark the original request as handled
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE SystemLink SET Is_Read = 1 " +
                        "WHERE Reference_No = @ref AND Target_App = 'FES'", conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", _referenceNo);
                        cmd.ExecuteNonQuery();
                    }
                }

                SendConfirmationEmail();

                MessageBox.Show("Appointment confirmed. Patient notified by email.",
                                "Confirmed", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Confirmation failed: " + ex.Message);
            }
        }

        private void SendConfirmationEmail()
        {
            if (string.IsNullOrWhiteSpace(_patientEmail))
            {
                MessageBox.Show("Patient has no email — email skipped.");
                return;
            }

            try
            {
                // ---------------- CHANGE THESE 4 LINES ----------------
                string smtpHost = "sandbox.smtp.mailtrap.io";
                int smtpPort = 2525;
                string smtpUser = "YOUR_MAILTRAP_USERNAME";
                string smtpPass = "YOUR_MAILTRAP_PASSWORD";
                string fromAddress = "noreply@mtkhandental.co.za";
                // -------------------------------------------------------

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromAddress, "Dr MT Khan Dental Practice");
                    mail.To.Add(_patientEmail);
                    mail.Subject = "Your dental appointment is confirmed";
                    mail.Body =
                        $"Dear {_patientName},\n\n" +
                        $"Your appointment has been confirmed for:\n" +
                        $"{lblRequested.Text}\n\n" +
                        $"Reference: {_referenceNo}\n\n" +
                        $"Please arrive 10 minutes early.\n\n" +
                        $"Kind regards,\nDr MT Khan Dental Practice";

                    using (SmtpClient client = new SmtpClient(smtpHost, smtpPort))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                        client.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Appointment saved, but email failed: " + ex.Message);
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Decline this request?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(
                    Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Appointment SET Appointment_Status = 'Declined' " +
                        "WHERE Appointment_ID = @aid", conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO SystemLink
                            (Source_App, Target_App, Reference_No,
                             Patient_ID, Appointment_ID,
                             Message_Type, Message_Text)
                        VALUES
                            ('FES', 'Website', @ref, @pid, @aid,
                             'AppointmentDeclined',
                             'Unfortunately we cannot accommodate the requested time. ' +
                             'Please submit a new request or call us.')", conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", _referenceNo);
                        cmd.Parameters.AddWithValue("@pid", _patientId);
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE SystemLink SET Is_Read = 1 " +
                        "WHERE Reference_No = @ref AND Target_App = 'FES'", conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", _referenceNo);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Request declined.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Decline failed: " + ex.Message);
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}