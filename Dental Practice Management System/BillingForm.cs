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
         decimal amount=0;
        string appointmentID = "";
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

            pnlInvoice.Visible = false;
            pnlPayment.Visible = false;
        }

        private void txtApptID_TextChanged(object sender, EventArgs e)
            
        {
            /* if (txtAppt.Text == "")
            {
                patientBindingSource.DataSource = null;

                dgvPatient.DataSource = patientBindingSource;
                return;
            }

            try
            {

                patientTableAdapter.FillByAppointmentID(dsDentist.Patient, Convert.ToInt32(txtAppt.Text));

                dgvPatient.DataSource = dsDentist.Patient;

            }
            catch (Exception)
            {
                dgvPatient.DataSource = null;
            }*/

            if (string.IsNullOrWhiteSpace(txtAppt.Text))
            {
                patientBindingSource.DataSource = null;
                dgvPatient.DataSource = patientBindingSource;
                return;
            }

            try
            {
                //dsDentist.Patient.Clear();

                patientTableAdapter.FillByAppointmentID(dsDentist.Patient, Convert.ToInt32(txtAppt.Text));

                if (dsDentist.Patient.Rows.Count > 0)
                {
                    dgvPatient.DataSource = dsDentist.Patient;
                    appointmentID = txtAppt.Text;
                }
                else
                {
                    dgvPatient.DataSource = null;
                    MessageBox.Show("Error: Appointment ID not found.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Appointment ID.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnTreatment_Click(object sender, EventArgs e)
        {
            /*if (txtAppt.Text == "")
            {
                MessageBox.Show("Error:Enter Appointment ID");

                return;
            }

            try
            {

                treatmentTableAdapter.FillByAppointmentID(dsDentist.Treatment, Convert.ToInt32(txtAppt.Text));

                dgvTreatment.DataSource = treatmentBindingSource1;

                total = 0;

                foreach (DataGridViewRow row in dgvTreatment.Rows)
                {


                    if (row.Cells["TreatmentCost"].Value != null)

                    {



                    }

                }

                //lblTotall.Text = "R" + total;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }*/

            if (string.IsNullOrWhiteSpace(txtAppt.Text))
            {
                MessageBox.Show("Error: Enter Appointment ID");
                return;
            }

            try
            {
                //dsDentist.Treatment.Clear();

                int rows = treatmentTableAdapter.FillByAppointmentID(dsDentist.Treatment, Convert.ToInt32(txtAppt.Text));

                if (rows == 0)
                {
                    dgvTreatment.DataSource = null;
                    lblTotal.Text = "R-.--";

                    MessageBox.Show("Error: Appointment ID not found");
                    return;
                }

                dgvTreatment.DataSource = treatmentBindingSource1;

                total = 0;

                foreach (DataGridViewRow row in dgvTreatment.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    if (row.Cells["TreatmentCost"].Value != null)
                    {
                        total += Convert.ToDecimal(row.Cells["TreatmentCost"].Value);
                    }
                }

                lblTotal.Text = "R" + total.ToString("0.00");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Appointment ID");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            /*if (dgvTreatment.Rows.Count == 0)
            {
                MessageBox.Show("Error:Load treatment first");

                return;
            }

            Invoice frm = new Invoice();

            frm.lblApptID.Text = txtAppt.Text;

            frm.lblDateToday.Text = DateTime.Now.ToShortDateString();

            frm.lblInvoiceTotal.Text = "R" + total;

            frm.lblBalDue.Text = "R" + (total-amount).ToString("0.00");

            frm.dgvInvoiceTreatment.DataSource = dgvTreatment.DataSource;

            frm.ShowDialog();*/

            if (dgvTreatment.Rows.Count == 0)
            {
                MessageBox.Show("Error: Load treatment first");
                return;
            }

            // Ensure a patient record exists
            if (dsDentist.Patient.Rows.Count == 0)
            {
                MessageBox.Show("Error: No patient found for this appointment");
                return;
            }

            DataRow patientRow = dsDentist.Patient.Rows[0];

            string patientID = patientRow["Patient_ID"].ToString();
            string firstName = patientRow["Patient_First_Name"].ToString();
            string lastName = patientRow["Patient_Last_Name"].ToString();
            string phoneNumber = patientRow["Patient_Phone_Number"].ToString();
            string email = patientRow["Patient_Email"].ToString();
            string address = patientRow["Patient_Address"].ToString();
            string DOB = patientRow["Date_Of_Birth"].ToString();

            string patientName = firstName + " " + lastName;

            Invoice frm = new Invoice();

            frm.lblApptID.Text = appointmentID;

            frm.lblDateToday.Text = DateTime.Now.ToShortDateString();

            //frm.lblPatientID.Text = patientID;

            frm.lblPatientName.Text = patientName;

            //frm.lblDOB.Text = DOB;

            //frm.lblAddress.Text = address;

            //frm.lblEmail.Text = email;

            frm.lblPatientNumber.Text = phoneNumber;

            frm.lblInvoiceTotal.Text = "R" + total;

            frm.lblBalDue.Text = "R" + (total - amount).ToString("0.00");

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
            /*if (txtInvoiceID.Text == "")
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

                paymentTableAdapter.Insert(Convert.ToInt32(txtInvoiceID.Text), Convert.ToInt32(txtAppt.Text), amount, cmbMethod.Text, dateTimePicker1.Value);

                MessageBox.Show("Payment has been saved");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }*/

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

            amount = Decimal.Parse(txtPaymentAmount.Text);

            try
            {
                int paymentID = CreatePaymentID();

                paymentTableAdapter.Insert(paymentID, Convert.ToInt32(txtInvoiceID.Text), amount, cmbMethod.Text, dateTimePicker1.Value);

                MessageBox.Show("Payment has been saved");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private int CreatePaymentID()
        {
            Random rnd = new Random();
            int paymentID;
            bool exists;

            do
            {
                paymentID = rnd.Next(100000, 999999);

                exists = dsDentist.Payment.AsEnumerable().Any(row => row.Field<int>("Payment_ID") == paymentID);

            } while (exists);

            return paymentID;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAppt.Clear();

            txtInvoiceID.Clear();

            txtPaymentAmount.Clear();

            cmbMethod.SelectedIndex = -1;

            dateTimePicker1.Value = DateTime.Today;

            dgvPatient.DataSource = null;

            dgvTreatment.DataSource = null;

            //lblTotall.Text = "R0.00";

            total = 0;

            txtAppt.Focus();

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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlInvoice.Location = new Point(796, 188);
            pnlInvoice.Visible = false;
            pnlPayment.Location = new Point(23, 188);
            pnlPayment.Visible = true;
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            pnlPayment.Location = new Point(796, 188);
            pnlPayment.Visible = false;
            pnlInvoice.Location = new Point(23, 188);
            pnlInvoice.Visible = true;
        }

        private void txtAppt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAppt.Text))
            {
                patientBindingSource.DataSource = null;
                dgvPatient.DataSource = patientBindingSource;
                return;
            }

            try
            {
                //dsDentist.Patient.Clear();

                patientTableAdapter.FillByAppointmentID(dsDentist.Patient, Convert.ToInt32(txtAppt.Text));

                if (dsDentist.Patient.Rows.Count > 0)
                {
                    dgvPatient.DataSource = dsDentist.Patient;
                    appointmentID = txtAppt.Text;
                }
                else
                {
                    dgvPatient.DataSource = null;
                    MessageBox.Show("Error: Appointment ID not found.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Appointment ID.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
    }
 } 
    