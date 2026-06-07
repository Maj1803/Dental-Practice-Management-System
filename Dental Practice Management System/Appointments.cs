using Dental_Practice_Management_System.dsDentistTableAdapters;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class Appointments : Form
    {
        int selectedPatientID = -1;
        int selectedAppointmentID = -1;
        int selectedEmployeeID = -1;
        DataView viewAppointmentsDataView;
        DataView updateAppointmentsDataView;

        dsDentist dsDentist = new dsDentist();
        PatientTableAdapter patientTableAdapter = new PatientTableAdapter();
        EmployeeTableAdapter employeeTableAdapter = new EmployeeTableAdapter();
        AppointmentTableAdapter appointmentTableAdapter = new AppointmentTableAdapter();
        TimeslotTableAdapter timeslotTableAdapter = new TimeslotTableAdapter();
        AppointmentViewTableAdapter appointmentViewTableAdapter = new AppointmentViewTableAdapter();

        public Appointments()
        {
            InitializeComponent();
            pnlContent.Visible = true;
            ShowPanel(pnlBookAppointment);
        }

        private void ShowPanel(Panel panelToShow)
        {
            pnlViewAppointments.Visible = false;
            pnlBookAppointment.Visible = false;
            pnlUpdateAppointment.Visible = false;
            panelToShow.Visible = true;

            btnBookAppointment.BackColor = System.Drawing.Color.FromArgb(14, 116, 144);
            btnBookAppointment.ForeColor = System.Drawing.Color.White;
            btnViewAppointments.BackColor = System.Drawing.Color.FromArgb(14, 116, 144);
            btnViewAppointments.ForeColor = System.Drawing.Color.White;
            btnUpdateAppointment.BackColor = System.Drawing.Color.FromArgb(14, 116, 144);
            btnUpdateAppointment.ForeColor = System.Drawing.Color.White;

            if (panelToShow == pnlBookAppointment)
            {
                btnBookAppointment.BackColor = System.Drawing.Color.FromArgb(26, 58, 143);
                btnBookAppointment.ForeColor = System.Drawing.Color.White;
            }
            else if (panelToShow == pnlViewAppointments)
            {
                btnViewAppointments.BackColor = System.Drawing.Color.FromArgb(26, 58, 143);
                btnViewAppointments.ForeColor = System.Drawing.Color.White;
            }
            else if (panelToShow == pnlUpdateAppointment)
            {
                btnUpdateAppointment.BackColor = System.Drawing.Color.FromArgb(26, 58, 143);
                btnUpdateAppointment.ForeColor = System.Drawing.Color.White;
            }
        }

        private void GoToViewForDate(DateTime dateToShow)
        {
            appointmentViewTableAdapter.Fill(dsDentist.AppointmentView);

            viewAppointmentsDataView = new DataView(dsDentist.AppointmentView);
            updateAppointmentsDataView = new DataView(dsDentist.AppointmentView);

            dgvAppointments.DataSource = viewAppointmentsDataView;
            dgvUpdateAppointments.DataSource = updateAppointmentsDataView;

            txtSearchAppointments.Clear();
            cmbStatusFilter.SelectedItem = "All";
            dtpFilterDate.Value = dateToShow.Date;

            ApplyViewFilter();
            ApplyUpdateFilter();

            ShowPanel(pnlViewAppointments);
        }

        private void FormatAppointmentGrid(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            if (dgv.Columns.Contains("Employee_ID"))
                dgv.Columns["Employee_ID"].Visible = false;
            if (dgv.Columns.Contains("Timeslot_ID"))
                dgv.Columns["Timeslot_ID"].Visible = false;
            if (dgv.Columns.Contains("Appointment_ID"))
            {
                dgv.Columns["Appointment_ID"].HeaderText = "ID";
                dgv.Columns["Appointment_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (dgv.Columns.Contains("Patient_First_Name"))
                dgv.Columns["Patient_First_Name"].HeaderText = "First Name";
            if (dgv.Columns.Contains("Patient_Last_Name"))
                dgv.Columns["Patient_Last_Name"].HeaderText = "Last Name";
            if (dgv.Columns.Contains("Employee_First_Name"))
                dgv.Columns["Employee_First_Name"].HeaderText = "Dentist";
            if (dgv.Columns.Contains("Employee_Last_Name"))
                dgv.Columns["Employee_Last_Name"].HeaderText = "Surname";
            if (dgv.Columns.Contains("Slot_Start_Time"))
            {
                dgv.Columns["Slot_Start_Time"].HeaderText = "Time";
                dgv.Columns["Slot_Start_Time"].DefaultCellStyle.Format = @"hh\:mm";
            }
            if (dgv.Columns.Contains("Appointment_Date"))
                dgv.Columns["Appointment_Date"].HeaderText = "Date";
            if (dgv.Columns.Contains("Appointment_Status"))
                dgv.Columns["Appointment_Status"].HeaderText = "Status";

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(14, 116, 144);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;

            dgv.AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void FormatPatientGrid(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            string[] toHide = {
                "Patient_Street", "Patient_Suburb",
                "Patient_City", "Patient_Code",
                "Patient_Email", "Patient_Allergies",
                "Patient_DOB", "Patient_Phone_Number"
            };

            foreach (string col in toHide)
                if (dgv.Columns.Contains(col))
                    dgv.Columns[col].Visible = false;

            if (dgv.Columns.Contains("Patient_ID"))
                dgv.Columns["Patient_ID"].HeaderText = "ID";
            if (dgv.Columns.Contains("Patient_First_Name"))
                dgv.Columns["Patient_First_Name"].HeaderText = "First Name";
            if (dgv.Columns.Contains("Patient_Last_Name"))
                dgv.Columns["Patient_Last_Name"].HeaderText = "Last Name";

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(14, 116, 144);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;

            dgv.AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void LoadAvailableSlots()
        {
            if (cmbDentist.SelectedValue == null) return;
            if (cmbDentist.SelectedValue is System.Data.DataRowView) return;

            try
            {
                int employeeID = Convert.ToInt32(cmbDentist.SelectedValue);
                DateTime chosenDate = dtpAppointmentDate.Value.Date;
                int dayOfWeek = (int)chosenDate.DayOfWeek + 1;

                dsDentist.Timeslot.Clear();
                dsDentist.EnforceConstraints = false;

                using (var conn = new System.Data.SqlClient.SqlConnection(
                    Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();
                    string sql = @"
                SELECT t.Timeslot_ID, t.Slot_Start_Time
                FROM Timeslot t
                WHERE t.Day_Of_Week = @dayOfWeek
                AND t.Is_Active = 1
                AND t.Timeslot_ID NOT IN (
                    SELECT a.Timeslot_ID FROM Appointment a
                    WHERE CAST(a.Appointment_Date AS DATE) = @date
                    AND a.Employee_ID = @employeeID
                    AND a.Appointment_Status != 'Cancelled'
                )
                AND t.Timeslot_ID NOT IN (
                    SELECT ao.Timeslot_ID FROM Availability_Override ao
                    WHERE ao.Target_Date = @date
                    AND ao.Employee_ID = @employeeID
                    AND ao.Is_Full_Day = 0
                )
                AND NOT EXISTS (
                    SELECT 1 FROM Availability_Override ao
                    WHERE ao.Target_Date = @date
                    AND ao.Employee_ID = @employeeID
                    AND ao.Is_Full_Day = 1
                )
                AND (
                    CAST(@date AS DATE) > CAST(GETDATE() AS DATE)
                    OR t.Slot_Start_Time > CAST(GETDATE() AS TIME)
                )
                ORDER BY t.Slot_Start_Time";

                    var cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@dayOfWeek", dayOfWeek);
                    cmd.Parameters.AddWithValue("@date", chosenDate);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    var table = new System.Data.DataTable();
                    adapter.Fill(table);

                    cmbTimeSlot.DataSource = null;
                    cmbTimeSlot.Items.Clear();
                    cmbTimeSlot.DataSource = table;
                    cmbTimeSlot.DisplayMember = "Slot_Start_Time";
                    cmbTimeSlot.ValueMember = "Timeslot_ID";
                    cmbTimeSlot.Format -= cmbTimeSlot_Format;
                    cmbTimeSlot.Format += cmbTimeSlot_Format;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load available slots: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTimeSlot_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.Value != null &&
                TimeSpan.TryParse(e.Value.ToString(), out TimeSpan time))
            {
                e.Value = time.ToString(@"hh\:mm");
            }
        }

        private void LoadNewSlotsForUpdate()
        {
            if (selectedEmployeeID == -1) return;

            try
            {
                int dayOfWeek = (int)dtpNewDate.Value.Date.DayOfWeek + 1;

                dsDentist.Timeslot.Clear();
                dsDentist.EnforceConstraints = false;

                timeslotTableAdapter.FillByAvailableSlots(
                    dsDentist.Timeslot,
                    dayOfWeek,
                    dtpNewDate.Value.Date,
                    selectedEmployeeID);

                cmbNewTimeSlot.DataSource = null;
                cmbNewTimeSlot.Items.Clear();
                cmbNewTimeSlot.DataSource = dsDentist.Timeslot;
                cmbNewTimeSlot.DisplayMember = "Slot_Start_Time";
                cmbNewTimeSlot.ValueMember = "Timeslot_ID";
                cmbNewTimeSlot.Format -= cmbTimeSlot_Format;
                cmbNewTimeSlot.Format += cmbTimeSlot_Format;

                if (cmbNewTimeSlot.Items.Count == 0)
                    MessageBox.Show("No available slots for this date. Please choose another date.",
                        "No Slots Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load slots: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyViewFilter()
        {
            if (viewAppointmentsDataView == null) return;

            string status = cmbStatusFilter.SelectedItem?.ToString() ?? "All";
            string name = txtSearchAppointments.Text.Trim().Replace("'", "''");
            string filter = "";

            if (dtpFilterDate.Checked)
            {
                filter =
                    $"Appointment_Date >= #{dtpFilterDate.Value.Date:MM/dd/yyyy}# " +
                    $"AND Appointment_Date < #{dtpFilterDate.Value.Date.AddDays(1):MM/dd/yyyy}#";
            }

            if (status != "All")
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"Appointment_Status = '{status}'";
            }

            if (!string.IsNullOrEmpty(name))
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"(Patient_First_Name LIKE '%{name}%' OR Patient_Last_Name LIKE '%{name}%')";
            }

            viewAppointmentsDataView.RowFilter = filter;
            dgvAppointments.DataSource = viewAppointmentsDataView;
            FormatAppointmentGrid(dgvAppointments);
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            try
            {
                patientTableAdapter.Fill(dsDentist.Patient);
                employeeTableAdapter.Fill(dsDentist.Employee);
                appointmentViewTableAdapter.Fill(dsDentist.AppointmentView);

                viewAppointmentsDataView = new DataView(dsDentist.AppointmentView);
                updateAppointmentsDataView = new DataView(dsDentist.AppointmentView);

                dgvAppointments.DataSource = viewAppointmentsDataView;
                dgvUpdateAppointments.DataSource = updateAppointmentsDataView;
                FormatAppointmentGrid(dgvAppointments);
                FormatAppointmentGrid(dgvUpdateAppointments);

                cmbStatusFilter.Items.Add("All");
                cmbStatusFilter.Items.Add("Scheduled");
                cmbStatusFilter.Items.Add("Completed");
                cmbStatusFilter.Items.Add("Cancelled");
                cmbStatusFilter.SelectedIndex = 0;
                cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;

                dtpFilterDate.Value = DateTime.Today;
                dtpFilterDate.Enabled = true;
                dtpFilterDate.ValueChanged += dtpFilterDate_ValueChanged;
                txtSearchAppointments.TextChanged += txtSearchAppointments_TextChanged;

                employeeTableAdapter.FillByDentist(dsDentist.Employee);
                cmbDentist.DataSource = dsDentist.Employee;
                cmbDentist.DisplayMember = "Employee_First_Name";
                cmbDentist.ValueMember = "Employee_ID";
              
             
                if (dsDentist.Employee.Rows.Count > 0)
                {
                    txtDentistNum.Text = dsDentist.Employee.Rows[0]["Employee_Phone_Number"]?.ToString() ?? "";
                    txtDentistEmail.Text = dsDentist.Employee.Rows[0]["Employee_Email"]?.ToString() ?? "";
                }

                cmbUpdateStatusFilter.Items.Add("All");
                cmbUpdateStatusFilter.Items.Add("Scheduled");
                cmbUpdateStatusFilter.Items.Add("Completed");
                cmbUpdateStatusFilter.Items.Add("Cancelled");
                cmbUpdateStatusFilter.Items.Add("Past Scheduled");

                cmbUpdateStatusFilter.SelectedIndex = 1;

                LoadUpdateActions();
                cmbUpdateAction.SelectedIndexChanged += cmbUpdateAction_SelectedIndexChanged;
                btnMarkAllCompleted.Visible = false;

                dtpUpdateFilterDate.Enabled = true;
                dtpUpdateFilterDate.Value = DateTime.Today;

                dtpNewDate.Enabled = false;
                cmbNewTimeSlot.Enabled = false;

                txtUpdateSearch.TextChanged += txtUpdateSearch_TextChanged;
                txtSearchPatient.TextChanged += txtSearchPatient_TextChanged;
                dtpAppointmentDate.MinDate = DateTime.Today;
                dtpNewDate.MinDate = DateTime.Today;
                ApplyViewFilter();
                ApplyUpdateFilter();
                LoadAvailableSlots();
                UpdateBulkCompleteButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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




        private void txtUpdateSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyUpdateFilter();
            UpdateBulkCompleteButton();
        }

        private void btnUpdateSearch_Click(object sender, EventArgs e)
        {
            ApplyUpdateFilter();

            if (dgvUpdateAppointments.Rows.Count <= 1)
            {
                MessageBox.Show("No appointments found for the selected filters.",
                    "No Results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void txtSearchPatient_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchPatient.Text))
            {
                dgvPatientResults.DataSource = null;
                return;
            }

            var results = patientTableAdapter.GetDataBy4(txtSearchPatient.Text);
            dgvPatientResults.DataSource = results;
            FormatPatientGrid(dgvPatientResults);

            if (dgvPatientResults.Rows.Count > 0)
            {
                dgvPatientResults.Rows[0].Selected = true;
                var firstRow = dgvPatientResults.Rows[0];

                if (firstRow.Cells[0].Value != null)
                    selectedPatientID = Convert.ToInt32(firstRow.Cells[0].Value);

                string name = firstRow.Cells["Patient_First_Name"].Value?.ToString() ?? "";
                string surname = firstRow.Cells["Patient_Last_Name"].Value?.ToString() ?? "";

       
            }
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchPatient.Text))
            {
                MessageBox.Show("Please enter a patient name to search.",
                    "Empty Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchPatient.Focus();
                return;
            }

            var results = patientTableAdapter.GetDataBy4(txtSearchPatient.Text);
            dgvPatientResults.DataSource = results;
            FormatPatientGrid(dgvPatientResults);

            if (dgvPatientResults.Rows.Count == 0)
                MessageBox.Show($"No patients found for '{txtSearchPatient.Text}'.",
                    "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvPatientResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                selectedPatientID = Convert.ToInt32(
                    dgvPatientResults.CurrentRow.Cells[0].Value);

                string name = dgvPatientResults.CurrentRow.Cells["Patient_First_Name"].Value.ToString();
                string surname = dgvPatientResults.CurrentRow.Cells["Patient_Last_Name"].Value.ToString();

                txtPatient.Text = name + " " + surname;
                txtPatientNum.Text = dgvPatientResults.CurrentRow.Cells["Patient_Phone_Number"].Value?.ToString() ?? "";
                txtEmail.Text = dgvPatientResults.CurrentRow.Cells["Patient_Email"].Value?.ToString() ?? "";
                txtPatient.ForeColor = System.Drawing.Color.FromArgb(26, 58, 143);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting patient: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAvailableSlots();
        }

        private void cmbDentist_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableSlots();

            if (cmbDentist.SelectedValue == null || cmbDentist.SelectedValue is DataRowView) return;

            try
            {
                int empID = Convert.ToInt32(cmbDentist.SelectedValue);
                DataRow[] emp = dsDentist.Employee.Select($"Employee_ID = {empID}");
                if (emp != null && emp.Length > 0)
                {
                    txtDentistNum.Text = emp[0]["Employee_Phone_Number"]?.ToString() ?? "";
                    txtDentistEmail.Text = emp[0]["Employee_Email"]?.ToString() ?? "";
                }
            }
            catch { }
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (selectedPatientID == -1)
            {
                MessageBox.Show("Please search for and select a patient first.",
                    "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTimeSlot.SelectedValue == null || cmbTimeSlot.Items.Count == 0)
            {
                MessageBox.Show("No available time slots for the selected date and dentist.\nPlease choose a different date.",
                    "No Slots Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpAppointmentDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Cannot book an appointment in the past.\nPlease select today or a future date.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        

            string patientName = txtPatient.Text.Replace("Selected: ", "");
            string dentistName = cmbDentist.Text;
            string timeSlot = cmbTimeSlot.Text;
            string date = dtpAppointmentDate.Value.ToString("dddd, dd MMMM yyyy");

            DialogResult confirm = MessageBox.Show(
                $"Please confirm the following booking:\n\n" +
                $"Patient:  {patientName}\n" +
                $"Dentist:  {dentistName}\n" +
                $"Date:     {date}\n" +
                $"Time:     {timeSlot}\n\n" +
                $"Proceed?",
                "Confirm Booking",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.OK)
            {
                try
                {
                    appointmentTableAdapter.Insert(
                        selectedPatientID,
                        Convert.ToInt32(cmbDentist.SelectedValue),
                        Convert.ToInt32(cmbTimeSlot.SelectedValue),
                        dtpAppointmentDate.Value.Date,
                        txtAppointmentNotes.Text,
                        null,
                        "Scheduled");

                    MessageBox.Show(
                        $"Appointment booked successfully!\n\n" +
                        $"Patient:  {patientName}\n" +
                        $"Dentist:  {dentistName}\n" +
                        $"Date:     {date}\n" +
                        $"Time:     {timeSlot}",
                        "Booking Confirmed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadAvailableSlots();
                    GoToViewForDate(dtpAppointmentDate.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving appointment: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearBooking_Click(object sender, EventArgs e)
        {
            selectedPatientID = -1;
            txtSearchPatient.Clear();
            txtAppointmentNotes.Clear();
            dsDentist.Patient.Clear();
            dgvPatientResults.DataSource = null;
            txtPatient.Text = "";
            txtPatientNum.Text = "";
            txtEmail.Text = "";
            txtDentistNum.Text = "";
            txtDentistEmail.Text = "";
        }

        private void dgvUpdateAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                string currentStatus = dgvUpdateAppointments.CurrentRow
                    .Cells["Appointment_Status"].Value.ToString();

                if (currentStatus == "Completed" || currentStatus == "Cancelled")
                {
                    MessageBox.Show(
                        $"This appointment is already {currentStatus} and cannot be modified.",
                        "Cannot Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    selectedAppointmentID = -1;
                    selectedEmployeeID = -1;
                  
                    cmbUpdateAction.SelectedIndex = -1;
                    dtpNewDate.Enabled = false;
                    cmbNewTimeSlot.Enabled = false;
                    return;
                }

                selectedAppointmentID = Convert.ToInt32(
                    dgvUpdateAppointments.CurrentRow.Cells["Appointment_ID"].Value);

                selectedEmployeeID = Convert.ToInt32(
                    dgvUpdateAppointments.CurrentRow.Cells["Employee_ID"].Value);

                string patientFirst = dgvUpdateAppointments.CurrentRow
                    .Cells["Patient_First_Name"].Value.ToString();
                string patientLast = dgvUpdateAppointments.CurrentRow
                    .Cells["Patient_Last_Name"].Value.ToString();

                txtPatientName.Text =
                    $"{patientFirst} {patientLast}";
                

                var pt = patientTableAdapter.GetDataBy4(patientFirst);
                if (pt.Rows.Count > 0)
                {
                    txtPatientNo.Text = pt.Rows[0]["Patient_Phone_Number"]?.ToString() ?? "";
                    txtPatientEmailAdd.Text = pt.Rows[0]["Patient_Email"]?.ToString() ?? "";
                }
                txtDentistName.Text = dgvUpdateAppointments.CurrentRow.Cells["Employee_First_Name"].Value + " " +
                                         dgvUpdateAppointments.CurrentRow.Cells["Employee_Last_Name"].Value;
                txtCurrentDate.Text = Convert.ToDateTime(dgvUpdateAppointments.CurrentRow.Cells["Appointment_Date"].Value).ToString("dd MMM yyyy");
                txtCurrentTime.Text =
                    TimeSpan.Parse(
                        dgvUpdateAppointments.CurrentRow.Cells["Slot_Start_Time"].Value.ToString())
                        .ToString(@"hh\:mm");
                txtUpdStatus.Text = currentStatus;

                cmbNewTimeSlot.DataSource = null;
                cmbNewTimeSlot.Items.Clear();

                if (cmbUpdateAction.SelectedItem?.ToString() == "Reschedule")
                    LoadNewSlotsForUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting appointment: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentID == -1)
            {
                MessageBox.Show("Please search for and select an appointment first.",
                    "No Appointment Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbUpdateAction.SelectedItem == null)
            {
                MessageBox.Show("Please select an action (Reschedule, Cancel, or Completed).",
                    "No Action Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string action = cmbUpdateAction.SelectedItem.ToString();

            if (cmbUpdateStatusFilter.SelectedItem?.ToString() == "Past Scheduled" &&
                action != "Completed")
            {
                MessageBox.Show(
                    "Past scheduled appointments can only be marked as Completed.",
                    "Invalid Action",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (action == "Cancel")
                {
                    DialogResult confirm = MessageBox.Show(
                        "Are you sure you want to CANCEL this appointment?\nThis cannot be undone.",
                        "Cancel Appointment",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        appointmentTableAdapter.CancelAppointment(selectedAppointmentID);

                        MessageBox.Show("Appointment has been cancelled successfully.",
                            "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        appointmentViewTableAdapter.Fill(dsDentist.AppointmentView);
                        FormatAppointmentGrid(dgvAppointments);
                        FormatAppointmentGrid(dgvUpdateAppointments);
                        ResetUpdatePanel();
                    }
                }
                else if (action == "Completed")
                {
                    DateTime apptDate = Convert.ToDateTime(
                        dgvUpdateAppointments.CurrentRow.Cells["Appointment_Date"].Value);

                    TimeSpan apptTime = TimeSpan.Parse(
                        dgvUpdateAppointments.CurrentRow.Cells["Slot_Start_Time"].Value.ToString());

                    DateTime appointmentEndTime =
                        apptDate.Date + apptTime + TimeSpan.FromMinutes(30);

                    if (DateTime.Now < appointmentEndTime)
                    {
                        MessageBox.Show(
                            "This appointment cannot be marked as Completed yet.",
                            "Cannot Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (apptDate.Date > DateTime.Today)
                    {
                        MessageBox.Show(
                            $"This appointment is scheduled for {apptDate:dd MMM yyyy} and cannot be marked as Completed before that date.",
                            "Cannot Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult confirm = MessageBox.Show(
                        "Mark this appointment as Completed?",
                        "Complete Appointment",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        bool isPastScheduled =
                            cmbUpdateStatusFilter.SelectedItem?.ToString() == "Past Scheduled";

                        string followUpFirstName = dgvUpdateAppointments.CurrentRow
                            .Cells["Patient_First_Name"].Value.ToString();

                        string followUpLastName = dgvUpdateAppointments.CurrentRow
                            .Cells["Patient_Last_Name"].Value.ToString();

                        appointmentTableAdapter.CompleteAppointment(selectedAppointmentID);

                        MessageBox.Show("Appointment marked as Completed successfully.",
                            "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        appointmentViewTableAdapter.Fill(dsDentist.AppointmentView);
                        FormatAppointmentGrid(dgvAppointments);
                        FormatAppointmentGrid(dgvUpdateAppointments);
                        ResetUpdatePanel();

                        if (!isPastScheduled)
                        {
                            DialogResult followUp = MessageBox.Show(
                                "Would you like to schedule a follow-up appointment for this patient?",
                                "Follow-Up Appointment",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (followUp == DialogResult.Yes)
                            {
                                var results = patientTableAdapter.GetDataBy4(followUpFirstName);
                                dgvPatientResults.DataSource = results;
                                FormatPatientGrid(dgvPatientResults);

                                if (dgvPatientResults.Rows.Count > 0)
                                {
                                    selectedPatientID = Convert.ToInt32(dgvPatientResults.Rows[0].Cells[0].Value);
                                    txtPatient.Text = "Selected: " + followUpFirstName + " " + followUpLastName;
                                    txtPatient.ForeColor = System.Drawing.Color.FromArgb(26, 58, 143);
                                }

                                ShowPanel(pnlBookAppointment);
                            }
                        }
                    }
                }
                else
                {
                    if (cmbNewTimeSlot.SelectedValue == null || cmbNewTimeSlot.Items.Count == 0)
                    {
                        MessageBox.Show("Please select a new time slot.",
                            "No Time Slot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (dtpNewDate.Value.Date < DateTime.Today)
                    {
                        MessageBox.Show("Cannot reschedule to a past date.",
                            "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (dtpNewDate.Value.Date == DateTime.Today)
                    {
                        TimeSpan selectedTime = TimeSpan.Parse(cmbNewTimeSlot.Text);
                        DateTime selectedDateTime = dtpNewDate.Value.Date + selectedTime;

                        if (selectedDateTime <= DateTime.Now)
                        {
                            MessageBox.Show("Cannot reschedule an appointment to a time that has already passed.",
                                "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DialogResult confirm = MessageBox.Show(
                        $"Are you sure you want to reschedule this appointment?\n\n" +
                        $"New Date: {dtpNewDate.Value:dddd, dd MMMM yyyy}\n" +
                        $"New Time: {cmbNewTimeSlot.Text}",
                        "Confirm Reschedule",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm != DialogResult.Yes)
                        return;

                    appointmentTableAdapter.UpdateAppointment(
                        dtpNewDate.Value.Date,
                        Convert.ToInt32(cmbNewTimeSlot.SelectedValue),
                        txtUpdateReason.Text,
                        "Scheduled",
                        selectedAppointmentID);

                    MessageBox.Show(
                        $"Appointment rescheduled successfully!\n\n" +
                        $"New Date:  {dtpNewDate.Value:dddd, dd MMMM yyyy}\n" +
                        $"New Time:  {cmbNewTimeSlot.Text}",
                        "Rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetUpdatePanel();
                    GoToViewForDate(dtpNewDate.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointment: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetUpdatePanel()
        {
            selectedAppointmentID = -1;
            selectedEmployeeID = -1;

            txtPatientName.Clear();
            txtPatientNo.Clear();
            txtPatientEmailAdd.Clear();
            txtDentistName.Clear();
            txtCurrentDate.Clear();
            txtCurrentTime.Clear();
            txtUpdStatus.Clear();
            txtUpdateReason.Clear();

            cmbUpdateAction.SelectedIndex = -1;
            cmbNewTimeSlot.DataSource = null;
            cmbNewTimeSlot.Items.Clear();

            dtpNewDate.Enabled = false;
            cmbNewTimeSlot.Enabled = false;

            ApplyUpdateFilter();
            FormatAppointmentGrid(dgvUpdateAppointments);
        }

        private void btnClearUpdate_Click(object sender, EventArgs e)
        {
            ResetUpdatePanel();
            txtUpdateSearch.Focus();
        }

        private void dtpNewDate_ValueChanged(object sender, EventArgs e)
        {
            if (selectedEmployeeID != -1 && cmbUpdateAction.SelectedItem?.ToString() == "Reschedule")
                LoadNewSlotsForUpdate();
        }

        private void cmbUpdateAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUpdateAction.SelectedItem == null) return;

            string action = cmbUpdateAction.SelectedItem.ToString();
            bool isReschedule = action == "Reschedule";

            dtpNewDate.Enabled = isReschedule;
            cmbNewTimeSlot.Enabled = isReschedule;

            if (!isReschedule)
            {
                cmbNewTimeSlot.DataSource = null;
                cmbNewTimeSlot.Items.Clear();
                cmbNewTimeSlot.Text = "";
            }
            else if (selectedAppointmentID != -1)
            {
                LoadNewSlotsForUpdate();
            }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyViewFilter();
        }

        private void dtpFilterDate_ValueChanged(object sender, EventArgs e)
        {
            ApplyViewFilter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                Form openForm = Application.OpenForms["AvailabilityOverride"];

                if (openForm != null)
                {
                    openForm.BringToFront();
                    openForm.Focus();

                    this.Close();
                }
                else
                {
                    AvailabilityOverride overrideForm = new AvailabilityOverride();
                    overrideForm.MdiParent = this.MdiParent;
                    overrideForm.FormBorderStyle = FormBorderStyle.None;
                    overrideForm.Dock = DockStyle.Fill;
                    overrideForm.Show();

                    this.Close();
                }
            }
            else
            {
                AvailabilityOverride overrideForm = new AvailabilityOverride();
                overrideForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchAppointments_TextChanged(object sender, EventArgs e)
        {
            ApplyViewFilter();
        }

        private void btnClearFilter_Click_1(object sender, EventArgs e)
        {
            txtSearchAppointments.Clear();
            dtpFilterDate.Value = DateTime.Today;
            dtpFilterDate.Checked = true;
            cmbStatusFilter.SelectedIndex = 0;
            ApplyViewFilter();
            txtSearchAppointments.Focus();
        }
        private void ApplyUpdateFilter()
        {
            string status = cmbUpdateStatusFilter.SelectedItem?.ToString() ?? "Scheduled";
            string name = txtUpdateSearch.Text.Trim().Replace("'", "''");
            string filter = "";

            if (status == "Past Scheduled")
            {
                filter =
                    $"Appointment_Status = 'Scheduled' " +
                    $"AND Appointment_Date < #{DateTime.Today:MM/dd/yyyy}#";
            }
            else
            {
                if (dtpUpdateFilterDate.Checked)
                {
                    filter =
                        $"Appointment_Date >= #{dtpUpdateFilterDate.Value.Date:MM/dd/yyyy}# " +
                        $"AND Appointment_Date < #{dtpUpdateFilterDate.Value.Date.AddDays(1):MM/dd/yyyy}#";
                }

                if (status != "All")
                {
                    if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                    filter += $"Appointment_Status = '{status}'";
                }
            }

            if (!string.IsNullOrEmpty(name))
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"(Patient_First_Name LIKE '%{name}%' OR Patient_Last_Name LIKE '%{name}%')";
            }

            dsDentist.AppointmentView.DefaultView.RowFilter = filter;
            dgvUpdateAppointments.DataSource = dsDentist.AppointmentView.DefaultView;
            FormatAppointmentGrid(dgvUpdateAppointments);
        }
        private void txtUpdateSearch_TextChanged_1(object sender, EventArgs e)
        {
            ApplyUpdateFilter();
            UpdateBulkCompleteButton();

        }

        private void cmbUpdateStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetUpdatePanel();
            LoadUpdateActions();
            UpdateBulkCompleteButton();
        }

        private void dtpUpdateFilterDate_ValueChanged(object sender, EventArgs e)
        {
            ApplyUpdateFilter();
            UpdateBulkCompleteButton();
        }


        private void btnClearUpdateFilter_Click(object sender, EventArgs e)
        {
            txtUpdateSearch.Clear();
            dtpUpdateFilterDate.Value = DateTime.Today;
            dtpUpdateFilterDate.Checked = true;
            cmbUpdateStatusFilter.SelectedIndex = 1;

            selectedAppointmentID = -1;
            selectedEmployeeID = -1;
            cmbUpdateAction.SelectedIndex = -1;

            txtPatientName.Clear();
            txtPatientNo.Clear();
            txtDentistName.Clear();
            txtCurrentDate.Clear();
            txtCurrentTime.Clear();
            txtUpdStatus.Clear();
            txtPatientEmailAdd.Clear();
            txtUpdateReason.Clear();

            cmbNewTimeSlot.DataSource = null;
            cmbNewTimeSlot.Items.Clear();
            dtpNewDate.Enabled = false;
            cmbNewTimeSlot.Enabled = false;

            ApplyUpdateFilter();
            UpdateBulkCompleteButton();
            txtUpdateSearch.Focus();
        }

        private void LoadUpdateActions()
        {
            cmbUpdateAction.Items.Clear();

            if (cmbUpdateStatusFilter.SelectedItem?.ToString() == "Past Scheduled")
            {
                cmbUpdateAction.Items.Add("Completed");
                cmbUpdateAction.SelectedIndex = 0;
            }
            else
            {
                cmbUpdateAction.Items.Add("Reschedule");
                cmbUpdateAction.Items.Add("Cancel");
                cmbUpdateAction.Items.Add("Completed");
                cmbUpdateAction.SelectedIndex = -1;
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
                LoadAvailableSlots();
        }

        private void btnMarkAllCompleted_Click(object sender, EventArgs e)
        {
           
            DialogResult confirm = MessageBox.Show(
                "Set all past scheduled appointments to Completed?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            int rowsAffected =
                appointmentTableAdapter.CompletePastScheduledAppointments();

            MessageBox.Show(
                $"{rowsAffected} appointment(s) marked as Completed.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            appointmentViewTableAdapter.Fill(dsDentist.AppointmentView);

            ResetUpdatePanel();
            ApplyUpdateFilter();
            UpdateBulkCompleteButton();
        }

        private void UpdateBulkCompleteButton()
        {
            bool isPastScheduled =
                cmbUpdateStatusFilter.SelectedItem?.ToString() == "Past Scheduled";

            bool hasAppointments =
                dsDentist.AppointmentView.DefaultView.Count > 0;

            btnMarkAllCompleted.Visible =
                isPastScheduled && hasAppointments;
        }
    }
}