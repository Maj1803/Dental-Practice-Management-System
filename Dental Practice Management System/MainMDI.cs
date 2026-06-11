using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class MainMDI : Form
    {
        private string userRole;
        private string userFullName;

        public MainMDI(string fullName, string role)
        {
            InitializeComponent();
            userFullName = fullName;
            userRole = role;
            this.IsMdiContainer = true;
            lblRole.Text = role + " | " + fullName;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = Color.FromArgb(203, 213, 225);
                }
            }
            ApplyRolePermissions();
            OpenChildForm(new Dashboard(userFullName));
        }

        private void ApplyRolePermissions()
        {
            if (userRole == "Dentist")
            {
                btnPatients.Enabled = false;
                btnPatients.ForeColor = Color.Gray;

                btnAppointments.Enabled = false;
                btnAppointments.ForeColor = Color.Gray;

                btnBilling.Enabled = false;
                btnBilling.ForeColor = Color.Gray;
            }
            else if (userRole == "Receptionist")
            {
                btnTreatments.Enabled = false;
                btnTreatments.ForeColor = Color.Gray;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            childForm.MdiParent = this;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }

        private void ShowAccessDenied(string formName)
        {
            MessageBox.Show(
                "Access Denied: You do not have permission to access " + formName + ".",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void btnDashboardForm_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Dashboard(userFullName));
        }

        // --- PATIENTS: Dentist blocked ---
        private void btnPatientsForm_Click_1(object sender, EventArgs e)
        {
            if (userRole == "Dentist") { ShowAccessDenied("Patients"); return; }
            OpenChildForm(new Patients());
        }

        // --- APPOINTMENTS: Dentist blocked ---
        private void btnAppointmentsForm_Click_1(object sender, EventArgs e)
        {
            if (userRole == "Dentist") { ShowAccessDenied("Appointments"); return; }
            OpenChildForm(new Appointments());
        }

        // --- TREATMENTS: Receptionist blocked ---
        private void btnTreatmentMedicineForm_Click_1(object sender, EventArgs e)
        {
            if (userRole == "Receptionist") { ShowAccessDenied("Treatments"); return; }
            OpenChildForm(new TreatmentMedicine());
        }

        // --- BILLING: Dentist blocked ---
        private void btnBillingForm_Click_1(object sender, EventArgs e)
        {
            if (userRole == "Dentist") { ShowAccessDenied("Billing"); return; }
            OpenChildForm(new BillingForm());
        }

        private void btnReportsForm_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Reports());
        }

        private void btnStaffForm_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Staff());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Dashboard(userFullName));
        }

        // --- PATIENTS: Dentist blocked ---
        private void btnPatients_Click(object sender, EventArgs e)
        {
            if (userRole == "Dentist") { ShowAccessDenied("Patients"); return; }
            OpenChildForm(new Patients());
        }

        // --- APPOINTMENTS: Dentist blocked ---
        private void btnAppointments_Click(object sender, EventArgs e)
        {
            if (userRole == "Dentist") { ShowAccessDenied("Appointments"); return; }
            OpenChildForm(new Appointments());
        }

        // --- TREATMENTS: Receptionist blocked ---
        private void btnTreatments_Click(object sender, EventArgs e)
        {
            if (userRole == "Receptionist") { ShowAccessDenied("Treatments"); return; }
            OpenChildForm(new TreatmentMedicine());
        }

        // --- BILLING: Dentist blocked ---
        private void btnBilling_Click(object sender, EventArgs e)
        {
            if (userRole == "Dentist") { ShowAccessDenied("Billing"); return; }
            OpenChildForm(new BillingForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reports());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Employees());
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Help());
        }

        private void MainMDI_Load(object sender, EventArgs e)
        {
        }
    }
}