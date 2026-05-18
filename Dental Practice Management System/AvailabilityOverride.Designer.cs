namespace Dental_Practice_Management_System
{
    partial class AvailabilityOverride
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkFullDay = new System.Windows.Forms.CheckBox();
            this.cmbDentist = new System.Windows.Forms.ComboBox();
            this.cmbTimeSlot = new System.Windows.Forms.ComboBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvOverrides = new System.Windows.Forms.DataGridView();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.gbTimeBlock = new System.Windows.Forms.GroupBox();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.lblTimeSlot = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDentist = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblOther = new System.Windows.Forms.Label();
            this.btnAppointmentFrm = new System.Windows.Forms.Button();
            this.btnPatientsFrm = new System.Windows.Forms.Button();
            this.btnDashboardFrm = new System.Windows.Forms.Button();
            this.btnTreatmentMedicineFrm = new System.Windows.Forms.Button();
            this.btnBillingFrm = new System.Windows.Forms.Button();
            this.btnReportsFrm = new System.Windows.Forms.Button();
            this.btnStaffFrm = new System.Windows.Forms.Button();
            this.btnLogInFrm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverrides)).BeginInit();
            this.gbTimeBlock.SuspendLayout();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(99, 40);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(199, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // chkFullDay
            // 
            this.chkFullDay.AutoSize = true;
            this.chkFullDay.Location = new System.Drawing.Point(6, 19);
            this.chkFullDay.Name = "chkFullDay";
            this.chkFullDay.Size = new System.Drawing.Size(64, 17);
            this.chkFullDay.TabIndex = 2;
            this.chkFullDay.Text = "Full Day";
            this.chkFullDay.UseVisualStyleBackColor = true;
            this.chkFullDay.CheckedChanged += new System.EventHandler(this.chkFullDay_CheckedChanged);
            // 
            // cmbDentist
            // 
            this.cmbDentist.FormattingEnabled = true;
            this.cmbDentist.Location = new System.Drawing.Point(99, 30);
            this.cmbDentist.Name = "cmbDentist";
            this.cmbDentist.Size = new System.Drawing.Size(199, 21);
            this.cmbDentist.TabIndex = 3;
            // 
            // cmbTimeSlot
            // 
            this.cmbTimeSlot.FormattingEnabled = true;
            this.cmbTimeSlot.Location = new System.Drawing.Point(99, 73);
            this.cmbTimeSlot.Name = "cmbTimeSlot";
            this.cmbTimeSlot.Size = new System.Drawing.Size(199, 21);
            this.cmbTimeSlot.TabIndex = 4;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(99, 93);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(199, 20);
            this.txtReason.TabIndex = 5;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Thistle;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(201, 427);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // dgvOverrides
            // 
            this.dgvOverrides.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverrides.Location = new System.Drawing.Point(507, 110);
            this.dgvOverrides.Name = "dgvOverrides";
            this.dgvOverrides.Size = new System.Drawing.Size(364, 345);
            this.dgvOverrides.TabIndex = 7;
            // 
            // cmbReason
            // 
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Items.AddRange(new object[] {
            "Public Holiday",
            "Leave",
            "Emergency",
            "Other"});
            this.cmbReason.Location = new System.Drawing.Point(99, 61);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(199, 21);
            this.cmbReason.TabIndex = 8;
            this.cmbReason.SelectedIndexChanged += new System.EventHandler(this.cmbReason_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(114, 62);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 24);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Availability Override";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDescription.Location = new System.Drawing.Point(115, 86);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(176, 13);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Manage unavailable times and days";
            // 
            // gbTimeBlock
            // 
            this.gbTimeBlock.BackColor = System.Drawing.SystemColors.Control;
            this.gbTimeBlock.Controls.Add(this.lblDate);
            this.gbTimeBlock.Controls.Add(this.lblTimeSlot);
            this.gbTimeBlock.Controls.Add(this.chkFullDay);
            this.gbTimeBlock.Controls.Add(this.dtpDate);
            this.gbTimeBlock.Controls.Add(this.cmbTimeSlot);
            this.gbTimeBlock.Location = new System.Drawing.Point(118, 120);
            this.gbTimeBlock.Name = "gbTimeBlock";
            this.gbTimeBlock.Size = new System.Drawing.Size(327, 114);
            this.gbTimeBlock.TabIndex = 11;
            this.gbTimeBlock.TabStop = false;
            this.gbTimeBlock.Text = "Time Block";
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.lblOther);
            this.gbDetails.Controls.Add(this.lblReason);
            this.gbDetails.Controls.Add(this.lblDentist);
            this.gbDetails.Controls.Add(this.cmbDentist);
            this.gbDetails.Controls.Add(this.cmbReason);
            this.gbDetails.Controls.Add(this.txtReason);
            this.gbDetails.Location = new System.Drawing.Point(118, 262);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(327, 139);
            this.gbDetails.TabIndex = 12;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Details";
            // 
            // lblTimeSlot
            // 
            this.lblTimeSlot.AutoSize = true;
            this.lblTimeSlot.Location = new System.Drawing.Point(6, 76);
            this.lblTimeSlot.Name = "lblTimeSlot";
            this.lblTimeSlot.Size = new System.Drawing.Size(87, 13);
            this.lblTimeSlot.TabIndex = 5;
            this.lblTimeSlot.Text = "Pick a Time Slot:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 44);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(81, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Choose a Date:";
            // 
            // lblDentist
            // 
            this.lblDentist.AutoSize = true;
            this.lblDentist.Location = new System.Drawing.Point(6, 33);
            this.lblDentist.Name = "lblDentist";
            this.lblDentist.Size = new System.Drawing.Size(82, 13);
            this.lblDentist.TabIndex = 7;
            this.lblDentist.Text = "Choose Dentist:";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(6, 64);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(86, 13);
            this.lblReason.TabIndex = 9;
            this.lblReason.Text = "Choose Reason:";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Location = new System.Drawing.Point(59, 97);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(33, 13);
            this.lblOther.TabIndex = 10;
            this.lblOther.Text = "Other";
            // 
            // btnAppointmentFrm
            // 
            this.btnAppointmentFrm.BackColor = System.Drawing.Color.Transparent;
            this.btnAppointmentFrm.FlatAppearance.BorderSize = 0;
            this.btnAppointmentFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointmentFrm.Location = new System.Drawing.Point(2, 170);
            this.btnAppointmentFrm.Name = "btnAppointmentFrm";
            this.btnAppointmentFrm.Size = new System.Drawing.Size(98, 60);
            this.btnAppointmentFrm.TabIndex = 11;
            this.btnAppointmentFrm.UseVisualStyleBackColor = false;
            this.btnAppointmentFrm.Click += new System.EventHandler(this.btnAppointmentFrm_Click);
            // 
            // btnPatientsFrm
            // 
            this.btnPatientsFrm.BackColor = System.Drawing.Color.Transparent;
            this.btnPatientsFrm.FlatAppearance.BorderSize = 0;
            this.btnPatientsFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientsFrm.Location = new System.Drawing.Point(2, 110);
            this.btnPatientsFrm.Name = "btnPatientsFrm";
            this.btnPatientsFrm.Size = new System.Drawing.Size(98, 54);
            this.btnPatientsFrm.TabIndex = 13;
            this.btnPatientsFrm.UseVisualStyleBackColor = false;
            this.btnPatientsFrm.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // btnDashboardFrm
            // 
            this.btnDashboardFrm.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboardFrm.FlatAppearance.BorderSize = 0;
            this.btnDashboardFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboardFrm.Location = new System.Drawing.Point(2, 48);
            this.btnDashboardFrm.Name = "btnDashboardFrm";
            this.btnDashboardFrm.Size = new System.Drawing.Size(98, 61);
            this.btnDashboardFrm.TabIndex = 14;
            this.btnDashboardFrm.UseVisualStyleBackColor = false;
            this.btnDashboardFrm.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTreatmentMedicineFrm
            // 
            this.btnTreatmentMedicineFrm.BackColor = System.Drawing.Color.Transparent;
            this.btnTreatmentMedicineFrm.FlatAppearance.BorderSize = 0;
            this.btnTreatmentMedicineFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTreatmentMedicineFrm.Location = new System.Drawing.Point(2, 244);
            this.btnTreatmentMedicineFrm.Name = "btnTreatmentMedicineFrm";
            this.btnTreatmentMedicineFrm.Size = new System.Drawing.Size(98, 60);
            this.btnTreatmentMedicineFrm.TabIndex = 15;
            this.btnTreatmentMedicineFrm.UseVisualStyleBackColor = false;
            this.btnTreatmentMedicineFrm.Click += new System.EventHandler(this.btnTreatmentMedicine_Click);
            // 
            // btnBillingFrm
            // 
            this.btnBillingFrm.BackColor = System.Drawing.Color.Transparent;
            this.btnBillingFrm.FlatAppearance.BorderSize = 0;
            this.btnBillingFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillingFrm.Location = new System.Drawing.Point(2, 317);
            this.btnBillingFrm.Name = "btnBillingFrm";
            this.btnBillingFrm.Size = new System.Drawing.Size(98, 60);
            this.btnBillingFrm.TabIndex = 16;
            this.btnBillingFrm.UseVisualStyleBackColor = false;
            this.btnBillingFrm.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnReportsFrm
            // 
            this.btnReportsFrm.BackColor = System.Drawing.Color.Transparent;
            this.btnReportsFrm.FlatAppearance.BorderSize = 0;
            this.btnReportsFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportsFrm.Location = new System.Drawing.Point(2, 383);
            this.btnReportsFrm.Name = "btnReportsFrm";
            this.btnReportsFrm.Size = new System.Drawing.Size(98, 60);
            this.btnReportsFrm.TabIndex = 17;
            this.btnReportsFrm.UseVisualStyleBackColor = false;
            this.btnReportsFrm.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnStaffFrm
            // 
            this.btnStaffFrm.BackColor = System.Drawing.Color.Transparent;
            this.btnStaffFrm.FlatAppearance.BorderSize = 0;
            this.btnStaffFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffFrm.Location = new System.Drawing.Point(2, 449);
            this.btnStaffFrm.Name = "btnStaffFrm";
            this.btnStaffFrm.Size = new System.Drawing.Size(98, 60);
            this.btnStaffFrm.TabIndex = 18;
            this.btnStaffFrm.UseVisualStyleBackColor = false;
            this.btnStaffFrm.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnLogInFrm
            // 
            this.btnLogInFrm.BackColor = System.Drawing.Color.Transparent;
            this.btnLogInFrm.FlatAppearance.BorderSize = 0;
            this.btnLogInFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogInFrm.Location = new System.Drawing.Point(791, 14);
            this.btnLogInFrm.Name = "btnLogInFrm";
            this.btnLogInFrm.Size = new System.Drawing.Size(88, 23);
            this.btnLogInFrm.TabIndex = 19;
            this.btnLogInFrm.UseVisualStyleBackColor = false;
            // 
            // AvailabilityOverride
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dental_Practice_Management_System.Properties.Resources.System_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(901, 511);
            this.Controls.Add(this.btnLogInFrm);
            this.Controls.Add(this.btnStaffFrm);
            this.Controls.Add(this.btnReportsFrm);
            this.Controls.Add(this.btnBillingFrm);
            this.Controls.Add(this.btnTreatmentMedicineFrm);
            this.Controls.Add(this.btnDashboardFrm);
            this.Controls.Add(this.btnPatientsFrm);
            this.Controls.Add(this.btnAppointmentFrm);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gbTimeBlock);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvOverrides);
            this.Controls.Add(this.btnSave);
            this.Name = "AvailabilityOverride";
            this.Text = "AvailabilityOverride";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverrides)).EndInit();
            this.gbTimeBlock.ResumeLayout(false);
            this.gbTimeBlock.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.CheckBox chkFullDay;
        private System.Windows.Forms.ComboBox cmbDentist;
        private System.Windows.Forms.ComboBox cmbTimeSlot;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvOverrides;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox gbTimeBlock;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTimeSlot;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblDentist;
        private System.Windows.Forms.Button btnAppointmentFrm;
        private System.Windows.Forms.Button btnPatientsFrm;
        private System.Windows.Forms.Button btnDashboardFrm;
        private System.Windows.Forms.Button btnTreatmentMedicineFrm;
        private System.Windows.Forms.Button btnBillingFrm;
        private System.Windows.Forms.Button btnReportsFrm;
        private System.Windows.Forms.Button btnStaffFrm;
        private System.Windows.Forms.Button btnLogInFrm;
    }
}