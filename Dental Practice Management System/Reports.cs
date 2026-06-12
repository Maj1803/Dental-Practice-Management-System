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

        private void Reports_Load(object sender, EventArgs e)
        {
            try
            {
                // Create a local instance of the dataset structure
                dsDentist ds = new dsDentist();
                ds.EnforceConstraints = false;

                dsDentistTableAdapters.AppointmentViewTableAdapter viewAdapter =
                    new dsDentistTableAdapters.AppointmentViewTableAdapter();

                viewAdapter.Connection.ConnectionString = "Server=146.230.177.46;Database=GroupWst33;User Id=GroupWst33;Password=9d3dx;";
                viewAdapter.Fill(ds.AppointmentView);

                // Strip away structural matching and bind straight to table index 0
                this.rptAppointments1.Database.Tables[0].SetDataSource((DataTable)ds.AppointmentView);

                this.crystalReportViewer1.ReportSource = this.rptAppointments1;
                this.crystalReportViewer1.RefreshReport();
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

            try
            {
                dsDentist dsFiltered = new dsDentist();

                dsFiltered.EnforceConstraints = false;

                string connectionString = "Server=146.230.177.46;Database=GroupWst33;User Id=GroupWst33;Password=9d3dx;";

                string query = @"SELECT        
                            a.Appointment_ID, 
                            0 AS Employee_ID,            -- Dummy ID to bypass validation
                            a.Appointment_Date, 
                            a.Appointment_Status, 
                            p.Patient_First_Name, 
                            p.Patient_Last_Name, 
                            p.Patient_Phone_Number, 
                            '' AS Employee_First_Name,   -- Dummy string to bypass validation
                            e.Employee_Last_Name, 
                            t.Slot_Start_Time
                        FROM dbo.Appointment AS a 
                        INNER JOIN dbo.Patient AS p ON a.Patient_ID = p.Patient_ID 
                        INNER JOIN dbo.Employee AS e ON a.Employee_ID = e.Employee_ID 
                        INNER JOIN dbo.Timeslot AS t ON a.Timeslot_ID = t.Timeslot_ID
                        WHERE a.Appointment_Date BETWEEN @StartDate AND @EndDate";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDateWithTime);
                        cmd.Parameters.AddWithValue("@EndDate", endDateWithTime);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dsFiltered.AppointmentView);
                        }
                    }
                }

                this.rptAppointments1.Database.Tables[0].SetDataSource((DataTable)dsFiltered.AppointmentView);

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
    }
}