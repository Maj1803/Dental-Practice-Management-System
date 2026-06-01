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

            OpenChildForm(new Dashboard(userFullName));
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


        private void btnDashboardForm_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Dashboard(userFullName));
        }

        private void btnPatientsForm_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Patients());
        }

        private void btnAppointmentsForm_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Appointments());
        }

        private void btnTreatmentMedicineForm_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new TreatmentMedicine());
        }

        private void btnBillingForm_Click_1(object sender, EventArgs e)
        {
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

        private void btnPatients_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Patients());
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Appointments());
        }

        private void btnTreatments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TreatmentMedicine());
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillingForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Reports());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Staff());
        }
    }
}
