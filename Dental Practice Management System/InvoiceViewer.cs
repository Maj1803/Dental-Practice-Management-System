using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class InvoiceViewer : Form
    {
        public InvoiceViewer(DataSet reportData, int invoiceID)
        {
            InitializeComponent();

            CrystalReportViewer reportViewer = new CrystalReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer); 

            InvoiceBreakdown report = new InvoiceBreakdown();

            report.SetDataSource(reportData);
                                    
            reportViewer.Show();

            reportViewer.ReportSource = report;
            reportViewer.Refresh();

        }
    }
}
