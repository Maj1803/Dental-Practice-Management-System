using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            lblDate.Text = "Today is - " + DateTime.Now.ToString("dddd dd MMMM yyyy");
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    // Appointments today
                    SqlCommand cmd1 = new SqlCommand(
                        "SELECT COUNT(*) FROM Appointment WHERE CAST(Appointment_Date AS DATE) = CAST(GETDATE() AS DATE)", conn);
                    lblAppointmentsCount.Text = cmd1.ExecuteScalar().ToString();

                    // Registered patients
                    SqlCommand cmd2 = new SqlCommand(
                        "SELECT COUNT(*) FROM Patient", conn);
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
                            reader["TreatmentName"] == DBNull.Value ? "No Treatment" : reader["TreatmentName"].ToString(),
                            reader["Appointment_Status"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }
    }
}