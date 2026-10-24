using System;
using System.Collections.Generic;
using System.Data;
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
        private DateTime _requestedDate;
        private bool _isBooked = false;

        public AppointmentRequestForm(string referenceNo)
        {
            InitializeComponent();
            _referenceNo = referenceNo;
            lblRef.Text = referenceNo;
            btnCommunicate.Visible = false; // Hide until booked
        }

        private void AppointmentRequestForm_Load(object sender, EventArgs e)
        {
            LoadDetails();
            LoadAvailableSlots();
        }

        private void LoadDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
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
                                _patientName = r["Patient_First_Name"] + " " + r["Patient_Last_Name"];
                                _patientEmail = r["Patient_Email"]?.ToString() ?? "";
                                _requestedDate = Convert.ToDateTime(r["Appointment_Date"]);

                                lblPatient.Text = _patientName;
                                lblRequested.Text = _requestedDate.ToString("dddd, dd MMMM yyyy");
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

        private void LoadAvailableSlots()
        {
            cmbAvailableSlots.Items.Clear();
            cmbAvailableSlots.Items.Add("--- Select a time ---");

            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    // Get the Day_Of_Week for the requested date
                    // (Sunday = 1, Monday = 2, Tuesday = 3, etc.)
                    int dayOfWeek = (int)_requestedDate.DayOfWeek + 1;

                    // Find all active timeslots for this day, excluding ones already booked
                    string sql = @"
                SELECT t.Timeslot_ID, t.Slot_Start_Time 
                FROM Timeslot t
                WHERE t.Day_Of_Week = @dow 
                  AND t.Is_Active = 1
                  AND NOT EXISTS (
                      SELECT 1 FROM Appointment a 
                      WHERE a.Timeslot_ID = t.Timeslot_ID 
                        AND CAST(a.Appointment_Date AS DATE) = CAST(@reqDate AS DATE)
                        AND a.Appointment_ID != @aid
                        AND a.Appointment_Status NOT IN ('Cancelled', 'Declined')
                  )
                ORDER BY t.Slot_Start_Time";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@dow", dayOfWeek);
                        cmd.Parameters.AddWithValue("@reqDate", _requestedDate.Date);
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                // Read the time as a TimeSpan to avoid the conversion error
                                string timeStr = ((TimeSpan)r["Slot_Start_Time"]).ToString(@"hh\:mm");

                                // We pass 'false' for isRequested because the website data is unreliable
                                cmbAvailableSlots.Items.Add(new ComboBoxItem(timeStr, false, Convert.ToInt32(r["Timeslot_ID"])));
                            }
                        }
                    }
                }

                if (cmbAvailableSlots.Items.Count > 1)
                {
                    cmbAvailableSlots.SelectedIndex = 1;
                    lblSlotStatus.Text = "Available slots found for this date.";
                    lblSlotStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblSlotStatus.Text = "No available slots for this date.";
                    lblSlotStatus.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show("The requested date is fully booked or closed. Please suggest an alternative date to the patient.",
                        "No Slots", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading slots: " + ex.Message);
            }
        }

        // ---------------------------------------------------------
        // BUTTON 2: COMMUNICATE (Website + Email)
        // ---------------------------------------------------------
        private void btnCommunicate_Click(object sender, EventArgs e)
        {
            if (!_isBooked) return;

            try
            {
                ComboBoxItem selectedItem = (ComboBoxItem)cmbAvailableSlots.SelectedItem;
                string newDateTimeStr = _requestedDate.ToString("dddd, dd MMMM yyyy") + " at " + selectedItem.Text;

                // 1. Update SystemLink (Website Message)
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    string confirmMsg = $"Your appointment has been CONFIRMED for {newDateTimeStr}. Please arrive 10 minutes early.";

                    using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO SystemLink
                            (Source_App, Target_App, Reference_No, Patient_ID, Appointment_ID, Message_Type, Message_Text)
                        VALUES
                            ('FES', 'Website', @ref, @pid, @aid, 'AppointmentConfirmed', @msg)", conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", _referenceNo);
                        cmd.Parameters.AddWithValue("@pid", _patientId);
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        cmd.Parameters.AddWithValue("@msg", confirmMsg);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Mark original request as read
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE SystemLink SET Is_Read = 1 WHERE Reference_No = @ref AND Target_App = 'FES'", conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", _referenceNo);
                        cmd.ExecuteNonQuery();
                    }
                }

                // 3. Send Email
                SendConfirmationEmail(newDateTimeStr);

                MessageBox.Show("Patient notified via Website Message and Email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Communication failed: " + ex.Message);
            }
        }

        private void SendConfirmationEmail(string newDateTimeStr)
        {
            if (string.IsNullOrWhiteSpace(_patientEmail))
            {
                MessageBox.Show("Patient has no email — email skipped.");
                return;
            }

            try
            {
                // ---------------- CHANGE THESE 4 LINES ----------------
                // ---------------- CHANGE THESE 4 LINES ----------------
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUser = "practiceadminmtk@gmail.com"; // Your full Gmail address
                string smtpPass = "PracticeKhan12@";      // The 16-letter App Password (no spaces)
                string fromAddress = "practiceadminmtk@gmail.com"; // Must match the smtpUser
                                                                 // -------------------------------------------------------
                                                                 // -------------------------------------------------------

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromAddress, "Dr MT Khan Dental Practice");
                    mail.To.Add(_patientEmail);
                    mail.Subject = "Your dental appointment is confirmed";

                    // HTML Body with Link
                    mail.IsBodyHtml = true;
                    mail.Body = $@"
                        <p>Dear {_patientName},</p>
                        <p>Your appointment has been confirmed for:</p>
                        <h3>{newDateTimeStr}</h3>
                        <p>Reference: {_referenceNo}</p>
                        <p>Please arrive 10 minutes early.</p>
                        <br/>
                        <p>Need to book another appointment? <a href='https://www.mtkhandental.co.za/request-appointment'>Click here to Request Appointment</a></p>
                        <br/>
                        <p>Kind regards,<br/>Dr MT Khan Dental Practice</p>";

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

        // ---------------------------------------------------------
        // BUTTON 3: DECLINE
        // ---------------------------------------------------------
        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Decline this request?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    // 1. Update Status
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Appointment SET Appointment_Status = 'Declined' WHERE Appointment_ID = @aid", conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Message to Website
                    using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO SystemLink
                            (Source_App, Target_App, Reference_No, Patient_ID, Appointment_ID, Message_Type, Message_Text)
                        VALUES
                            ('FES', 'Website', @ref, @pid, @aid, 'AppointmentDeclined',
                             'Unfortunately we cannot accommodate the requested time. Please submit a new request or call us.')", conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", _referenceNo);
                        cmd.Parameters.AddWithValue("@pid", _patientId);
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Mark read
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE SystemLink SET Is_Read = 1 WHERE Reference_No = @ref AND Target_App = 'FES'", conn))
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

        // Helper class for ComboBox to store the Timeslot_ID
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public bool IsRequested { get; set; }
            public int TimeslotId { get; set; }

            public ComboBoxItem(string text, bool isRequested, int timeslotId)
            {
                Text = text;
                IsRequested = isRequested;
                TimeslotId = timeslotId;
            }

            public override string ToString()
            {
                return Text + (IsRequested ? " (Requested)" : "");
            }
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {
            if (cmbAvailableSlots.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a valid time slot.");
                return;
            }

            try
            {
                ComboBoxItem selectedItem = (ComboBoxItem)cmbAvailableSlots.SelectedItem;

                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    // Final safety check: Ensure no one else booked this slot in the last few seconds
                    string checkSql = @"
                        SELECT COUNT(*) FROM Appointment 
                        WHERE Timeslot_ID = @tid 
                          AND CAST(Appointment_Date AS DATE) = CAST(@reqDate AS DATE)
                          AND Appointment_Status NOT IN ('Cancelled', 'Declined')
                          AND Appointment_ID != @aid";

                    using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@tid", selectedItem.TimeslotId);
                        checkCmd.Parameters.AddWithValue("@reqDate", _requestedDate.Date);
                        checkCmd.Parameters.AddWithValue("@aid", _appointmentId);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Sorry, this slot was just booked by another receptionist. Please select another time.",
                                "Double Booked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoadAvailableSlots(); // Refresh list
                            return;
                        }
                    }

                    // 2. Update Appointment
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Appointment SET Timeslot_ID = @tid, Appointment_Status = 'Scheduled' " +
                        "WHERE Appointment_ID = @aid", conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", selectedItem.TimeslotId);
                        cmd.Parameters.AddWithValue("@aid", _appointmentId);
                        cmd.ExecuteNonQuery();
                    }
                }

                _isBooked = true;
                btnBook.Enabled = false;
                cmbAvailableSlots.Enabled = false;
                btnCommunicate.Visible = true;
                lblSlotStatus.Text = "Booked successfully. Ready to communicate.";
                lblSlotStatus.ForeColor = System.Drawing.Color.Blue;

                MessageBox.Show("Appointment booked in system. Please click 'Communicate' to notify the patient.",
                    "Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Booking failed: " + ex.Message);
            }

        }
    }
}