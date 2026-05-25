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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblApptID = new System.Windows.Forms.Label();
            this.lblDateToday = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblBalDue = new System.Windows.Forms.Label();
            this.dgvInvoiceTreatment = new System.Windows.Forms.DataGridView();
            this.dsDentist = new Dental_Practice_Management_System.dsDentist();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceTreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Balance Due";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(33, 43);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(106, 16);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "Apopointment ID";
            // 
            // lblApptID
            // 
            this.lblApptID.AutoSize = true;
            this.lblApptID.Location = new System.Drawing.Point(192, 43);
            this.lblApptID.Name = "lblApptID";
            this.lblApptID.Size = new System.Drawing.Size(44, 16);
            this.lblApptID.TabIndex = 4;
            this.lblApptID.Text = "label4";
            // 
            // lblDateToday
            // 
            this.lblDateToday.AutoSize = true;
            this.lblDateToday.Location = new System.Drawing.Point(192, 89);
            this.lblDateToday.Name = "lblDateToday";
            this.lblDateToday.Size = new System.Drawing.Size(44, 16);
            this.lblDateToday.TabIndex = 5;
            this.lblDateToday.Text = "label5";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(372, 255);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 16);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "label6";
            // 
            // lblBalDue
            // 
            this.lblBalDue.AutoSize = true;
            this.lblBalDue.Location = new System.Drawing.Point(372, 301);
            this.lblBalDue.Name = "lblBalDue";
            this.lblBalDue.Size = new System.Drawing.Size(44, 16);
            this.lblBalDue.TabIndex = 7;
            this.lblBalDue.Text = "label7";
            // 
            // dgvInvoiceTreatment
            // 
            this.dgvInvoiceTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceTreatment.Location = new System.Drawing.Point(148, 136);
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
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvInvoiceTreatment);
            this.Controls.Add(this.lblBalDue);
            this.Controls.Add(this.lblTotal);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblApptID;
        private System.Windows.Forms.Label lblDateToday;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblBalDue;
        private System.Windows.Forms.DataGridView dgvInvoiceTreatment;
        private dsDentist dsDentist;
    }
}