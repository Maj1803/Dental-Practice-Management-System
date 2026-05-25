using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class MDIParent : Form
    {
        private string userFullName = "";
        private string userRole = "";

        public MDIParent(string fullName, string role)
        {
            InitializeComponent();
            userFullName = fullName;
            userRole = role;
            lblRole.Text = role;
            lblDate.Text = "Welcome back! - " + DateTime.Now.ToString("dddd dd MMMM yyyy");
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
                          p.Patient_First_Name + ' ' + p.Patient_Last_Name AS PatientName
                          FROM Appointment a
                          JOIN Patient p ON a.Patient_ID = p.Patient_ID
                          JOIN Timeslot t ON a.Timeslot_ID = t.Timeslot_ID
                          WHERE CAST(a.Appointment_Date AS DATE) = CAST(GETDATE() AS DATE)
                          ORDER BY t.Slot_Start_Time", conn);

                    SqlDataReader reader = cmd4.ExecuteReader();
                    dgvSchedule.Rows.Clear();
                    while (reader.Read())
                    {
                        dgvSchedule.Rows.Add(
                            reader["Slot_Start_Time"].ToString(),
                            reader["PatientName"].ToString()
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

        private void btnDashboardFrm_Click(object sender, EventArgs e)
        {
            // NavigateTo("Dashboard");
        }

        private void btnPatientsFrm_Click(object sender, EventArgs e)
        {
            // NavigateTo("Patients");
        }

        private void btnAppointmentFrm_Click(object sender, EventArgs e)
        {
            // NavigateTo("Appointments");
        }

        private void btnTreatmentMedicineFrm_Click(object sender, EventArgs e)
        {
            // NavigateTo("Treatments");
        }

        private void btnBillingFrm_Click(object sender, EventArgs e)
        {
            // NavigateTo("Billing");
        }

        private void btnReportsFrm_Click(object sender, EventArgs e)
        {
            // NavigateTo("Reports");
        }

        private void btnStaffFrm_Click(object sender, EventArgs e)
        {
            // NavigateTo("Staff");
        }

        private void btnLogOutFrm_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}