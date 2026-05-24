using Dental_Practice_Management_System.dsDentistTableAdapters;
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
    public partial class TreatmentMedicine : Form
    {
        private bool isMedicineLoading = false; // Flag to prevent event firing during loading
        private DataTable medicineData; // Store medicine data for easy access
        private dsDentistTableAdapters.MedicineTableAdapter medicineTableAdapter = new dsDentistTableAdapters.MedicineTableAdapter();
        private bool isDiagnosisLoading = false; // Flag to prevent event firing during loading
        private DataTable diagnosisData; // Store diagnosis data for easy access
        public TreatmentMedicine()
        {
            InitializeComponent();
            HideAllPanels();
        }
        private void HideAllPanels()
        {
            pnlPatientDetails.Visible = false;
            pnlAddTreatment.Visible = false;
            pnlPrescribeMedication.Visible = false;
            pnlTreatmentHistory.Visible = false;
            pnlAddDiagnosis.Visible = false;
        }

        private void btnAddTreatment_Click(object sender, EventArgs e)
        {
            if(cmbAppointment.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment before adding treatment details.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HideAllPanels();
            pnlAddTreatment.Visible = true;

        }

        private DataTable treatmentData;
        private void TreatmentMedicine_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsDentist.vw_PatientAppointmentDetails' table. You can move, or remove it, as needed.
            this.vw_PatientAppointmentDetailsTableAdapter.Fill(this.dsDentist.vw_PatientAppointmentDetails);
            // TODO: This line of code loads data into the 'dsDentist1.PatientTreatment' table. You can move, or remove it, as needed.
            this.patientTreatmentTableAdapter.Fill(this.dsDentist1.PatientTreatment);
            // TODO: This line of code loads data into the 'dsDentist1.Treatment' table. You can move, or remove it, as needed.
            this.treatmentTableAdapter.Fill(this.dsDentist1.Treatment);
            this.vw_PatientAppointmentDetailsTableAdapter.Fill(this.dsDentist.vw_PatientAppointmentDetails);
           // this.medicineTableAdapter.Fill(this.dsDentist1.Medicine);

            //LoadAppointments();
            LoadTreatments();

            HideAllPanels();
            pnlPatientDetails.Visible = true;
             //pnlAddTreatment.Visible = false;
             LoadMedicines();



        }
        private void LoadMedicines()
        {
            try
            {
                isMedicineLoading = true; // Set flag to prevent event firing
                medicineData = medicineTableAdapter.GetData();
                cmbMedicine.DataSource = null;
                cmbMedicine.Items.Clear();
                cmbMedicine.DataSource = medicineData;
                cmbMedicine.DisplayMember = "MedicineName";
                cmbMedicine.ValueMember = "MedicineID";
                cmbMedicine.SelectedIndex = -1; // No selection by default
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading medicines: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isMedicineLoading = false; // Reset flag after loading
            }
        }
        private void LoadTreatments()
        {
            try
            {

            
            treatmentData = treatmentTableAdapter.GetData();
            cmbTreatment.DataSource = treatmentData;
            cmbTreatment.DisplayMember = "TreatmentName";
            cmbTreatment.ValueMember = "TreatmentID";
            cmbTreatment.SelectedIndex = -1;
        }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading treatments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cmbAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedItem != null)
            {
                // Get the selected appointment's ID
                int selectedAppointmentId = (int)cmbAppointment.SelectedValue;
                
                DataRowView row = (DataRowView)cmbAppointment.SelectedItem;
                // Populate patient details based on the selected appointment
                txtPatientName.Text = row["Patient_First_Name"].ToString();
                txtPatientID.Text = row["Patient_ID"].ToString();
                txtAppointmentID.Text = row["Appointment_ID"].ToString();
                //txtFollowUpDate.Text = row["Appointment_Date"].ToString();
                txtStatus.Text = row["Appointment_Status"].ToString();
                txtPresciptionAllergies.Text = row["Patient_Allergies"].ToString();

                if (DateTime.TryParse(row["Appointment_Date"].ToString(), out DateTime appointmentDate))
                {
                    txtFollowUpDate.Text = appointmentDate.ToShortDateString();
                }
                else
                {
                    txtFollowUpDate.Text = "N/A";
                }

                if (!string.IsNullOrEmpty(txtPresciptionAllergies.Text))
                {
                    MessageBox.Show("Patient has allergies: " + txtPresciptionAllergies.Text, "Allergy Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmbTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTreatment.SelectedIndex == -1) return;
            if (cmbTreatment.SelectedItem == null) return;
            if (cmbTreatment.SelectedIndex == -1) return;

            try
            {
                int selectedIndex = cmbTreatment.SelectedIndex;
                DataRow row = treatmentData.Rows[selectedIndex];
                if (row == null) return;
                txtCost.Text = "R " + row["TreatmentCost"].ToString();
                txtDuration.Text = row["TreatmentDuration"].ToString() + " mins";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading treatment details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isMedicineLoading) return; // Prevent event from firing during loading
            if(cmbMedicine.SelectedIndex == -1) return; // No selection
            if(cmbMedicine.SelectedItem == null) return; // Safety check
            try
            {
                DataRow row = medicineData.Rows[cmbMedicine.SelectedIndex];
                txtCodeMedicine.Text= row["MedicineCode"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading medicine details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveTreatment_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedIndex == -1 || cmbTreatment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both an appointment and a treatment before saving.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DataTable dt = patientTreatmentTableAdapter.GetData();
                DataRow[] rows = dt.Select("Appointment_ID = " + cmbAppointment.SelectedValue.ToString());
                if (rows.Length == 0)
                {
                    MessageBox.Show("No treatment record found for the selected appointment. Please add treatment details first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving treatment details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(!string.IsNullOrEmpty(txtPresciptionAllergies.Text))
            {
                txtPresciptionAllergies.Text = "Allergies: " + txtPresciptionAllergies.Text;
            }
            else
            {
                txtPresciptionAllergies.Text = "No known allergies";

            }
            HideAllPanels();
            pnlPrescribeMedication.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTreatmentDetails();
        }
        private void ClearTreatmentDetails()
        {
           
            cmbTreatment.SelectedIndex = -1;
           
            
            txtStatus.Clear();
            txtCost.Clear();
            txtDuration.Clear();
      
            txtTreatmentNotes.Clear();
        }

        private void btnPrescribeMedication_Click(object sender, EventArgs e)
        {
            pnlPrescribeMedication.Visible = true;
            pnlAddDiagnosis.Visible = false;
            pnlAddTreatment.Visible = false;
            pnlPatientDetails.Visible = false;
            pnlTreatmentHistory.Visible = false;

        }

        private void btnTreatmentHistory_Click(object sender, EventArgs e)
        {
            pnlTreatmentHistory.Visible = true;
        }

        private void btnAddDiagnosis_Click(object sender, EventArgs e)
        {
            if(cmbAppointment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an appointment before adding a diagnosis.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CopyAppointmentToDiagnosisPanel();
                         HideAllPanels();

            pnlAddDiagnosis.Visible = true;
        }
        private void CopyAppointmentToDiagnosisPanel()
        {
            txtPatientNameDiag.Text = txtPatientName.Text;
            txtPatientIDDiag.Text = txtPatientID.Text;
            txtAppointmentDateDiag.Text = txtFollowUpDate.Text;
            cmbAppointmentDiagnosis.Text = cmbAppointment.Text; // Assuming you want to copy the appointment details to the diagnosis panel's ComboBox for selection

        }
        private void LoadTreatmentHistory()
        {
            try
            {
                DataTable dt = patientTreatmentTableAdapter.GetData();
                dgvTreatmentHistory.DataSource = dt;
                lblRecordCount.Text = "Total Records: " + dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading treatment history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           if (string.IsNullOrEmpty(txtSearchPatient.Text))
            {
                LoadTreatmentHistory(); // Load all records if search box is empty
                return;
            }
            DataTable dt = patientTreatmentTableAdapter.GetData();
            if (!dt.Columns.Contains("PatientName"))
                dt.Columns.Add("PatientName", typeof(string));

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearchPatient.Clear();
                LoadTreatmentHistory(); // Reload all records after clearing search
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private PrescriptionTableAdapter prescriptionTableAdapter = new PrescriptionTableAdapter();

        private void btnSavePrescription_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedItem == null || cmbMedicine.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment and medicine before saving the prescription.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMedicine.SelectedItem != null)
            {
                // Get the selected medicine ID
                int selectedMedicineId = (int)cmbMedicine.SelectedValue;
                // Here you would typically save the prescription details to the database
                // For example, you might call a method like SavePrescriptionDetails(selectedMedicineId);
                MessageBox.Show("Prescription details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                DataTable dt = patientTreatmentTableAdapter.GetData();
                DataRow[] rows = dt.Select("AppointmentID = " + cmbAppointment.SelectedValue);
                if (rows.Length == 0)
                {
                    MessageBox.Show("No treatment record found for the selected appointment. Please save treatment details first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int patientTreatmentId = Convert.ToInt32(rows[0]["PatientTreatment_ID"]);
                prescriptionTableAdapter.InsertPrescription(
                    patientTreatmentId,
                    Convert.ToInt32(cmbMedicine.SelectedValue),
                    txtQuantity.Text.Trim(),
                    txtDosage.Text.Trim(), // Dosage_Instructions
                    DateTime.Now // Date_Issued (or use a value from a control if available)
                );
                MessageBox.Show("Prescription details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving prescription details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearPrescription_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the prescription details?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmbMedicine.SelectedIndex = -1;
                txtQuantity.Clear();
                txtDosage.Clear();
            }
        }

        private void cmbAppointmentDiagnosis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isDiagnosisLoading) return; // Prevent event from firing during loading
            if(cmbAppointmentDiagnosis.SelectedItem == null) return; // No selection
            if(cmbAppointmentDiagnosis.SelectedIndex == -1) return; // No selection
            try
            {
                DataRowView row = (DataRowView)cmbAppointmentDiagnosis.SelectedItem;
                txtPatientNameDiag.Text = row["PatientFullName"].ToString();
                txtPatientIDDiag.Text = row["Patient_ID"].ToString();
                txtAppointmentDateDiag.Text = row["Appointment_Follow_Up_Date"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading diagnosis details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private void btnSaveDiagnosis_Click(object sender, EventArgs e)
        {
            try
            {
                patientTreatmentTableAdapter.InsertDiagnosis(
                    Convert.ToInt32(cmbAppointmentDiagnosis.SelectedValue), // Appointment_ID
                    0,
                    cmbDiagnosis.Text, // Diagnosis_Code
                    txtDiagnosisNotes.Text.Trim(), // Diagnosis_Notes
                    " ",
                    DateTime.Now // Diagnosis_Date (or use a value from a control if available)
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving diagnosis details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
    }
