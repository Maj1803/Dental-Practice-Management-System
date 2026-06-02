using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Instantiate the global QueriesTableAdapter to run your join query
                dsDentistTableAdapters.QueriesTableAdapter globalQueries = new dsDentistTableAdapters.QueriesTableAdapter();

                // 2. Create a completely blank, generic data table at runtime
                DataTable dynamicTable = new DataTable();

                // 3. Fill this blank table using your custom query method
                // Because dynamicTable is blank, it will automatically adapt to your SQL columns (Patient, Dentist, etc.)
                globalQueries.FillReportApp();

                // 4. Feed this dynamically built data table straight into your report component tray instance
                this.CrystalReport11.SetDataSource(dynamicTable);

                // 5. Link the populated layout to your UI viewer control window
                this.crystalReportViewer1.ReportSource = this.CrystalReport11;

                // 6. Draw the complete report layout page cleanly on the screen
                this.crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate Appointment Report: {ex.Message}",
                                "Report Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
