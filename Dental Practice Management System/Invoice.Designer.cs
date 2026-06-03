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
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceTreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(708, 522);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(17, 38);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(157, 25);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "Apopointment ID";
            this.lblText.Click += new System.EventHandler(this.lblText_Click);
            // 
            // lblApptID
            // 
            this.lblApptID.AutoSize = true;
            this.lblApptID.Location = new System.Drawing.Point(347, 438);
            this.lblApptID.Name = "lblApptID";
            this.lblApptID.Size = new System.Drawing.Size(10, 16);
            this.lblApptID.TabIndex = 4;
            this.lblApptID.Text = ".";
            this.lblApptID.Click += new System.EventHandler(this.lblApptID_Click);
            // 
            // lblDateToday
            // 
            this.lblDateToday.AutoSize = true;
            this.lblDateToday.Location = new System.Drawing.Point(347, 497);
            this.lblDateToday.Name = "lblDateToday";
            this.lblDateToday.Size = new System.Drawing.Size(10, 16);
            this.lblDateToday.TabIndex = 5;
            this.lblDateToday.Text = ".";
            this.lblDateToday.Click += new System.EventHandler(this.lblDateToday_Click);
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.Location = new System.Drawing.Point(879, 522);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(10, 16);
            this.lblInvoiceTotal.TabIndex = 6;
            this.lblInvoiceTotal.Text = ".";
            this.lblInvoiceTotal.Click += new System.EventHandler(this.lblInvoiceTotal_Click);
            // 
            // lblBalDue
            // 
            this.lblBalDue.AutoSize = true;
            this.lblBalDue.Location = new System.Drawing.Point(1154, 59);
            this.lblBalDue.Name = "lblBalDue";
            this.lblBalDue.Size = new System.Drawing.Size(10, 16);
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
            this.dgvInvoiceTreatment.Location = new System.Drawing.Point(624, 11);
            this.dgvInvoiceTreatment.Name = "dgvInvoiceTreatment";
            this.dgvInvoiceTreatment.RowHeadersWidth = 51;
            this.dgvInvoiceTreatment.RowTemplate.Height = 24;
            this.dgvInvoiceTreatment.Size = new System.Drawing.Size(305, 105);
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
            this.label4.Location = new System.Drawing.Point(647, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "INVOICE";
            // 
            // treatmentTableAdapter
            // 
            this.treatmentTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(405, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Invoice No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "label6";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblText);
            this.groupBox1.Location = new System.Drawing.Point(28, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1052, 168);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appointment Details";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Dentist Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Patient Phone Number";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Patient Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(935, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = " Date";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dgvInvoiceTreatment);
            this.groupBox2.Location = new System.Drawing.Point(28, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1052, 261);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fees";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Before VAT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(867, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 4;
            this.label12.Text = "VAT @ 15%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 16);
            this.label13.TabIndex = 11;
            this.label13.Text = "Total";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(867, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 16);
            this.label14.TabIndex = 12;
            this.label14.Text = "label14";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(867, 231);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 16);
            this.label15.TabIndex = 13;
            this.label15.Text = "label15";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(28, 685);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1052, 147);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payment";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 16);
            this.label16.TabIndex = 14;
            this.label16.Text = "Amount Paid";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(867, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 16);
            this.label17.TabIndex = 15;
            this.label17.Text = "label17";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 16);
            this.label18.TabIndex = 16;
            this.label18.Text = "Balance Due";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(870, 66);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 16);
            this.label19.TabIndex = 17;
            this.label19.Text = "label19";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(766, 113);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(223, 16);
            this.label20.TabIndex = 18;
            this.label20.Text = "PAYMENT SUCCESSFULLY MADE";
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 855);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBalDue);
            this.Controls.Add(this.lblInvoiceTotal);
            this.Controls.Add(this.lblDateToday);
            this.Controls.Add(this.lblApptID);
            this.Controls.Add(this.label2);
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceTreatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
    }
}