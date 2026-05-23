using Dental_Practice_Management_System.dsDentistTableAdapters;
using System;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class Appointments : Form
    {
        // tracks which patient and appointment the user has clicked
        int selectedPatientID = -1;
        int selectedAppointmentID = -1;

        // dataset and table adapters for all tables we need
        dsDentist dsDentist = new dsDentist();
        PatientTableAdapter patientTableAdapter = new PatientTableAdapter();
        EmployeeTableAdapter employeeTableAdapter = new EmployeeTableAdapter();
        AppointmentTableAdapter appointmentTableAdapter = new AppointmentTableAdapter();
        TimeslotTableAdapter timeslotTableAdapter = new TimeslotTableAdapter();
        AppointmentViewTableAdapter appointmentViewTableAdapter = new AppointmentViewTableAdapter();

        public Appointments()
        {
            InitializeComponent();
            ShowPanel(pnlViewAppointments);
        }

        // hides all panels then shows only the one we want
        private void ShowPanel(Panel panelToShow)
        {
            pnlViewAppointments.Visible = false;
            pnlBookAppointment.Visible = false;
            pnlUpdateAppointment.Visible = false;
            panelToShow.Visible = true;
        }

        // reloads the timeslot combo using our FillByAvailableSlots query
        // automatically excludes booked slots and dentist override blocks
        private void LoadAvailableSlots()
        {
            if (cmbDentist.SelectedValue == null) return;
            if (!(cmbDentist.SelectedValue is int)) return;

            try
            {
                timeslotTableAdapter.FillByAvailableSlots(
                    dsDentist.Timeslot,
                    dtpAppointmentDate.Value.ToShortDateString(),
                    Convert.ToInt32(cmbDentist.SelectedValue));

                cmbTimeSlot.DataSource = dsDentist.Timeslot;
                cmbTimeSlot.DisplayMember = "Slot_StartTime";
                cmbTimeSlot.ValueMember = "Timeslot_ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load available slots: " + ex.Message);
            }
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            // fill all tables into the dataset on startup
            patientTableAdapter.Fill(dsDentist.Patient);
            employeeTableAdapter.Fill(dsDentist.Employee);
            appointmentViewTableAdapter.Fill(dsDentist.AppointmentView);

            // view panel - bind inner join grid
            dgvAppointments.DataSource = dsDentist.AppointmentView;

            // view panel - status filter options
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Booked");
            cmbStatusFilter.Items.Add("Completed");
            cmbStatusFilter.Items.Add("Cancelled");
            cmbStatusFilter.SelectedIndex = 0;

            // book panel - load dentists into combo
            cmbDentist.DataSource = dsDentist.Employee;
            cmbDentist.DisplayMember = "Employee_First_Name";
            cmbDentist.ValueMember = "Employee_ID";

            // update panel - action options
            cmbUpdateAction.Items.Add("Reschedule");
            cmbUpdateAction.Items.Add("Cancel");

            // update panel - bind grid to same inner join table
            dgvUpdateAppointments.DataSource = dsDentist.AppointmentView;
        }

        private void btnViewAppointments_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlViewAppointments);
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlBookAppointment);
        }

        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlUpdateAppointment);
        }

        private void btnSearchAppointments_Click(object sender, EventArgs e)
        {
            // filters the appointments grid by patient name
            string search = txtSearchAppointments.Text.Trim();

            if (string.IsNullOrEmpty(search))
                dsDentist.AppointmentView.DefaultView.RowFilter = "";
            else
                dsDentist.AppointmentView.DefaultView.RowFilter =
                    $"Patient_First_Name LIKE '%{search}%' OR " +
                    $"Patient_Last_Name  LIKE '%{search}%'";

            dgvAppointments.DataSource = dsDentist.AppointmentView.DefaultView;
        }

        private void btnUpdateSearch_Click(object sender, EventArgs e)
        {
            // filters update grid by patient name so user can find the appointment
            string search = txtUpdateSearch.Text.Trim();

            if (string.IsNullOrEmpty(search))
                dsDentist.AppointmentView.DefaultView.RowFilter = "";
            else
                dsDentist.AppointmentView.DefaultView.RowFilter =
                    $"Patient_First_Name LIKE '%{search}%' OR " +
                    $"Patient_Last_Name  LIKE '%{search}%'";

            dgvUpdateAppointments.DataSource = dsDentist.AppointmentView.DefaultView;
        
        }

        private void dgvPatientResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // stores the selected patient ID and shows their name in the label
            if (e.RowIndex < 0) return;

            selectedPatientID = Convert.ToInt32(
                dgvPatientResults.CurrentRow.Cells[0].Value);

            string name = dgvPatientResults.CurrentRow.Cells[1].Value.ToString();
            string surname = dgvPatientResults.CurrentRow.Cells[2].Value.ToString();

            lblSelectedPatient.Text = "Selected: " + name + " " + surname;
        }

        private void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
        {
            // reload available slots whenever the date is changed
            LoadAvailableSlots();
        }

        private void cmbDentist_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reload available slots whenever a different dentist is selected
            LoadAvailableSlots();
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            // validate before inserting
            if (selectedPatientID == -1)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            if (cmbTimeSlot.SelectedValue == null)
            {
                MessageBox.Show("No available time slots for this date.");
                return;
            }

            if (dtpAppointmentDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Cannot book an appointment in the past.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Confirm this appointment booking?",
                "Confirm Booking",
                MessageBoxButtons.OKCancel);

            if (confirm == DialogResult.OK)
            {
                // insert new appointment with status Booked
                appointmentTableAdapter.Insert(
                    selectedPatientID,
                    Convert.ToInt32(cmbDentist.SelectedValue),
                    Convert.ToInt32(cmbTimeSlot.SelectedValue),
                    dtpAppointmentDate.Value.Date,
                    txtAppointmentNotes.Text,
                    null,
                    "Booked");

                MessageBox.Show("Appointment booked successfully.");

                // always refill after insert so grids update automatically
                appointmentViewTableAdapter.Fill(dsDentist.AppointmentView);
                LoadAvailableSlots();
            }
        }

        private void btnClearBooking_Click(object sender, EventArgs e)
        {
            // resets the entire booking panel back to default
            selectedPatientID = -1;
            lblSelectedPatient.Text = "No patient selected.";
            txtSearchPatient.Clear();
            txtAppointmentNotes.Clear();
            dsDentist.Patient.Clear();
            dgvPatientResults.DataSource = null;
        }

        private void dgvUpdateAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // stores the appointment ID from the selected row
            if (e.RowIndex < 0) return;

            selectedAppointmentID = Convert.ToInt32(
                dgvUpdateAppointments.CurrentRow.Cells[0].Value);

            lblSelectedAppointment.Text =
                "Selected Appointment ID: " + selectedAppointmentID;
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            // uses our FillByPatientSearch query to search by name
            patientTableAdapter.SearchName(
                dsDentist.Patient, txtSearchPatient.Text);

            dgvPatientResults.DataSource = dsDentist.Patient;
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            // check an appointment is actually selected first
            if (selectedAppointmentID == -1)
            {
                MessageBox.Show("Please select an appointment first.");
                return;
            }

            if (cmbUpdateAction.SelectedItem != null &&
                cmbUpdateAction.SelectedItem.ToString() == "Cancel")
            {
                // cancel path - uses our CancelAppointment query
                // sets Appointment_Status to Cancelled in the database
                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to CANCEL this appointment?",
                    "Cancel Appointment",
                    MessageBoxButtons.OKCancel);

                if (confirm == DialogResult.OK)
                {
                    appointmentTableAdapter.CancelAppointment(selectedAppointmentID);
                    MessageBox.Show("Appointment cancelled.");

                    // always refill after cancel so grids update automatically
                    appointmentViewTableAdapter.Fill(dsDentist.AppointmentView);
                    LoadAvailableSlots();
                }
            }
            else
            {
                // reschedule path - uses our UpdateAppointment query
                // updates date, timeslot, notes and keeps status as Booked
                appointmentTableAdapter.UpdateAppointment(
                    dtpNewDate.Value.ToShortDateString(),
                    Convert.ToInt32(cmbNewTimeSlot.SelectedValue),
                    txtUpdateReason.Text,
                    "Booked",
                    selectedAppointmentID);

                MessageBox.Show("Appointment updated successfully.");

                // always refill after update so grids update automatically
                appointmentViewTableAdapter.Fill(dsDentist.AppointmentView);
                LoadAvailableSlots();
            }
        }

        private void btnClearUpdate_Click(object sender, EventArgs e)
        {
            // resets the entire update panel back to default
            selectedAppointmentID = -1;
            lblSelectedAppointment.Text = "No appointment selected.";
            txtUpdateReason.Clear();
            cmbUpdateAction.SelectedIndex = -1;
            dsDentist.AppointmentView.DefaultView.RowFilter = "";
            dgvUpdateAppointments.DataSource = dsDentist.AppointmentView;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            //Dashboard dashboardForm = new Dashboard();
            //dashboardForm.Show();
            //this.Close();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            Patients patientsForm = new Patients();
            patientsForm.Show();
            this.Hide();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            Appointments appointmentsForm = new Appointments();
            appointmentsForm.Show();
            this.Hide();
        }

        private void btnTreatments_Click(object sender, EventArgs e)
        {
            TreatmentMedicine treatmentMedicineForm = new TreatmentMedicine();
            treatmentMedicineForm.Show();
            this.Hide();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
           // Billing billingForm = new Billing();
           //billingForm.Show();
           //this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //Reports reportsForm = new Reports();
            //reportsForm.Show();
            //this.Hide();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            //Staff staffForm = new Staff();
            //staffForm.Show();
            //this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Login loginForm = new Login();
            //loginForm.Show();
            //this.Hide();
        }

        private void cmbUpdateAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool reschedule =
                cmbUpdateAction.SelectedItem.ToString() == "Reschedule";

            dtpNewDate.Enabled = reschedule;
            cmbNewTimeSlot.Enabled = reschedule;
        }


    }
}