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
            this.txtApptID = new System.Windows.Forms.TextBox();
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.AppointmentTableAdapter();
            this.tableAdapterManager = new Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager();
            this.invoiceTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.InvoiceTableAdapter();
            this.paymentTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.PaymentTableAdapter();
            this.treatmentTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.TreatmentTableAdapter();
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.patientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.PatientTableAdapter();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblnvoiceTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dsDentistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientPhoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientFirstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.invoicedateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicetotalamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicestatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicebalancedueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentistBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtApptID
            // 
            this.txtApptID.Location = new System.Drawing.Point(21, 60);
            this.txtApptID.Name = "txtApptID";
            this.txtApptID.Size = new System.Drawing.Size(171, 22);
            this.txtApptID.TabIndex = 0;
            // 
            // btnTreatment
            // 
            this.btnTreatment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTreatment.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnTreatment.Location = new System.Drawing.Point(21, 260);
            this.btnTreatment.Name = "btnTreatment";
            this.btnTreatment.Size = new System.Drawing.Size(156, 36);
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
            this.dgvTreatment.Location = new System.Drawing.Point(203, 220);
            this.dgvTreatment.Name = "dgvTreatment";
            this.dgvTreatment.ReadOnly = true;
            this.dgvTreatment.RowHeadersWidth = 51;
            this.dgvTreatment.RowTemplate.Height = 24;
            this.dgvTreatment.Size = new System.Drawing.Size(334, 140);
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
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnInvoice.Location = new System.Drawing.Point(249, 383);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(167, 36);
            this.btnInvoice.TabIndex = 4;
            this.btnInvoice.Text = "Generate Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Location = new System.Drawing.Point(251, 304);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(121, 22);
            this.txtPaymentAmount.TabIndex = 5;
            this.txtPaymentAmount.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // cmbMethod
            // 
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Location = new System.Drawing.Point(251, 251);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(121, 24);
            this.cmbMethod.TabIndex = 6;
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Location = new System.Drawing.Point(10, 75);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(121, 22);
            this.txtInvoiceID.TabIndex = 7;
            this.txtInvoiceID.TextChanged += new System.EventHandler(this.txtInvoiceID_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(235, 353);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(251, 22);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSave.Location = new System.Drawing.Point(195, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 36);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Receipt";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(597, 426);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 36);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            // paymentBindingSource
            // 
            this.paymentBindingSource.DataMember = "Payment";
            this.paymentBindingSource.DataSource = this.dsDentist;
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
            this.dgvPatient.Location = new System.Drawing.Point(21, 101);
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            this.dgvPatient.RowHeadersWidth = 51;
            this.dgvPatient.RowTemplate.Height = 24;
            this.dgvPatient.Size = new System.Drawing.Size(531, 90);
            this.dgvPatient.TabIndex = 12;
            // 
            // patientBindingSource
            // 
            this.patientBindingSource.DataMember = "Patient";
            this.patientBindingSource.DataSource = this.dsDentist;
            // 
            // patientTableAdapter
            // 
            this.patientTableAdapter.ClearBeforeFill = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(421, 443);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 16);
            this.lblTotal.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(18, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select Date";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(18, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter Payment Amount";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(18, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select Payment Method";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Search Invoice(Enter Invoice ID)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblnvoiceTotal
            // 
            this.lblnvoiceTotal.AutoSize = true;
            this.lblnvoiceTotal.Location = new System.Drawing.Point(1203, 118);
            this.lblnvoiceTotal.Name = "lblnvoiceTotal";
            this.lblnvoiceTotal.Size = new System.Drawing.Size(10, 16);
            this.lblnvoiceTotal.TabIndex = 15;
            this.lblnvoiceTotal.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(17, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(472, 22);
            this.label5.TabIndex = 13;
            this.label5.Text = "Search Appointment (Enter Patient Name/Appointment ID)";
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(218, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 54);
            this.button1.TabIndex = 18;
            this.button1.Text = "Add Invoice";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(567, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 54);
            this.button2.TabIndex = 19;
            this.button2.Text = "Process Payment";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(155)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(937, 103);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(223, 54);
            this.button3.TabIndex = 20;
            this.button3.Text = "Payment History";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(23, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 520);
            this.panel1.TabIndex = 21;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtApptID);
            this.groupBox3.Controls.Add(this.dgvPatient);
            this.groupBox3.Controls.Add(this.btnTreatment);
            this.groupBox3.Controls.Add(this.btnInvoice);
            this.groupBox3.Controls.Add(this.dgvTreatment);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Location = new System.Drawing.Point(33, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(711, 468);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Invoice";
            // 
            // dsDentistBindingSource
            // 
            this.dsDentistBindingSource.DataSource = this.dsDentist;
            this.dsDentistBindingSource.Position = 0;
            // 
            // patientPhoneNumberDataGridViewTextBoxColumn
            // 
            this.patientPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "Patient_Phone_Number";
            this.patientPhoneNumberDataGridViewTextBoxColumn.HeaderText = "Patient_Phone_Number";
            this.patientPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.patientPhoneNumberDataGridViewTextBoxColumn.Name = "patientPhoneNumberDataGridViewTextBoxColumn";
            this.patientPhoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patientLastNameDataGridViewTextBoxColumn
            // 
            this.patientLastNameDataGridViewTextBoxColumn.DataPropertyName = "Patient_Last_Name";
            this.patientLastNameDataGridViewTextBoxColumn.HeaderText = "Patient_Last_Name";
            this.patientLastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.patientLastNameDataGridViewTextBoxColumn.Name = "patientLastNameDataGridViewTextBoxColumn";
            this.patientLastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patientFirstNameDataGridViewTextBoxColumn
            // 
            this.patientFirstNameDataGridViewTextBoxColumn.DataPropertyName = "Patient_First_Name";
            this.patientFirstNameDataGridViewTextBoxColumn.HeaderText = "Patient_First_Name";
            this.patientFirstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.patientFirstNameDataGridViewTextBoxColumn.Name = "patientFirstNameDataGridViewTextBoxColumn";
            this.patientFirstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(796, 188);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 497);
            this.panel2.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbMethod);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPaymentAmount);
            this.groupBox2.Controls.Add(this.txtInvoiceID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 446);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoicedateDataGridViewTextBoxColumn,
            this.invoicetotalamountDataGridViewTextBoxColumn,
            this.invoicestatusDataGridViewTextBoxColumn,
            this.invoicebalancedueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.invoiceBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(10, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(508, 103);
            this.dataGridView1.TabIndex = 11;
            // 
            // invoicedateDataGridViewTextBoxColumn
            // 
            this.invoicedateDataGridViewTextBoxColumn.DataPropertyName = "invoice_date";
            this.invoicedateDataGridViewTextBoxColumn.HeaderText = "invoice_date";
            this.invoicedateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.invoicedateDataGridViewTextBoxColumn.Name = "invoicedateDataGridViewTextBoxColumn";
            this.invoicedateDataGridViewTextBoxColumn.Width = 125;
            // 
            // invoicetotalamountDataGridViewTextBoxColumn
            // 
            this.invoicetotalamountDataGridViewTextBoxColumn.DataPropertyName = "invoice_total_amount";
            this.invoicetotalamountDataGridViewTextBoxColumn.HeaderText = "invoice_total_amount";
            this.invoicetotalamountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.invoicetotalamountDataGridViewTextBoxColumn.Name = "invoicetotalamountDataGridViewTextBoxColumn";
            this.invoicetotalamountDataGridViewTextBoxColumn.Width = 125;
            // 
            // invoicestatusDataGridViewTextBoxColumn
            // 
            this.invoicestatusDataGridViewTextBoxColumn.DataPropertyName = "invoice_status";
            this.invoicestatusDataGridViewTextBoxColumn.HeaderText = "invoice_status";
            this.invoicestatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.invoicestatusDataGridViewTextBoxColumn.Name = "invoicestatusDataGridViewTextBoxColumn";
            this.invoicestatusDataGridViewTextBoxColumn.Width = 125;
            // 
            // invoicebalancedueDataGridViewTextBoxColumn
            // 
            this.invoicebalancedueDataGridViewTextBoxColumn.DataPropertyName = "invoice_balance_due";
            this.invoicebalancedueDataGridViewTextBoxColumn.HeaderText = "invoice_balance_due";
            this.invoicebalancedueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.invoicebalancedueDataGridViewTextBoxColumn.Name = "invoicebalancedueDataGridViewTextBoxColumn";
            this.invoicebalancedueDataGridViewTextBoxColumn.Width = 125;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(379, 407);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(821, 718);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(517, 260);
            this.panel3.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(26, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment History";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(44, 52);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(203, 38);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Search Payment(Enter Payment ID)";
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 990);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblnvoiceTotal);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotal);
            this.Name = "BillingForm";
            this.Text = "BillingForm";
            this.Load += new System.EventHandler(this.BillingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentistBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtApptID;
        private System.Windows.Forms.Button btnTreatment;
        private System.Windows.Forms.DataGridView dgvTreatment;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
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
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblnvoiceTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatmentCost;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource dsDentistBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientPhoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicedateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicetotalamountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicestatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicebalancedueDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}