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

        // Run this inside your Form_Load or after data binding configuration finishes
        private void InitializeSearchControls()
        {
            // Set the dentist drop-down to unselected by default
            cmbSearchDentist.SelectedIndex = -1;
            dtpSearchDate.Checked = false;

            isInitializing = false;
            PerformDynamicSearch(); // Run initial unfiltered load
        }

        private void PerformDynamicSearch()
        {
            if (isInitializing) return;

            try
            {
                // 1. Determine Date Filter Parameter as a clean, nullable string
                string searchDateParam = null;
                if (dtpSearchDate.Checked)
                {
                    searchDateParam = dtpSearchDate.Value.ToString("yyyy-MM-dd");
                }

                // 2. Determine Dentist Filter Parameter as a clean, nullable string
                string searchEmployeeParam = null;
                if (cmbSearchDentist.SelectedIndex != -1 && cmbSearchDentist.SelectedValue != null)
                {
                    searchEmployeeParam = cmbSearchDentist.SelectedValue.ToString();
                }

                // 3. Pass the strings directly. C# null safely translates to SQL NULL via ADO.NET string mapping
                this.availability_OverrideTableAdapter.FillBySearch(
                    this.dsDentist.Availability_Override,
                    searchDateParam,
                    searchEmployeeParam
                );

                dgvOverrides.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search execution failed: {ex.Message}", "Database Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public AvailabilityOverride()
        {
           
            InitializeComponent();
            
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
        }

        private void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If they select "Other", show the custom textbox so they can type it out
            if (cmbReason.SelectedItem != null && cmbReason.SelectedItem.ToString() == "Other")
            {
                txtReason.Focus();
            }
            else
            {
                txtReason.Enabled = false;
                txtReason.Clear(); // Clears any old text
            }
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            // If the user starts typing and "Other" isn't already selected...
            if (!string.IsNullOrEmpty(txtReason.Text) && cmbReason.SelectedItem?.ToString() != "Other")
            {
                // ...automatically switch the ComboBox to "Other"
                cmbReason.SelectedItem = "Other";
            }
        }

        

        private void btCancel_MouseHover(object sender, EventArgs e)
        {
            btCancel.ForeColor = Color.White;
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            ClearFormInputs();

            if (cmbDentist.Items.Count > 0)
                cmbDentist.SelectedIndex = 0;

            LoadOverrideTimeSlots();
            ShowPanel(pnlForm);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            // Check if they canceled while updating or while creating new
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

        private void AvailabilityOverride_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsDentist.Availability_Override' table. You can move, or remove it, as needed.
            //this.availability_OverrideTableAdapter.Fill(this.dsDentist.Availability_Override);
            // TODO: This line of code loads data into the 'dsDentist.Availability_Override' table. You can move, or remove it, as needed.
            this.availability_OverrideTableAdapter.FillBy(this.dsDentist.Availability_Override);
            // TODO: This line of code loads data into the 'dsDentist.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.FillByDentist(this.dsDentist.Employee);

            cmbDentist.SelectedIndexChanged -= cmbDentist_SelectedIndexChanged;
            cmbDentist.SelectedIndexChanged += cmbDentist_SelectedIndexChanged;

            dtpDate.ValueChanged -= dtpDate_ValueChanged;
            dtpDate.ValueChanged += dtpDate_ValueChanged;

            cmbDentist.SelectedIndex = -1;

            isInitializing = false;
            PerformDynamicSearch();

            dgvOverrides.DataError += (s, ev) => ev.ThrowException = false;

            LoadOverrideTimeSlots();
            pnlDisplay.Dock = DockStyle.Fill;
            pnlForm.Dock = DockStyle.Fill;

            pnlDisplay.Visible = false;
            pnlForm.Visible = false;

            ShowPanel(pnlDisplay);

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
                        sql = @"SELECT COUNT(*)
                        FROM Appointment
                        WHERE Employee_ID = @EmployeeID
                        AND Appointment_Date = @AppointmentDate
                        AND Appointment_Status = 'Scheduled'";
                    }
                    else
                    {
                        sql = @"SELECT COUNT(*)
                        FROM Appointment
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
                        "Override Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

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

        private void ClearFormInputs()
        {
            cmbDentist.SelectedIndex = -1;
            cmbTimeSlot.SelectedIndex = -1;
            cmbReason.SelectedIndex = -1;
            txtReason.Clear();
            txtReason.Enabled = false;
            chkFullDay.Checked = false;
            cmbTimeSlot.Enabled = true;
            dtpDate.Value = DateTime.Today; // Resets calendar selection to today
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.ForeColor = Color.White;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btCancel.ForeColor = Color.Indigo;
        }

        private void btCancel_MouseEnter(object sender, EventArgs e)
        {
            btCancel.ForeColor = Color.White;
        }

        private void btCancel_MouseLeave(object sender, EventArgs e)
        {
            btCancel.ForeColor = Color.DimGray;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadOverrideTimeSlots();
        }

        private void cmbDentist_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOverrideTimeSlots();
        }

        private void dtpSearchDate_ValueChanged(object sender, EventArgs e)
        {
            PerformDynamicSearch();
        }

        private void cmbSearchDentist_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformDynamicSearch();
        }

        private void dtpSearchDate_MouseDown(object sender, MouseEventArgs e)
        {
            PerformDynamicSearch();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Temporarily pause automatic searching while we wipe the inputs
            isInitializing = true;

            cmbSearchDentist.SelectedIndex = -1;
            dtpSearchDate.Checked = false;
            dtpSearchDate.Value = DateTime.Today;

            isInitializing = false;

            // Re-run the search now that all inputs are completely cleared out
            PerformDynamicSearch();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure the grid has a valid selected row and that the index isn't out of bounds
            if (dgvOverrides.CurrentRow == null || dgvOverrides.CurrentRow.Index < 0 || dgvOverrides.CurrentRow.Cells[0].Value == DBNull.Value)
            {
                MessageBox.Show("Please select a valid record from the list.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Extract ID from the selected row
            selectedOverrideId = Convert.ToInt32(dgvOverrides.CurrentRow.Cells["Override_ID"].Value);

            //autofill info
            dtpDate.Value = Convert.ToDateTime(dgvOverrides.CurrentRow.Cells["Target_Date"].Value);
            cmbDentist.SelectedValue = dgvOverrides.CurrentRow.Cells["Employee_ID"].Value;

            // Handle the full day checkbox conversion safely
            string isFullDayStr = dgvOverrides.CurrentRow.Cells["Is_Full_Day"].Value.ToString();
            chkFullDay.Checked = (isFullDayStr == "Y" || isFullDayStr == "True");

            // Handle timeslot selection if it isn't a full-day block
            if (!chkFullDay.Checked && dgvOverrides.CurrentRow.Cells["Timeslot_ID"].Value != DBNull.Value)
            {
                LoadOverrideTimeSlots();
                cmbTimeSlot.SelectedValue = dgvOverrides.CurrentRow.Cells["Timeslot_ID"].Value;
            }
            else
            {
                cmbTimeSlot.SelectedIndex = -1;
            }

            // Fill in the reason fields
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

            // 3. Open the entry form panel
            ShowPanel(pnlForm);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Ensure a row is selected
            if (dgvOverrides.CurrentRow == null || dgvOverrides.CurrentRow.Cells["Override_ID"].Value == DBNull.Value)
            {
                MessageBox.Show("Please select an availability override record from the table list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask the user for deletion confirmation
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to permanently delete this availability override rule?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int targetId = Convert.ToInt32(dgvOverrides.CurrentRow.Cells["Override_ID"].Value);

                    // Execute the delete query
                    this.availability_OverrideTableAdapter.DeleteOverride(targetId);

                    MessageBox.Show("The availability override record has been successfully deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the grid contents immediately
                    this.availability_OverrideTableAdapter.FillBy(this.dsDentist.Availability_Override);
                    dgvOverrides.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database deletion failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
    }
}