using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class Dashboard : Form
    {
        private string _senderName;

        public Dashboard(string senderName)
        {
            InitializeComponent();
            _senderName = senderName;
            lblDate.Text = "Today is - " + DateTime.Now.ToString("dddd dd MMMM yyyy");
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                this.staffMessageTableAdapter.Fill(this.dsDentist.StaffMessage);
                ScrollToBottom();

                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    // Appointments today
                    SqlCommand cmd1 = new SqlCommand(
                        "SELECT COUNT(*) FROM Appointment WHERE CAST(Appointment_Date AS DATE) = CAST(GETDATE() AS DATE)", conn);
                    lblAppointmentsCount.Text = cmd1.ExecuteScalar().ToString();

                    // Appointments this week
                    SqlCommand cmd2 = new SqlCommand(
                        @"SELECT COUNT(*) FROM Appointment 
                          WHERE Appointment_Date >= DATEADD(DAY, 1-DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
                          AND Appointment_Date < DATEADD(DAY, 8-DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))", conn);
                    lblPatientsCount.Text = cmd2.ExecuteScalar().ToString();

                    // Unpaid invoices
                    SqlCommand cmd3 = new SqlCommand(
                        "SELECT COUNT(*) FROM Invoice WHERE invoice_status = 'Unpaid'", conn);
                    lblInvoicesCount.Text = cmd3.ExecuteScalar().ToString();

                    // Today's schedule
                    SqlCommand cmd4 = new SqlCommand(
                        @"SELECT t.Slot_Start_Time,
                          p.Patient_First_Name + ' ' + p.Patient_Last_Name AS PatientName,
                          tr.TreatmentName,
                          a.Appointment_Status
                          FROM Appointment a
                          JOIN Patient p ON a.Patient_ID = p.Patient_ID
                          JOIN Timeslot t ON a.Timeslot_ID = t.Timeslot_ID
                          LEFT JOIN PatientTreatment pt ON a.Appointment_ID = pt.Appointment_ID
                          LEFT JOIN Treatment tr ON pt.TreatmentID = tr.TreatmentID
                          WHERE CAST(a.Appointment_Date AS DATE) = CAST(GETDATE() AS DATE)
                          ORDER BY t.Slot_Start_Time", conn);

                    SqlDataReader reader = cmd4.ExecuteReader();

                    dgvSchedule.Rows.Clear();

                    while (reader.Read())
                    {
                        dgvSchedule.Rows.Add(
                            reader["Slot_Start_Time"].ToString(),
                            reader["PatientName"].ToString(),
                            reader["TreatmentName"] == DBNull.Value
                                ? "No Treatment"
                                : reader["TreatmentName"].ToString(),
                            reader["Appointment_Status"].ToString()
                        );
                    }

                    dgvSchedule.ClearSelection();
                    dgvSchedule.CurrentCell = null; // Prevent first row auto-selection
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading messages: " + ex.Message);
                MessageBox.Show("Error loading dashboard: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                this.staffMessageTableAdapter.Fill(this.dsDentist.StaffMessage);
                lstMessages.SelectedIndex = -1;
                ScrollToBottom();

                dgvSchedule.ClearSelection();
                dgvSchedule.CurrentCell = null; // Prevent first row auto-selection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading messages: " + ex.Message);
            }
        }

        private void staffMessageBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.staffMessageBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsDentist);
        }

        private void staffMessageBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.staffMessageBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsDentist);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessages.Text) ||
                txtMessages.Text == "Type your message here...")
                return;

            try
            {
                this.staffMessageTableAdapter.Insert(
                    _senderName,
                    txtMessages.Text.Trim(),
                    DateTime.Now);

                this.staffMessageTableAdapter.Fill(this.dsDentist.StaffMessage);
                txtMessages.Clear();
                ScrollToBottom();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message);
            }
        }

        private void ScrollToBottom()
        {
            if (lstMessages.Items.Count > 0)
            {
                lstMessages.TopIndex = lstMessages.Items.Count - 1;
            }
        }

        private void txtMessages_Enter(object sender, EventArgs e)
        {
            if (txtMessages.Text == "Type your message here...")
            {
                txtMessages.Clear();
                txtMessages.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtMessages_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessages.Text))
            {
                txtMessages.Text = "Type your message here...";
                txtMessages.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void lstMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMessages.SelectedIndex != -1)
            {
                lstMessages.SelectedIndex = -1;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void lblInvoicesText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string unpaidPatients = "";

                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"SELECT
                            p.Patient_First_Name + ' ' + p.Patient_Last_Name AS PatientName,
                            i.invoice_total_amount
                          FROM Invoice i
                          INNER JOIN Appointment a ON i.appointment_id = a.Appointment_ID
                          INNER JOIN Patient p ON a.Patient_ID = p.Patient_ID
                          WHERE i.invoice_status = 'Unpaid'", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        unpaidPatients +=
                            reader["PatientName"].ToString() +
                            " - R" +
                            reader["invoice_total_amount"].ToString() +
                            Environment.NewLine;
                    }

                    reader.Close();
                }

                if (string.IsNullOrWhiteSpace(unpaidPatients))
                {
                    MessageBox.Show(
                        "There are no unpaid invoices.",
                        "Unpaid Invoices",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        unpaidPatients,
                        "Patients With Unpaid Invoices",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading unpaid invoices: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}