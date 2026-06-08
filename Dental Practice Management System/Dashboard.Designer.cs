namespace Dental_Practice_Management_System
{
    partial class Dashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAppointmentsText = new System.Windows.Forms.Label();
            this.lblAppointmentsCount = new System.Windows.Forms.Label();
            this.pnlPatients = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPatientsText = new System.Windows.Forms.Label();
            this.lblPatientsCount = new System.Windows.Forms.Label();
            this.pnlInvoices = new System.Windows.Forms.Panel();
            this.lblInvoicesText = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblInvoicesCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lBLScheduleHeader = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTreatment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpStaffMessages = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.staffMessageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDentist = new Dental_Practice_Management_System.dsDentist();
            this.staffMessageTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.StaffMessageTableAdapter();
            this.tableAdapterManager = new Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager();
            this.pnlAppointments.SuspendLayout();
            this.pnlPatients.SuspendLayout();
            this.pnlInvoices.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.grpStaffMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffMessageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(104, 122);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(24, 25);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "0";
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.BackColor = System.Drawing.Color.White;
            this.pnlAppointments.Controls.Add(this.panel2);
            this.pnlAppointments.Controls.Add(this.lblAppointmentsText);
            this.pnlAppointments.Controls.Add(this.lblAppointmentsCount);
            this.pnlAppointments.Location = new System.Drawing.Point(20, 71);
            this.pnlAppointments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(315, 134);
            this.pnlAppointments.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(47, 134);
            this.panel2.TabIndex = 7;
            // 
            // lblAppointmentsText
            // 
            this.lblAppointmentsText.AutoSize = true;
            this.lblAppointmentsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsText.ForeColor = System.Drawing.Color.Lime;
            this.lblAppointmentsText.Location = new System.Drawing.Point(79, 98);
            this.lblAppointmentsText.Name = "lblAppointmentsText";
            this.lblAppointmentsText.Size = new System.Drawing.Size(193, 22);
            this.lblAppointmentsText.TabIndex = 0;
            this.lblAppointmentsText.Text = "Appointments Today";
            // 
            // lblAppointmentsCount
            // 
            this.lblAppointmentsCount.AutoSize = true;
            this.lblAppointmentsCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsCount.ForeColor = System.Drawing.Color.Lime;
            this.lblAppointmentsCount.Location = new System.Drawing.Point(143, 16);
            this.lblAppointmentsCount.Name = "lblAppointmentsCount";
            this.lblAppointmentsCount.Size = new System.Drawing.Size(56, 65);
            this.lblAppointmentsCount.TabIndex = 0;
            this.lblAppointmentsCount.Text = "0";
            // 
            // pnlPatients
            // 
            this.pnlPatients.BackColor = System.Drawing.Color.White;
            this.pnlPatients.Controls.Add(this.panel3);
            this.pnlPatients.Controls.Add(this.lblPatientsText);
            this.pnlPatients.Controls.Add(this.lblPatientsCount);
            this.pnlPatients.Location = new System.Drawing.Point(614, 71);
            this.pnlPatients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPatients.Name = "pnlPatients";
            this.pnlPatients.Size = new System.Drawing.Size(310, 134);
            this.pnlPatients.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(47, 134);
            this.panel3.TabIndex = 2;
            // 
            // lblPatientsText
            // 
            this.lblPatientsText.AutoSize = true;
            this.lblPatientsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsText.Location = new System.Drawing.Point(53, 98);
            this.lblPatientsText.Name = "lblPatientsText";
            this.lblPatientsText.Size = new System.Drawing.Size(232, 22);
            this.lblPatientsText.TabIndex = 1;
            this.lblPatientsText.Text = "Appointments This Week";
            // 
            // lblPatientsCount
            // 
            this.lblPatientsCount.AutoSize = true;
            this.lblPatientsCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsCount.Location = new System.Drawing.Point(148, 16);
            this.lblPatientsCount.Name = "lblPatientsCount";
            this.lblPatientsCount.Size = new System.Drawing.Size(56, 65);
            this.lblPatientsCount.TabIndex = 0;
            this.lblPatientsCount.Text = "0";
            // 
            // pnlInvoices
            // 
            this.pnlInvoices.BackColor = System.Drawing.Color.White;
            this.pnlInvoices.Controls.Add(this.lblInvoicesText);
            this.pnlInvoices.Controls.Add(this.panel4);
            this.pnlInvoices.Controls.Add(this.lblInvoicesCount);
            this.pnlInvoices.Location = new System.Drawing.Point(1177, 71);
            this.pnlInvoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlInvoices.Name = "pnlInvoices";
            this.pnlInvoices.Size = new System.Drawing.Size(294, 134);
            this.pnlInvoices.TabIndex = 4;
            // 
            // lblInvoicesText
            // 
            this.lblInvoicesText.ActiveLinkColor = System.Drawing.Color.Red;
            this.lblInvoicesText.AutoSize = true;
            this.lblInvoicesText.ForeColor = System.Drawing.Color.Red;
            this.lblInvoicesText.LinkColor = System.Drawing.Color.Red;
            this.lblInvoicesText.Location = new System.Drawing.Point(95, 95);
            this.lblInvoicesText.Name = "lblInvoicesText";
            this.lblInvoicesText.Size = new System.Drawing.Size(166, 25);
            this.lblInvoicesText.TabIndex = 5;
            this.lblInvoicesText.TabStop = true;
            this.lblInvoicesText.Text = "Unpaid Invoices";
            this.lblInvoicesText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblInvoicesText_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(47, 134);
            this.panel4.TabIndex = 2;
            // 
            // lblInvoicesCount
            // 
            this.lblInvoicesCount.AutoSize = true;
            this.lblInvoicesCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoicesCount.ForeColor = System.Drawing.Color.Red;
            this.lblInvoicesCount.Location = new System.Drawing.Point(151, 16);
            this.lblInvoicesCount.Name = "lblInvoicesCount";
            this.lblInvoicesCount.Size = new System.Drawing.Size(56, 65);
            this.lblInvoicesCount.TabIndex = 0;
            this.lblInvoicesCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.lBLScheduleHeader);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(20, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1462, 56);
            this.panel1.TabIndex = 5;
            // 
            // lBLScheduleHeader
            // 
            this.lBLScheduleHeader.AutoSize = true;
            this.lBLScheduleHeader.BackColor = System.Drawing.Color.Transparent;
            this.lBLScheduleHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBLScheduleHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(143)))));
            this.lBLScheduleHeader.Location = new System.Drawing.Point(16, 15);
            this.lBLScheduleHeader.Name = "lBLScheduleHeader";
            this.lBLScheduleHeader.Size = new System.Drawing.Size(208, 22);
            this.lBLScheduleHeader.TabIndex = 0;
            this.lBLScheduleHeader.Text = "TODAY\'S SCHEDULE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlAppointments);
            this.groupBox1.Controls.Add(this.pnlPatients);
            this.groupBox1.Controls.Add(this.pnlInvoices);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(100, 185);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1506, 248);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QuickView Stats";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSchedule);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(100, 476);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1506, 402);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QuickView  Appointment Information";
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSchedule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSchedule.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatient,
            this.colTime,
            this.colTreatment,
            this.colStatus});
            this.dgvSchedule.EnableHeadersVisualStyles = false;
            this.dgvSchedule.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvSchedule.Location = new System.Drawing.Point(20, 126);
            this.dgvSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersVisible = false;
            this.dgvSchedule.RowHeadersWidth = 62;
            this.dgvSchedule.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSchedule.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvSchedule.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(105)))), ((int)(((byte)(161)))));
            this.dgvSchedule.RowTemplate.Height = 35;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(1462, 226);
            this.dgvSchedule.TabIndex = 7;
            // 
            // colPatient
            // 
            this.colPatient.HeaderText = "Patient Name";
            this.colPatient.MinimumWidth = 8;
            this.colPatient.Name = "colPatient";
            this.colPatient.ReadOnly = true;
            this.colPatient.Width = 150;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.MinimumWidth = 8;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 150;
            // 
            // colTreatment
            // 
            this.colTreatment.HeaderText = "Treatment";
            this.colTreatment.MinimumWidth = 8;
            this.colTreatment.Name = "colTreatment";
            this.colTreatment.ReadOnly = true;
            this.colTreatment.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Appointment status";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 150;
            // 
            // grpStaffMessages
            // 
            this.grpStaffMessages.Controls.Add(this.btnSend);
            this.grpStaffMessages.Controls.Add(this.txtMessages);
            this.grpStaffMessages.Controls.Add(this.lstMessages);
            this.grpStaffMessages.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStaffMessages.ForeColor = System.Drawing.Color.Blue;
            this.grpStaffMessages.Location = new System.Drawing.Point(88, 918);
            this.grpStaffMessages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStaffMessages.Name = "grpStaffMessages";
            this.grpStaffMessages.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStaffMessages.Size = new System.Drawing.Size(1495, 350);
            this.grpStaffMessages.TabIndex = 9;
            this.grpStaffMessages.TabStop = false;
            this.grpStaffMessages.Text = "Staff Noticeboard";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Teal;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(1340, 252);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(110, 55);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessages
            // 
            this.txtMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessages.ForeColor = System.Drawing.Color.Gray;
            this.txtMessages.Location = new System.Drawing.Point(43, 266);
            this.txtMessages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.Size = new System.Drawing.Size(1256, 35);
            this.txtMessages.TabIndex = 1;
            this.txtMessages.Text = "Type your message here...";
            this.txtMessages.Enter += new System.EventHandler(this.txtMessages_Enter);
            this.txtMessages.Leave += new System.EventHandler(this.txtMessages_Leave);
            // 
            // lstMessages
            // 
            this.lstMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMessages.DataSource = this.staffMessageBindingSource;
            this.lstMessages.DisplayMember = "DisplayText";
            this.lstMessages.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.ItemHeight = 25;
            this.lstMessages.Location = new System.Drawing.Point(24, 38);
            this.lstMessages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(1426, 152);
            this.lstMessages.TabIndex = 0;
            this.lstMessages.ValueMember = "Message_ID";
            this.lstMessages.SelectedIndexChanged += new System.EventHandler(this.lstMessages_SelectedIndexChanged);
            // 
            // staffMessageBindingSource
            // 
            this.staffMessageBindingSource.DataMember = "StaffMessage";
            this.staffMessageBindingSource.DataSource = this.dsDentist;
            // 
            // dsDentist
            // 
            this.dsDentist.DataSetName = "dsDentist";
            this.dsDentist.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // staffMessageTableAdapter
            // 
            this.staffMessageTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AppointmentTableAdapter = null;
            this.tableAdapterManager.Availability_OverrideTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.InvoiceTableAdapter = null;
            this.tableAdapterManager.MedicineTableAdapter = null;
            this.tableAdapterManager.PatientTableAdapter = null;
            this.tableAdapterManager.PatientTreatmentTableAdapter = null;
            this.tableAdapterManager.PaymentTableAdapter = null;
            this.tableAdapterManager.PrescriptionTableAdapter = null;
            this.tableAdapterManager.StaffMessageTableAdapter = this.staffMessageTableAdapter;
            this.tableAdapterManager.TimeslotTableAdapter = null;
            this.tableAdapterManager.Treatment1TableAdapter = null;
            this.tableAdapterManager.TreatmentTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1667, 1050);
            this.Controls.Add(this.grpStaffMessages);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.pnlAppointments.ResumeLayout(false);
            this.pnlAppointments.PerformLayout();
            this.pnlPatients.ResumeLayout(false);
            this.pnlPatients.PerformLayout();
            this.pnlInvoices.ResumeLayout(false);
            this.pnlInvoices.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.grpStaffMessages.ResumeLayout(false);
            this.grpStaffMessages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffMessageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlAppointments;
        private System.Windows.Forms.Panel pnlPatients;
        private System.Windows.Forms.Panel pnlInvoices;
        private System.Windows.Forms.Label lblAppointmentsText;
        private System.Windows.Forms.Label lblAppointmentsCount;
        private System.Windows.Forms.Label lblPatientsCount;
        private System.Windows.Forms.Label lblPatientsText;
        private System.Windows.Forms.Label lblInvoicesCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lBLScheduleHeader;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTreatment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.GroupBox grpStaffMessages;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.Button btnSend;
        private dsDentist dsDentist;
        private System.Windows.Forms.BindingSource staffMessageBindingSource;
        private dsDentistTableAdapters.StaffMessageTableAdapter staffMessageTableAdapter;
        private dsDentistTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.LinkLabel lblInvoicesText;
    }
}