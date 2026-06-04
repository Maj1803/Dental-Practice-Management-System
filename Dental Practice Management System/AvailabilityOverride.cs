using Dental_Practice_Management_System.dsDentistTableAdapters;
using System.Data.SqlClient;
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
    public partial class AvailabilityOverride : Form
    {
        // Prevent searches running while initializing dropdowns
        private bool isInitializing = true;
        private int selectedOverrideId = -1; // Stores the ID of the record being edited (-1 means adding new)
        TimeslotTableAdapter timeslotTableAdapter = new TimeslotTableAdapter();

        // Reason choices when the dentist is gone for the entire day
        private readonly string[] fullDayReasons = new string[]
        {
            "Annual Leave",
            "Sick Leave",
            "Dental Conference / Training",
            "Personal Matter",
            "Emergency",
            "Other"
        };

        // Reason choices when blocking out a minor individual time slot
        private readonly string[] partialDayReasons = new string[]
        {
            "Lunch Break",
            "Complex Surgery Preparation",
            "Meeting / Admin Work",
            "Other"
        };

        public AvailabilityOverride()
        {
            InitializeComponent();
        }

        private void AvailabilityOverride_Load(object sender, EventArgs e)
        {
            isInitializing = true;

            // Load master lookup lists from the Dataset TableAdapters
            this.availability_OverrideTableAdapter.FillBy(this.dsDentist.Availability_Override);
            this.employeeTableAdapter.FillByDentist(this.dsDentist.Employee);

            // Wire up core entry element event hooks safely
            cmbDentist.SelectedIndexChanged -= cmbDentist_SelectedIndexChanged;
            cmbDentist.SelectedIndexChanged += cmbDentist_SelectedIndexChanged;

            dtpDate.ValueChanged -= dtpDate_ValueChanged;
            dtpDate.ValueChanged += dtpDate_ValueChanged;

            cmbDentist.SelectedIndex = -1;

            // Setup search UI state defaults
            txtUnifiedSearch.Clear();

            isInitializing = false;
            PerformDynamicSearch();

            dgvOverrides.DataError += (s, ev) => ev.ThrowException = false;

            LoadOverrideTimeSlots();

            // Establish visual panels dock states
            pnlDisplay.Dock = DockStyle.Fill;
            pnlForm.Dock = DockStyle.Fill;

            pnlDisplay.Visible = false;
            pnlForm.Visible = false;

            ShowPanel(pnlDisplay);
        }

        private void InitializeSearchControls()
        {
            txtUnifiedSearch.Clear();
            isInitializing = false;
            PerformDynamicSearch();
        }

        private void PerformDynamicSearch()
        {
            if (isInitializing) return;

            try
            {
                string userInput = txtUnifiedSearch.Text.Trim();

                // If the search bar is empty, load everything using your default FillBy method
                if (string.IsNullOrEmpty(userInput))
                {
                    this.availability_OverrideTableAdapter.FillBy(this.dsDentist.Availability_Override);
                    dgvOverrides.Refresh();
                    return;
                }

                // Default fallbacks to pass to new SQL layout parameters
                int isDateSearch = 0;
                string searchDateParam = null;
                string searchValueParam = userInput;

                // Try to parse the input into a valid Date
                if (DateTime.TryParse(userInput, out DateTime parsedDate))
                {
                    isDateSearch = 1;
                    searchDateParam = parsedDate.ToString("yyyy-MM-dd");
                    searchValueParam = null;
                }

                // Execute updated three-parameter TableAdapter query tool
                this.availability_OverrideTableAdapter.FillBySearch(
                    this.dsDentist.Availability_Override,
                    isDateSearch,
                    searchDateParam,
                    searchValueParam
                );

                dgvOverrides.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPanel(Panel panelToShow)
        {
            pnlDisplay.Visible = false;
            pnlForm.Visible = false;

            panelToShow.Dock = DockStyle.Fill;
            panelToShow.Visible = true;
            panelToShow.BringToFront();

            bool shouldShowButton = (panelToShow == pnlDisplay);

            btAddNew.Visible = shouldShowButton;
            btAddNew.Enabled = shouldShowButton;

            panelToShow.Refresh();
        }

        private void LoadOverrideTimeSlots()
        {
            if (cmbDentist.SelectedValue == null) return;
            if (cmbDentist.SelectedValue is System.Data.DataRowView) return;

            try
            {
                int employeeID = Convert.ToInt32(cmbDentist.SelectedValue);
                DateTime chosenDate = dtpDate.Value.Date;
                int dayOfWeek = (int)chosenDate.DayOfWeek + 1;

                this.dsDentist.Timeslot.Clear();
                this.dsDentist.EnforceConstraints = false;

                timeslotTableAdapter.FillByAvailableSlots(
                    this.dsDentist.Timeslot, dayOfWeek, chosenDate, employeeID);

                cmbTimeSlot.DataSource = null;
                cmbTimeSlot.Items.Clear();
                cmbTimeSlot.DataSource = this.dsDentist.Timeslot;
                cmbTimeSlot.DisplayMember = "Slot_Start_Time";
                cmbTimeSlot.ValueMember = "Timeslot_ID";
                cmbTimeSlot.Format -= cmbOverrideTimeSlot_Format;
                cmbTimeSlot.Format += cmbOverrideTimeSlot_Format;
                cmbTimeSlot.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load available slots: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOverrideTimeSlot_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.Value != null &&
                TimeSpan.TryParse(e.Value.ToString(), out TimeSpan time))
            {
                e.Value = time.ToString(@"hh\:mm");
            }
        }

        private void chkFullDay_CheckedChanged(object sender, EventArgs e)
        {
            cmbTimeSlot.Enabled = !chkFullDay.Checked;
            if (chkFullDay.Checked)
            {
                cmbTimeSlot.SelectedIndex = -1;
            }

            UpdateReasonComboBoxOptions();
        }

        private void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReason.SelectedItem != null && cmbReason.SelectedItem.ToString() == "Other")
            {
                txtReason.Enabled = true;
                txtReason.Focus();
            }
            else
            {
                txtReason.Enabled = false;
                txtReason.Clear();
            }
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReason.Text) && cmbReason.SelectedItem?.ToString() != "Other")
            {
                cmbReason.SelectedItem = "Other";
            }
        }

        private void UpdateReasonComboBoxOptions()
        {
            cmbReason.SelectedIndexChanged -= cmbReason_SelectedIndexChanged;

            cmbReason.DataSource = null;
            cmbReason.Items.Clear();

            if (chkFullDay.Checked)
            {
                cmbReason.DataSource = fullDayReasons;
            }
            else
            {
                cmbReason.DataSource = partialDayReasons;
            }

            cmbReason.SelectedIndex = -1;
            txtReason.Clear();
            txtReason.Enabled = false;

            cmbReason.SelectedIndexChanged += cmbReason_SelectedIndexChanged;
        }

        private void ClearFormInputs()
        {
            cmbDentist.SelectedIndex = -1;
            cmbTimeSlot.SelectedIndex = -1;

            chkFullDay.Checked = false;
            cmbTimeSlot.Enabled = true;
            dtpDate.Value = DateTime.Today;

            UpdateReasonComboBoxOptions();
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            ClearFormInputs();

            if (cmbDentist.Items.Count > 0)
                cmbDentist.SelectedIndex = 0;

            LoadOverrideTimeSlots();
            ShowPanel(pnlForm);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("The selected date cannot be in the past. Please choose a current or future date.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDate.Focus();
                return;
            }

            if (cmbDentist.SelectedIndex == -1 || cmbDentist.SelectedValue == null)
            {
                MessageBox.Show("Please select a dentist from the drop-down list before saving.", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDentist.Focus();
                return;
            }

            if (!chkFullDay.Checked && (cmbTimeSlot.SelectedIndex == -1 || cmbTimeSlot.SelectedValue == null))
            {
                MessageBox.Show("Please select a specific 30-minute time slot, or check 'Full Day' to block the entire date.", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTimeSlot.Focus();
                return;
            }

            if (cmbReason.SelectedIndex == -1 || cmbReason.SelectedItem == null)
            {
                MessageBox.Show("Please select a reason for this availability override.", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbReason.Focus();
                return;
            }

            string finalReason = "";
            string selectedReason = cmbReason.SelectedItem.ToString();

            if (selectedReason == "Other")
            {
                if (string.IsNullOrWhiteSpace(txtReason.Text))
                {
                    MessageBox.Show("Please type your custom reason into the text field.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReason.Focus();
                    return;
                }
                finalReason = txtReason.Text.Trim();
            }
            else
            {
                finalReason = selectedReason;
            }

            try
            {
                int employeeId = Convert.ToInt32(cmbDentist.SelectedValue);
                DateTime targetDate = dtpDate.Value.Date;
                int? timeslotId = null;

                if (!chkFullDay.Checked)
                    timeslotId = Convert.ToInt32(cmbTimeSlot.SelectedValue);

                int clashCount = 0;

                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    con.Open();
                    string sql;

                    if (chkFullDay.Checked)
                    {
                        sql = @"SELECT COUNT(*) FROM Appointment
                                WHERE Employee_ID = @EmployeeID
                                AND Appointment_Date = @AppointmentDate
                                AND Appointment_Status = 'Scheduled'";
                    }
                    else
                    {
                        sql = @"SELECT COUNT(*) FROM Appointment
                                WHERE Employee_ID = @EmployeeID
                                AND Appointment_Date = @AppointmentDate
                                AND Timeslot_ID = @TimeslotID
                                AND Appointment_Status = 'Scheduled'";
                    }

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Parameters.AddWithValue("@AppointmentDate", targetDate);

                    if (!chkFullDay.Checked)
                        cmd.Parameters.AddWithValue("@TimeslotID", timeslotId.Value);

                    clashCount = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (clashCount > 0)
                {
                    MessageBox.Show(
                        "This dentist already has a scheduled appointment during this override period.\n\n" +
                        "Please cancel or reschedule the appointment first.",
                        "Override Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string targetDateStr = dtpDate.Value.ToString("yyyy-MM-dd");
                bool isFullDayBool = chkFullDay.Checked;

                if (selectedOverrideId == -1)
                {
                    availability_OverrideTableAdapter.InsertOverride(targetDateStr, timeslotId, isFullDayBool, finalReason, employeeId);
                    MessageBox.Show("The availability override has been successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    availability_OverrideTableAdapter.UpdateOverride(targetDateStr, timeslotId, isFullDayBool, finalReason, employeeId, selectedOverrideId);
                    MessageBox.Show("The availability override has been successfully updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                availability_OverrideTableAdapter.FillBy(dsDentist.Availability_Override);
                dgvOverrides.Refresh();

                ClearFormInputs();
                ShowPanel(pnlDisplay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database save operation failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOverrides.CurrentRow == null || dgvOverrides.CurrentRow.Index < 0 || dgvOverrides.CurrentRow.Cells[0].Value == DBNull.Value)
            {
                MessageBox.Show("Please select a valid record from the list.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedOverrideId = Convert.ToInt32(dgvOverrides.CurrentRow.Cells["Override_ID"].Value);

            dtpDate.Value = Convert.ToDateTime(dgvOverrides.CurrentRow.Cells["Target_Date"].Value);
            cmbDentist.SelectedValue = dgvOverrides.CurrentRow.Cells["Employee_ID"].Value;

            string isFullDayStr = dgvOverrides.CurrentRow.Cells["Is_Full_Day"].Value.ToString();
            chkFullDay.Checked = (isFullDayStr == "Y" || isFullDayStr == "True");

            // Build list collection array boundaries before applying selected values
            UpdateReasonComboBoxOptions();

            if (!chkFullDay.Checked && dgvOverrides.CurrentRow.Cells["Timeslot_ID"].Value != DBNull.Value)
            {
                LoadOverrideTimeSlots();
                cmbTimeSlot.SelectedValue = dgvOverrides.CurrentRow.Cells["Timeslot_ID"].Value;
            }
            else
            {
                cmbTimeSlot.SelectedIndex = -1;
            }

            string gridReason = dgvOverrides.CurrentRow.Cells["Reason"].Value.ToString();
            if (cmbReason.Items.Contains(gridReason))
            {
                cmbReason.SelectedItem = gridReason;
                txtReason.Clear();
                txtReason.Enabled = false;
            }
            else
            {
                cmbReason.SelectedItem = "Other";
                txtReason.Enabled = true;
                txtReason.Text = gridReason;
            }

            ShowPanel(pnlForm);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOverrides.CurrentRow == null || dgvOverrides.CurrentRow.Cells["Override_ID"].Value == DBNull.Value)
            {
                MessageBox.Show("Please select an availability override record from the table list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Are you sure you want to permanently delete this availability override rule?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int targetId = Convert.ToInt32(dgvOverrides.CurrentRow.Cells["Override_ID"].Value);
                    this.availability_OverrideTableAdapter.DeleteOverride(targetId);

                    MessageBox.Show("The availability override record has been successfully deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.availability_OverrideTableAdapter.FillBy(this.dsDentist.Availability_Override);
                    dgvOverrides.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database deletion failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            isInitializing = true;
            txtUnifiedSearch.Clear();
            isInitializing = false;

            PerformDynamicSearch();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (selectedOverrideId != -1)
            {
                MessageBox.Show("Update canceled. No modifications were made to the record.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No updates have been made.", "Cancel Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ClearFormInputs();
            ShowPanel(pnlDisplay);
        }

        private void txtUnifiedSearch_TextChanged(object sender, EventArgs e)
        {
            PerformDynamicSearch();
        }

        private void txtUnifiedSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = txtUnifiedSearch.Text.Trim();

                if (System.Text.RegularExpressions.Regex.IsMatch(input, @"\d") && !DateTime.TryParse(input, out _))
                {
                    MessageBox.Show(
                        "The date format wasn't recognized. Please use a standard layout:\n\n" +
                        " • 2026-06-04\n" +
                        " • 04 June 2026\n" +
                        " • 04/06/2026",
                        "Invalid Date Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );

                    txtUnifiedSearch.Focus();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadOverrideTimeSlots();
        }

        private void cmbDentist_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOverrideTimeSlots();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                Appointments appointmentsForm = new Appointments();
                appointmentsForm.MdiParent = this.MdiParent;
                appointmentsForm.FormBorderStyle = FormBorderStyle.None;
                appointmentsForm.Dock = DockStyle.Fill;
                appointmentsForm.Show();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btCancel_MouseHover(object sender, EventArgs e) { btCancel.ForeColor = Color.White; }
        private void btnSave_MouseEnter(object sender, EventArgs e) { btnSave.ForeColor = Color.White; }
        private void btnSave_MouseLeave(object sender, EventArgs e) { btCancel.ForeColor = Color.Indigo; }
        private void btCancel_MouseEnter(object sender, EventArgs e) { btCancel.ForeColor = Color.White; }
        private void btCancel_MouseLeave(object sender, EventArgs e) { btCancel.ForeColor = Color.DimGray; }
    }
}