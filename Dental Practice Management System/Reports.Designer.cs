namespace Dental_Practice_Management_System
{
    partial class Reports
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Appointments1 = new Dental_Practice_Management_System.Appointments();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CrystalReport11 = new Dental_Practice_Management_System.CrystalReport1();
            this.dsDentist1 = new Dental_Practice_Management_System.dsDentist();
            this.tableAdapterManager1 = new Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager();
            this.tableAdapterManager2 = new Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager();
            this.appointmentTableAdapter1 = new Dental_Practice_Management_System.dsDentistTableAdapters.AppointmentTableAdapter();
            this.queriesTableAdapter1 = new Dental_Practice_Management_System.dsDentistTableAdapters.QueriesTableAdapter();
            this.queriesTableAdapter2 = new Dental_Practice_Management_System.dsDentistTableAdapters.QueriesTableAdapter();
            this.InvoiceSummary1 = new Dental_Practice_Management_System.InvoiceSummary();
            this.crystalReportViewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TreatmentHistory1 = new Dental_Practice_Management_System.TreatmentHistory();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbPatientName = new System.Windows.Forms.ComboBox();
            this.cmbPatientID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1063, 571);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crystalReportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1055, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Appointments Reports";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.Appointments1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1049, 532);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crystalReportViewer2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1055, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Invoice Summary";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = 0;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(3, 44);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.ReportSource = this.InvoiceSummary1;
            this.crystalReportViewer2.Size = new System.Drawing.Size(1049, 491);
            this.crystalReportViewer2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.crystalReportViewer3);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1055, 538);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Treatment History";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dsDentist1
            // 
            this.dsDentist1.DataSetName = "dsDentist";
            this.dsDentist1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.AppointmentTableAdapter = null;
            this.tableAdapterManager1.Availability_OverrideTableAdapter = null;
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.EmployeeTableAdapter = null;
            this.tableAdapterManager1.InvoiceTableAdapter = null;
            this.tableAdapterManager1.MedicineTableAdapter = null;
            this.tableAdapterManager1.PatientTableAdapter = null;
            this.tableAdapterManager1.PatientTreatmentTableAdapter = null;
            this.tableAdapterManager1.PaymentTableAdapter = null;
            this.tableAdapterManager1.PrescriptionTableAdapter = null;
            this.tableAdapterManager1.StaffMessageTableAdapter = null;
            this.tableAdapterManager1.TimeslotTableAdapter = null;
            this.tableAdapterManager1.Treatment1TableAdapter = null;
            this.tableAdapterManager1.TreatmentTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.AppointmentTableAdapter = null;
            this.tableAdapterManager2.Availability_OverrideTableAdapter = null;
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.Connection = null;
            this.tableAdapterManager2.EmployeeTableAdapter = null;
            this.tableAdapterManager2.InvoiceTableAdapter = null;
            this.tableAdapterManager2.MedicineTableAdapter = null;
            this.tableAdapterManager2.PatientTableAdapter = null;
            this.tableAdapterManager2.PatientTreatmentTableAdapter = null;
            this.tableAdapterManager2.PaymentTableAdapter = null;
            this.tableAdapterManager2.PrescriptionTableAdapter = null;
            this.tableAdapterManager2.StaffMessageTableAdapter = null;
            this.tableAdapterManager2.TimeslotTableAdapter = null;
            this.tableAdapterManager2.Treatment1TableAdapter = null;
            this.tableAdapterManager2.TreatmentTableAdapter = null;
            this.tableAdapterManager2.UpdateOrder = Dental_Practice_Management_System.dsDentistTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // appointmentTableAdapter1
            // 
            this.appointmentTableAdapter1.ClearBeforeFill = true;
            // 
            // crystalReportViewer3
            // 
            this.crystalReportViewer3.ActiveViewIndex = 0;
            this.crystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer3.Location = new System.Drawing.Point(0, 41);
            this.crystalReportViewer3.Name = "crystalReportViewer3";
            this.crystalReportViewer3.ReportSource = this.TreatmentHistory1;
            this.crystalReportViewer3.Size = new System.Drawing.Size(1055, 497);
            this.crystalReportViewer3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbPatientID);
            this.panel1.Controls.Add(this.cmbPatientName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 41);
            this.panel1.TabIndex = 1;
            // 
            // cmbPatientName
            // 
            this.cmbPatientName.FormattingEnabled = true;
            this.cmbPatientName.Location = new System.Drawing.Point(208, 9);
            this.cmbPatientName.Name = "cmbPatientName";
            this.cmbPatientName.Size = new System.Drawing.Size(195, 28);
            this.cmbPatientName.TabIndex = 0;
            // 
            // cmbPatientID
            // 
            this.cmbPatientID.FormattingEnabled = true;
            this.cmbPatientID.Location = new System.Drawing.Point(531, 7);
            this.cmbPatientID.Name = "cmbPatientID";
            this.cmbPatientID.Size = new System.Drawing.Size(180, 28);
            this.cmbPatientID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search patient name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patient ID";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1049, 41);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Patient ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Search patient name:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(531, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(208, 9);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(195, 28);
            this.comboBox2.TabIndex = 0;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 571);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport1 CrystalReport11;
        private dsDentist dsDentist1;
        private dsDentistTableAdapters.TableAdapterManager tableAdapterManager1;
        private dsDentistTableAdapters.TableAdapterManager tableAdapterManager2;
        private dsDentistTableAdapters.AppointmentTableAdapter appointmentTableAdapter1;
        private dsDentistTableAdapters.QueriesTableAdapter queriesTableAdapter1;
        private dsDentistTableAdapters.QueriesTableAdapter queriesTableAdapter2;
        private Appointments Appointments1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private InvoiceSummary InvoiceSummary1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer3;
        private TreatmentHistory TreatmentHistory1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPatientID;
        private System.Windows.Forms.ComboBox cmbPatientName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}