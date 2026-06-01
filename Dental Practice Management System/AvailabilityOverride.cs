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
            InitializeSearchControls();
        }

        private void ShowPanel(Panel panelToShow)
        {
            panelToShow.BringToFront();

            
            bool shouldShowButton = (panelToShow == pnlDisplay);

            btAddNew.Visible = shouldShowButton;
            btAddNew.Enabled = shouldShowButton;


                panelToShow.Visible = true;

            panelToShow.Refresh();
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

            ShowPanel(pnlDisplay);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validation

            // Check valid date
            if (dtpDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("The selected date cannot be in the past. Please choose a current or future date.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDate.Focus();
                return;
            }

            // Check if a dentist is selected
            if (cmbDentist.SelectedIndex == -1 || cmbDentist.SelectedValue == null)
            {
                MessageBox.Show("Please select a dentist from the drop-down list before saving.", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDentist.Focus();
                return;
            }

            // Check if a time slot is selected (ONLY if "Full Day" is NOT checked)
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

            // Capture the override reason
            string finalReason = "";
            if (cmbReason.SelectedItem != null)
            {
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

            }

            //insert override
            try
            {
                string targetDateStr = dtpDate.Value.ToString("yyyy-MM-dd");
                bool isFullDayBool = chkFullDay.Checked;
                int employeeId = Convert.ToInt32(cmbDentist.SelectedValue);

                int? timeslotId = null;
                if (!chkFullDay.Checked)
                {
                    timeslotId = Convert.ToInt32(cmbTimeSlot.SelectedValue);
                }

                // Determine whether to run an INSERT or an UPDATE operation
                if (selectedOverrideId == -1)
                {
                    //insert
                    this.availability_OverrideTableAdapter.InsertOverride(targetDateStr, timeslotId, isFullDayBool, finalReason, employeeId);
                    MessageBox.Show("The availability override has been successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //update
                    this.availability_OverrideTableAdapter.UpdateOverride(targetDateStr, timeslotId, isFullDayBool, finalReason, employeeId, selectedOverrideId);
                    MessageBox.Show("The availability override has been successfully updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Pull fresh records and sync the UI grid container
                this.availability_OverrideTableAdapter.FillBy(this.dsDentist.Availability_Override);
                dgvOverrides.Refresh();

                ClearFormInputs();
                ShowPanel(pnlDisplay);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database save operation failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
