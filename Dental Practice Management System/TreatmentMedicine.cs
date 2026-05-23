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
        public TreatmentMedicine()
        {
            InitializeComponent();
            pnlPatientDetails.Visible = true;
            pnlAddTreatment.Visible = false;
            pnlPrescribeMedication.Visible = false;
            pnlTreatmentHistory.Visible = false;
            pnlAddDiagnosis.Visible = false;
        }

        private void btnAddTreatment_Click(object sender, EventArgs e)
        {
            pnlAddTreatment.Visible = true;

        }

        private void TreatmentMedicine_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsDentist1.PatientTreatment' table. You can move, or remove it, as needed.
            this.patientTreatmentTableAdapter.Fill(this.dsDentist1.PatientTreatment);
            // TODO: This line of code loads data into the 'dsDentist1.Treatment' table. You can move, or remove it, as needed.
            this.treatmentTableAdapter.Fill(this.dsDentist1.Treatment);
            // TODO: This line of code loads data into the 'dsDentist.AppointmentView' table. You can move, or remove it, as needed.
            this.appointmentViewTableAdapter.Fill(this.dsDentist.AppointmentView);

            

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
                //txtPatientID.Text = row["PatientID"].ToString();
                txtAppointmentID.Text = row["Appointment_ID"].ToString();
                txtFollowUpDate.Text = row["Appointment_Date"].ToString();
                txtStatus.Text = row["Appointment_Status"].ToString();
                //txtAllergies.Text = row["Allergies"].ToString();

                //if(!string.IsNullOrEmpty(txtAllergies.Text))
                //{
                 //   MessageBox.Show("Patient has allergies: " + txtAllergies.Text, "Allergy Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // }
            }
        }

        private void cmbTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTreatment.SelectedItem != null)
            {
                // Get the selected treatment's ID
                int selectedTreatmentId = (int)cmbTreatment.SelectedValue;
                DataRowView row = (DataRowView)cmbTreatment.SelectedItem;
                // Populate treatment details based on the selected treatment
               // txtTreatmentID.Text = row["Treatment_ID"].ToString();
               // txtTreatmentDescription.Text = row["Treatment_Description"].ToString();
                txtCost.Text = row["TreatmentCost"].ToString();
                txtDuration.Text = row["TreatmentDuration"].ToString();
            }
        }

        private void cmbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMedicine.SelectedItem != null)
            {
                // Get the selected medicine's ID
                int selectedMedicineId = (int)cmbMedicine.SelectedValue;
                DataRowView row = (DataRowView)cmbMedicine.SelectedItem;
                // Populate medicine details based on the selected medicine
               // txtMedicineID.Text = row["Medicine_ID"].ToString();
               // txtMedicineName.Text = row["Medicine_Name"].ToString();
                txtCode.Text = row["MedicineCode"].ToString();
                //txtFrequency.Text = row["Frequency"].ToString();
            }
        }

        private void btnSaveTreatment_Click(object sender, EventArgs e)
        {
            if (cmbAppointment.SelectedItem == null || cmbTreatment.SelectedItem == null || cmbMedicine.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment, treatment, and medicine before saving.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTreatment.SelectedItem != null && cmbMedicine.SelectedItem != null)
            {
                // Get the selected treatment and medicine IDs
                int selectedTreatmentId = (int)cmbTreatment.SelectedValue;
                int selectedMedicineId = (int)cmbMedicine.SelectedValue;
                // Here you would typically save the treatment and medicine details to the database
                // For example, you might call a method like SaveTreatmentDetails(selectedTreatmentId, selectedMedicineId);
                MessageBox.Show("Treatment and medicine details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                patientTreatmentTableAdapter.InsertQuery(
                    Convert.ToInt32(cmbAppointment.SelectedValue),
                    Convert.ToInt32(cmbTreatment.SelectedValue),
                    cmbDiagnosis.Text, // Diagnosis
                    " ", // Diagnosis_Notes (empty or provide a value if available)
                    txtTreatmentNotes.Text, // Treatment_Notes
                    DateTime.Now // Date_Recorded (or use a value from a control if available)
                    
                );
                MessageBox.Show("Treatment details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving treatment details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            pnlAddDiagnosis.Visible = true;
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
            DataView dv = dt.DefaultView;
            dv.RowFilter= "PatientName LIKE '%" + txtSearchPatient.Text + "%'";
            dgvTreatmentHistory.DataSource = dv.ToTable();
             lblRecordCount.Text = "Total Records: " + dv.Count.ToString();
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
                int patientTreatmentId = Convert.ToInt32(rows[0]["PatientTreatmentID"]);
                prescriptionTableAdapter.InsertPrescription(
                    patientTreatmentId,
                    Convert.ToInt32(cmbMedicine.SelectedValue),
                    txtQuantity.Text,
                    txtDosage.Text, // Dosage_Instructions
                    DateTime.Now // Date_Issued (or use a value from a control if available)
                );
                MessageBox.Show("Prescription details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving prescription details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
