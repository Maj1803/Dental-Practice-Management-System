using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class PatientHistoryViewer : Form
    {
        private const string ConnStr =
            "Server=146.230.177.46;Database=GroupWst33;User Id=GroupWst33;Password=9d3dx;";

        private PatientHistory crPatientHistory;

        public PatientHistoryViewer()
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

        private void BuildLayout()
        {
            cmbPatientFilter.Width = 260;
            cmbPatientFilter.Margin = new Padding(10, 8, 10, 0);

            dtpStart.Width = 200;
            dtpStart.Margin = new Padding(10, 8, 20, 0);

            dtpEnd.Width = 200;
            dtpEnd.Margin = new Padding(10, 8, 20, 0);

            btnGenerate.Size = new Size(140, 40);
            btnGenerate.Margin = new Padding(30, 0, 0, 0);

            FlowLayoutPanel bar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 70,
                WrapContents = false,
                Padding = new Padding(10, 10, 10, 0)
            };

            bar.Controls.AddRange(new Control[]
            {
                MakeLabel("Patient:"), cmbPatientFilter,
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

        private void FillTable(DataSet ds, string tableName)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo." + tableName, ConnStr))
            {
                da.Fill(ds, tableName);
            }
        }

        private void PatientHistoryViewer_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Patient_ID", typeof(int));
                dt.Columns.Add("FullName", typeof(string));
                dt.Rows.Add(0, "All patients");

                using (SqlConnection conn = new SqlConnection(ConnStr))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT Patient_ID, Patient_First_Name + ' ' + Patient_Last_Name AS FullName " +
                    "FROM dbo.Patient ORDER BY Patient_Last_Name", conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            dt.Rows.Add((int)r["Patient_ID"], r["FullName"].ToString());
                    }
                }

                cmbPatientFilter.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbPatientFilter.DataSource = dt;
                cmbPatientFilter.DisplayMember = "FullName";
                cmbPatientFilter.ValueMember = "Patient_ID";

                dtpStart.Format = DateTimePickerFormat.Custom;
                dtpStart.CustomFormat = "yyyy/MM/dd";
                dtpEnd.Format = DateTimePickerFormat.Custom;
                dtpEnd.CustomFormat = "yyyy/MM/dd";

                dtpStart.Value = DateTime.Now.AddMonths(-3);
                dtpEnd.Value = DateTime.Now;
                this.BeginInvoke(new Action(() => btnGenerate_Click(this, EventArgs.Empty)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load patients: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
            {
                MessageBox.Show("The Start Date cannot be after the End Date.",
                                "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int patientId = 0;
                if (cmbPatientFilter.SelectedValue != null)
                    patientId = Convert.ToInt32(cmbPatientFilter.SelectedValue);

                DataSet ds = new DataSet();
                FillTable(ds, "Patient");
                FillTable(ds, "Appointment");
                FillTable(ds, "PatientTreatment");
                FillTable(ds, "Treatment");
                FillTable(ds, "Prescription");
                FillTable(ds, "Medicine");

                crPatientHistory = new PatientHistory();
                crPatientHistory.SetDataSource(ds);

                crPatientHistory.SetParameterValue("paramPatientID", patientId);
                crPatientHistory.SetParameterValue("paramStartDate", dtpStart.Value.Date);
                crPatientHistory.SetParameterValue("paramEndDate", dtpEnd.Value.Date);

                crystalReportViewer1.ReportSource = crPatientHistory;
                crystalReportViewer1.ToolPanelView = ToolPanelViewType.GroupTree;
                crystalReportViewer1.ToolPanelWidth = 200;
                crystalReportViewer1.Zoom(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate the report: " + ex.Message,
                                "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}