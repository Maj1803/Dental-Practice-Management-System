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

            dateTimePicker1.Value = DateTime.Today;
        }

        private void txtApptID_TextChanged(object sender, EventArgs e)
            
        {
            if (txtApptID.Text == "")
            {
                patientBindingSource.DataSource = null;

                dgvPatient.DataSource = patientBindingSource;
                return;
            }

            try
            {

                patientTableAdapter.FillByAppointmentID(dsDentist.Patient, Convert.ToInt32(txtApptID.Text));
               
                dgvPatient.DataSource = dsDentist.Patient;

            }
            catch (Exception)
            {
                dgvPatient.DataSource = null;
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

                treatmentTableAdapter.FillByAppointmentID(dsDentist.Treatment, Convert.ToInt32(txtApptID.Text));

                dgvTreatment.DataSource = treatmentBindingSource1;

                total = 0;

                foreach (DataRow row in dsDentist.Treatment.Rows)
                {

               


                    {

                        total += Convert.ToDecimal(row.["TreatmentCost"]);

                    }

                }

                lblTotall.Text = "R" + total;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (dgvTreatment.Rows.Count == 0)
            {
                MessageBox.Show("Error:Load treatment first");

                return;
            }

            Invoice frm = new Invoice();

            frm.lblApptID.Text = txtApptID.Text;

            frm.lblDateToday.Text = DateTime.Now.ToShortDateString();

            frm.lblInvoiceTotal.Text = "R" + total;

            frm.lblBalDue.Text = "R" + total;

            frm.dgvInvoiceTreatment.DataSource = dgvTreatment.DataSource;

            frm.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // validate payment amount 


            decimal amount;

            if (txtPaymentAmount.Text != "" && !decimal.TryParse(txtPaymentAmount.Text, out amount))
            {

                MessageBox.Show("Error:Enter numbers only");

                txtPaymentAmount.Focus();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInvoiceID.Text == "")
            {
                MessageBox.Show("Error:Enter Invoice ID");

                return;
            }

            if (cmbMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Error:Select payment method");

                return;
            }

            decimal amount;

            if (!decimal.TryParse(txtPaymentAmount.Text, out amount))
            {
                MessageBox.Show("Error:Enter a valid amount");

                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Amount must greater than 0");

                return;
            }

            try
            {

                paymentTableAdapter.Insert(Convert.ToInt32(txtInvoiceID.Text), Convert.ToInt32(txtApptID.Text), amount, cmbMethod.Text, dateTimePicker1.Value);

                MessageBox.Show("Payment has been saved");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtApptID.Clear();

            txtInvoiceID.Clear();

            txtPaymentAmount.Clear();

            cmbMethod.SelectedIndex = -1;

            dateTimePicker1.Value = DateTime.Today;

            dgvPatient.DataSource = null;

            dgvTreatment.DataSource = null;

            lblTotall.Text = "R0.00";

            total = 0;

            txtApptID.Focus();

            patientBindingSource.DataSource = null;

            treatmentBindingSource1.DataSource = null;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtInvoiceID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblTotall_Click(object sender, EventArgs e)
        {

        }
    }
        }
    