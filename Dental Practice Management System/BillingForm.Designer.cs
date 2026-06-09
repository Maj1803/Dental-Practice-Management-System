namespace Dental_Practice_Management_System
{
    partial class BillingForm
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
            this.txtAppt = new System.Windows.Forms.TextBox();
            this.btnTreatment = new System.Windows.Forms.Button();
            this.dgvTreatment = new System.Windows.Forms.DataGridView();
            this.treatmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsDentist = new Dental_Practice_Management_System.dsDentist();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.btnClear1 = new System.Windows.Forms.Button();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.patientFirstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientPhoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.btnPaymentHistory = new System.Windows.Forms.Button();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.grpInvoice = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.rtxtbxDetails = new System.Windows.Forms.RichTextBox();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.btnClear2 = new System.Windows.Forms.Button();
            this.pnlPaymentHistory = new System.Windows.Forms.Panel();
            this.grpPaymentHistory = new System.Windows.Forms.GroupBox();
            this.rtxtbxPaymentHistory = new System.Windows.Forms.RichTextBox();
            this.btnSearch2 = new System.Windows.Forms.Button();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.btnClear3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.paymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.AppointmentTableAdapter();
            this.tableAdapterManager = new Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager();
            this.invoiceTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.InvoiceTableAdapter();
            this.paymentTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.PaymentTableAdapter();
            this.treatmentTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.TreatmentTableAdapter();
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.PatientTableAdapter();
            this.dsDentistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).BeginInit();
            this.pnlInvoice.SuspendLayout();
            this.grpInvoice.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.grpPayment.SuspendLayout();
            this.pnlPaymentHistory.SuspendLayout();
            this.grpPaymentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentistBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAppt
            // 
            this.txtAppt.Location = new System.Drawing.Point(21, 117);
            this.txtAppt.Name = "txtAppt";
            this.txtAppt.Size = new System.Drawing.Size(171, 38);
            this.txtAppt.TabIndex = 0;
            this.txtAppt.TextChanged += new System.EventHandler(this.txtAppt_TextChanged);
            // 
            // btnTreatment
            // 
            this.btnTreatment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTreatment.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnTreatment.Location = new System.Drawing.Point(101, 464);
            this.btnTreatment.Name = "btnTreatment";
            this.btnTreatment.Size = new System.Drawing.Size(201, 38);
            this.btnTreatment.TabIndex = 1;
            this.btnTreatment.Text = "Load Treatment";
            this.btnTreatment.UseVisualStyleBackColor = true;
            this.btnTreatment.Click += new System.EventHandler(this.btnTreatment_Click);
            // 
            // dgvTreatment
            // 
            this.dgvTreatment.AutoGenerateColumns = false;
            this.dgvTreatment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreatment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.treatmentNameDataGridViewTextBoxColumn,
            this.treatmentCost});
            this.dgvTreatment.DataSource = this.treatmentBindingSource1;
            this.dgvTreatment.Location = new System.Drawing.Point(361, 425);
            this.dgvTreatment.Name = "dgvTreatment";
            this.dgvTreatment.ReadOnly = true;
            this.dgvTreatment.RowHeadersWidth = 51;
            this.dgvTreatment.RowTemplate.Height = 24;
            this.dgvTreatment.Size = new System.Drawing.Size(544, 140);
            this.dgvTreatment.TabIndex = 2;
            // 
            // treatmentNameDataGridViewTextBoxColumn
            // 
            this.treatmentNameDataGridViewTextBoxColumn.DataPropertyName = "TreatmentName";
            this.treatmentNameDataGridViewTextBoxColumn.HeaderText = "TreatmentName";
            this.treatmentNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.treatmentNameDataGridViewTextBoxColumn.Name = "treatmentNameDataGridViewTextBoxColumn";
            this.treatmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // treatmentCost
            // 
            this.treatmentCost.DataPropertyName = "TreatmentCost";
            this.treatmentCost.HeaderText = "TreatmentCost";
            this.treatmentCost.MinimumWidth = 6;
            this.treatmentCost.Name = "treatmentCost";
            this.treatmentCost.ReadOnly = true;
            // 
            // treatmentBindingSource1
            // 
            this.treatmentBindingSource1.DataMember = "Treatment";
            this.treatmentBindingSource1.DataSource = this.dsDentist;
            // 
            // dsDentist
            // 
            this.dsDentist.DataSetName = "dsDentist";
            this.dsDentist.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnInvoice
            // 
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnInvoice.Location = new System.Drawing.Point(477, 571);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(224, 49);
            this.btnInvoice.TabIndex = 4;
            this.btnInvoice.Text = "Generate Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Location = new System.Drawing.Point(912, 198);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(187, 38);
            this.txtPaymentAmount.TabIndex = 5;
            this.txtPaymentAmount.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // cmbMethod
            // 
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Location = new System.Drawing.Point(912, 280);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(187, 39);
            this.cmbMethod.TabIndex = 6;
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Location = new System.Drawing.Point(41, 116);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(179, 38);
            this.txtInvoiceID.TabIndex = 7;
            this.txtInvoiceID.TextChanged += new System.EventHandler(this.txtInvoiceID_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(912, 370);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(282, 30);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnReceipt
            // 
            this.btnReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnReceipt.Location = new System.Drawing.Point(779, 508);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(175, 46);
            this.btnReceipt.TabIndex = 9;
            this.btnReceipt.Text = "Receipt";
            this.btnReceipt.UseVisualStyleBackColor = true;
            this.btnReceipt.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear1
            // 
            this.btnClear1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnClear1.Location = new System.Drawing.Point(1077, 571);
            this.btnClear1.Name = "btnClear1";
            this.btnClear1.Size = new System.Drawing.Size(100, 38);
            this.btnClear1.TabIndex = 10;
            this.btnClear1.Text = "Clear";
            this.btnClear1.UseVisualStyleBackColor = true;
            this.btnClear1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvPatient
            // 
            this.dgvPatient.AutoGenerateColumns = false;
            this.dgvPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patientFirstNameDataGridViewTextBoxColumn,
            this.patientLastNameDataGridViewTextBoxColumn,
            this.patientPhoneNumberDataGridViewTextBoxColumn});
            this.dgvPatient.DataSource = this.patientBindingSource;
            this.dgvPatient.Location = new System.Drawing.Point(20, 208);
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            this.dgvPatient.RowHeadersWidth = 51;
            this.dgvPatient.RowTemplate.Height = 24;
            this.dgvPatient.Size = new System.Drawing.Size(1066, 128);
            this.dgvPatient.TabIndex = 12;
            // 
            // patientFirstNameDataGridViewTextBoxColumn
            // 
            this.patientFirstNameDataGridViewTextBoxColumn.DataPropertyName = "Patient_First_Name";
            this.patientFirstNameDataGridViewTextBoxColumn.HeaderText = "Patient_First_Name";
            this.patientFirstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.patientFirstNameDataGridViewTextBoxColumn.Name = "patientFirstNameDataGridViewTextBoxColumn";
            this.patientFirstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patientLastNameDataGridViewTextBoxColumn
            // 
            this.patientLastNameDataGridViewTextBoxColumn.DataPropertyName = "Patient_Last_Name";
            this.patientLastNameDataGridViewTextBoxColumn.HeaderText = "Patient_Last_Name";
            this.patientLastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.patientLastNameDataGridViewTextBoxColumn.Name = "patientLastNameDataGridViewTextBoxColumn";
            this.patientLastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patientPhoneNumberDataGridViewTextBoxColumn
            // 
            this.patientPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "Patient_Phone_Number";
            this.patientPhoneNumberDataGridViewTextBoxColumn.HeaderText = "Patient_Phone_Number";
            this.patientPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.patientPhoneNumberDataGridViewTextBoxColumn.Name = "patientPhoneNumberDataGridViewTextBoxColumn";
            this.patientPhoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patientBindingSource
            // 
            this.patientBindingSource.DataMember = "Patient";
            this.patientBindingSource.DataSource = this.dsDentist;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(599, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select Date";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(597, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter Payment Amount";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(598, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select Payment Method";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(36, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Search Invoice(Enter Invoice ID)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(15, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(479, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Search Appointment (Enter Appointment ID)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 46);
            this.label6.TabIndex = 16;
            this.label6.Text = "Billing";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(18, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(278, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Manage invoice and payments";
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnAddInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInvoice.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddInvoice.Location = new System.Drawing.Point(259, 133);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(238, 65);
            this.btnAddInvoice.TabIndex = 18;
            this.btnAddInvoice.Text = "Add Invoice";
            this.btnAddInvoice.UseVisualStyleBackColor = false;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnProcessPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessPayment.ForeColor = System.Drawing.SystemColors.Control;
            this.btnProcessPayment.Location = new System.Drawing.Point(593, 133);
            this.btnProcessPayment.Name = "btnProcessPayment";
            this.btnProcessPayment.Size = new System.Drawing.Size(238, 65);
            this.btnProcessPayment.TabIndex = 19;
            this.btnProcessPayment.Text = "Process Payment";
            this.btnProcessPayment.UseVisualStyleBackColor = false;
            this.btnProcessPayment.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPaymentHistory
            // 
            this.btnPaymentHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(155)))));
            this.btnPaymentHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymentHistory.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPaymentHistory.Location = new System.Drawing.Point(933, 133);
            this.btnPaymentHistory.Name = "btnPaymentHistory";
            this.btnPaymentHistory.Size = new System.Drawing.Size(238, 65);
            this.btnPaymentHistory.TabIndex = 20;
            this.btnPaymentHistory.Text = "Payment History";
            this.btnPaymentHistory.UseVisualStyleBackColor = false;
            this.btnPaymentHistory.Click += new System.EventHandler(this.btnPaymentHistory_Click);
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.Controls.Add(this.grpInvoice);
            this.pnlInvoice.Location = new System.Drawing.Point(52, 250);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(1265, 677);
            this.pnlInvoice.TabIndex = 21;
            // 
            // grpInvoice
            // 
            this.grpInvoice.Controls.Add(this.btnSearch);
            this.grpInvoice.Controls.Add(this.label5);
            this.grpInvoice.Controls.Add(this.txtAppt);
            this.grpInvoice.Controls.Add(this.dgvPatient);
            this.grpInvoice.Controls.Add(this.btnTreatment);
            this.grpInvoice.Controls.Add(this.btnInvoice);
            this.grpInvoice.Controls.Add(this.dgvTreatment);
            this.grpInvoice.Controls.Add(this.btnClear1);
            this.grpInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInvoice.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpInvoice.Location = new System.Drawing.Point(33, 19);
            this.grpInvoice.Name = "grpInvoice";
            this.grpInvoice.Size = new System.Drawing.Size(1200, 658);
            this.grpInvoice.TabIndex = 0;
            this.grpInvoice.TabStop = false;
            this.grpInvoice.Text = "Invoice";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSearch.Location = new System.Drawing.Point(226, 117);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(136, 38);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlPayment
            // 
            this.pnlPayment.Controls.Add(this.grpPayment);
            this.pnlPayment.Location = new System.Drawing.Point(52, 250);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(1286, 674);
            this.pnlPayment.TabIndex = 22;
            // 
            // grpPayment
            // 
            this.grpPayment.Controls.Add(this.rtxtbxDetails);
            this.grpPayment.Controls.Add(this.btnShowDetails);
            this.grpPayment.Controls.Add(this.btnClear2);
            this.grpPayment.Controls.Add(this.btnReceipt);
            this.grpPayment.Controls.Add(this.dateTimePicker1);
            this.grpPayment.Controls.Add(this.label1);
            this.grpPayment.Controls.Add(this.label4);
            this.grpPayment.Controls.Add(this.cmbMethod);
            this.grpPayment.Controls.Add(this.label2);
            this.grpPayment.Controls.Add(this.txtPaymentAmount);
            this.grpPayment.Controls.Add(this.txtInvoiceID);
            this.grpPayment.Controls.Add(this.label3);
            this.grpPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPayment.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpPayment.Location = new System.Drawing.Point(33, 20);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(1214, 640);
            this.grpPayment.TabIndex = 0;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Payment";
            // 
            // rtxtbxDetails
            // 
            this.rtxtbxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtbxDetails.Location = new System.Drawing.Point(41, 207);
            this.rtxtbxDetails.Name = "rtxtbxDetails";
            this.rtxtbxDetails.Size = new System.Drawing.Size(509, 267);
            this.rtxtbxDetails.TabIndex = 16;
            this.rtxtbxDetails.Text = "";
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDetails.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnShowDetails.Location = new System.Drawing.Point(295, 116);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(147, 38);
            this.btnShowDetails.TabIndex = 15;
            this.btnShowDetails.Text = "Show Details";
            this.btnShowDetails.UseVisualStyleBackColor = true;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // btnClear2
            // 
            this.btnClear2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnClear2.Location = new System.Drawing.Point(1087, 587);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(107, 32);
            this.btnClear2.TabIndex = 14;
            this.btnClear2.Text = "Clear";
            this.btnClear2.UseVisualStyleBackColor = true;
            this.btnClear2.Click += new System.EventHandler(this.btnClear2_Click);
            // 
            // pnlPaymentHistory
            // 
            this.pnlPaymentHistory.Controls.Add(this.grpPaymentHistory);
            this.pnlPaymentHistory.Location = new System.Drawing.Point(52, 250);
            this.pnlPaymentHistory.Name = "pnlPaymentHistory";
            this.pnlPaymentHistory.Size = new System.Drawing.Size(1286, 674);
            this.pnlPaymentHistory.TabIndex = 23;
            // 
            // grpPaymentHistory
            // 
            this.grpPaymentHistory.Controls.Add(this.rtxtbxPaymentHistory);
            this.grpPaymentHistory.Controls.Add(this.btnSearch2);
            this.grpPaymentHistory.Controls.Add(this.txtPatientName);
            this.grpPaymentHistory.Controls.Add(this.btnClear3);
            this.grpPaymentHistory.Controls.Add(this.label8);
            this.grpPaymentHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPaymentHistory.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpPaymentHistory.Location = new System.Drawing.Point(26, 20);
            this.grpPaymentHistory.Name = "grpPaymentHistory";
            this.grpPaymentHistory.Size = new System.Drawing.Size(1236, 634);
            this.grpPaymentHistory.TabIndex = 0;
            this.grpPaymentHistory.TabStop = false;
            this.grpPaymentHistory.Text = "Payment History";
            // 
            // rtxtbxPaymentHistory
            // 
            this.rtxtbxPaymentHistory.Location = new System.Drawing.Point(47, 289);
            this.rtxtbxPaymentHistory.Name = "rtxtbxPaymentHistory";
            this.rtxtbxPaymentHistory.Size = new System.Drawing.Size(491, 212);
            this.rtxtbxPaymentHistory.TabIndex = 6;
            this.rtxtbxPaymentHistory.Text = "";
            // 
            // btnSearch2
            // 
            this.btnSearch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSearch2.Location = new System.Drawing.Point(395, 164);
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(118, 35);
            this.btnSearch2.TabIndex = 5;
            this.btnSearch2.Text = "Search";
            this.btnSearch2.UseVisualStyleBackColor = true;
            this.btnSearch2.Click += new System.EventHandler(this.btnSearch2_Click);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(48, 160);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(208, 38);
            this.txtPatientName.TabIndex = 4;
            // 
            // btnClear3
            // 
            this.btnClear3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnClear3.Location = new System.Drawing.Point(919, 536);
            this.btnClear3.Name = "btnClear3";
            this.btnClear3.Size = new System.Drawing.Size(114, 40);
            this.btnClear3.TabIndex = 3;
            this.btnClear3.Text = "Clear";
            this.btnClear3.UseVisualStyleBackColor = true;
            this.btnClear3.Click += new System.EventHandler(this.btnClear3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(43, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(470, 29);
            this.label8.TabIndex = 2;
            this.label8.Text = "Search Patient Name (Enter Patient Name)";
            // 
            // paymentBindingSource
            // 
            this.paymentBindingSource.DataMember = "Payment";
            this.paymentBindingSource.DataSource = this.dsDentist;
            // 
            // appointmentBindingSource
            // 
            this.appointmentBindingSource.DataMember = "Appointment";
            this.appointmentBindingSource.DataSource = this.dsDentist;
            // 
            // appointmentTableAdapter
            // 
            this.appointmentTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AppointmentTableAdapter = this.appointmentTableAdapter;
            this.tableAdapterManager.Availability_OverrideTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.InvoiceTableAdapter = this.invoiceTableAdapter;
            this.tableAdapterManager.MedicineTableAdapter = null;
            this.tableAdapterManager.PatientTableAdapter = null;
            this.tableAdapterManager.PatientTreatmentTableAdapter = null;
            this.tableAdapterManager.PaymentTableAdapter = this.paymentTableAdapter;
            this.tableAdapterManager.PrescriptionTableAdapter = null;
            this.tableAdapterManager.StaffMessageTableAdapter = null;
            this.tableAdapterManager.TimeslotTableAdapter = null;
            this.tableAdapterManager.Treatment1TableAdapter = null;
            this.tableAdapterManager.TreatmentTableAdapter = this.treatmentTableAdapter;
            this.tableAdapterManager.UpdateOrder = Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // invoiceTableAdapter
            // 
            this.invoiceTableAdapter.ClearBeforeFill = true;
            // 
            // paymentTableAdapter
            // 
            this.paymentTableAdapter.ClearBeforeFill = true;
            // 
            // treatmentTableAdapter
            // 
            this.treatmentTableAdapter.ClearBeforeFill = true;
            // 
            // invoiceBindingSource
            // 
            this.invoiceBindingSource.DataMember = "Invoice";
            this.invoiceBindingSource.DataSource = this.dsDentist;
            // 
            // patientTableAdapter
            // 
            this.patientTableAdapter.ClearBeforeFill = true;
            // 
            // dsDentistBindingSource
            // 
            this.dsDentistBindingSource.DataSource = this.dsDentist;
            this.dsDentistBindingSource.Position = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 953);
            this.Controls.Add(this.pnlPaymentHistory);
            this.Controls.Add(this.pnlPayment);
            this.Controls.Add(this.pnlInvoice);
            this.Controls.Add(this.btnPaymentHistory);
            this.Controls.Add(this.btnProcessPayment);
            this.Controls.Add(this.btnAddInvoice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "BillingForm";
            this.Text = "BillingForm";
            this.Load += new System.EventHandler(this.BillingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).EndInit();
            this.pnlInvoice.ResumeLayout(false);
            this.grpInvoice.ResumeLayout(false);
            this.grpInvoice.PerformLayout();
            this.pnlPayment.ResumeLayout(false);
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            this.pnlPaymentHistory.ResumeLayout(false);
            this.grpPaymentHistory.ResumeLayout(false);
            this.grpPaymentHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentistBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAppt;
        private System.Windows.Forms.Button btnTreatment;
        private System.Windows.Forms.DataGridView dgvTreatment;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.Button btnClear1;
        private dsDentist dsDentist;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
        private dsDentistTableAdapters.AppointmentTableAdapter appointmentTableAdapter;
        private dsDentistTableAdapters.TableAdapterManager tableAdapterManager;
        private dsDentistTableAdapters.InvoiceTableAdapter invoiceTableAdapter;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
        private dsDentistTableAdapters.PaymentTableAdapter paymentTableAdapter;
        private System.Windows.Forms.BindingSource paymentBindingSource;
        private dsDentistTableAdapters.TreatmentTableAdapter treatmentTableAdapter;
        private System.Windows.Forms.BindingSource treatmentBindingSource1;
        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.BindingSource patientBindingSource;
        private dsDentistTableAdapters.PatientTableAdapter patientTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatmentCost;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.Button btnPaymentHistory;
        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.GroupBox grpInvoice;
        private System.Windows.Forms.BindingSource dsDentistBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientPhoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Button btnClear2;
        private System.Windows.Forms.Panel pnlPaymentHistory;
        private System.Windows.Forms.GroupBox grpPaymentHistory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClear3;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.RichTextBox rtxtbxDetails;
        private System.Windows.Forms.Button btnSearch2;
        private System.Windows.Forms.RichTextBox rtxtbxPaymentHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}