using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Dental_Practice_Management_System
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();

            ShowPanel(pnlViewEmployees);
        }

        private void pnlUpdateEmployees_Paint(object sender, PaintEventArgs e)
        {

        }


        private void ShowPanel(Panel panelToShow)
        {
            // Hide all panels
            pnlViewEmployees.Visible = false;
            pnlUpdateEmployees.Visible = false;
            pnlCreateEmployee.Visible = false;
            // Show the selected panel
            panelToShow.Visible = true;
        }

        private void btnCreateEmployees_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlCreateEmployee);
        }

        private void btnViewEmployee_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlViewEmployees);
            this.employeeTableAdapter.Fill(this.dsDentist.Employee);
        }

        private void btnUpdateEmployees_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlUpdateEmployees);
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsDentist.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.dsDentist.Employee);

        }

        private void txtSearchEmployees_TextChanged(object sender, EventArgs e)
        {
            employeeTableAdapter.FillBySearchName(dsDentist.Employee, txtSearchEmployees.Text);
            if (dsDentist.Patient.Rows.Count <= 0)
            {
                MessageBox.Show("Patient Not Found.");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //employeeTableAdapter.InsertQuery(txtCreateFirstName.Text, txtCreateSurname.Text, txtCreateRole.Text, txtCreateContactNo.Text, txtCreateEmail.Text, txtCreateUsername.Text, txtCreatePassword.Text, txtCreateNationalID.Text, numCreateAge.Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /* 
            if (gvUpdateEmployee.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee to update.");
                return;
            }
            employeeTableAdapter.UpdateQuery(txtFirstName.Text, txtSurname.Text, txtContactNo.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtCode.Text, txtEmail.Text, Convert.ToInt32(gvUpdateEmployee.CurrentRow.Cells[0].Value));
            MessageBox.Show("Employee Updated Successfully.");
            employeeTableAdapter.Fill(this.dsDentist.Employee);

            */

        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            /* if (gvEmployees.CurrentRow == null)
             {
                 MessageBox.Show("Please select a patient to delete.");
                 return;
             }
             employeeTableAdapter.DeleteQuery(Convert.ToInt32(gvEmployees.CurrentRow.Cells[0].Value));
             MessageBox.Show("Employee Deleted Successfully.");
             employeeTableAdapter.Fill(this.dsDentist.Employee);

            */
        }

        private void gvUpdateEmployee_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtFirstName.Text = gvUpdateEmployee.CurrentRow.Cells[1].Value.ToString();
            txtSurname.Text = gvUpdateEmployee.CurrentRow.Cells[2].Value.ToString();
            txtRole.Text = gvUpdateEmployee.CurrentRow.Cells[3].Value.ToString();
            txtRole.Text = gvUpdateEmployee.CurrentRow.Cells[4].Value.ToString();
            txtNationalID.Text = gvUpdateEmployee.CurrentRow.Cells[5].Value.ToString();
            txtUsername.Text = gvUpdateEmployee.CurrentRow.Cells[6].Value.ToString();
            txtPassword.Text = gvUpdateEmployee.CurrentRow.Cells[7].Value.ToString();
            txtNationalID.Text = gvUpdateEmployee.CurrentRow.Cells[8].Value.ToString();
            numAge.Text = gvUpdateEmployee.CurrentRow.Cells[9].Value.ToString();
        }
    }
}
