using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class BillingForm : Form
    {
        int selectedPatientID = -1;
        int selectedAppointmentID = -1;
        int searchInvoiceID = -1;
        int lastOpenedInvoiceID = -1;

        decimal total = 0;
        decimal currentBalance = 0;

        string patientFullName = "";
        string patientPhone = "";

        int DGPatientID = -1;
        String DGPatientName = "";
        String DGPatientSurname = "";
        String DGPatientNumber = "";

        //String constr = "Data Source=146.230.177.46;Persist Security Info=True;User ID=GroupWst33;Password=●●●●●●;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio";
        string constr = @"Server=146.230.177.46;User Id=GroupWst33;Password=9d3dx;Encrypt=True;TrustServerCertificate=True;";
        public BillingForm()
        {
            InitializeComponent();

            searchTimer.Tick += searchTimer_Tick;

            txtAppt.TextChanged += txtAppt_TextChanged;
        }

       /* private void dgvPatient_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            DataGridViewRow row = dgvPatient.Rows[e.RowIndex];

            int id = Convert.ToInt32(row.Cells["Patient_ID"].Value);
            DGPatientName = row.Cells["Patient_First_Name"].Value.ToString();
            DGPatientSurname = row.Cells["Patient_Last_Name"].Value.ToString();
            DGPatientNumber = row.Cells["Patient_First_Name"].Value.ToString();
        }*/

        private void txtAppt_TextChanged(Object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void searchTimer_Tick(Object sender, EventArgs e)
        {
            searchTimer.Stop();
            SearchData(txtAppt.Text.Trim());
        }

        private void SearchData(String searchVal)
        {
            string query = @"SELECT Patient_ID, Patient_First_Name, Patient_Last_Name, Patient_Phone_Number FROM Patient WHERE Patient_First_name LIKE @searchVal";

            using (SqlConnection con = new SqlConnection(constr)) 
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@searchVal", searchVal + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    adapter.Fill(dt);
                    dgvPatient.DataSource = dt;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }

        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            dsDentist.EnforceConstraints = false;

            patientTableAdapter.Fill(dsDentist.Patient);
            treatmentTableAdapter.Fill(dsDentist.Treatment);
            paymentTableAdapter.Fill(dsDentist.Payment);
            invoiceTableAdapter.Fill(dsDentist.Invoice);
            appointmentTableAdapter.Fill(dsDentist.Appointment);

            cmbMethod.Items.Clear();
            cmbMethod.Items.Add("Cash");
            cmbMethod.Items.Add("Card");
            cmbMethod.Items.Add("EFT");
            cmbMethod.SelectedIndex = -1;

            label5.Text = "Search Patient Name";
            label8.Text = "Search Patient Name";
            label1.Text = "Invoice ID";
            label4.Text = "Treatments for Selected Patient";
            btnShowDetails.Text = "Load Invoice";
            btnReceipt.Text = "Save Payment";

            lblSelectedBillingPatient.Text = "Selected Patient: none";

            dgvPatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatient.MultiSelect = false;
            dgvPatient.CellClick += dgvPatient_CellClick;

            dgvTreatment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTreatment.MultiSelect = false;

            btnTreatment.Visible = false;
            btnInvoice.Enabled = false;

            FixBillingLayout();

            ShowPanel(pnlInvoice);
            ClearInvoicePanel();
            ClearPaymentPanel();
            ClearHistoryPanel();
        }

        private void FixBillingLayout()
        {
            pnlInvoice.Location = new Point(23, 230);
            pnlPayment.Location = new Point(23, 230);
            pnlPaymentHistory.Location = new Point(23, 230);

            pnlInvoice.Size = new Size(1120, 520);
            pnlPayment.Size = new Size(1120, 520);
            pnlPaymentHistory.Size = new Size(1120, 520);

            grpInvoice.Location = new Point(3, 3);
            grpInvoice.Size = new Size(1080, 500);

           // dgvPatient.Location = new Point(20, 170);
            //dgvPatient.Size = new Size(980, 110);

            btnTreatment.Visible = false;

            //lblSelectedBillingPatient.Location = new Point(20, 295);
            lblSelectedBillingPatient.AutoSize = true;
           // lblSelectedBillingPatient.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
           // lblSelectedBillingPatient.ForeColor = Color.FromArgb(0, 102, 204);

            //dgvTreatment.Location = new Point(170, 330);
            //dgvTreatment.Size = new Size(620, 135);
           // dgvTreatment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnInvoice.Location = new Point(830, 335);
            btnInvoice.Size = new Size(220, 45);
            btnInvoice.Visible = true;
            btnInvoice.BringToFront();

            btnClear1.Location = new Point(890, 405);
            btnClear1.Size = new Size(120, 38);
            btnClear1.BringToFront();
        }

        

        private void ShowPanel(System.Windows.Forms.Panel panel)
        {
            pnlInvoice.Visible = false;
            pnlPayment.Visible = false;
            pnlPaymentHistory.Visible = false;

            panel.Visible = true;
            panel.BringToFront();

            if (panel == pnlInvoice)
            {
                btnInvoice.Visible = true;
                btnInvoice.BringToFront();
                btnClear1.BringToFront();
            }
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlInvoice);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlPayment);

            if (lastOpenedInvoiceID != -1)
            {
                txtInvoiceID.Text = lastOpenedInvoiceID.ToString();
                btnShowDetails_Click(sender, e);
            }
        }

        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlPaymentHistory);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtAppt.Text.Trim().ToLower();
            ClearInvoiceResultsOnly();

            if (search == "")
            {
                MessageBox.Show("Please enter a patient name.");
                return;
            }

            try
            {
                dsDentist.EnforceConstraints = false;
                dsDentist.Patient.Clear();
                dsDentist.Appointment.Clear();
                dsDentist.Treatment.Clear();
                dsDentist.Invoice.Clear();
                
                patientTableAdapter.Fill(dsDentist.Patient);
                appointmentTableAdapter.Fill(dsDentist.Appointment);
                treatmentTableAdapter.Fill(dsDentist.Treatment);
                invoiceTableAdapter.Fill(dsDentist.Invoice);

                DataTable results = dsDentist.Patient.Clone();

                foreach (DataRow row in dsDentist.Patient.Rows)
                {
                    string first = row["Patient_First_Name"].ToString().Trim().ToLower();
                    string last = row["Patient_Last_Name"].ToString().Trim().ToLower();
                    string full = first + " " + last;

                    if (first.Contains(search) || last.Contains(search) || full.Contains(search))

                        results.ImportRow(row);
                }

                patientBindingSource.DataSource = results;
                dgvPatient.DataSource = patientBindingSource;

                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("No patients found for that name.");
                }
                else
                {
                    dgvPatient.ClearSelection();
                    dgvPatient.Rows[0].Selected = true;
                    patientBindingSource.Position = 0;
                   // SelectCurrentPatientAndLoadTreatment(e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching patient: " + ex.Message);
            }
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SelectCurrentPatientAndLoadTreatment(e);
        }

        private void SelectCurrentPatientAndLoadTreatment(DataGridViewCellEventArgs e)
        {
            /*if (patientBindingSource.Current == null)
                return;

            DataRowView rowView = patientBindingSource.Current as DataRowView;
            if (rowView == null)
                return;

            DataRow row = rowView.Row;*/

            DataGridViewRow row = dgvPatient.Rows[e.RowIndex];

            selectedPatientID = Convert.ToInt32(row.Cells["Patient_ID"].Value);
            patientFullName = row.Cells["Patient_First_Name"].Value.ToString() + " " + row.Cells["Patient_Last_Name"].Value.ToString();
            patientPhone = row.Cells["Patient_Phone_Number"].Value.ToString();

            selectedAppointmentID = -1;
            total = 0;
            dgvTreatment.DataSource = null;

            //lblSelectedBillingPatient.Text = "Selected Patient: " + patientFullName;
            lblSelectedBillingPatient.Text = "Selected Patient:\n" +
                                     $"Name: {patientFullName}\n" +
                                     $"Phone: {patientPhone}\n" +
                                     $"Patient ID: {selectedPatientID}";

            LoadTreatmentForSelectedPatient();
        }

        private void LoadTreatmentForSelectedPatient()
        {
            if (selectedPatientID == -1)
                return;

            try
            {
                dsDentist.EnforceConstraints = false;

                dsDentist.Appointment.Clear();
                appointmentTableAdapter.Fill(dsDentist.Appointment);

                var appointments = dsDentist.Appointment.AsEnumerable()
                    .Where(r => Convert.ToInt32(r["Patient_ID"]) == selectedPatientID)
                    .OrderByDescending(r => Convert.ToDateTime(r["Appointment_Date"]))
                    .ToList();



                if (appointments.Count == 0)
                {
                    dgvTreatment.DataSource = null;
                    total = 0;
                    selectedAppointmentID = -1;

                   
                    lblSelectedBillingPatient.Text += "\n\nStatus: No treatments found for this patient.";
                    btnInvoice.Enabled = false; 
                    return;
                   // MessageBox.Show("This patient has no appointments, so no treatment can be loaded.");
                   // return;
                }

                foreach (DataRow appt in appointments)
                {
                    int apptID = Convert.ToInt32(appt["Appointment_ID"]);

                    dsDentist.Treatment.Clear();
                    int rows = treatmentTableAdapter.FillByAppointmentID(dsDentist.Treatment, apptID);

                    if (rows > 0)
                    {
                        selectedAppointmentID = apptID;

                        treatmentBindingSource1.DataSource = dsDentist.Treatment;
                        dgvTreatment.DataSource = treatmentBindingSource1;

                        total = 0;

                        foreach (DataGridViewRow treatmentRow in dgvTreatment.Rows)
                        {
                            if (treatmentRow.IsNewRow)
                                continue;

                            if (treatmentRow.Cells["treatmentCost"].Value != null &&
                                treatmentRow.Cells["treatmentCost"].Value != DBNull.Value)
                            {
                                total += Convert.ToDecimal(treatmentRow.Cells["treatmentCost"].Value);
                            }
                        }
                        btnInvoice.Enabled = true;

                        return;
                    }
                }

                dgvTreatment.DataSource = null;
                total = 0;
                selectedAppointmentID = -1;
                lblSelectedBillingPatient.Text += "\n\nStatus: No treatments found for this patient.";
                // MessageBox.Show("This patient has appointments, but no treatment has been assigned yet.");
                btnInvoice.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading treatment: " + ex.Message);
            }
        }

        private void btnTreatment_Click(object sender, EventArgs e)
        {
            LoadTreatmentForSelectedPatient();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (selectedPatientID == -1)
            {
                MessageBox.Show("Please search and select a patient first.");
                return;
            }

            if (selectedAppointmentID == -1)
            {
                MessageBox.Show("No treatment has been loaded for this patient. An invoice cannot be generated.");
                return;
            }

            if (dgvTreatment.DataSource == null || total <= 0)
            {
                MessageBox.Show("Treatment must be available before generating an invoice.");
                return;
            }

            try
            {
                dsDentist.EnforceConstraints = false;
                dsDentist.Invoice.Clear();
                invoiceTableAdapter.Fill(dsDentist.Invoice);

                foreach (DataRow row in dsDentist.Invoice.Rows)
                {
                    if (Convert.ToInt32(row["appointment_id"]) == selectedAppointmentID)
                    {
                        int existingInvoiceID = Convert.ToInt32(row["invoice_id"]);

                        DialogResult result = MessageBox.Show(
                            "An invoice already exists for this appointment. Would you like to view the existing invoice?",
                            "Invoice Already Exists",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            lastOpenedInvoiceID = existingInvoiceID;
                            //OpenInvoicePopup(existingInvoiceID, row);
                            OpenCrystalInvoice(lastOpenedInvoiceID, row);
                        }

                        return;
                    }
                }

                decimal vat = total * 0.15m;
                decimal grandTotal = total + vat;

                int invoiceID = CreateInvoiceID();
                int paymentID = CreatePaymentID();

                invoiceTableAdapter.Insert(invoiceID, selectedAppointmentID, paymentID, DateTime.Now, grandTotal, "Unpaid", grandTotal);

                lastOpenedInvoiceID = invoiceID;

                foreach(DataRow row in dsDentist.Invoice.Rows)
                {
                    if (Convert.ToInt32(row["appointment_id"]) == selectedAppointmentID)
                            {
                        OpenCrystalInvoice(lastOpenedInvoiceID, row);
                    }
                }

                //OpenInvoicePopup(invoiceID, null);

                GenerateAndViewInvoice(lastOpenedInvoiceID);

                MessageBox.Show("Invoice generated successfully.\nInvoice ID: " + invoiceID);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating invoice: " + ex.Message);
            }
        }
        private void OpenCrystalInvoice(int invoiceID, DataRow existingInvoiceRow)
        {
            try
            {
                decimal grandTotal;
                DateTime invoiceDate;



                if (existingInvoiceRow == null)
                {
                    grandTotal = total + (total * 0.15m);
                    invoiceDate = DateTime.Now;
                }
                else
                {
                    grandTotal = Convert.ToDecimal(
                    existingInvoiceRow["invoice_total_amount"]);



                    invoiceDate = Convert.ToDateTime(
                    existingInvoiceRow["invoice_date"]);
                }



                decimal totalBeforeVat = grandTotal / 1.15m;
                decimal vat = grandTotal - totalBeforeVat;

                InvoiceBreakdown report = new InvoiceBreakdown();

                DataTable treatmentTable =
         dgvTreatment.DataSource as DataTable;



               /* if (treatmentTable != null)
                {
                    report.SetDataSource();
                }*/



                // Set report parameters
                report.SetParameterValue(
                                         "invoice_ID",
                                         invoiceID);



                report.SetParameterValue(
                "Appointment_ID",
                selectedAppointmentID);



                report.SetParameterValue(
                "invoice_date",
                invoiceDate);



                report.SetParameterValue(
                "Patient_First_Name",
                patientFullName);


                report.SetParameterValue(
                "Patient_Phone_Number",
                patientPhone);



                /*report.SetParameterValue(
                "pSubtotal",
                totalBeforeVat);



                report.SetParameterValue(
                "pVAT",
                vat);*/



                report.SetParameterValue(
                "invoice_total_amount",
                grandTotal);


                /*
                Open report viewer
                InvoiceReportViewer viewer =
         new InvoiceReportViewer();



                viewer.crystalReportViewer1.ReportSource = report;
                viewer.crystalReportViewer1.Refresh();



                viewer.ShowDialog();



                Clean up report
                */
                /*crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();*/

                MessageBox.Show("Done");

                report.Close();
                report.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                "Error displaying invoice report: " + ex.Message,
                "Crystal Reports Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        public void GenerateAndViewInvoice(int invoiceID)
        {
            byte[] pdfBytes = GenerateInvoicePdf(invoiceID);
            string tempPath = Path.Combine(Path.GetTempPath(), $"Invoice_{invoiceID}.pdf");
            File.WriteAllBytes(tempPath, pdfBytes);
            Process.Start(new ProcessStartInfo(tempPath) { UseShellExecute = true});
        }
        public byte[] GenerateInvoicePdf(int invoiceId)
        {
            ReportDocument report = new ReportDocument();

            try
            {
                string reportPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "InvoiceBreakdown.rpt"
                );

                report.Load(reportPath);
                                
                DataSet dataSet = new DataSet();

                using (SqlConnection connection =
                new SqlConnection(constr))
                {
                    connection.Open();

                    string headerQuery = @"
                                         SELECT
                                         I.invoice_id,
                                         I.invoice_date,
                                         I.invoice_total_amount,
                                         I.invoice_status,

                                         A.Appointment_ID,
                                         A.Appointment_Date,

                                         P.Patient_ID,
                                         P.Patient_First_Name,
                                         P.Patient_Last_Name,
                                         P.Patient_Phone_Number

                                         FROM INVOICE I

                                         INNER JOIN APPOINTMENT A
                                         ON I.appointment_id = A.Appointment_ID

                                         INNER JOIN PATIENT P
                                         ON A.Patient_ID = P.Patient_ID

                                         WHERE I.invoice_id = @InvoiceID
                                         ";

                    using (SqlCommand command =
                    new SqlCommand(headerQuery, connection))
                    {
                        command.Parameters.AddWithValue(
                        "@InvoiceID",
                        invoiceId
                        );

                        using (SqlDataAdapter adapter =
                        new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet, "InvoiceHeader");
                        }
                    }

                    string treatmentQuery = @"
                                             SELECT
                                             PT.PatientTreatment_ID,
                                             PT.Appointment_ID,

                                             T.TreatmentID,
                                             T.TreatmentName,
                                             T.TreatmentDescription,
                                             T.TreatmentCost

                                             FROM PATIENTTREATMENT PT

                                             INNER JOIN TREATMENT T
                                             ON PT.TreatmentID = T.TreatmentID

                                             INNER JOIN APPOINTMENT A
                                             ON PT.Appointment_ID = A.Appointment_ID

                                             INNER JOIN INVOICE I
                                             ON A.Appointment_ID = I.appointment_id

                                             WHERE I.invoice_id = @InvoiceID
                                             ";

                    using (SqlCommand command =
                    new SqlCommand(treatmentQuery, connection))
                    {
                        command.Parameters.AddWithValue(
                        "@InvoiceID",
                        invoiceId
                        );

                        using (SqlDataAdapter adapter =
                        new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet, "InvoiceItems");
                        }
                    }
                }


                report.SetDataSource(dataSet);

                using (Stream stream =
                report.ExportToStream(
                ExportFormatType.PortableDocFormat))
                {
                    using (MemoryStream memoryStream =
                    new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);

                        return memoryStream.ToArray();
                    }
                }
            }
            finally
            {
                report.Close();
                report.Dispose();
            }
        }
        private void OpenInvoicePopup(int invoiceID, DataRow existingInvoiceRow)
        {
            decimal grandTotal;
            DateTime invoiceDate;

            if (existingInvoiceRow == null)
            {
                grandTotal = total + (total * 0.15m);
                invoiceDate = DateTime.Now;
            }
            else
            {
                grandTotal = Convert.ToDecimal(existingInvoiceRow["invoice_total_amount"]);
                invoiceDate = Convert.ToDateTime(existingInvoiceRow["invoice_date"]);
            }

            decimal totalBeforeVat = grandTotal / 1.15m;
            decimal vat = grandTotal - totalBeforeVat;

            Invoice frm = new Invoice();
            frm.dgvInvoiceTreatment.DataSource = dgvTreatment.DataSource;
            frm.lblAppointment.Text = selectedAppointmentID.ToString();
            frm.lblDate.Text = invoiceDate.ToShortDateString();
            frm.lblPatientName.Text = patientFullName;
            frm.lblPatientNumber.Text = patientPhone;
            frm.lblTotal.Text = "R" + totalBeforeVat.ToString("0.00");
            frm.lblVAT.Text = "R" + vat.ToString("0.00");
            frm.lblGrandTotal.Text = "R" + grandTotal.ToString("0.00");
            frm.lblInvoiceID.Text = invoiceID.ToString();
            frm.grpPayment.Visible = false;
            frm.ShowDialog();
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInvoiceID.Text.Trim(), out searchInvoiceID))
            {
                MessageBox.Show("Please enter a valid invoice ID.");
                return;
            }

            try
            {
                dsDentist.EnforceConstraints = false;
                dsDentist.Invoice.Clear();
                invoiceTableAdapter.Fill(dsDentist.Invoice);

                DataRow invoiceRow = null;

                foreach (DataRow row in dsDentist.Invoice.Rows)
                {
                    if (Convert.ToInt32(row["invoice_id"]) == searchInvoiceID)
                    {
                        invoiceRow = row;
                        break;
                    }
                }

                if (invoiceRow == null)
                {
                    rtxtbxDetails.Clear();
                    currentBalance = 0;
                    searchInvoiceID = -1;
                    MessageBox.Show("Invoice ID not found.");
                    return;
                }

                decimal invoiceTotal = Convert.ToDecimal(invoiceRow["invoice_total_amount"]);
                currentBalance = Convert.ToDecimal(invoiceRow["invoice_balance_due"]);

                string displayStatus = "Unpaid";

                if (currentBalance == 0)
                    displayStatus = "Paid";
                else if (currentBalance < invoiceTotal)
                    displayStatus = "Partial";

                rtxtbxDetails.Clear();
                rtxtbxDetails.AppendText("Invoice Details\n");
                rtxtbxDetails.AppendText("----------------------------------------\n");
                rtxtbxDetails.AppendText("Invoice ID: " + invoiceRow["invoice_id"] + Environment.NewLine);
                rtxtbxDetails.AppendText("Date: " + Convert.ToDateTime(invoiceRow["invoice_date"]).ToShortDateString() + Environment.NewLine);
                rtxtbxDetails.AppendText("Total Amount: R" + invoiceTotal.ToString("0.00") + Environment.NewLine);
                rtxtbxDetails.AppendText("Status: " + displayStatus + Environment.NewLine);
                rtxtbxDetails.AppendText("Balance Due: R" + currentBalance.ToString("0.00") + Environment.NewLine);

                if (currentBalance == 0)
                    MessageBox.Show("This invoice is already fully paid. No payment is required.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoice details: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            if (searchInvoiceID == -1)
            {
                MessageBox.Show("Please load invoice details first.");
                return;
            }

            if (currentBalance <= 0)
            {
                MessageBox.Show("This invoice is already fully paid. No further payment is needed.");
                return;
            }

            if (cmbMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            string paymentMethod = cmbMethod.SelectedItem.ToString();

            if (!decimal.TryParse(txtPaymentAmount.Text.Trim(), out decimal amountPaid))
            {
                MessageBox.Show("Please enter a valid payment amount.");
                return;
            }

            if (amountPaid <= 0)
            {
                MessageBox.Show("Payment amount must be greater than 0.");
                return;
            }

            if ((amountPaid > currentBalance)&&(paymentMethod!="Cash"))
            {
                MessageBox.Show("Payment amount cannot be bigger than the balance due.");
                return;
            }

            try
            {
                decimal newBalance = currentBalance - amountPaid;
                string status = newBalance <= 0 ? "Paid" : "Partial";

                int paymentID = CreatePaymentID();

                //currentBalance = newBalance;
                
                decimal vat = currentBalance*((decimal)15/115);
                
                String receipt = "";

                if (paymentMethod == "Cash")
                {
                    if (amountPaid > currentBalance)
                    {
                        decimal changeGiven = amountPaid - currentBalance;
                        newBalance = 0;
                        
                        receipt = "--- PAYMENT RECEIPT ---\n" +
                       "Invoice ID: " + searchInvoiceID + "\n" +
                       "Payment ID: " + paymentID + "\n" +
                       "Amount Paid: R" + amountPaid.ToString("0.00") + "\n" +
                       "Method: " + paymentMethod + "\n" +
                       "VAT: R" + vat.ToString("0.00") + "\n" +
                       "Remaining Balance: R" + newBalance.ToString("0.00") + "\n" +
                       "Change Given: R" + changeGiven.ToString("0.00") + "\n" +
                       "-----------------------";

                        amountPaid = currentBalance;

                    }
                    else
                    {
                        receipt = "--- PAYMENT RECEIPT ---\n" +
                         "Invoice ID: " + searchInvoiceID + "\n" +
                         "Payment ID: " + paymentID + "\n" +
                         "Amount Paid: R" + amountPaid.ToString("0.00") + "\n" +
                         "Method: " + paymentMethod + "\n" +
                         "VAT: " + vat.ToString("0.00") + "\n" +
                         "Remaining Balance: R" + newBalance.ToString("0.00") + "\n" +
                         "-----------------------";
                    }
                }
                else {
                    receipt = "--- PAYMENT RECEIPT ---\n" +
                         "Invoice ID: " + searchInvoiceID + "\n" +
                         "Payment ID: " + paymentID + "\n" +
                         "Amount Paid: R" + amountPaid.ToString("0.00") + "\n" +
                         "Method: " + paymentMethod + "\n" +
                         "VAT: " + vat.ToString("0.00") + "\n" +
                         "Remaining Balance: R" + newBalance.ToString("0.00") + "\n" +
                         "-----------------------";
                 }

                paymentTableAdapter.Insert(paymentID, searchInvoiceID, amountPaid, cmbMethod.Text, dateTimePicker1.Value);
                invoiceTableAdapter.UpdateQuery(status, newBalance, searchInvoiceID);

                currentBalance = newBalance;

                txtPaymentAmount.Clear();
                cmbMethod.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Today;

                MessageBox.Show(receipt, "Payment Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnShowDetails_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving payment: " + ex.Message);
            }
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            rtxtbxPaymentHistory.Clear();

            string search = txtPatientName.Text.Trim().ToLower();

            if (search == "")
            {
                MessageBox.Show("Please enter a patient name.");
                return;
            }

            try
            {
                dsDentist.EnforceConstraints = false;

                dsDentist.Patient.Clear();
                dsDentist.Appointment.Clear();
                dsDentist.Invoice.Clear();
                dsDentist.Payment.Clear();

                patientTableAdapter.Fill(dsDentist.Patient);
                appointmentTableAdapter.Fill(dsDentist.Appointment);
                invoiceTableAdapter.Fill(dsDentist.Invoice);
                paymentTableAdapter.Fill(dsDentist.Payment);

                string history = "";
                bool foundPatient = false;
                bool foundPayment = false;

                foreach (DataRow patient in dsDentist.Patient.Rows)
                {
                    string first = patient["Patient_First_Name"].ToString().Trim().ToLower();
                    string last = patient["Patient_Last_Name"].ToString().Trim().ToLower();
                    string full = first + " " + last;

                    if (first.Contains(search) || last.Contains(search) || full.Contains(search))
                    {
                        foundPatient = true;
                        int patientID = Convert.ToInt32(patient["Patient_ID"]);
                        string displayName = patient["Patient_First_Name"] + " " + patient["Patient_Last_Name"];

                        history += "Patient: " + displayName + Environment.NewLine;
                        history += "----------------------------------------" + Environment.NewLine;

                        foreach (DataRow appointment in dsDentist.Appointment.Rows)
                        {
                            if (Convert.ToInt32(appointment["Patient_ID"]) != patientID)
                                continue;

                            int appointmentID = Convert.ToInt32(appointment["Appointment_ID"]);

                            foreach (DataRow invoice in dsDentist.Invoice.Rows)
                            {
                                if (Convert.ToInt32(invoice["appointment_id"]) != appointmentID)
                                    continue;

                                int invoiceID = Convert.ToInt32(invoice["invoice_id"]);

                                foreach (DataRow payment in dsDentist.Payment.Rows)
                                {
                                    if (Convert.ToInt32(payment["invoice_id"]) == invoiceID)
                                    {
                                        foundPayment = true;

                                        history += "Invoice ID: " + invoiceID + Environment.NewLine;
                                        history += "Payment ID: " + payment["payment_id"] + Environment.NewLine;
                                        history += "Amount: R" + Convert.ToDecimal(payment["payment_amount"]).ToString("0.00") + Environment.NewLine;
                                        history += "Method: " + payment["payment_method"] + Environment.NewLine;
                                        history += "Date: " + Convert.ToDateTime(payment["payment_date"]).ToShortDateString() + Environment.NewLine;
                                        history += "------------------------" + Environment.NewLine;
                                    }
                                }
                            }
                        }

                        history += Environment.NewLine;
                    }
                }

                if (!foundPatient)
                {
                    MessageBox.Show("No patient found for that name.");
                    return;
                }

                if (!foundPayment)
                    history += "No payment history found for this patient." + Environment.NewLine;

                rtxtbxPaymentHistory.Text = history;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payment history: " + ex.Message);
            }
        }

        private int CreateInvoiceID()
        {
            dsDentist.EnforceConstraints = false;
            invoiceTableAdapter.Fill(dsDentist.Invoice);

            Random rnd = new Random();
            int invoiceID;
            bool exists;

            do
            {
                invoiceID = rnd.Next(100000, 999999);
                exists = dsDentist.Invoice.AsEnumerable().Any(row => Convert.ToInt32(row["invoice_id"]) == invoiceID);
            } while (exists);

            return invoiceID;
        }

        private int CreatePaymentID()
        {
            dsDentist.EnforceConstraints = false;
            paymentTableAdapter.Fill(dsDentist.Payment);

            Random rnd = new Random();
            int paymentID;
            bool exists;

            do
            {
                paymentID = rnd.Next(100000, 999999);
                exists = dsDentist.Payment.AsEnumerable().Any(row => Convert.ToInt32(row["payment_id"]) == paymentID);
            } while (exists);

            return paymentID;
        }

        private void ClearInvoicePanel()
        {
            txtAppt.Clear();
            ClearInvoiceResultsOnly();
            txtAppt.Focus();
        }

        private void ClearInvoiceResultsOnly()
        {
            selectedPatientID = -1;
            selectedAppointmentID = -1;
            patientFullName = "";
            patientPhone = "";
            total = 0;

            //lblSelectedBillingPatient.Text = "Selected Patient: none";
            lblSelectedBillingPatient.Text = "Selected Patient:\nName: none\nPhone: none\nPatientID: none";

            patientBindingSource.DataSource = null;
            dgvPatient.DataSource = patientBindingSource;

            treatmentBindingSource1.DataSource = null;
            dgvTreatment.DataSource = null;
            btnInvoice.Enabled = false;
        }

        private void ClearPaymentPanel()
        {
            txtInvoiceID.Clear();
            txtPaymentAmount.Clear();
            cmbMethod.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            rtxtbxDetails.Clear();
            searchInvoiceID = -1;
            currentBalance = 0;
        }

        private void ClearHistoryPanel()
        {
            txtPatientName.Clear();
            rtxtbxPaymentHistory.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e) { ClearInvoicePanel(); }
        private void btnClear2_Click(object sender, EventArgs e) { ClearPaymentPanel(); }
        private void btnClear3_Click(object sender, EventArgs e) { ClearHistoryPanel(); }

        private void txtApptID_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void txtInvoiceID_TextChanged(object sender, EventArgs e) { }
        private void appointmentBindingNavigatorSaveItem_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void lblTotall_Click(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }

        private void lblSelectedBillingPatient_TextChanged(object sender, EventArgs e)
        {

        }
    }
}