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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblApptID = new System.Windows.Forms.Label();
            this.lblDateToday = new System.Windows.Forms.Label();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.lblBalDue = new System.Windows.Forms.Label();
            this.dgvInvoiceTreatment = new System.Windows.Forms.DataGridView();
            this.dsDentist = new Dental_Practice_Management_System.dsDentist();
            this.label4 = new System.Windows.Forms.Label();
            this.treatmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treatmentTableAdapter = new Dental_Practice_Management_System.dsDentistTableAdapters.TreatmentTableAdapter();
            this.treatmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceTreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(351, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Balance Due";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(12, 125);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(133, 20);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "Apopointment ID";
            this.lblText.Click += new System.EventHandler(this.lblText_Click);
            // 
            // lblApptID
            // 
            this.lblApptID.AutoSize = true;
            this.lblApptID.Location = new System.Drawing.Point(174, 125);
            this.lblApptID.Name = "lblApptID";
            this.lblApptID.Size = new System.Drawing.Size(10, 16);
            this.lblApptID.TabIndex = 4;
            this.lblApptID.Text = ".";
            this.lblApptID.Click += new System.EventHandler(this.lblApptID_Click);
            // 
            // lblDateToday
            // 
            this.lblDateToday.AutoSize = true;
            this.lblDateToday.Location = new System.Drawing.Point(174, 173);
            this.lblDateToday.Name = "lblDateToday";
            this.lblDateToday.Size = new System.Drawing.Size(10, 16);
            this.lblDateToday.TabIndex = 5;
            this.lblDateToday.Text = ".";
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.Location = new System.Drawing.Point(424, 354);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(10, 16);
            this.lblInvoiceTotal.TabIndex = 6;
            this.lblInvoiceTotal.Text = ".";
            // 
            // lblBalDue
            // 
            this.lblBalDue.AutoSize = true;
            this.lblBalDue.Location = new System.Drawing.Point(424, 387);
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
            this.dgvInvoiceTreatment.Location = new System.Drawing.Point(151, 205);
            this.dgvInvoiceTreatment.Name = "dgvInvoiceTreatment";
            this.dgvInvoiceTreatment.RowHeadersWidth = 51;
            this.dgvInvoiceTreatment.RowTemplate.Height = 24;
            this.dgvInvoiceTreatment.Size = new System.Drawing.Size(305, 105);
            this.dgvInvoiceTreatment.TabIndex = 8;
            this.dgvInvoiceTreatment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dsDentist
            // 
            this.dsDentist.DataSetName = "dsDentist";
            this.dsDentist.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(183, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "DR MR KHAN - INVOICE";
            // 
            // treatmentBindingSource
            // 
            this.treatmentBindingSource.DataMember = "Treatment";
            this.treatmentBindingSource.DataSource = this.dsDentist;
            // 
            // treatmentTableAdapter
            // 
            this.treatmentTableAdapter.ClearBeforeFill = true;
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
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvInvoiceTreatment);
            this.Controls.Add(this.lblBalDue);
            this.Controls.Add(this.lblInvoiceTotal);
            this.Controls.Add(this.lblDateToday);
            this.Controls.Add(this.lblApptID);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceTreatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
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
    }
}