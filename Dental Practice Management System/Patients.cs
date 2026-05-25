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
            pnlViewPatients.Visible = false;
            pnlUpdatePatients.Visible = false;
            pnlCreatePatients.Visible = false;
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
            ShowPanel(pnlViewPatients);
            this.patientTableAdapter1.Fill(this.dsDentist.Patient);

        }


        private void txtSearchPatients_TextChanged(object sender, EventArgs e)
        {
            patientTableAdapter1.FillByName(dsDentist.Patient, txtSearchPatients.Text);
            if (dsDentist.Patient.Rows.Count <= 0)
            {
                MessageBox.Show("Patient Not Found.");
            }
        }

        private void btnUpdatePatients_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlUpdatePatients);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gvUpdatePatient.CurrentRow == null)
            {
                MessageBox.Show("Please select a patient to update.");
                return;
            }

            patientTableAdapter1.UpdateQuery(txtFirstName.Text, txtSurname.Text, txtContactNo.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtCode.Text, txtEmail.Text, txtAllergies.Text, txtDOB.Text, Convert.ToInt32(gvUpdatePatient.CurrentRow.Cells[0].Value));
            MessageBox.Show("Patient updated successfully.");
            patientTableAdapter1.Fill(this.dsDentist.Patient);
        }

        private void btnCreatePatients_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlCreatePatients);
        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            if (gvPatients.CurrentRow == null)
            {
                MessageBox.Show("Please select a patient to delete.");
                return;
            }

            patientTableAdapter1.DeleteQuery(Convert.ToInt32(gvPatients.CurrentRow.Cells[0].Value));
            MessageBox.Show("Patient deleted successfully.");
            patientTableAdapter1.Fill(this.dsDentist.Patient);

        }

        private void gvUpdatePatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtFirstName.Text = gvUpdatePatient.CurrentRow.Cells[1].Value.ToString();
            txtSurname.Text = gvUpdatePatient.CurrentRow.Cells[2].Value.ToString();
            txtContactNo.Text = gvUpdatePatient.CurrentRow.Cells[3].Value.ToString();
            txtStreet.Text = gvUpdatePatient.CurrentRow.Cells[4].Value.ToString();
            txtSuburb.Text = gvUpdatePatient.CurrentRow.Cells[5].Value.ToString();
            txtCity.Text = gvUpdatePatient.CurrentRow.Cells[6].Value.ToString();
            txtCode.Text = gvUpdatePatient.CurrentRow.Cells[7].Value.ToString();
            txtEmail.Text = gvUpdatePatient.CurrentRow.Cells[8].Value.ToString();
            txtAllergies.Text = gvUpdatePatient.CurrentRow.Cells[9].Value.ToString();
            txtDOB.Text = gvUpdatePatient.CurrentRow.Cells[10].Value.ToString();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtSurname.Text == "" || txtContactNo.Text == "" || txtStreet.Text == "" || txtSuburb.Text == "" || txtCity.Text == "" || txtCode.Text == "" || txtEmail.Text == "" || txtAllergies.Text == "" || txtDOB.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            patientTableAdapter1.CreateQuery(txtFirstName.Text, txtSurname.Text, txtContactNo.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtCode.Text, txtEmail.Text, txtAllergies.Text, txtDOB.Text);
        }
    }
}
