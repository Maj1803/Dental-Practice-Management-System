using CrystalDecisions.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    /// <summary>
    /// Generate Revenue report. Built the same way as PatientHistoryViewer:
    /// a borderless form that Reports.cs drops into its own tab.
    /// Revenue = payments actually received (Payment table), joined to the
    /// invoice, appointment, patient and dentist they belong to.
    /// </summary>
    public partial class RevenueViewer : Form
    {
        private const string ConnStr =
            "Server=146.230.177.46;Database=GroupWst33;User Id=GroupWst33;Password=9d3dx;";

        private RevenueReport crRevenue;

        public RevenueViewer()
        {
            InitializeComponent();
            BuildLayout();
        }

        private Label MakeLabel(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = dtpStart.Font,
                Margin = new Padding(20, 12, 0, 0)
            };
        }

        // Same filter-bar layout as the Patient History tab so the two tabs look alike
        private void BuildLayout()
        {
            cmbDentistFilter.Width = 220;
            cmbDentistFilter.Margin = new Padding(10, 8, 10, 0);

            cmbMethodFilter.Width = 130;
            cmbMethodFilter.Margin = new Padding(10, 8, 10, 0);

            dtpStart.Width = 170;
            dtpStart.Margin = new Padding(10, 8, 10, 0);

            dtpEnd.Width = 170;
            dtpEnd.Margin = new Padding(10, 8, 10, 0);

            btnGenerate.Size = new Size(140, 40);
            btnGenerate.Margin = new Padding(20, 0, 0, 0);

            FlowLayoutPanel bar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 70,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10, 10, 10, 0)
            };

            bar.Controls.AddRange(new Control[]
            {
                MakeLabel("Dentist:"), cmbDentistFilter,
                MakeLabel("Method:"), cmbMethodFilter,
                MakeLabel("Start Date:"), dtpStart,
                MakeLabel("End Date:"), dtpEnd,
                btnGenerate
            });

            Controls.Add(bar);

            crystalReportViewer1.Dock = DockStyle.Fill;
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.GroupTree;
            crystalReportViewer1.ToolPanelWidth = 200;
            crystalReportViewer1.ShowRefreshButton = false;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.ShowGroupTreeButton = false;
            crystalReportViewer1.BringToFront();
        }

        private void RevenueViewer_Load(object sender, EventArgs e)
        {
            try
            {
                // Dentist filter: "All dentists" plus every dentist in the Employee table
                DataTable dentists = new DataTable();
                dentists.Columns.Add("Employee_ID", typeof(int));
                dentists.Columns.Add("FullName", typeof(string));
                dentists.Rows.Add(0, "All dentists");

                using (SqlConnection conn = new SqlConnection(ConnStr))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT Employee_ID, Employee_First_Name + ' ' + Employee_Last_Name AS FullName " +
                    "FROM dbo.Employee WHERE Employee_Role = 'Dentist' ORDER BY Employee_Last_Name", conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            dentists.Rows.Add((int)r["Employee_ID"], r["FullName"].ToString());
                    }
                }

                cmbDentistFilter.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbDentistFilter.DataSource = dentists;
                cmbDentistFilter.DisplayMember = "FullName";
                cmbDentistFilter.ValueMember = "Employee_ID";

                // Payment methods used by BillingForm
                cmbMethodFilter.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbMethodFilter.Items.Clear();
                cmbMethodFilter.Items.AddRange(new object[] { "All", "Cash", "Card", "EFT" });
                cmbMethodFilter.SelectedIndex = 0;

                dtpStart.Format = DateTimePickerFormat.Custom;
                dtpStart.CustomFormat = "yyyy/MM/dd";
                dtpEnd.Format = DateTimePickerFormat.Custom;
                dtpEnd.CustomFormat = "yyyy/MM/dd";

                // Lecturer rule: the start date cannot be today
                DateTime yesterday = DateTime.Today.AddDays(-1);
                dtpStart.MaxDate = yesterday;
                dtpEnd.MaxDate = DateTime.Today;

                dtpStart.Value = yesterday.AddMonths(-3);
                dtpEnd.Value = yesterday;

                // Show the last 3 months straight away
                this.BeginInvoke(new Action(() => GenerateReport(false)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load the revenue filters: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport(true);
        }

        private void GenerateReport(bool showEmptyMessage)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
            {
                MessageBox.Show("The Start Date cannot be after the End Date.",
                                "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpStart.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("The Start Date cannot be today. Please choose an earlier date.",
                                "Invalid Start Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int dentistId = 0;
                if (cmbDentistFilter.SelectedValue != null)
                    dentistId = Convert.ToInt32(cmbDentistFilter.SelectedValue);

                string method = cmbMethodFilter.SelectedItem == null ? "All" : cmbMethodFilter.SelectedItem.ToString();

                DateTime start = dtpStart.Value.Date;
                DateTime end = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1); // include the whole end day

                // Column names and types must match RevenueSchema.xml, which the report was designed from.
                // The CASTs keep the types fixed even if a column in the DB is money/float/date.
                string query = @"
                    SELECT
                        CAST(pay.payment_id AS int)                    AS Payment_ID,
                        CAST(pay.invoice_id AS int)                    AS Invoice_ID,
                        CAST(pay.payment_date AS datetime)             AS Payment_Date,
                        CAST(pay.payment_method AS varchar(20))        AS Payment_Method,
                        CAST(pay.payment_amount AS decimal(12,2))      AS Payment_Amount,
                        CAST(inv.invoice_total_amount AS decimal(12,2)) AS Invoice_Total,
                        CAST(inv.invoice_status AS varchar(30))        AS Invoice_Status,
                        p.Patient_First_Name + ' ' + p.Patient_Last_Name   AS Patient_Name,
                        e.Employee_First_Name + ' ' + e.Employee_Last_Name AS Dentist_Name
                    FROM dbo.Payment AS pay
                    INNER JOIN dbo.Invoice     AS inv ON pay.invoice_id = inv.invoice_id
                    INNER JOIN dbo.Appointment AS a   ON inv.appointment_id = a.Appointment_ID
                    INNER JOIN dbo.Patient     AS p   ON a.Patient_ID = p.Patient_ID
                    INNER JOIN dbo.Employee    AS e   ON a.Employee_ID = e.Employee_ID
                    WHERE pay.payment_date BETWEEN @StartDate AND @EndDate
                      AND (@DentistID = 0 OR e.Employee_ID = @DentistID)
                      AND (@Method = 'All' OR pay.payment_method = @Method)
                    ORDER BY pay.payment_date";

                // Table name must match the table in RevenueSchema.xml
                DataTable dt = new DataTable("Revenue");

                using (SqlConnection conn = new SqlConnection(ConnStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", start);
                    cmd.Parameters.AddWithValue("@EndDate", end);
                    cmd.Parameters.AddWithValue("@DentistID", dentistId);
                    cmd.Parameters.AddWithValue("@Method", method);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                crRevenue = new RevenueReport();
                crRevenue.SetDataSource(dt);

                crystalReportViewer1.ReportSource = crRevenue;
                crystalReportViewer1.Zoom(100);

                if (dt.Rows.Count == 0 && showEmptyMessage)
                {
                    MessageBox.Show("No payments were recorded for the selected filters and dates.",
                                    "No Revenue Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate the Revenue Report: " + ex.Message,
                                "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
