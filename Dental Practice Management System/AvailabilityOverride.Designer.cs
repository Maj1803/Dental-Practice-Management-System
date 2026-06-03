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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailabilityOverride));
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkFullDay = new System.Windows.Forms.CheckBox();
            this.cmbDentist = new System.Windows.Forms.ComboBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDentist = new Dental_Practice_Management_System.dsDentist();
            this.cmbTimeSlot = new System.Windows.Forms.ComboBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvOverrides = new System.Windows.Forms.DataGridView();
            this.Override_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timeslot_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is_Full_Day = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_Last_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availability_OverrideBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.gbTimeBlock = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTimeSlot = new System.Windows.Forms.Label();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblDentist = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btAddNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gpsearch = new System.Windows.Forms.GroupBox();
            this.cmbSearchDentist = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSearchDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.employeeTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.EmployeeTableAdapter();
            this.tableAdapterManager = new Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager();
            this.availability_OverrideTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.Availability_OverrideTableAdapter();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverrides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availability_OverrideBindingSource)).BeginInit();
            this.gbTimeBlock.SuspendLayout();
            this.gbDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.gpsearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(208, 96);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(285, 32);
            this.dtpDate.TabIndex = 0;
            // 
            // chkFullDay
            // 
            this.chkFullDay.AutoSize = true;
            this.chkFullDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFullDay.Location = new System.Drawing.Point(13, 41);
            this.chkFullDay.Margin = new System.Windows.Forms.Padding(4);
            this.chkFullDay.Name = "chkFullDay";
            this.chkFullDay.Size = new System.Drawing.Size(114, 30);
            this.chkFullDay.TabIndex = 2;
            this.chkFullDay.Text = "Full Day";
            this.chkFullDay.UseVisualStyleBackColor = true;
            this.chkFullDay.CheckedChanged += new System.EventHandler(this.chkFullDay_CheckedChanged);
            // 
            // cmbDentist
            // 
            this.cmbDentist.DataSource = this.employeeBindingSource;
            this.cmbDentist.DisplayMember = "Employee_Last_Name";
            this.cmbDentist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDentist.FormattingEnabled = true;
            this.cmbDentist.Location = new System.Drawing.Point(212, 37);
            this.cmbDentist.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDentist.Name = "cmbDentist";
            this.cmbDentist.Size = new System.Drawing.Size(264, 34);
            this.cmbDentist.TabIndex = 3;
            this.cmbDentist.ValueMember = "Employee_ID";
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.dsDentist;
            // 
            // dsDentist
            // 
            this.dsDentist.DataSetName = "dsDentist";
            this.dsDentist.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbTimeSlot
            // 
            this.cmbTimeSlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimeSlot.FormattingEnabled = true;
            this.cmbTimeSlot.Location = new System.Drawing.Point(208, 156);
            this.cmbTimeSlot.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTimeSlot.Name = "cmbTimeSlot";
            this.cmbTimeSlot.Size = new System.Drawing.Size(284, 34);
            this.cmbTimeSlot.TabIndex = 4;
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(212, 169);
            this.txtReason.Margin = new System.Windows.Forms.Padding(4);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(264, 32);
            this.txtReason.TabIndex = 5;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Indigo;
            this.btnSave.Location = new System.Drawing.Point(844, 519);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(184, 44);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
           
            // 
            // dgvOverrides
            // 
            this.dgvOverrides.AutoGenerateColumns = false;
            this.dgvOverrides.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverrides.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Override_ID,
            this.Target_Date,
            this.Timeslot_ID,
            this.Is_Full_Day,
            this.Reason,
            this.Employee_ID,
            this.Employee_Last_Name});
            this.dgvOverrides.DataSource = this.availability_OverrideBindingSource;
            this.dgvOverrides.Location = new System.Drawing.Point(32, 97);
            this.dgvOverrides.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOverrides.Name = "dgvOverrides";
            this.dgvOverrides.RowHeadersWidth = 51;
            this.dgvOverrides.Size = new System.Drawing.Size(1351, 425);
            this.dgvOverrides.TabIndex = 7;
            // 
            // Override_ID
            // 
            this.Override_ID.DataPropertyName = "Override_ID";
            this.Override_ID.HeaderText = "Override_ID";
            this.Override_ID.MinimumWidth = 6;
            this.Override_ID.Name = "Override_ID";
            this.Override_ID.ReadOnly = true;
            this.Override_ID.Width = 125;
            // 
            // Target_Date
            // 
            this.Target_Date.DataPropertyName = "Target_Date";
            this.Target_Date.HeaderText = "Target_Date";
            this.Target_Date.MinimumWidth = 6;
            this.Target_Date.Name = "Target_Date";
            this.Target_Date.Width = 125;
            // 
            // Timeslot_ID
            // 
            this.Timeslot_ID.DataPropertyName = "Timeslot_ID";
            this.Timeslot_ID.HeaderText = "Timeslot_ID";
            this.Timeslot_ID.MinimumWidth = 6;
            this.Timeslot_ID.Name = "Timeslot_ID";
            this.Timeslot_ID.Width = 125;
            // 
            // Is_Full_Day
            // 
            this.Is_Full_Day.DataPropertyName = "Is_Full_Day";
            this.Is_Full_Day.HeaderText = "Is_Full_Day";
            this.Is_Full_Day.MinimumWidth = 6;
            this.Is_Full_Day.Name = "Is_Full_Day";
            this.Is_Full_Day.Width = 125;
            // 
            // Reason
            // 
            this.Reason.DataPropertyName = "Reason";
            this.Reason.HeaderText = "Reason";
            this.Reason.MinimumWidth = 6;
            this.Reason.Name = "Reason";
            this.Reason.Width = 125;
            // 
            // Employee_ID
            // 
            this.Employee_ID.DataPropertyName = "Employee_ID";
            this.Employee_ID.HeaderText = "Employee_ID";
            this.Employee_ID.MinimumWidth = 6;
            this.Employee_ID.Name = "Employee_ID";
            this.Employee_ID.Width = 125;
            // 
            // Employee_Last_Name
            // 
            this.Employee_Last_Name.DataPropertyName = "Employee_Last_Name";
            this.Employee_Last_Name.HeaderText = "Dentist Name";
            this.Employee_Last_Name.MinimumWidth = 6;
            this.Employee_Last_Name.Name = "Employee_Last_Name";
            this.Employee_Last_Name.Width = 125;
            // 
            // availability_OverrideBindingSource
            // 
            this.availability_OverrideBindingSource.DataMember = "Availability_Override";
            this.availability_OverrideBindingSource.DataSource = this.dsDentist;
            // 
            // cmbReason
            // 
            this.cmbReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Items.AddRange(new object[] {
            "Public Holiday",
            "Leave",
            "Emergency",
            "Other"});
            this.cmbReason.Location = new System.Drawing.Point(212, 111);
            this.cmbReason.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(264, 34);
            this.cmbReason.TabIndex = 8;
            this.cmbReason.SelectedIndexChanged += new System.EventHandler(this.cmbReason_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(162, 30);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(340, 39);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Availability Override";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDescription.Location = new System.Drawing.Point(166, 69);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(234, 17);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Manage unavailable times and days";
            // 
            // gbTimeBlock
            // 
            this.gbTimeBlock.BackColor = System.Drawing.Color.White;
            this.gbTimeBlock.Controls.Add(this.lblDate);
            this.gbTimeBlock.Controls.Add(this.lblTimeSlot);
            this.gbTimeBlock.Controls.Add(this.chkFullDay);
            this.gbTimeBlock.Controls.Add(this.dtpDate);
            this.gbTimeBlock.Controls.Add(this.cmbTimeSlot);
            this.gbTimeBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTimeBlock.Location = new System.Drawing.Point(44, 54);
            this.gbTimeBlock.Margin = new System.Windows.Forms.Padding(4);
            this.gbTimeBlock.Name = "gbTimeBlock";
            this.gbTimeBlock.Padding = new System.Windows.Forms.Padding(4);
            this.gbTimeBlock.Size = new System.Drawing.Size(563, 350);
            this.gbTimeBlock.TabIndex = 11;
            this.gbTimeBlock.TabStop = false;
            this.gbTimeBlock.Text = "Time Block";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(8, 96);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(163, 26);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Choose a Date:";
            // 
            // lblTimeSlot
            // 
            this.lblTimeSlot.AutoSize = true;
            this.lblTimeSlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSlot.Location = new System.Drawing.Point(8, 160);
            this.lblTimeSlot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeSlot.Name = "lblTimeSlot";
            this.lblTimeSlot.Size = new System.Drawing.Size(176, 26);
            this.lblTimeSlot.TabIndex = 5;
            this.lblTimeSlot.Text = "Pick a Time Slot:";
            // 
            // gbDetails
            // 
            this.gbDetails.BackColor = System.Drawing.Color.White;
            this.gbDetails.Controls.Add(this.lblOther);
            this.gbDetails.Controls.Add(this.lblReason);
            this.gbDetails.Controls.Add(this.lblDentist);
            this.gbDetails.Controls.Add(this.cmbDentist);
            this.gbDetails.Controls.Add(this.cmbReason);
            this.gbDetails.Controls.Add(this.txtReason);
            this.gbDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetails.Location = new System.Drawing.Point(700, 54);
            this.gbDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbDetails.Size = new System.Drawing.Size(561, 262);
            this.gbDetails.TabIndex = 12;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Details";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOther.Location = new System.Drawing.Point(119, 172);
            this.lblOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(66, 26);
            this.lblOther.TabIndex = 10;
            this.lblOther.Text = "Other";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(8, 111);
            this.lblReason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(174, 26);
            this.lblReason.TabIndex = 9;
            this.lblReason.Text = "Choose Reason:";
            // 
            // lblDentist
            // 
            this.lblDentist.AutoSize = true;
            this.lblDentist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDentist.Location = new System.Drawing.Point(8, 41);
            this.lblDentist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDentist.Name = "lblDentist";
            this.lblDentist.Size = new System.Drawing.Size(167, 26);
            this.lblDentist.TabIndex = 7;
            this.lblDentist.Text = "Choose Dentist:";
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.White;
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btCancel.FlatAppearance.BorderSize = 2;
            this.btCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Gray;
            this.btCancel.Location = new System.Drawing.Point(1077, 519);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(184, 44);
            this.btCancel.TabIndex = 13;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
           
            this.btCancel.MouseHover += new System.EventHandler(this.btCancel_MouseHover);
            // 
            // btAddNew
            // 
            this.btAddNew.BackColor = System.Drawing.Color.White;
            this.btAddNew.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btAddNew.FlatAppearance.BorderSize = 2;
            this.btAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btAddNew.ForeColor = System.Drawing.Color.Indigo;
            this.btAddNew.Location = new System.Drawing.Point(1250, 37);
            this.btAddNew.Margin = new System.Windows.Forms.Padding(4);
            this.btAddNew.Name = "btAddNew";
            this.btAddNew.Size = new System.Drawing.Size(133, 44);
            this.btAddNew.TabIndex = 14;
            this.btAddNew.Text = "Add New";
            this.btAddNew.UseVisualStyleBackColor = false;
            this.btAddNew.Click += new System.EventHandler(this.btAddNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btAddNew);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1417, 94);
            this.panel1.TabIndex = 15;
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.gbTimeBlock);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.gbDetails);
            this.pnlForm.Controls.Add(this.btCancel);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 94);
            this.pnlForm.Margin = new System.Windows.Forms.Padding(4);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1417, 609);
            this.pnlForm.TabIndex = 16;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.btnUpdate);
            this.pnlDisplay.Controls.Add(this.btnDelete);
            this.pnlDisplay.Controls.Add(this.gpsearch);
            this.pnlDisplay.Controls.Add(this.dgvOverrides);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 94);
            this.pnlDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(1417, 609);
            this.pnlDisplay.TabIndex = 17;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.Indigo;
            this.btnUpdate.Location = new System.Drawing.Point(1021, 550);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(164, 44);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.Gray;
            this.btnDelete.Location = new System.Drawing.Point(1219, 550);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(164, 44);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gpsearch
            // 
            this.gpsearch.Controls.Add(this.cmbSearchDentist);
            this.gpsearch.Controls.Add(this.button1);
            this.gpsearch.Controls.Add(this.label2);
            this.gpsearch.Controls.Add(this.dtpSearchDate);
            this.gpsearch.Controls.Add(this.label3);
            this.gpsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gpsearch.Location = new System.Drawing.Point(32, 18);
            this.gpsearch.Margin = new System.Windows.Forms.Padding(4);
            this.gpsearch.Name = "gpsearch";
            this.gpsearch.Padding = new System.Windows.Forms.Padding(4);
            this.gpsearch.Size = new System.Drawing.Size(929, 73);
            this.gpsearch.TabIndex = 14;
            this.gpsearch.TabStop = false;
            this.gpsearch.Text = "Search By";
            // 
            // cmbSearchDentist
            // 
            this.cmbSearchDentist.DataSource = this.employeeBindingSource;
            this.cmbSearchDentist.DisplayMember = "Employee_Last_Name";
            this.cmbSearchDentist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbSearchDentist.FormattingEnabled = true;
            this.cmbSearchDentist.Location = new System.Drawing.Point(529, 27);
            this.cmbSearchDentist.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSearchDentist.Name = "cmbSearchDentist";
            this.cmbSearchDentist.Size = new System.Drawing.Size(195, 28);
            this.cmbSearchDentist.TabIndex = 9;
            this.cmbSearchDentist.ValueMember = "Employee_ID";
            this.cmbSearchDentist.SelectedIndexChanged += new System.EventHandler(this.cmbSearchDentist_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(812, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 13;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(28, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Date";
            // 
            // dtpSearchDate
            // 
            this.dtpSearchDate.Checked = false;
            this.dtpSearchDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpSearchDate.Location = new System.Drawing.Point(85, 30);
            this.dtpSearchDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpSearchDate.Name = "dtpSearchDate";
            this.dtpSearchDate.ShowCheckBox = true;
            this.dtpSearchDate.Size = new System.Drawing.Size(265, 26);
            this.dtpSearchDate.TabIndex = 12;
            this.dtpSearchDate.ValueChanged += new System.EventHandler(this.dtpSearchDate_ValueChanged);
            this.dtpSearchDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpSearchDate_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(440, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Dentist";
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AppointmentTableAdapter = null;
            this.tableAdapterManager.Availability_OverrideTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EmployeeTableAdapter = this.employeeTableAdapter;
            this.tableAdapterManager.InvoiceTableAdapter = null;
            this.tableAdapterManager.MedicineTableAdapter = null;
            this.tableAdapterManager.PatientTableAdapter = null;
            this.tableAdapterManager.PatientTreatmentTableAdapter = null;
            this.tableAdapterManager.PaymentTableAdapter = null;
            this.tableAdapterManager.PrescriptionTableAdapter = null;
            this.tableAdapterManager.StaffMessageTableAdapter = null;
            this.tableAdapterManager.TimeslotTableAdapter = null;
            this.tableAdapterManager.Treatment1TableAdapter = null;
            this.tableAdapterManager.TreatmentTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // availability_OverrideTableAdapter
            // 
            this.availability_OverrideTableAdapter.ClearBeforeFill = true;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(32, 37);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 37);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // AvailabilityOverride
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1417, 703);
            this.Controls.Add(this.pnlDisplay);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AvailabilityOverride";
            this.Text = "AvailabilityOverride";
            this.Load += new System.EventHandler(this.AvailabilityOverride_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverrides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availability_OverrideBindingSource)).EndInit();
            this.gbTimeBlock.ResumeLayout(false);
            this.gbTimeBlock.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlDisplay.ResumeLayout(false);
            this.gpsearch.ResumeLayout(false);
            this.gpsearch.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAddNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlDisplay;
        private dsDentist dsDentist;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private dsDentistTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private dsDentistTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource availability_OverrideBindingSource;
        private dsDentistTableAdapters.Availability_OverrideTableAdapter availability_OverrideTableAdapter;
        private System.Windows.Forms.ComboBox cmbSearchDentist;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpSearchDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gpsearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Override_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timeslot_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Is_Full_Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_Last_Name;
        private System.Windows.Forms.Button btnBack;
    }
}