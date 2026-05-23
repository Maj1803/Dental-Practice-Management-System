namespace Dental_Practice_Management_System
{
    partial class Appointments
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Appointments));
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewAppointments = new System.Windows.Forms.Button();
            this.btnBookAppointment = new System.Windows.Forms.Button();
            this.btnUpdateAppointment = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlBookAppointment = new System.Windows.Forms.Panel();
            this.grpAppointmentDetails = new System.Windows.Forms.GroupBox();
            this.btnClearBooking = new System.Windows.Forms.Button();
            this.btnConfirmBooking = new System.Windows.Forms.Button();
            this.txtAppointmentNotes = new System.Windows.Forms.TextBox();
            this.lblAppointmentNotes = new System.Windows.Forms.Label();
            this.cmbTimeSlot = new System.Windows.Forms.ComboBox();
            this.lblTimeSlot = new System.Windows.Forms.Label();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.lblAppointmentDate = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblAssistant = new System.Windows.Forms.Label();
            this.cmbDentist = new System.Windows.Forms.ComboBox();
            this.lblDentist = new System.Windows.Forms.Label();
            this.grpPatientInfo = new System.Windows.Forms.GroupBox();
            this.pnlUpdateAppointment = new System.Windows.Forms.Panel();
            this.grpUpdateDetails = new System.Windows.Forms.GroupBox();
            this.btnClearUpdate = new System.Windows.Forms.Button();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.txtUpdateReason = new System.Windows.Forms.TextBox();
            this.lblUpdateReason = new System.Windows.Forms.Label();
            this.cmbNewTimeSlot = new System.Windows.Forms.ComboBox();
            this.lblNewTimeSlot = new System.Windows.Forms.Label();
            this.dtpNewDate = new System.Windows.Forms.DateTimePicker();
            this.lblNewDate = new System.Windows.Forms.Label();
            this.cmbUpdateAction = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpFindAppointment = new System.Windows.Forms.GroupBox();
            this.lblSelectedAppointment = new System.Windows.Forms.Label();
            this.dgvUpdateAppointments = new System.Windows.Forms.DataGridView();
            this.btnUpdateSearch = new System.Windows.Forms.Button();
            this.txtUpdateSearch = new System.Windows.Forms.TextBox();
            this.lblUpdateSearch = new System.Windows.Forms.Label();
            this.lblSelectedPatient = new System.Windows.Forms.Label();
            this.dgvPatientResults = new System.Windows.Forms.DataGridView();
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.txtSearchPatient = new System.Windows.Forms.TextBox();
            this.lblSearchPatient = new System.Windows.Forms.Label();
            this.pnlViewAppointments = new System.Windows.Forms.Panel();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.grpViewFilters = new System.Windows.Forms.GroupBox();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.lblFilterDate = new System.Windows.Forms.Label();
            this.btnSearchAppointments = new System.Windows.Forms.Button();
            this.txtSearchAppointments = new System.Windows.Forms.TextBox();
            this.lblSearchAppointments = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnPatients = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnTreatments = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.pnlBookAppointment.SuspendLayout();
            this.grpAppointmentDetails.SuspendLayout();
            this.grpPatientInfo.SuspendLayout();
            this.pnlUpdateAppointment.SuspendLayout();
            this.grpUpdateDetails.SuspendLayout();
            this.grpFindAppointment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientResults)).BeginInit();
            this.pnlViewAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.grpViewFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(152, 65);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(154, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Manage Appointment Bookings";
            // 
            // btnViewAppointments
            // 
            this.btnViewAppointments.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnViewAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAppointments.Location = new System.Drawing.Point(157, 128);
            this.btnViewAppointments.Name = "btnViewAppointments";
            this.btnViewAppointments.Size = new System.Drawing.Size(151, 37);
            this.btnViewAppointments.TabIndex = 2;
            this.btnViewAppointments.Text = "View Appointments";
            this.btnViewAppointments.UseVisualStyleBackColor = true;
            this.btnViewAppointments.Click += new System.EventHandler(this.btnViewAppointments_Click);
            // 
            // btnBookAppointment
            // 
            this.btnBookAppointment.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnBookAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookAppointment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBookAppointment.Location = new System.Drawing.Point(330, 128);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Size = new System.Drawing.Size(142, 37);
            this.btnBookAppointment.TabIndex = 3;
            this.btnBookAppointment.Text = "Book Appointment";
            this.btnBookAppointment.UseVisualStyleBackColor = true;
            this.btnBookAppointment.Click += new System.EventHandler(this.btnBookAppointment_Click);
            // 
            // btnUpdateAppointment
            // 
            this.btnUpdateAppointment.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnUpdateAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateAppointment.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAppointment.Location = new System.Drawing.Point(501, 128);
            this.btnUpdateAppointment.Name = "btnUpdateAppointment";
            this.btnUpdateAppointment.Size = new System.Drawing.Size(151, 37);
            this.btnUpdateAppointment.TabIndex = 4;
            this.btnUpdateAppointment.Text = "Update Appointment";
            this.btnUpdateAppointment.UseVisualStyleBackColor = true;
            this.btnUpdateAppointment.Click += new System.EventHandler(this.btnUpdateAppointment_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.pnlViewAppointments);
            this.pnlContent.Controls.Add(this.pnlBookAppointment);
            this.pnlContent.Controls.Add(this.pnlUpdateAppointment);
            this.pnlContent.Location = new System.Drawing.Point(157, 171);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(900, 418);
            this.pnlContent.TabIndex = 5;
            this.pnlContent.Visible = false;
            // 
            // pnlBookAppointment
            // 
            this.pnlBookAppointment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBookAppointment.Controls.Add(this.grpAppointmentDetails);
            this.pnlBookAppointment.Controls.Add(this.grpPatientInfo);
            this.pnlBookAppointment.Location = new System.Drawing.Point(0, 0);
            this.pnlBookAppointment.Name = "pnlBookAppointment";
            this.pnlBookAppointment.Size = new System.Drawing.Size(900, 418);
            this.pnlBookAppointment.TabIndex = 0;
            this.pnlBookAppointment.Visible = false;
            // 
            // grpAppointmentDetails
            // 
            this.grpAppointmentDetails.Controls.Add(this.btnClearBooking);
            this.grpAppointmentDetails.Controls.Add(this.btnConfirmBooking);
            this.grpAppointmentDetails.Controls.Add(this.txtAppointmentNotes);
            this.grpAppointmentDetails.Controls.Add(this.lblAppointmentNotes);
            this.grpAppointmentDetails.Controls.Add(this.cmbTimeSlot);
            this.grpAppointmentDetails.Controls.Add(this.lblTimeSlot);
            this.grpAppointmentDetails.Controls.Add(this.dtpAppointmentDate);
            this.grpAppointmentDetails.Controls.Add(this.lblAppointmentDate);
            this.grpAppointmentDetails.Controls.Add(this.comboBox1);
            this.grpAppointmentDetails.Controls.Add(this.lblAssistant);
            this.grpAppointmentDetails.Controls.Add(this.cmbDentist);
            this.grpAppointmentDetails.Controls.Add(this.lblDentist);
            this.grpAppointmentDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAppointmentDetails.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpAppointmentDetails.Location = new System.Drawing.Point(9, 204);
            this.grpAppointmentDetails.Name = "grpAppointmentDetails";
            this.grpAppointmentDetails.Size = new System.Drawing.Size(882, 207);
            this.grpAppointmentDetails.TabIndex = 1;
            this.grpAppointmentDetails.TabStop = false;
            this.grpAppointmentDetails.Text = "Appointment Details";
            // 
            // btnClearBooking
            // 
            this.btnClearBooking.BackColor = System.Drawing.Color.MistyRose;
            this.btnClearBooking.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClearBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnClearBooking.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearBooking.Location = new System.Drawing.Point(784, 161);
            this.btnClearBooking.Name = "btnClearBooking";
            this.btnClearBooking.Size = new System.Drawing.Size(75, 31);
            this.btnClearBooking.TabIndex = 11;
            this.btnClearBooking.Text = "Clear";
            this.btnClearBooking.UseVisualStyleBackColor = false;
            this.btnClearBooking.Click += new System.EventHandler(this.btnClearBooking_Click);
            // 
            // btnConfirmBooking
            // 
            this.btnConfirmBooking.BackColor = System.Drawing.Color.Azure;
            this.btnConfirmBooking.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnConfirmBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnConfirmBooking.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConfirmBooking.Location = new System.Drawing.Point(601, 161);
            this.btnConfirmBooking.Name = "btnConfirmBooking";
            this.btnConfirmBooking.Size = new System.Drawing.Size(165, 31);
            this.btnConfirmBooking.TabIndex = 10;
            this.btnConfirmBooking.Text = "Book Appointment";
            this.btnConfirmBooking.UseVisualStyleBackColor = false;
            this.btnConfirmBooking.Click += new System.EventHandler(this.btnConfirmBooking_Click);
            // 
            // txtAppointmentNotes
            // 
            this.txtAppointmentNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAppointmentNotes.Location = new System.Drawing.Point(512, 52);
            this.txtAppointmentNotes.Multiline = true;
            this.txtAppointmentNotes.Name = "txtAppointmentNotes";
            this.txtAppointmentNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAppointmentNotes.Size = new System.Drawing.Size(254, 77);
            this.txtAppointmentNotes.TabIndex = 9;
            // 
            // lblAppointmentNotes
            // 
            this.lblAppointmentNotes.AutoSize = true;
            this.lblAppointmentNotes.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAppointmentNotes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAppointmentNotes.Location = new System.Drawing.Point(508, 30);
            this.lblAppointmentNotes.Name = "lblAppointmentNotes";
            this.lblAppointmentNotes.Size = new System.Drawing.Size(45, 19);
            this.lblAppointmentNotes.TabIndex = 8;
            this.lblAppointmentNotes.Text = "Notes";
            // 
            // cmbTimeSlot
            // 
            this.cmbTimeSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeSlot.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.cmbTimeSlot.FormattingEnabled = true;
            this.cmbTimeSlot.Location = new System.Drawing.Point(298, 108);
            this.cmbTimeSlot.Name = "cmbTimeSlot";
            this.cmbTimeSlot.Size = new System.Drawing.Size(150, 25);
            this.cmbTimeSlot.TabIndex = 7;
            // 
            // lblTimeSlot
            // 
            this.lblTimeSlot.AutoSize = true;
            this.lblTimeSlot.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTimeSlot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTimeSlot.Location = new System.Drawing.Point(294, 86);
            this.lblTimeSlot.Name = "lblTimeSlot";
            this.lblTimeSlot.Size = new System.Drawing.Size(65, 19);
            this.lblTimeSlot.TabIndex = 6;
            this.lblTimeSlot.Text = "Time Slot";
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(9, 105);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(185, 25);
            this.dtpAppointmentDate.TabIndex = 5;
            this.dtpAppointmentDate.ValueChanged += new System.EventHandler(this.dtpAppointmentDate_ValueChanged);
            // 
            // lblAppointmentDate
            // 
            this.lblAppointmentDate.AutoSize = true;
            this.lblAppointmentDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAppointmentDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAppointmentDate.Location = new System.Drawing.Point(6, 83);
            this.lblAppointmentDate.Name = "lblAppointmentDate";
            this.lblAppointmentDate.Size = new System.Drawing.Size(38, 19);
            this.lblAppointmentDate.TabIndex = 4;
            this.lblAppointmentDate.Text = "Date";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(298, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 25);
            this.comboBox1.TabIndex = 3;
            // 
            // lblAssistant
            // 
            this.lblAssistant.AutoSize = true;
            this.lblAssistant.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAssistant.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAssistant.Location = new System.Drawing.Point(294, 31);
            this.lblAssistant.Name = "lblAssistant";
            this.lblAssistant.Size = new System.Drawing.Size(68, 19);
            this.lblAssistant.TabIndex = 2;
            this.lblAssistant.Text = "Assistant ";
            // 
            // cmbDentist
            // 
            this.cmbDentist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDentist.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.cmbDentist.FormattingEnabled = true;
            this.cmbDentist.Location = new System.Drawing.Point(10, 52);
            this.cmbDentist.Name = "cmbDentist";
            this.cmbDentist.Size = new System.Drawing.Size(185, 25);
            this.cmbDentist.TabIndex = 1;
            this.cmbDentist.SelectedIndexChanged += new System.EventHandler(this.cmbDentist_SelectedIndexChanged);
            // 
            // lblDentist
            // 
            this.lblDentist.AutoSize = true;
            this.lblDentist.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDentist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDentist.Location = new System.Drawing.Point(6, 30);
            this.lblDentist.Name = "lblDentist";
            this.lblDentist.Size = new System.Drawing.Size(53, 19);
            this.lblDentist.TabIndex = 0;
            this.lblDentist.Text = "Dentist";
            // 
            // grpPatientInfo
            // 
            this.grpPatientInfo.Controls.Add(this.lblSelectedPatient);
            this.grpPatientInfo.Controls.Add(this.dgvPatientResults);
            this.grpPatientInfo.Controls.Add(this.btnSearchPatient);
            this.grpPatientInfo.Controls.Add(this.txtSearchPatient);
            this.grpPatientInfo.Controls.Add(this.lblSearchPatient);
            this.grpPatientInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPatientInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpPatientInfo.Location = new System.Drawing.Point(3, 4);
            this.grpPatientInfo.Name = "grpPatientInfo";
            this.grpPatientInfo.Size = new System.Drawing.Size(888, 194);
            this.grpPatientInfo.TabIndex = 0;
            this.grpPatientInfo.TabStop = false;
            this.grpPatientInfo.Text = "Patient Information";
            // 
            // pnlUpdateAppointment
            // 
            this.pnlUpdateAppointment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdateAppointment.Controls.Add(this.grpUpdateDetails);
            this.pnlUpdateAppointment.Controls.Add(this.grpFindAppointment);
            this.pnlUpdateAppointment.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateAppointment.Name = "pnlUpdateAppointment";
            this.pnlUpdateAppointment.Size = new System.Drawing.Size(900, 418);
            this.pnlUpdateAppointment.TabIndex = 7;
            this.pnlUpdateAppointment.Visible = false;
            // 
            // grpUpdateDetails
            // 
            this.grpUpdateDetails.Controls.Add(this.btnClearUpdate);
            this.grpUpdateDetails.Controls.Add(this.btnSaveUpdate);
            this.grpUpdateDetails.Controls.Add(this.txtUpdateReason);
            this.grpUpdateDetails.Controls.Add(this.lblUpdateReason);
            this.grpUpdateDetails.Controls.Add(this.cmbNewTimeSlot);
            this.grpUpdateDetails.Controls.Add(this.lblNewTimeSlot);
            this.grpUpdateDetails.Controls.Add(this.dtpNewDate);
            this.grpUpdateDetails.Controls.Add(this.lblNewDate);
            this.grpUpdateDetails.Controls.Add(this.cmbUpdateAction);
            this.grpUpdateDetails.Controls.Add(this.label1);
            this.grpUpdateDetails.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.grpUpdateDetails.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpUpdateDetails.Location = new System.Drawing.Point(15, 217);
            this.grpUpdateDetails.Name = "grpUpdateDetails";
            this.grpUpdateDetails.Size = new System.Drawing.Size(876, 196);
            this.grpUpdateDetails.TabIndex = 1;
            this.grpUpdateDetails.TabStop = false;
            this.grpUpdateDetails.Text = "Update Details";
            // 
            // btnClearUpdate
            // 
            this.btnClearUpdate.BackColor = System.Drawing.Color.MistyRose;
            this.btnClearUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClearUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnClearUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearUpdate.Location = new System.Drawing.Point(774, 146);
            this.btnClearUpdate.Name = "btnClearUpdate";
            this.btnClearUpdate.Size = new System.Drawing.Size(80, 35);
            this.btnClearUpdate.TabIndex = 9;
            this.btnClearUpdate.Text = "Clear";
            this.btnClearUpdate.UseVisualStyleBackColor = false;
            this.btnClearUpdate.Click += new System.EventHandler(this.btnClearUpdate_Click);
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.BackColor = System.Drawing.Color.Azure;
            this.btnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnSaveUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaveUpdate.Location = new System.Drawing.Point(622, 147);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(130, 35);
            this.btnSaveUpdate.TabIndex = 8;
            this.btnSaveUpdate.Text = "Save Changes";
            this.btnSaveUpdate.UseVisualStyleBackColor = false;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // txtUpdateReason
            // 
            this.txtUpdateReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateReason.Location = new System.Drawing.Point(24, 115);
            this.txtUpdateReason.Multiline = true;
            this.txtUpdateReason.Name = "txtUpdateReason";
            this.txtUpdateReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUpdateReason.Size = new System.Drawing.Size(217, 67);
            this.txtUpdateReason.TabIndex = 7;
            // 
            // lblUpdateReason
            // 
            this.lblUpdateReason.AutoSize = true;
            this.lblUpdateReason.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUpdateReason.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUpdateReason.Location = new System.Drawing.Point(20, 93);
            this.lblUpdateReason.Name = "lblUpdateReason";
            this.lblUpdateReason.Size = new System.Drawing.Size(118, 19);
            this.lblUpdateReason.TabIndex = 6;
            this.lblUpdateReason.Text = "Reason (Optional)";
            // 
            // cmbNewTimeSlot
            // 
            this.cmbNewTimeSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewTimeSlot.FormattingEnabled = true;
            this.cmbNewTimeSlot.Location = new System.Drawing.Point(248, 59);
            this.cmbNewTimeSlot.Name = "cmbNewTimeSlot";
            this.cmbNewTimeSlot.Size = new System.Drawing.Size(147, 25);
            this.cmbNewTimeSlot.TabIndex = 5;
            // 
            // lblNewTimeSlot
            // 
            this.lblNewTimeSlot.AutoSize = true;
            this.lblNewTimeSlot.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNewTimeSlot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNewTimeSlot.Location = new System.Drawing.Point(244, 37);
            this.lblNewTimeSlot.Name = "lblNewTimeSlot";
            this.lblNewTimeSlot.Size = new System.Drawing.Size(96, 19);
            this.lblNewTimeSlot.TabIndex = 4;
            this.lblNewTimeSlot.Text = "New Time Slot";
            // 
            // dtpNewDate
            // 
            this.dtpNewDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNewDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNewDate.Location = new System.Drawing.Point(432, 57);
            this.dtpNewDate.Name = "dtpNewDate";
            this.dtpNewDate.Size = new System.Drawing.Size(150, 25);
            this.dtpNewDate.TabIndex = 3;
            // 
            // lblNewDate
            // 
            this.lblNewDate.AutoSize = true;
            this.lblNewDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNewDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNewDate.Location = new System.Drawing.Point(434, 35);
            this.lblNewDate.Name = "lblNewDate";
            this.lblNewDate.Size = new System.Drawing.Size(69, 19);
            this.lblNewDate.TabIndex = 2;
            this.lblNewDate.Text = "New Date";
            // 
            // cmbUpdateAction
            // 
            this.cmbUpdateAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdateAction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbUpdateAction.FormattingEnabled = true;
            this.cmbUpdateAction.Location = new System.Drawing.Point(24, 57);
            this.cmbUpdateAction.Name = "cmbUpdateAction";
            this.cmbUpdateAction.Size = new System.Drawing.Size(180, 25);
            this.cmbUpdateAction.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action";
            // 
            // grpFindAppointment
            // 
            this.grpFindAppointment.Controls.Add(this.lblSelectedAppointment);
            this.grpFindAppointment.Controls.Add(this.dgvUpdateAppointments);
            this.grpFindAppointment.Controls.Add(this.btnUpdateSearch);
            this.grpFindAppointment.Controls.Add(this.txtUpdateSearch);
            this.grpFindAppointment.Controls.Add(this.lblUpdateSearch);
            this.grpFindAppointment.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.grpFindAppointment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpFindAppointment.Location = new System.Drawing.Point(15, 15);
            this.grpFindAppointment.Name = "grpFindAppointment";
            this.grpFindAppointment.Size = new System.Drawing.Size(876, 196);
            this.grpFindAppointment.TabIndex = 0;
            this.grpFindAppointment.TabStop = false;
            this.grpFindAppointment.Text = "Find Appointment";
            // 
            // lblSelectedAppointment
            // 
            this.lblSelectedAppointment.AutoSize = true;
            this.lblSelectedAppointment.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.lblSelectedAppointment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSelectedAppointment.Location = new System.Drawing.Point(710, 173);
            this.lblSelectedAppointment.Name = "lblSelectedAppointment";
            this.lblSelectedAppointment.Size = new System.Drawing.Size(144, 15);
            this.lblSelectedAppointment.TabIndex = 4;
            this.lblSelectedAppointment.Text = "No appointment selected.";
            // 
            // dgvUpdateAppointments
            // 
            this.dgvUpdateAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpdateAppointments.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvUpdateAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdateAppointments.Location = new System.Drawing.Point(15, 84);
            this.dgvUpdateAppointments.MultiSelect = false;
            this.dgvUpdateAppointments.Name = "dgvUpdateAppointments";
            this.dgvUpdateAppointments.ReadOnly = true;
            this.dgvUpdateAppointments.RowHeadersWidth = 51;
            this.dgvUpdateAppointments.RowTemplate.Height = 24;
            this.dgvUpdateAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpdateAppointments.Size = new System.Drawing.Size(839, 86);
            this.dgvUpdateAppointments.TabIndex = 3;
            this.dgvUpdateAppointments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUpdateAppointments_CellClick);
            // 
            // btnUpdateSearch
            // 
            this.btnUpdateSearch.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnUpdateSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.btnUpdateSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateSearch.Location = new System.Drawing.Point(256, 55);
            this.btnUpdateSearch.Name = "btnUpdateSearch";
            this.btnUpdateSearch.Size = new System.Drawing.Size(87, 23);
            this.btnUpdateSearch.TabIndex = 2;
            this.btnUpdateSearch.Text = "Search";
            this.btnUpdateSearch.UseVisualStyleBackColor = true;
            this.btnUpdateSearch.Click += new System.EventHandler(this.btnUpdateSearch_Click);
            // 
            // txtUpdateSearch
            // 
            this.txtUpdateSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateSearch.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.txtUpdateSearch.Location = new System.Drawing.Point(15, 55);
            this.txtUpdateSearch.Name = "txtUpdateSearch";
            this.txtUpdateSearch.Size = new System.Drawing.Size(235, 23);
            this.txtUpdateSearch.TabIndex = 1;
            // 
            // lblUpdateSearch
            // 
            this.lblUpdateSearch.AutoSize = true;
            this.lblUpdateSearch.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUpdateSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUpdateSearch.Location = new System.Drawing.Point(15, 30);
            this.lblUpdateSearch.Name = "lblUpdateSearch";
            this.lblUpdateSearch.Size = new System.Drawing.Size(226, 19);
            this.lblUpdateSearch.TabIndex = 0;
            this.lblUpdateSearch.Text = "Search Patient (Patient Name or ID)";
            // 
            // lblSelectedPatient
            // 
            this.lblSelectedPatient.AutoSize = true;
            this.lblSelectedPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPatient.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSelectedPatient.Location = new System.Drawing.Point(756, 170);
            this.lblSelectedPatient.Name = "lblSelectedPatient";
            this.lblSelectedPatient.Size = new System.Drawing.Size(126, 16);
            this.lblSelectedPatient.TabIndex = 4;
            this.lblSelectedPatient.Text = "No patient selected.";
            // 
            // dgvPatientResults
            // 
            this.dgvPatientResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatientResults.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvPatientResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientResults.Location = new System.Drawing.Point(6, 95);
            this.dgvPatientResults.MultiSelect = false;
            this.dgvPatientResults.Name = "dgvPatientResults";
            this.dgvPatientResults.ReadOnly = true;
            this.dgvPatientResults.RowHeadersWidth = 51;
            this.dgvPatientResults.RowTemplate.Height = 24;
            this.dgvPatientResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatientResults.Size = new System.Drawing.Size(876, 72);
            this.dgvPatientResults.TabIndex = 3;
            this.dgvPatientResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatientResults_CellClick);
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearchPatient.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPatient.Location = new System.Drawing.Point(251, 49);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(70, 25);
            this.btnSearchPatient.TabIndex = 2;
            this.btnSearchPatient.Text = "Search";
            this.btnSearchPatient.UseVisualStyleBackColor = true;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // txtSearchPatient
            // 
            this.txtSearchPatient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchPatient.Location = new System.Drawing.Point(10, 49);
            this.txtSearchPatient.Name = "txtSearchPatient";
            this.txtSearchPatient.Size = new System.Drawing.Size(235, 27);
            this.txtSearchPatient.TabIndex = 1;
            // 
            // lblSearchPatient
            // 
            this.lblSearchPatient.AutoSize = true;
            this.lblSearchPatient.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchPatient.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSearchPatient.Location = new System.Drawing.Point(7, 29);
            this.lblSearchPatient.Name = "lblSearchPatient";
            this.lblSearchPatient.Size = new System.Drawing.Size(193, 15);
            this.lblSearchPatient.TabIndex = 0;
            this.lblSearchPatient.Text = "Search Patient (Patient Name or ID)";
            // 
            // pnlViewAppointments
            // 
            this.pnlViewAppointments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewAppointments.Controls.Add(this.dgvAppointments);
            this.pnlViewAppointments.Controls.Add(this.grpViewFilters);
            this.pnlViewAppointments.Location = new System.Drawing.Point(0, 0);
            this.pnlViewAppointments.Name = "pnlViewAppointments";
            this.pnlViewAppointments.Size = new System.Drawing.Size(900, 418);
            this.pnlViewAppointments.TabIndex = 5;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(15, 129);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(876, 265);
            this.dgvAppointments.TabIndex = 1;
            // 
            // grpViewFilters
            // 
            this.grpViewFilters.AutoSize = true;
            this.grpViewFilters.Controls.Add(this.cmbStatusFilter);
            this.grpViewFilters.Controls.Add(this.lblStatusFilter);
            this.grpViewFilters.Controls.Add(this.dtpFilterDate);
            this.grpViewFilters.Controls.Add(this.lblFilterDate);
            this.grpViewFilters.Controls.Add(this.btnSearchAppointments);
            this.grpViewFilters.Controls.Add(this.txtSearchAppointments);
            this.grpViewFilters.Controls.Add(this.lblSearchAppointments);
            this.grpViewFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpViewFilters.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpViewFilters.Location = new System.Drawing.Point(15, 19);
            this.grpViewFilters.Name = "grpViewFilters";
            this.grpViewFilters.Size = new System.Drawing.Size(1059, 617);
            this.grpViewFilters.TabIndex = 0;
            this.grpViewFilters.TabStop = false;
            this.grpViewFilters.Text = "Appointments";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(622, 54);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(121, 28);
            this.cmbStatusFilter.TabIndex = 6;
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusFilter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStatusFilter.Location = new System.Drawing.Point(619, 30);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(43, 17);
            this.lblStatusFilter.TabIndex = 5;
            this.lblStatusFilter.Text = "Status";
            // 
            // dtpFilterDate
            // 
            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterDate.Location = new System.Drawing.Point(468, 55);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.Size = new System.Drawing.Size(121, 27);
            this.dtpFilterDate.TabIndex = 4;
            // 
            // lblFilterDate
            // 
            this.lblFilterDate.AutoSize = true;
            this.lblFilterDate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFilterDate.Location = new System.Drawing.Point(465, 30);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(35, 17);
            this.lblFilterDate.TabIndex = 3;
            this.lblFilterDate.Text = "Date";
            // 
            // btnSearchAppointments
            // 
            this.btnSearchAppointments.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearchAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAppointments.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchAppointments.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchAppointments.Location = new System.Drawing.Point(268, 53);
            this.btnSearchAppointments.Name = "btnSearchAppointments";
            this.btnSearchAppointments.Size = new System.Drawing.Size(75, 25);
            this.btnSearchAppointments.TabIndex = 2;
            this.btnSearchAppointments.Text = "Search";
            this.btnSearchAppointments.UseVisualStyleBackColor = true;
            this.btnSearchAppointments.Click += new System.EventHandler(this.btnSearchAppointments_Click);
            // 
            // txtSearchAppointments
            // 
            this.txtSearchAppointments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchAppointments.Location = new System.Drawing.Point(18, 53);
            this.txtSearchAppointments.Name = "txtSearchAppointments";
            this.txtSearchAppointments.Size = new System.Drawing.Size(244, 27);
            this.txtSearchAppointments.TabIndex = 1;
            // 
            // lblSearchAppointments
            // 
            this.lblSearchAppointments.AutoSize = true;
            this.lblSearchAppointments.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchAppointments.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSearchAppointments.Location = new System.Drawing.Point(15, 30);
            this.lblSearchAppointments.Name = "lblSearchAppointments";
            this.lblSearchAppointments.Size = new System.Drawing.Size(328, 17);
            this.lblSearchAppointments.TabIndex = 0;
            this.lblSearchAppointments.Text = "Search Appointment (Patient Name or Appointment ID)";
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Location = new System.Drawing.Point(-1, 54);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(125, 75);
            this.btnDashboard.TabIndex = 15;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnPatients
            // 
            this.btnPatients.BackColor = System.Drawing.Color.Transparent;
            this.btnPatients.FlatAppearance.BorderSize = 0;
            this.btnPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatients.Location = new System.Drawing.Point(-1, 128);
            this.btnPatients.Margin = new System.Windows.Forms.Padding(4);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(125, 75);
            this.btnPatients.TabIndex = 16;
            this.btnPatients.UseVisualStyleBackColor = false;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.BackColor = System.Drawing.Color.Transparent;
            this.btnAppointments.FlatAppearance.BorderSize = 0;
            this.btnAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointments.Location = new System.Drawing.Point(-1, 206);
            this.btnAppointments.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(125, 75);
            this.btnAppointments.TabIndex = 17;
            this.btnAppointments.UseVisualStyleBackColor = false;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // btnTreatments
            // 
            this.btnTreatments.BackColor = System.Drawing.Color.Transparent;
            this.btnTreatments.FlatAppearance.BorderSize = 0;
            this.btnTreatments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTreatments.Location = new System.Drawing.Point(-1, 289);
            this.btnTreatments.Margin = new System.Windows.Forms.Padding(4);
            this.btnTreatments.Name = "btnTreatments";
            this.btnTreatments.Size = new System.Drawing.Size(125, 75);
            this.btnTreatments.TabIndex = 18;
            this.btnTreatments.UseVisualStyleBackColor = false;
            this.btnTreatments.Click += new System.EventHandler(this.btnTreatments_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.BackColor = System.Drawing.Color.Transparent;
            this.btnBilling.FlatAppearance.BorderSize = 0;
            this.btnBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilling.Location = new System.Drawing.Point(-1, 372);
            this.btnBilling.Margin = new System.Windows.Forms.Padding(4);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(125, 75);
            this.btnBilling.TabIndex = 19;
            this.btnBilling.UseVisualStyleBackColor = false;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Transparent;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Location = new System.Drawing.Point(-1, 455);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(125, 75);
            this.btnReports.TabIndex = 20;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.Transparent;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Location = new System.Drawing.Point(-1, 530);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(4);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(125, 75);
            this.btnStaff.TabIndex = 21;
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(947, 13);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(108, 32);
            this.btnLogin.TabIndex = 22;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::Dental_Practice_Management_System.Properties.Resources.System_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1082, 603);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.btnTreatments);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnPatients);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.btnUpdateAppointment);
            this.Controls.Add(this.btnBookAppointment);
            this.Controls.Add(this.btnViewAppointments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Appointments";
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.Appointments_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlBookAppointment.ResumeLayout(false);
            this.grpAppointmentDetails.ResumeLayout(false);
            this.grpAppointmentDetails.PerformLayout();
            this.grpPatientInfo.ResumeLayout(false);
            this.grpPatientInfo.PerformLayout();
            this.pnlUpdateAppointment.ResumeLayout(false);
            this.grpUpdateDetails.ResumeLayout(false);
            this.grpUpdateDetails.PerformLayout();
            this.grpFindAppointment.ResumeLayout(false);
            this.grpFindAppointment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientResults)).EndInit();
            this.pnlViewAppointments.ResumeLayout(false);
            this.pnlViewAppointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.grpViewFilters.ResumeLayout(false);
            this.grpViewFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewAppointments;
        private System.Windows.Forms.Button btnBookAppointment;
        private System.Windows.Forms.Button btnUpdateAppointment;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlBookAppointment;
        private System.Windows.Forms.GroupBox grpPatientInfo;
        private System.Windows.Forms.Label lblSearchPatient;
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.TextBox txtSearchPatient;
        private System.Windows.Forms.Label lblSelectedPatient;
        private System.Windows.Forms.DataGridView dgvPatientResults;
        private System.Windows.Forms.GroupBox grpAppointmentDetails;
        private System.Windows.Forms.Label lblAssistant;
        private System.Windows.Forms.ComboBox cmbDentist;
        private System.Windows.Forms.Label lblDentist;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.Label lblAppointmentDate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblTimeSlot;
        private System.Windows.Forms.ComboBox cmbTimeSlot;
        private System.Windows.Forms.TextBox txtAppointmentNotes;
        private System.Windows.Forms.Label lblAppointmentNotes;
        private System.Windows.Forms.Button btnConfirmBooking;
        private System.Windows.Forms.Button btnClearBooking;
        private System.Windows.Forms.Panel pnlViewAppointments;
        private System.Windows.Forms.GroupBox grpViewFilters;
        private System.Windows.Forms.Label lblSearchAppointments;
        private System.Windows.Forms.Button btnSearchAppointments;
        private System.Windows.Forms.TextBox txtSearchAppointments;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.Label lblFilterDate;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Panel pnlUpdateAppointment;
        private System.Windows.Forms.GroupBox grpFindAppointment;
        private System.Windows.Forms.Label lblUpdateSearch;
        private System.Windows.Forms.TextBox txtUpdateSearch;
        private System.Windows.Forms.DataGridView dgvUpdateAppointments;
        private System.Windows.Forms.Button btnUpdateSearch;
        private System.Windows.Forms.GroupBox grpUpdateDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedAppointment;
        private System.Windows.Forms.ComboBox cmbUpdateAction;
        private System.Windows.Forms.Label lblNewDate;
        private System.Windows.Forms.ComboBox cmbNewTimeSlot;
        private System.Windows.Forms.Label lblNewTimeSlot;
        private System.Windows.Forms.DateTimePicker dtpNewDate;
        private System.Windows.Forms.TextBox txtUpdateReason;
        private System.Windows.Forms.Label lblUpdateReason;
        private System.Windows.Forms.Button btnClearUpdate;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnPatients;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button btnTreatments;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnLogin;
    }
}