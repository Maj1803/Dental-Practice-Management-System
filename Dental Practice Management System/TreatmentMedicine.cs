using Dental_Practice_Management_System.dsDentistTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
        private string savedDiagnosisCode = "";
        private string savedDiagnosisNotes = "";

        public TreatmentMedicine()
        {
            InitializeComponent();
            HideAllPanels();
        }
        private void HideAllPanels()
        {
            //pnlPatientDetails.Visible = false;
            pnlAddTreatment.Visible = false;
            pnlPrescribeMedication.Visible = false;
            pnlTreatmentHistory.Visible = false;
            pnlAddDiagnosis.Visible = false;
        }

        private void btnAddTreatment_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment before adding treatment details.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HideAllPanels();
            pnlPatientDetails.Visible = true;
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
             this.medicineTableAdapter.Fill(this.dsDentist1.Medicine);
            cmbAppointment.SelectedIndexChanged -= cmbAppointment_SelectedIndexChanged;
            //cmbAppointment.SelectedIndex = -1;
            DataView appointmentView = new DataView(dsDentist.vw_PatientAppointmentDetails);
            appointmentView.RowFilter = "Appointment_Status <> 'Cancelled'";
            appointmentView.Sort = "Appointment_ID DESC";
            cmbAppointment.DataSource = appointmentView;


            cmbAppointment.SelectedIndex = -1;//no selection by default
                                              //cmbAppointment.SelectedIndexChanged -= cmbAppointment_SelectedIndexChanged;
                                              //this.patientTreatmentTableAdapter.Fill(this.dsDentist1.PatientTreatment);
                                              // this.treatmentTableAdapter.Fill(this.dsDentist1.Treatment);
                                              //cmbAppointment.SelectedIndex = -1;//no selection by default
            cmbAppointment.SelectedIndexChanged += cmbAppointment_SelectedIndexChanged;
            //LoadAppointments();
            LoadTreatments();

            HideAllPanels();
            pnlPatientDetails.Visible = true;
            //pnlAddTreatment.Visible = false;
            LoadMedicines();
            cmbMedicine.SelectedIndexChanged += new EventHandler(cmbMedicine_SelectedIndexChanged);

            


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
            if (cmbAppointment.SelectedIndex == -1 || cmbAppointment.SelectedItem == null)
            {
                return;
            }
            {
                // Get the selected appointment's ID
                int selectedAppointmentId = (int)cmbAppointment.SelectedValue;

                DataRowView row = (DataRowView)cmbAppointment.SelectedItem;
                // Populate patient details based on the selected appointment
                txtPatientName.Text = row["PatientFullName"].ToString();
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
                    lblAllergyWarning.Text = "Patient has allergies: " + txtPresciptionAllergies.Text;
                    lblAllergyWarning.Visible = true;
                    // MessageBox.Show("Patient has allergies: " + txtPresciptionAllergies.Text, "Allergy Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblAllergyWarning.Visible = false;
                }
                workflow("AppointmentSelected");
            }
        }

        private void cmbTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTreatment.SelectedIndex == -1 || cmbTreatment.SelectedItem == null)
            {
                txtCost.Visible = false;
                txtDuration.Visible = false;
                return;
            }
            txtCost.Visible = true;
            txtDuration.Visible = true;


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
            if (isMedicineLoading) return; // Prevent event from firing during loading
            if (cmbMedicine.SelectedIndex == -1 || cmbMedicine.SelectedItem == null)
            {
                txtCodeMedicine.Clear();
                return;
            }
            

            try
            {
                DataRowView selectedRow = (DataRowView)cmbMedicine.SelectedItem;
                
                txtCodeMedicine.Text = selectedRow["MedicineCode"].ToString();
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
                // DataTable dt = patientTreatmentTableAdapter.GetData();
                // DataRow[] rows = dt.Select("Appointment_ID = " + cmbAppointment.SelectedValue.ToString());
                int appointmentId = Convert.ToInt32(cmbAppointment.SelectedValue);
                int treatmentId = Convert.ToInt32(cmbTreatment.SelectedValue);
                string treatmentNotes = txtTreatmentNotes.Text.Trim();

                patientTreatmentTableAdapter.InsertDiagnosis(
                    appointmentId,       // @Appointment_ID
                    treatmentId,         // @TreatmentID
                    savedDiagnosisCode,  // @Diagnosis
                       savedDiagnosisNotes, // @Diagnosis_Notes
                        treatmentNotes,      // @Treatment_Notes
                           DateTime.Now);       // @Date_Recorded
        
                //Convert.ToInt32(cmbAppointment.SelectedValue), // Appointment_ID
                //Convert.ToInt32(cmbTreatment.SelectedValue), // Treatment_ID
                //txtTreatmentNotes.Text.Trim(), // Treatment_Notes
                //DateTime.Now // Treatment_Date (or use a value from a control if available)
                // );
                MessageBox.Show("Treatment details saved successfully! Moving to Prescription.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                workflow("TreatmentSaved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving treatment details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadTreatmentHistory();
            
           // HideAllPanels();
           // pnlPrescribeMedication.Visible = true;
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
            if(cmbAppointment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an appointment before prescribing medication.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CopyPatientToPrescriptionPanel();
            HideAllPanels();
            pnlPatientDetails.Visible = true;
            pnlPrescribeMedication.Visible = true;
            
            
           

        }

        private void btnTreatmentHistory_Click(object sender, EventArgs e)
        {
            HideAllPanels();

            pnlTreatmentHistory.Visible = true;
            LoadTreatmentHistory();
        }

        private void btnAddDiagnosis_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an appointment before adding a diagnosis.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CopyAppointmentToDiagnosisPanel();
            HideAllPanels();
            pnlPatientDetails.Visible = true;
            pnlAddDiagnosis.Visible = true;
        }
        private void CopyAppointmentToDiagnosisPanel()
        {
            txtPatientNameDiag.Text = txtPatientName.Text;
            txtPatientIDDiag.Text = txtPatientID.Text;
            txtAppointmentDateDiag.Text = txtFollowUpDate.Text;
            txtAppointmentDiagnosisID.Text = txtAppointmentID.Text; // Assuming you want to copy the appointment details to the diagnosis panel's ComboBox for selection

        }
        private void LoadTreatmentHistory()
        {
            try
            {
                DataTable dt;
                if (cmbAppointment.SelectedValue != null)
                {
                    int currentAppointmentId = Convert.ToInt32(cmbAppointment.SelectedValue);
                    dt = patientTreatmentTableAdapter.GetDataByAppointmentID(currentAppointmentId);
                }
                else
                {
                    dt = patientTreatmentTableAdapter.GetData();
                }
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
            string searchText = txtSearchPatient.Text.Trim();

            if(string.IsNullOrEmpty(searchText))
            {
                LoadTreatmentHistory(); // Load all records if search text is empty
                return;
            }
            try
            {
                DataTable filteredData = patientTreatmentTableAdapter.GetDataByPatientName(searchText);
                dgvTreatmentHistory.DataSource= filteredData;
                lblRecordCount.Text = "Total Records: " + filteredData.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching treatment history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            txtSearchPatient.Clear();
            LoadTreatmentHistory(); // Reload all records after clearing search
            txtSearchPatient.Focus();
        }
        catch (Exception ex)
            {
                MessageBox.Show("Error clearing search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlPatientDetails.Visible = true;
                
        }

        private PrescriptionTableAdapter prescriptionTableAdapter = new PrescriptionTableAdapter();

        private void btnSavePrescription_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedItem == null || cmbMedicine.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment and medicine before saving the prescription.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                DataTable dt = patientTreatmentTableAdapter.GetData();
                DataRow[] rows = dt.Select("Appointment_ID = " + cmbAppointment.SelectedValue.ToString());
                if (rows.Length == 0)
                {
                    DialogResult goToTreatment = MessageBox.Show(
                    "No treatment record found for this appointment.\n\nYou must save a treatment before prescribing medication.\n\nWould you like to go to Add Treatment now?","Treatment Required",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (goToTreatment == DialogResult.Yes)
                    {
                        HideAllPanels();
                        pnlPatientDetails.Visible = true;
                        pnlAddTreatment.Visible = true;
                    }


                    //MessageBox.Show("No treatment record found for the selected appointment. Please save treatment details first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int patientTreatmentId = Convert.ToInt32(rows[0]["PatientTreatment_ID"]);
                prescriptionTableAdapter.InsertPrescription(
                    patientTreatmentId,
                    Convert.ToInt32(cmbMedicine.SelectedValue),
                    txtQuantity.Text.Trim(),
                    txtDosage.Text.Trim(), // Dosage_Instructions
                    DateTime.Now // Date_Issued 
                );
                MessageBox.Show("Prescription details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult printQuery = MessageBox.Show("Would you like to print this prescription now?", "Print Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (printQuery == DialogResult.Yes)
                {
                    
                    btnPrintPrescription_Click(this, EventArgs.Empty);
                }
                cmbMedicine.SelectedIndex = -1;
                txtQuantity.Clear();
                txtDosage.Clear();
                txtCodeMedicine.Clear();
                LoadTreatmentHistory(); // Refresh treatment history to show new prescription details
                workflow("Complete");
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

        

        private void btnSaveDiagnosis_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedIndex == -1 || string.IsNullOrEmpty(txtAppointmentDiagnosisID.Text))
            {
                MessageBox.Show("Please select an appointment before saving the diagnosis details.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(cmbDiagnosis.Text))
            {
                MessageBox.Show("Please enter a diagnosis code before saving.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           /* try
            {
                int appointmentId = Convert.ToInt32(cmbAppointment.SelectedValue);
                //int patientId = Convert.ToInt32(txtPatientIDDiag.Text);

                patientTreatmentTableAdapter.InsertDiagnosis(appointmentId, // Appointment_ID
                    null,
                    cmbDiagnosis.Text, // Diagnosis_Code
                    txtDiagnosisNotes.Text.Trim(), // Diagnosis_Notes
                    null,
                    DateTime.Now // Diagnosis_Date (or use a value from a control if available)
               */ //);
            savedDiagnosisCode = cmbDiagnosis.Text;
            savedDiagnosisNotes = txtDiagnosisNotes.Text.Trim();
            MessageBox.Show("Diagnosis details saved successfully! Moving to Treatment Details.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiagnosisNotes.Clear();
                cmbDiagnosis.SelectedIndex = -1;
                workflow("DiagnosisSaved");
           // }
            //catch (Exception ex)
            //{
              //  MessageBox.Show("Error saving diagnosis details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the diagnosis details?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClearDiagnosisDetails();
            }

        }
        private void ClearDiagnosisDetails()
        {
           // txtAppointmentDiagnosisID.Clear();
            cmbDiagnosis.Text = string.Empty;
            cmbDiagnosis.SelectedIndex = -1;
            txtDiagnosisNotes.Clear();
            txtPatientNameDiag.Clear();
            txtPatientIDDiag.Clear();
            txtAppointmentDateDiag.Clear();
            CopyAppointmentToDiagnosisPanel();
        }
        private void CopyPatientToPrescriptionPanel()
        {
            if(cmbAppointment.SelectedItem != null)
            {
                DataRowView row = (DataRowView)cmbAppointment.SelectedItem;
                string allergies = row["Patient_Allergies"].ToString();
                if(!string.IsNullOrEmpty(allergies))
                {
                    txtPresciptionAllergies.Text = "Allergies: " + allergies;
                }
                else
                {
                    txtPresciptionAllergies.Text = "No known allergies";
                }
            }
        }

        private void pnlTreatmentHistory_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrintPrescription_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedIndex == -1 || cmbAppointment.SelectedValue == null)
            {
                MessageBox.Show("Please select an active appointment to print its prescription.",
                                "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMedicine.SelectedIndex == -1 || cmbMedicine.SelectedValue == null)
            {
                MessageBox.Show("Please select a medicine before printing the prescription.",
                                "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMedicine.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please enter a quantity before printing.",
                                "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }
            else if (!int.TryParse(txtQuantity.Text.Trim(), out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid numeric number for the quantity (e.g., 1, 2, 10).",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.SelectAll();
                txtQuantity.Focus();
                return;
            }

            try
            {
                
                int activeAppointmentId = Convert.ToInt32(cmbAppointment.SelectedValue);
               

                
                dsDentist reportingDataSet = new dsDentist();
                var apptViewAdapter = new dsDentistTableAdapters.vw_PatientAppointmentDetailsTableAdapter();
                var treatmentAdapter = new dsDentistTableAdapters.PatientTreatmentTableAdapter();
                var prescriptionAdapter = new dsDentistTableAdapters.PrescriptionTableAdapter();
                var medicineAdapter = new dsDentistTableAdapters.MedicineTableAdapter();

                
                apptViewAdapter.Fill(reportingDataSet.vw_PatientAppointmentDetails);
                treatmentAdapter.Fill(reportingDataSet.PatientTreatment);
                prescriptionAdapter.Fill(reportingDataSet.Prescription);
                medicineAdapter.Fill(reportingDataSet.Medicine);

                
                rptPrescription reportInstance = new rptPrescription();

                
                reportInstance.SetDataSource(reportingDataSet);


                string crystalSelectionFormula = string.Format("{{PatientTreatment.Appointment_ID}} = {0}", activeAppointmentId);
                reportInstance.RecordSelectionFormula = crystalSelectionFormula;
        
        

                
                PrescriptionReportView viewerForm = new PrescriptionReportView();

                
                viewerForm.crystalReportViewerPrescription.ReportSource = reportInstance;
                //viewerForm.crystalReportViewerPrescription.SelectionFormula = crystalSelectionFormula;

                
                viewerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while generating the prescription printout: " + ex.Message,
                                "Reporting System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void workflow(string step)
        {
            HideAllPanels();
            pnlPatientDetails.Visible = true;

            btnAddDiagnosis.Enabled = false;
            btnAddTreatment.Enabled = false;
            btnPrescribeMedication.Enabled = false;
            btnTreatmentHistory.Enabled = false;

            switch (step)
            {
                case "AppointmentSelected":
                    btnAddDiagnosis.Enabled = true;
                    pnlAddDiagnosis.Visible = true;
                    CopyAppointmentToDiagnosisPanel();
                    break;
                case "DiagnosisSaved":
                    btnAddDiagnosis.Enabled = true;
                    pnlAddTreatment.Visible = true;
                    break;
                case "TreatmentSaved":
                    btnAddDiagnosis.Enabled = true;
                    btnAddTreatment.Enabled = true;
                    btnPrescribeMedication.Enabled = true;
                    pnlPrescribeMedication.Visible = true;
                    CopyPatientToPrescriptionPanel();
                    break;
                case "Complete":
                    btnAddDiagnosis.Enabled = true;
                    btnAddTreatment.Enabled = true;
                    btnPrescribeMedication.Enabled = true;
                    btnTreatmentHistory.Enabled = true;
                    pnlTreatmentHistory.Visible = true;
                    LoadTreatmentHistory();
                    break;

            }
        }

        private void btnSkipPrescription_Click(object sender, EventArgs e)
        {
            cmbMedicine.SelectedIndex = -1;
            txtQuantity.Clear();
            txtDosage.Clear();
            txtCodeMedicine.Clear();

            // Move straight to the final history step
            MessageBox.Show("Consultation session completed. Loading treatment history.",
                            "Session Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            workflow("Complete");
        }
    }
    }
