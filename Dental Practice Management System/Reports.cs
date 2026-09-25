using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class Reports : Form
    {
        private TabPage hiddenTabInvoice;
        private TabPage hiddenTabTreatment;

        public Reports()
        {
            InitializeComponent();

            hiddenTabInvoice = tabPage2;
            hiddenTabTreatment = tabPage3;

            this.TreatmentHistory1 = new Dental_Practice_Management_System.TreatmentHistory();
            this.InvoiceSummary1 = new Dental_Practice_Management_System.InvoiceSummary();
            this.rptAppointments1 = new Dental_Practice_Management_System.rptAppointments();

            if (tabControl1.TabPages.Contains(hiddenTabInvoice))
            {
                tabControl1.TabPages.Remove(hiddenTabInvoice);
            }

            if (tabControl1.TabPages.Contains(hiddenTabTreatment))
            {
                tabControl1.TabPages.Remove(hiddenTabTreatment);
            }
        }

        private void SetReportLogon(ReportDocument report)
        {
            ConnectionInfo connectionInfo = new ConnectionInfo
            {
                ServerName = "146.230.177.46",
                DatabaseName = "GroupWst33",
                UserID = "GroupWst33",
                Password = "9d3dx"
            };

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
            {
                TableLogOnInfo logOnInfo = table.LogOnInfo;
                logOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(logOnInfo);
            }
        }

        private void LoadPerformanceFilters()
        {
            cmbDentistFilter.Items.Clear();
            cmbDentistFilter.Items.Add(new ComboItem { Id = 0, Name = "All Dentists" });

            using (SqlConnection conn = new SqlConnection("Server=146.230.177.46;Database=GroupWst33;User Id=GroupWst33;Password=9d3dx;"))
            using (SqlCommand cmd = new SqlCommand("SELECT Employee_ID, Employee_First_Name + ' ' + Employee_Last_Name AS FullName FROM dbo.Employee WHERE Employee_Role = 'Dentist'", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbDentistFilter.Items.Add(new ComboItem
                        {
                            Id = (int)reader["Employee_ID"],
                            Name = reader["FullName"].ToString()
                        });
                    }
                }
            }
            cmbDentistFilter.DisplayMember = "Name";
            cmbDentistFilter.SelectedIndex = 0;

            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new object[] { "All", "Completed", "Cancelled", "Scheduled" });
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=146.230.177.46;Database=GroupWst33;User Id=GroupWst33;Password=9d3dx;";

                string query = @"SELECT * FROM dbo.v_AppointmentReport ORDER BY Appointment_Date";

                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                this.rptAppointments1.Database.Tables[0].SetDataSource(dt);
                SetReportLogon(this.rptAppointments1);

                this.crystalReportViewer1.ReportSource = this.rptAppointments1;
                this.crystalReportViewer1.RefreshReport();

                LoadPerformanceFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate Appointment Report: {ex.Message}",
                                "Report Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Left blank intentionally
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
            {
                MessageBox.Show("The Start Date cannot be further ahead than the End Date. Please choose a valid date range.",
                                "Invalid Date Range",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            DateTime startDateWithTime = dtpStart.Value.Date;
            DateTime endDateWithTime = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1);

            int dentistId = 0;
            if (cmbDentistFilter.SelectedItem != null)
            {
                dentistId = ((ComboItem)cmbDentistFilter.SelectedItem).Id;
            }

            string status = "All";
            if (cmbStatusFilter.SelectedItem != null)
            {
                status = cmbStatusFilter.SelectedItem.ToString();
            }

            try
            {
                string connectionString = "Server=146.230.177.46;Database=GroupWst33;User Id=GroupWst33;Password=9d3dx;";

                string query = @"SELECT        
                    a.Appointment_ID, 
                    e.Employee_ID,
                    a.Appointment_Date, 
                    a.Appointment_Status, 
                    p.Patient_First_Name, 
                    p.Patient_Last_Name, 
                    p.Patient_Phone_Number, 
                    e.Employee_First_Name,
                    e.Employee_Last_Name, 
                    t.Slot_Start_Time,
                    ISNULL(i.invoice_total_amount - i.invoice_balance_due, 0) AS Revenue
                FROM dbo.Appointment AS a 
                INNER JOIN dbo.Patient AS p ON a.Patient_ID = p.Patient_ID 
                INNER JOIN dbo.Employee AS e ON a.Employee_ID = e.Employee_ID 
                INNER JOIN dbo.Timeslot AS t ON a.Timeslot_ID = t.Timeslot_ID
                LEFT JOIN dbo.Invoice AS i ON i.appointment_id = a.Appointment_ID
                WHERE a.Appointment_Date BETWEEN @StartDate AND @EndDate
                AND (@DentistID = 0 OR e.Employee_ID = @DentistID)
                AND (@Status = 'All' OR a.Appointment_Status = @Status)";

                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDateWithTime);
                    cmd.Parameters.AddWithValue("@EndDate", endDateWithTime);
                    cmd.Parameters.AddWithValue("@DentistID", dentistId);
                    cmd.Parameters.AddWithValue("@Status", status);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                this.rptAppointments1.Database.Tables[0].SetDataSource(dt);
                SetReportLogon(this.rptAppointments1);

                this.crystalReportViewer1.ReportSource = this.rptAppointments1;
                this.crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering report data: {ex.Message}",
                                "Database Pipeline Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

public class ComboItem
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return Name; // this is what displays if DisplayMember ever fails to bind
    }
}