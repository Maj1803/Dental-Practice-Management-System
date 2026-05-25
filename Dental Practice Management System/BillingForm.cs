using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Dental_Practice_Management_System
{
    public partial class BillingForm : Form
    {
        SqlConnection con;
        decimal total = 0;
        public BillingForm()
        {
            InitializeComponent();
        }

        private void appointmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.appointmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsDentist);

        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsDentist.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.dsDentist.Patient);
            // TODO: This line of code loads data into the 'dsDentist.Treatment' table. You can move, or remove it, as needed.
            this.treatmentTableAdapter.Fill(this.dsDentist.Treatment);
            // TODO: This line of code loads data into the 'dsDentist.Payment' table. You can move, or remove it, as needed.
            this.paymentTableAdapter.Fill(this.dsDentist.Payment);
            // TODO: This line of code loads data into the 'dsDentist.Invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter.Fill(this.dsDentist.Invoice);
            // TODO: This line of code loads data into the 'dsDentist.Appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.dsDentist.Appointment);

            
            cmbMethod.Items.Clear();
            cmbMethod.Items.Add("Cash");
            cmbMethod.Items.Add("Card");
            cmbMethod.Items.Add("EFT");
            cmbMethod.SelectedIndex = -1;

            lblTotal.Text = "R0.00";

            dateTimePicker1.Value =DateTime.Today;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtApptID.Text == "")
            {
                dgvPatient.DataSource = null;
                dgvTreatment.DataSource = null;
                lblTotal.Text = "R0.00";
                return;
            }

            try
            {

                SqlDataAdapter da =new SqlDataAdapter(

                @"SELECTP Patient.Patient_First,Patient.Patient_Last,Patient.Patient_Phone_Number
                  FROM Appointment 
                  INNER JOIN Patient 
                  ON Appointment.Patient_ID=Patient.Patient_ID
                  WHERE
                  Appointment.Appointment_ID=@id", con);

                  da.SelectCommand.Parameters.AddWithValue("@id",txtApptID.Text);

                DataTable dt =new DataTable();

                da.Fill(dt);

                dgvPatient.DataSource =dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }

        private void btnTreatment_Click(object sender, EventArgs e)
        {
            if (txtApptID.Text == "")
            {
                MessageBox.Show("Error:Enter Appointment ID");

                return;
            }

            try
            {

                SqlDataAdapter da =new SqlDataAdapter(@"SELECT Treatment.TreatmentName,Treatment.TreatmentCost
                FROM PatientTreatment 
                INNER JOIN Treatment 
                ON PatientTreatment.TreatmentID=Treatment.TreatmentID
                WHERE PatientTreatment.Appointment_ID=@id",con);

                da.SelectCommand.Parameters.AddWithValue("@id", txtApptID.Text);

                DataTable dt =new DataTable();

                da.Fill(dt);

                dgvTreatment.DataSource =dt;

                total = 0;

                foreach (DataRow rowin dt.Rows)
                {

                 total += Convert.ToDecimal(row["Treatment_Cost"]);
                }
                lblTotal.Text ="R" +total.ToString();

                }
                catch (Exception ex)
               {
                MessageBox.Show(
                ex.Message);

               }
}

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            
        }