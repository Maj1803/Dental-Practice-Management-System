namespace Dental_Practice_Management_System
{
    partial class Invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoice));
            this.label2 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblApptID = new System.Windows.Forms.Label();
            this.lblDateToday = new System.Windows.Forms.Label();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.lblBalDue = new System.Windows.Forms.Label();
            this.dgvInvoiceTreatment = new System.Windows.Forms.DataGridView();
            this.treatmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDentist = new Dental_Practice_Management_System.dsDentist();
            this.label4 = new System.Windows.Forms.Label();
            this.treatmentTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.TreatmentTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.grpAppointmentDetails = new System.Windows.Forms.GroupBox();
            this.lblPatientNumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAppointment = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grpFees = new System.Windows.Forms.GroupBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceTreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpAppointmentDetails.SuspendLayout();
            this.grpFees.SuspendLayout();
            this.grpPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(796, 587);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(22, 38);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(108, 18);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "Appointment ID";
            this.lblText.Click += new System.EventHandler(this.lblText_Click);
            // 
            // lblApptID
            // 
            this.lblApptID.AutoSize = true;
            this.lblApptID.Location = new System.Drawing.Point(390, 493);
            this.lblApptID.Name = "lblApptID";
            this.lblApptID.Size = new System.Drawing.Size(12, 18);
            this.lblApptID.TabIndex = 4;
            this.lblApptID.Text = ".";
            this.lblApptID.Click += new System.EventHandler(this.lblApptID_Click);
            // 
            // lblDateToday
            // 
            this.lblDateToday.AutoSize = true;
            this.lblDateToday.Location = new System.Drawing.Point(390, 559);
            this.lblDateToday.Name = "lblDateToday";
            this.lblDateToday.Size = new System.Drawing.Size(12, 18);
            this.lblDateToday.TabIndex = 5;
            this.lblDateToday.Text = ".";
            this.lblDateToday.Click += new System.EventHandler(this.lblDateToday_Click);
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.Location = new System.Drawing.Point(989, 587);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(12, 18);
            this.lblInvoiceTotal.TabIndex = 6;
            this.lblInvoiceTotal.Text = ".";
            this.lblInvoiceTotal.Click += new System.EventHandler(this.lblInvoiceTotal_Click);
            // 
            // lblBalDue
            // 
            this.lblBalDue.AutoSize = true;
            this.lblBalDue.Location = new System.Drawing.Point(1298, 66);
            this.lblBalDue.Name = "lblBalDue";
            this.lblBalDue.Size = new System.Drawing.Size(12, 18);
            this.lblBalDue.TabIndex = 7;
            this.lblBalDue.Text = ".";
            this.lblBalDue.Click += new System.EventHandler(this.lblBalDue_Click);
            // 
            // dgvInvoiceTreatment
            // 
            this.dgvInvoiceTreatment.AutoGenerateColumns = false;
            this.dgvInvoiceTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceTreatment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.treatmentNameDataGridViewTextBoxColumn,
            this.treatmentCostDataGridViewTextBoxColumn});
            this.dgvInvoiceTreatment.DataSource = this.treatmentBindingSource;
            this.dgvInvoiceTreatment.Location = new System.Drawing.Point(702, 12);
            this.dgvInvoiceTreatment.Name = "dgvInvoiceTreatment";
            this.dgvInvoiceTreatment.RowHeadersWidth = 51;
            this.dgvInvoiceTreatment.RowTemplate.Height = 24;
            this.dgvInvoiceTreatment.Size = new System.Drawing.Size(343, 118);
            this.dgvInvoiceTreatment.TabIndex = 8;
            this.dgvInvoiceTreatment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // treatmentNameDataGridViewTextBoxColumn
            // 
            this.treatmentNameDataGridViewTextBoxColumn.DataPropertyName = "TreatmentName";
            this.treatmentNameDataGridViewTextBoxColumn.HeaderText = "TreatmentName";
            this.treatmentNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.treatmentNameDataGridViewTextBoxColumn.Name = "treatmentNameDataGridViewTextBoxColumn";
            this.treatmentNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // treatmentCostDataGridViewTextBoxColumn
            // 
            this.treatmentCostDataGridViewTextBoxColumn.DataPropertyName = "TreatmentCost";
            this.treatmentCostDataGridViewTextBoxColumn.HeaderText = "TreatmentCost";
            this.treatmentCostDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.treatmentCostDataGridViewTextBoxColumn.Name = "treatmentCostDataGridViewTextBoxColumn";
            this.treatmentCostDataGridViewTextBoxColumn.Width = 125;
            // 
            // treatmentBindingSource
            // 
            this.treatmentBindingSource.DataMember = "Treatment";
            this.treatmentBindingSource.DataSource = this.dsDentist;
            // 
            // dsDentist
            // 
            this.dsDentist.DataSetName = "dsDentist";
            this.dsDentist.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(891, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "INVOICE - DR MT KHAN";
            // 
            // treatmentTableAdapter
            // 
            this.treatmentTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(483, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Invoice No.";
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Location = new System.Drawing.Point(138, 32);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(0, 18);
            this.lblInvoiceID.TabIndex = 12;
            // 
            // grpAppointmentDetails
            // 
            this.grpAppointmentDetails.Controls.Add(this.lblPatientNumber);
            this.grpAppointmentDetails.Controls.Add(this.lblEmail);
            this.grpAppointmentDetails.Controls.Add(this.lblAppointment);
            this.grpAppointmentDetails.Controls.Add(this.lblPatientName);
            this.grpAppointmentDetails.Controls.Add(this.label9);
            this.grpAppointmentDetails.Controls.Add(this.label8);
            this.grpAppointmentDetails.Controls.Add(this.label7);
            this.grpAppointmentDetails.Controls.Add(this.lblText);
            this.grpAppointmentDetails.Location = new System.Drawing.Point(32, 222);
            this.grpAppointmentDetails.Name = "grpAppointmentDetails";
            this.grpAppointmentDetails.Size = new System.Drawing.Size(1184, 189);
            this.grpAppointmentDetails.TabIndex = 13;
            this.grpAppointmentDetails.TabStop = false;
            this.grpAppointmentDetails.Text = "Patient Information";
            // 
            // lblPatientNumber
            // 
            this.lblPatientNumber.AutoSize = true;
            this.lblPatientNumber.Location = new System.Drawing.Point(249, 114);
            this.lblPatientNumber.Name = "lblPatientNumber";
            this.lblPatientNumber.Size = new System.Drawing.Size(120, 18);
            this.lblPatientNumber.TabIndex = 7;
            this.lblPatientNumber.Text = "lblPatientNumber";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(249, 146);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 18);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "label23";
            // 
            // lblAppointment
            // 
            this.lblAppointment.AutoSize = true;
            this.lblAppointment.Location = new System.Drawing.Point(249, 40);
            this.lblAppointment.Name = "lblAppointment";
            this.lblAppointment.Size = new System.Drawing.Size(54, 18);
            this.lblAppointment.TabIndex = 5;
            this.lblAppointment.Text = "label22";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(249, 74);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(107, 18);
            this.lblPatientName.TabIndex = 4;
            this.lblPatientName.Text = "lblPatientName";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Patient Email";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Patient Phone Number";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Patient Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1052, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 18);
            this.label10.TabIndex = 14;
            this.label10.Text = " Date";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // grpFees
            // 
            this.grpFees.Controls.Add(this.lblGrandTotal);
            this.grpFees.Controls.Add(this.lblVAT);
            this.grpFees.Controls.Add(this.label13);
            this.grpFees.Controls.Add(this.label12);
            this.grpFees.Controls.Add(this.lblTotal);
            this.grpFees.Controls.Add(this.label1);
            this.grpFees.Controls.Add(this.dgvInvoiceTreatment);
            this.grpFees.Location = new System.Drawing.Point(32, 434);
            this.grpFees.Name = "grpFees";
            this.grpFees.Size = new System.Drawing.Size(1184, 294);
            this.grpFees.TabIndex = 15;
            this.grpFees.TabStop = false;
            this.grpFees.Text = "Fees";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Location = new System.Drawing.Point(975, 260);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(54, 18);
            this.lblGrandTotal.TabIndex = 13;
            this.lblGrandTotal.Text = "label15";
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Location = new System.Drawing.Point(975, 212);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(54, 18);
            this.lblVAT.TabIndex = 12;
            this.lblVAT.Text = "label14";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 260);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 18);
            this.label13.TabIndex = 11;
            this.label13.Text = "Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 18);
            this.label12.TabIndex = 4;
            this.label12.Text = "VAT @ 15%";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(975, 163);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(54, 18);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "label11";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Before VAT";
            // 
            // grpPayment
            // 
            this.grpPayment.Controls.Add(this.label20);
            this.grpPayment.Controls.Add(this.lblBalance);
            this.grpPayment.Controls.Add(this.label18);
            this.grpPayment.Controls.Add(this.lblAmountPaid);
            this.grpPayment.Controls.Add(this.label16);
            this.grpPayment.Location = new System.Drawing.Point(32, 771);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(1184, 165);
            this.grpPayment.TabIndex = 16;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Payment";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(862, 127);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(248, 16);
            this.label20.TabIndex = 18;
            this.label20.Text = "PAYMENT SUCCESSFULLY MADE";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(979, 74);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(54, 18);
            this.lblBalance.TabIndex = 17;
            this.lblBalance.Text = "label19";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(22, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 18);
            this.label18.TabIndex = 16;
            this.label18.Text = "Balance Due";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Location = new System.Drawing.Point(975, 40);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(54, 18);
            this.lblAmountPaid.TabIndex = 15;
            this.lblAmountPaid.Text = "label17";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(19, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 18);
            this.label16.TabIndex = 14;
            this.label16.Text = "Amount Paid";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(1120, 200);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 18);
            this.lblDate.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(893, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "26 Mackeurtan Ave , Durban North";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(894, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Durban";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(893, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 18);
            this.label11.TabIndex = 20;
            this.label11.Text = "4068";
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 962);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.grpPayment);
            this.Controls.Add(this.grpFees);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grpAppointmentDetails);
            this.Controls.Add(this.lblInvoiceID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBalDue);
            this.Controls.Add(this.lblInvoiceTotal);
            this.Controls.Add(this.lblDateToday);
            this.Controls.Add(this.lblApptID);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceTreatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpAppointmentDetails.ResumeLayout(false);
            this.grpAppointmentDetails.PerformLayout();
            this.grpFees.ResumeLayout(false);
            this.grpFees.PerformLayout();
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblText;
        private dsDentist dsDentist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource treatmentBindingSource;
        private dsDentistTableAdapters.TreatmentTableAdapter treatmentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatmentCostDataGridViewTextBoxColumn;
        public System.Windows.Forms.Label lblApptID;
        public System.Windows.Forms.Label lblDateToday;
        public System.Windows.Forms.Label lblInvoiceTotal;
        public System.Windows.Forms.Label lblBalDue;
        public System.Windows.Forms.DataGridView dgvInvoiceTreatment;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpAppointmentDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpFees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label lblPatientNumber;
        public System.Windows.Forms.Label lblPatientName;
        public System.Windows.Forms.Label lblInvoiceID;
        public System.Windows.Forms.Label lblGrandTotal;
        public System.Windows.Forms.Label lblVAT;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.GroupBox grpPayment;
        public System.Windows.Forms.Label lblBalance;
        public System.Windows.Forms.Label lblAmountPaid;
        public System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.Label lblAppointment;
        public System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
    }
}