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
using Dental_Practice_Management_System.dsDentistTableAdapters;
namespace Dental_Practice_Management_System
{
    public partial class BillingForm : Form
    {
        decimal amountPaid = 0;
        string appointmentID = "";
        decimal total = 0;
        string patientFullName, patientPhone = "";
        int searchInvoiceID = -1;
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

            //lblTotal.Text = "R0.00";

            dateTimePicker1.Value = DateTime.Today;

            pnlInvoice.Visible = false;
            pnlPayment.Visible = false;
            pnlPaymentHistory.Visible = false;

            rtxtbxDetails.Clear();
            rtxtbxDetails.Clear();
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
                    //lblTotal.Text = "R-.--";

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

                //lblTotal.Text = "R" + total.ToString("0.00");
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

        private int CreateInvoiceID()
        {
            Random rnd = new Random();
            int invoiceID;
            bool exists;

            do
            {
                invoiceID = rnd.Next(100000, 999999);

                exists = dsDentist.Invoice.AsEnumerable().Any(row => row.Field<int>("invoice_id") == invoiceID);

            } while (exists);

            return invoiceID;
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            //NEW LABEL CODE

            dsDentist.Appointment.Clear();

            int rows = appointmentTableAdapter.Fill(dsDentist.Appointment);
                        
            bool found = false;
            int patientID = -1;

            foreach (DataRow row in dsDentist.Appointment.Rows)
            {
                int apptID = Convert.ToInt32(row["Appointment_ID"]);
                
                if (apptID == int.Parse(appointmentID))
                {
                    found = true;
                    patientID = Convert.ToInt32(row["Patient_ID"]);
                }

            }

            dsDentist.Patient.Clear();

            int rows2 = patientTableAdapter.Fill(dsDentist.Patient);

            bool found2 = false;
            
            foreach (DataRow row in dsDentist.Patient.Rows)
            {
                int pID = Convert.ToInt32(row["Patient_ID"]);

                if (pID == patientID)
                {
                    found = true;
                    patientFullName = row["Patient_First_Name"].ToString() +" "+ row["Patient_Last_Name"].ToString();
                    patientPhone = row["Patient_Phone_Number"].ToString();
                    break;

                }

            }

            Invoice frm = new Invoice();

            frm.dgvInvoiceTreatment.DataSource = treatmentBindingSource1;

            frm.lblAppointment.Text = appointmentID;

            

            frm.lblDate.Text = DateTime.Now.ToShortDateString();

            frm.lblPatientName.Text = patientFullName;
            
            frm.lblPatientNumber.Text = patientPhone;

            frm.lblTotal.Text = "R " + total;

            decimal VAT = total * 0.15m;

            frm.lblVAT.Text = "R " + VAT.ToString("0.00");

            decimal grandtotal = total + VAT;

            frm.lblGrandTotal.Text = "R " + grandtotal.ToString("0.00");

            int invoiceID = CreateInvoiceID();

            frm.lblInvoiceID.Text = invoiceID.ToString();

            int paymentID = CreatePaymentID();  

            invoiceTableAdapter.Insert(invoiceID, Convert.ToInt32(appointmentID), paymentID, DateTime.Now, grandtotal, "Unpaid", grandtotal);

            frm.dgvInvoiceTreatment.DataSource = dgvTreatment.DataSource;

            frm.grpPayment.Visible = false;

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
                        
            if (!decimal.TryParse(txtPaymentAmount.Text, out amountPaid))
            {
                MessageBox.Show("Error:Enter a valid amount");

                return;
            }

            amountPaid = Decimal.Parse(txtPaymentAmount.Text);

            if (amountPaid <= 0)
            {
                MessageBox.Show("Amount must greater than 0");

                return;
            }

            

            try
            {
                int paymentID = CreatePaymentID();

                paymentTableAdapter.Insert(paymentID, Convert.ToInt32(txtInvoiceID.Text), amountPaid, cmbMethod.Text, dateTimePicker1.Value);

                MessageBox.Show("Payment has been saved");

                dsDentist.Patient.Clear();

                int rows = patientTableAdapter.Fill(dsDentist.Patient);

                int rows2 = treatmentTableAdapter.FillByAppointmentID(dsDentist.Treatment, Convert.ToInt32(appointmentID));

                DataRow patientRow = dsDentist.Patient.Rows[0];                

                Invoice frm = new Invoice();

                frm.dgvInvoiceTreatment.DataSource = treatmentBindingSource1;

                frm.lblAppointment.Text = appointmentID;


                frm.lblDate.Text = DateTime.Now.ToShortDateString();

                frm.lblPatientName.Text = patientFullName;

                frm.lblPatientNumber.Text = patientPhone;

                frm.lblTotal.Text = "R " + total;

                decimal VAT = total * 0.15m;

                frm.lblVAT.Text = "R " + VAT.ToString("0.00");

                decimal grandtotal = total + VAT;
 
                frm.lblGrandTotal.Text = "R " + grandtotal.ToString("0.00");

                frm.lblInvoiceID.Text = txtInvoiceID.Text;

                /*dsDentist.Invoice.Clear();
                invoiceTableAdapter.Fill(dsDentist.Invoice);

                var row = dsDentist.Invoice.FindByinvoice_id(searchInvoiceID);

                row.invoice_balance_due = grandtotal - amount;
                invoiceTableAdapter.Update(dsDentist.Invoice);*/

                frm.dgvInvoiceTreatment.DataSource = dgvTreatment.DataSource;

                frm.grpPayment.Visible = true;

                decimal balanceD = grandtotal - amountPaid;

                frm.lblAmountPaid.Text = "R " + amountPaid.ToString("0.00");

                frm.lblBalance.Text = "R " + balanceD.ToString("0.00");

                frm.ShowDialog();

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

            dgvPatient.DataSource = null;

            dgvTreatment.DataSource = null;

            //lblTotall.Text = "R0.00";

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
            pnlPaymentHistory.Location = new Point(821, 718);
            pnlPaymentHistory.Visible = false;
            pnlPayment.Location = new Point(23, 188);
            pnlPayment.Visible = true;
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            pnlPayment.Location = new Point(796, 188);
            pnlPayment.Visible = false;
            pnlPaymentHistory.Location = new Point(821, 718);
            pnlPaymentHistory.Visible = false;
            pnlInvoice.Location = new Point(23, 188);
            pnlInvoice.Visible = true;
        }

        private void txtAppt_TextChanged(object sender, EventArgs e)
        {
            /*if (string.IsNullOrWhiteSpace(txtAppt.Text))
            {
                patientBindingSource.DataSource = null;
                dgvPatient.DataSource = patientBindingSource;
                return;
            }

            try
            {
                dsDentist.Patient.Clear();

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
            }*/

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAppt.Text))
            {
                patientBindingSource.DataSource = null;
                dgvPatient.DataSource = patientBindingSource;
                return;
            }

            try
            {
                dsDentist.Patient.Clear();

                patientTableAdapter.FillByAppointmentID(dsDentist.Patient, Convert.ToInt32(txtAppt.Text));

                appointmentID = txtAppt.Text.Trim();
               
                /*if (dsDentist.Patient.Rows.Count > 0)
                {
                    dgvPatient.DataSource = dsDentist.Patient;
                    appointmentID = txtAppt.Text;
                }
                else
                {
                    dgvPatient.DataSource = null;
                    MessageBox.Show("Error: Appointment ID not found.");
                }*/
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Appointment ID.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Patient Details loaded successfully ");
            }
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            string invoiceID = "";

            if (string.IsNullOrWhiteSpace(txtInvoiceID.Text))
            {
                patientBindingSource.DataSource = null;
                dgvPatient.DataSource = patientBindingSource;
                return;
            }

            try
            {
                dsDentist.Invoice.Clear();

                int rows = invoiceTableAdapter.Fill(dsDentist.Invoice);

                searchInvoiceID = int.Parse(txtInvoiceID.Text.Trim());

                if (dsDentist.Patient.Rows.Count > 0)
                {
                    //dgvPatient.DataSource = dsDentist.Patient;
                    invoiceID = txtInvoiceID.Text;

                    bool found = false;

                    foreach (DataRow row in dsDentist.Invoice.Rows)
                    {
                        int invoice = Convert.ToInt32(row["invoice_id"]);

                        if (invoice == int.Parse(invoiceID))
                        {
                            found = true;
                        }

                    }

                    if (found == false)
                    {
                        MessageBox.Show(
                            "No invoices were found for Invoice ID " +
                            invoiceID + ".");
                        return;
                    }

                    string invoices = "";

                    foreach (DataRow row in dsDentist.Invoice.Rows)
                    {
                        int invoice = Convert.ToInt32(row["invoice_id"]);

                        if (invoice == int.Parse(invoiceID))
                        {
                            invoices +=
                            "Invoice ID: " + row["invoice_id"] + Environment.NewLine +
                            "Inoice Date: " + Convert.ToDateTime(row["invoice_date"]).ToShortDateString() + Environment.NewLine +
                            "Invoice Total Amount: R" + row["invoice_total_amount"] + Environment.NewLine +
                            "Inoice Status: " + row["invoice_status"] + Environment.NewLine +
                            "Invoice Balance Due: R" + row["invoice_balance_due"] + Environment.NewLine +
                            Environment.NewLine +
                            "----------------------------------------" +
                            Environment.NewLine;
                        }
                    }

                    rtxtbxDetails.AppendText("Invoice Details for Invoice ID Number: " + invoiceID + "\n");
                    rtxtbxDetails.AppendText("----------------------------------------\n");
                    rtxtbxDetails.AppendText(invoices);

                }
                else
                {
                    //dgvPatient.DataSource = null;
                    MessageBox.Show("Error: Invoice ID not found.");
                    btnReceipt.Enabled = false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Invoice ID.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Appointments loaded successfully ");
            }
        }

        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            pnlInvoice.Location = new Point(796, 188);
            pnlInvoice.Visible = false;
            pnlPayment.Location = new Point(821, 718);
            pnlPayment.Visible = false;
            pnlPaymentHistory.Location = new Point(23, 188);
            pnlPaymentHistory.Visible = true;
            
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            txtInvoiceID.Clear();
            rtxtbxDetails.Clear();
            cmbMethod.SelectedIndex = -1;
            txtPaymentAmount.Clear();
            dateTimePicker1.Value = DateTime.Today;
            txtInvoiceID.Focus();
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            txtPatientName.Clear();
            rtxtbxPaymentHistory.Clear();
            txtPatientName.Focus();
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            string paymentHistory = "";

            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                patientBindingSource.DataSource = null;
                dgvPatient.DataSource = patientBindingSource;
                return;
            }

            try
            {
                dsDentist.Payment.Clear();
                dsDentist.Appointment.Clear();
                dsDentist.Invoice.Clear();
                dsDentist.Patient.Clear();

                int rows = patientTableAdapter.Fill(dsDentist.Patient);

                string patientName = txtPatientName.Text.Trim();
                patientName = patientName.ToLower();

                bool found = false;
                int patientID = -1;

                foreach (DataRow row in dsDentist.Patient.Rows)
                {
                    string name = row["Patient_First_Name"].ToString();
                    name = name.ToLower();

                    if (name == patientName)
                    {
                        found = true;
                        patientID = Convert.ToInt32(row["Patient_ID"]);
                    }

                }

                int rows2 = appointmentTableAdapter.Fill(dsDentist.Appointment);
                                
                bool found2 = false;

                int appointmentID = -1;

                foreach (DataRow row in dsDentist.Appointment.Rows)
                {
                    int pID = Convert.ToInt32(row["Patient_ID"]);

                    if (pID == patientID)
                    {
                        found2 = true;
                        appointmentID = Convert.ToInt32(row["Appointment_ID"]);

                        int rows3 = invoiceTableAdapter.Fill(dsDentist.Invoice);

                        bool found3 = false;

                        int invoiceID = -1;

                        foreach (DataRow row2 in dsDentist.Invoice.Rows)
                        {
                            int aID = Convert.ToInt32(row2["appointment_id"]);

                            if (aID == appointmentID)
                            {
                                found3 = true;
                                invoiceID = Convert.ToInt32(row2["invoice_id"]);
                            }

                        }

                        int rows4 = paymentTableAdapter.Fill(dsDentist.Payment);


                        bool found4 = false;


                        foreach (DataRow row3 in dsDentist.Payment.Rows)
                        {
                            int iID = Convert.ToInt32(row3["invoice_id"]);

                            if (iID == invoiceID)
                            {
                                found3 = true;

                                paymentHistory +=
                                    "Payment ID: " + row3["payment_id"] + Environment.NewLine +
                                    "Amount: R" + row3["payment_amount"] + Environment.NewLine +
                                    "Method: " + row3["payment_method"] + Environment.NewLine +
                                    "Date: " +
                                    Convert.ToDateTime(row3["payment_date"])
                                        .ToShortDateString() +
                                    Environment.NewLine +
                                    "------------------------" +
                                    Environment.NewLine;

                            }

                        }
                    }

                }

                rtxtbxPaymentHistory.AppendText("Payment History for Patient: " + patientName + "\n");
                rtxtbxPaymentHistory.AppendText("----------------------------------------\n");
                rtxtbxPaymentHistory.AppendText(paymentHistory);


            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Patient Name");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading details... ");
            }
        }
    }
 } 
    