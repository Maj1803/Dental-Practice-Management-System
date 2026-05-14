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
    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();

            ShowPanel(pnlViewAppointments); // Show the View Appointments panel by default
        }

    

    private void ShowPanel(Panel panelToShow)
        {
            // Hide all panels
            pnlBookAppointment.Visible = false;
            pnlViewAppointments.Visible = false;
            pnlUpdateAppointment.Visible = false;
            // Show the selected panel
            panelToShow.Visible = true;
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlBookAppointment);
        }

        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlUpdateAppointment);
        }

        private void btnViewAppointments_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlViewAppointments);
        }
    }
}
