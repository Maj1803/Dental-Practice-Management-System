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
    public partial class AvailabilityOverride : Form
    {
        public AvailabilityOverride()
        {
            InitializeComponent();
        }

        private void chkFullDay_CheckedChanged(object sender, EventArgs e)
        {
            cmbTimeSlot.Enabled = !chkFullDay.Checked;
            if (chkFullDay.Checked)
            {
                cmbTimeSlot.SelectedIndex = -1;
            }
        }

        private void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If they select "Other", show the custom textbox so they can type it out
            if (cmbReason.SelectedItem != null && cmbReason.SelectedItem.ToString() == "Other")
            {
                txtReason.Focus();
            }
            else
            {
                txtReason.Enabled = false;
                txtReason.Clear(); // Clears any old text
            }
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            // If the user starts typing and "Other" isn't already selected...
            if (!string.IsNullOrEmpty(txtReason.Text) && cmbReason.SelectedItem?.ToString() != "Other")
            {
                // ...automatically switch the ComboBox to "Other"
                cmbReason.SelectedItem = "Other";
            }
        }

        private void btnAppointmentFrm_Click(object sender, EventArgs e)
        {
            Appointments appointmentsForm = new Appointments();
            appointmentsForm.Show();
            this.Close();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            //Patients patientsForm = new Patients();
            //patientsForm.Show();
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Dashboard dashboardForm = new Dashboard();
            //dashboardForm.Show();
            //this.Close();
        }

        private void btnTreatmentMedicine_Click(object sender, EventArgs e)
        {
            TreatmentMedicine treatmentMedicineForm = new TreatmentMedicine();
            treatmentMedicineForm.Show();
            this.Close();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            //Billing billingForm = new Billing();
            //billingForm.Show();
            //this.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //Reports reportsForm = new Reports();
            //reportsForm.Show();
            //this.Close();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            //Staff staffForm = new Staff();
            //staffForm.Show();
            //this.Close();
        }
    }
}
