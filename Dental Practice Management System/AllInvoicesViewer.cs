using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class AllInvoicesViewer : Form
    {
        private readonly string connectionString;

        ///private TextBox txtPatientName;
        private ComboBox cmbStatus;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnApplyFilters;
        private Button btnClearFilters;
        private CrystalReportViewer crystalReportViewer;

        private ReportDocument currentReport;

        public AllInvoicesViewer(string connectionString)
        {
            this.connectionString = connectionString;

            InitializeViewer();
            LoadAllInvoices();
        }

        private void InitializeViewer()
        {
            Text = "Outstanding Balances";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(900, 600);

            Panel filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 110;
            filterPanel.Padding = new Padding(10);
            filterPanel.BackColor = Color.WhiteSmoke;

            /*Label lblPatientName = new Label();
            lblPatientName.Text = "Patient Name:";
            lblPatientName.Location = new Point(10, 15);
            lblPatientName.AutoSize = true;

            txtPatientName = new TextBox();
            txtPatientName.Location = new Point(100, 12);
            txtPatientName.Width = 180;*/

            Label lblStatus = new Label();
            lblStatus.Text = "Status:";
            lblStatus.Location = new Point(10, 15);
            lblStatus.AutoSize = true;
          
            cmbStatus = new ComboBox();
            cmbStatus.Location = new Point(80, 12);
            cmbStatus.Width = 130;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Paid");
            cmbStatus.Items.Add("Partial");
            cmbStatus.Items.Add("Unpaid");
            cmbStatus.SelectedIndex = 0;

            // Start date
            Label lblStartDate = new Label();
            lblStartDate.Text = "Start Date:";
            lblStartDate.Location = new Point(10, 58);
            lblStartDate.AutoSize = true;

            dtpStartDate = new DateTimePicker();
            dtpStartDate.Location = new Point(105, 54);
            dtpStartDate.Width = 180;
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.ShowCheckBox = true;
            dtpStartDate.Checked = false;

            // End date
            Label lblEndDate = new Label();
            lblEndDate.Text = "End Date:";
            lblEndDate.Location = new Point(380, 58);
            lblEndDate.AutoSize = true;

            dtpEndDate = new DateTimePicker();
            dtpEndDate.Location = new Point(420, 54);
            dtpEndDate.Width = 160;
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.ShowCheckBox = true;
            dtpEndDate.Checked = false;


            // Generate Button
            btnApplyFilters = new Button();
            btnApplyFilters.Text = "Generate";
            btnApplyFilters.Location = new Point(620, 12);
            btnApplyFilters.Size = new Size(120, 32);
            btnApplyFilters.Click += BtnApplyFilters_Click;

            //Clear Filters
            btnClearFilters = new Button();
            btnClearFilters.Text = "Clear Filters";
            btnClearFilters.Location = new Point(620, 52);
            btnClearFilters.Size = new Size(120, 32);
            btnClearFilters.Click += BtnClearFilters_Click;

            //filterPanel.Controls.Add(lblPatientName);
            //filterPanel.Controls.Add(txtPatientName);
            filterPanel.Controls.Add(lblStatus);
            filterPanel.Controls.Add(cmbStatus);
            filterPanel.Controls.Add(lblStartDate);
            filterPanel.Controls.Add(dtpStartDate);
            filterPanel.Controls.Add(lblEndDate);
            filterPanel.Controls.Add(dtpEndDate);
            filterPanel.Controls.Add(btnApplyFilters);
            filterPanel.Controls.Add(btnClearFilters);

            // Crystal Reports viewer
            crystalReportViewer = new CrystalReportViewer();
            crystalReportViewer.Dock = DockStyle.Fill;
            crystalReportViewer.ToolPanelView =
                ToolPanelViewType.None;
            crystalReportViewer.ShowGroupTreeButton = false;

            Controls.Add(crystalReportViewer);
            Controls.Add(filterPanel);

            FormClosed += AllInvoicesViewer_FormClosed;
        }

        private void BtnApplyFilters_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Checked && dtpStartDate.Value.Date == DateTime.Today)
            {
                MessageBox.Show("The Start Date cannot be the same as today's date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpStartDate.Checked &&
                dtpEndDate.Checked &&
                dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show(
                    "The Start Date cannot be after the End Date.",
                    "Invalid Date Range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            LoadAllInvoices();
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            //txtPatientName.Clear();
            cmbStatus.SelectedIndex = 0;

            dtpStartDate.Checked = false;
            dtpEndDate.Checked = false;

            LoadAllInvoices();
        }

        private void LoadAllInvoices()
        {
            DataTable invoiceTable = new DataTable("InvoiceList");

            string query = @"
                SELECT
                    I.invoice_id AS InvoiceID,
                    LTRIM(RTRIM(
                        P.Patient_First_Name + ' ' + P.Patient_Last_Name
                    )) AS PatientName,
                    P.Patient_ID AS PatientID,
                    I.invoice_date AS InvoiceDate,
                    I.invoice_status AS InvoiceStatus,
                    I.invoice_balance_due AS BalanceDue,
                    I.invoice_total_amount AS InvoiceAmount
                FROM Invoice I
                INNER JOIN Appointment A
                    ON I.appointment_id = A.Appointment_ID
                INNER JOIN Patient P
                    ON A.Patient_ID = P.Patient_ID
                WHERE
                    (@Status = 'All' OR I.invoice_status = @Status)
                    AND (@UseStartDate = 0 OR I.invoice_date >= @StartDate)
                    AND (@UseEndDate = 0 OR I.invoice_date < @EndDateExclusive)
                ORDER BY I.invoice_date DESC, I.invoice_id DESC;";

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    /*string patientName = txtPatientName.Text.Trim();

                    command.Parameters.Add(
                        "@PatientName", SqlDbType.NVarChar, 200
                    ).Value = patientName;

                    command.Parameters.Add(
                        "@PatientPattern", SqlDbType.NVarChar, 202
                    ).Value = "%" + patientName + "%";*/

                    command.Parameters.Add(
                        "@Status", SqlDbType.NVarChar, 50
                    ).Value = cmbStatus.SelectedItem.ToString();

                    command.Parameters.Add(
                        "@UseStartDate", SqlDbType.Bit
                    ).Value = dtpStartDate.Checked;

                    command.Parameters.Add(
                        "@StartDate", SqlDbType.DateTime
                    ).Value = dtpStartDate.Value.Date;

                    command.Parameters.Add(
                        "@UseEndDate", SqlDbType.Bit
                    ).Value = dtpEndDate.Checked;

                    command.Parameters.Add(
                        "@EndDateExclusive", SqlDbType.DateTime
                    ).Value = dtpEndDate.Value.Date.AddDays(1);

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(command))
                    {
                        adapter.Fill(invoiceTable);
                    }
                }

                if (invoiceTable.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No invoices match the selected filters.",
                        "No Invoices Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                DisplayInvoiceReport(invoiceTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load the invoices:\n\n" + ex.Message,
                    "Invoice Report Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DisplayInvoiceReport(DataTable invoiceTable)
        {
            string reportPath = Path.Combine(
                Application.StartupPath,
                "InvoiceListing.rpt"
            );

            if (!File.Exists(reportPath))
            {
                MessageBox.Show(
                    "The report file was not found:\n" + reportPath +
                    "\n\nCreate InvoiceListing.rpt and add the fields " +
                    "described in the instructions.",
                    "Missing Crystal Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            ReportDocument newReport = new ReportDocument();

            try
            {
                newReport.Load(reportPath);

                newReport.SetDataSource(invoiceTable);

                crystalReportViewer.ReportSource = newReport;
                crystalReportViewer.Refresh();

                ReportDocument oldReport = currentReport;
                currentReport = newReport;
                newReport = null;

                if (oldReport != null)
                {
                    oldReport.Close();
                    oldReport.Dispose();
                }
            }
            catch
            {
                if (newReport != null)
                {
                    newReport.Close();
                    newReport.Dispose();
                }

                MessageBox.Show(
                    "An error occurred while displaying the report.",
                    "Report Display Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                throw;
            }
        }

        private void AllInvoicesViewer_FormClosed(
            object sender, FormClosedEventArgs e)
        {
            crystalReportViewer.ReportSource = null;

            if (currentReport != null)
            {
                currentReport.Close();
                currentReport.Dispose();
                currentReport = null;
            }
        }

        public void ShowInsideTab(TabPage tabPage)
        {
            if (tabPage == null)
                throw new ArgumentNullException(nameof(tabPage));

            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;

            tabPage.Controls.Add(this);

            Show();
            BringToFront();
        }
    }
}
