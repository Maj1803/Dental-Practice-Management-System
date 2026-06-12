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
                //    dsDentistTableAdapters.QueriesTableAdapter globalQueries = new dsDentistTableAdapters.QueriesTableAdapter();
                //    DataTable dynamicTable = new DataTable();
                //    globalQueries.FillReportApp();
                //    this.CrystalReport11.SetDataSource(dynamicTable);
                //    this.crystalReportViewer1.ReportSource = this.CrystalReport11;
                //    this.crystalReportViewer1.RefreshReport();

                //dsDentist ds = new dsDentist();
                //ds.EnforceConstraints = false;
                //dsDentistTableAdapters.AppointmentTableAdapter appointmentAdapter = new dsDentistTableAdapters.AppointmentTableAdapter();
                //appointmentAdapter.FillByApp(ds.Appointment);
                //this.CrystalReport11.SetDatabaseLogon("GroupWst33", "9d3dx", "146.230.177.46", "GroupWst33");
                //this.CrystalReport11.SetDataSource(ds);
                //this.crystalReportViewer1.ReportSource = this.CrystalReport11;
                //this.crystalReportViewer1.RefreshReport();

                //dsDentist ds = new dsDentist();

                //// 1. Temporarily disable dataset validation checking to bypass any constraint crashes
                //ds.EnforceConstraints = false;

                //// 2. Instantiate the exact TableAdapter visible in your screenshot
                //dsDentistTableAdapters.AppointmentViewTableAdapter viewAdapter =
                //    new dsDentistTableAdapters.AppointmentViewTableAdapter();

                //// 3. Populate the AppointmentView DataTable inside your dataset container
                //viewAdapter.Fill(ds.AppointmentView);

                // 4. Send the populated dataset directly into Crystal Reports
                //this.CrystalReport11.SetDataSource(ds);
                //this.CrystalReport11.SetDataSource(ds.AppointmentView);
                //DataTable dt = ds.AppointmentView;
                //dt.TableName = "v_AppointmentReport"; // Force-rename it to trick the engine
                //this.CrystalReport11.SetDataSource(dt);

                // 5. Connect to the interface viewer object on your Form window
                //this.crystalReportViewer1.ReportSource = this.CrystalReport11;

                //this.CrystalReport11.Database.Tables[0].SetDataSource((DataTable)ds.AppointmentView);

                //this.crystalReportViewer1.ReportSource = this.CrystalReport11;
                //this.crystalReportViewer1.RefreshReport();

                //// 6. Paint the layout page onto the screen
                //this.crystalReportViewer1.RefreshReport();


                dsDentist ds = new dsDentist();

                // 1. Disable data validation rules to prevent crashes
                ds.EnforceConstraints = false;

                // 2. Instantiate your specific table adapter
                dsDentistTableAdapters.AppointmentViewTableAdapter viewAdapter =
                    new dsDentistTableAdapters.AppointmentViewTableAdapter();

                viewAdapter.Connection.ConnectionString = "Server=146.230.177.46;Database=GroupWst33;User Id=GroupWst33;Password=9d3dx;";

                // 3. Populate your DataTable array container
                viewAdapter.Fill(ds.AppointmentView);

                // --- THE MAGIC FIX STARTS HERE ---
                // 4. Force feed the rows into the absolute first table layout template index slot
                // This strips away name matching completely!
                this.rptAppointments1.Database.Tables[0].SetDataSource((DataTable)ds.AppointmentView);
                // --- THE MAGIC FIX ENDS HERE ---

                // 5. Connect the loaded template container straight to your UI window viewer
                this.crystalReportViewer1.ReportSource = this.rptAppointments1;

                // 6. Draw the complete report layout page onto the screen
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

        }
    }
}
