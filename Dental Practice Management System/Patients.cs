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
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();

            ShowPanel(pnlViewPatients);
        }

        private void ShowPanel(Panel panelToShow)
        {
            // Hide all panels
           /* pnlBookAppointment.Visible = false;
            pnlViewAppointments.Visible = false;
            pnlUpdateAppointment.Visible = false; */
            // Show the selected panel
            panelToShow.Visible = true;
        }


        private void lblSearchAppointments_Click(object sender, EventArgs e)
        {

        }

        private void Patients_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsDentist.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter1.Fill(this.dsDentist.Patient);
            // TODO: This line of code loads data into the 'dsPatients.Patient' table. You can move, or remove it, as needed.
           // this.patientTableAdapter.Fill(this.dsPatients.Patient);

        }

        private void btnViewPatients_Click(object sender, EventArgs e)
        {

        }

        private void searchPatientToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnSearchPatients_Click(object sender, EventArgs e)
        {
            string FirstName = txtSearchPatients.Text;
            if (txtSearchPatients.Text.Length == 0)
            {
                MessageBox.Show("Please input a name of a patient");
            }
            else
            {
                this.patientTableAdapter1.SearchName(this.dsDentist.Patient, FirstName);
                if (dsDentist.Patient.Rows.Count <= 0)
                {
                    MessageBox.Show("Patient Not Found.");
                }
            }
               
        }

        private void searchPatientToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void searchPatientsNameToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void searchNameToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.patientTableAdapter1.SearchName(this.dsDentist.Patient, firstNameToolStripTextBox1.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
