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
    public partial class BillingForm : Form
    {
        public BillingForm()
        {
            InitializeComponent();
        }

        private void invoiceBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.invoiceBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsDentist);

        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsDentist.Treatment' table. You can move, or remove it, as needed.
            this.treatmentTableAdapter.Fill(this.dsDentist.Treatment);
            // TODO: This line of code loads data into the 'dsDentist.Treatment' table. You can move, or remove it, as needed.
            this.treatmentTableAdapter.Fill(this.dsDentist.Treatment);
            // TODO: This line of code loads data into the 'dsDentist.PatientTreatment' table. You can move, or remove it, as needed.
            this.patientTreatmentTableAdapter.Fill(this.dsDentist.PatientTreatment);
            // TODO: This line of code loads data into the 'dsDentist.Invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter.Fill(this.dsDentist.Invoice);

        }
    }
}
