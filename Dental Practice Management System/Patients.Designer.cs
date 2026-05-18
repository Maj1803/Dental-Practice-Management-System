namespace Dental_Practice_Management_System
{
    partial class Patients
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewPatients = new System.Windows.Forms.Button();
            this.btnUpdatePatients = new System.Windows.Forms.Button();
            this.btnDeletePatients = new System.Windows.Forms.Button();
            this.btnCreatePatients = new System.Windows.Forms.Button();
            this.pnlViewPatients = new System.Windows.Forms.Panel();
            this.grpViewFilters = new System.Windows.Forms.GroupBox();
            this.lblSearchPatients = new System.Windows.Forms.Label();
            this.txtSearchPatients = new System.Windows.Forms.TextBox();
            this.btnSearchPatients = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchNameToolStrip = new System.Windows.Forms.ToolStrip();
            this.firstNameToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.firstNameToolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.searchNameToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.patientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientFirstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientPhoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientStreetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientSuburbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientCityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientEmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientAllergiesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientDOBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsDentist = new Dental_Practice_Management_System.dsDentist();
            this.patientTableAdapter1 = new Dental_Practice_Management_System.dsDentistTableAdapters.PatientTableAdapter();
            this.pnlViewPatients.SuspendLayout();
            this.grpViewFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.searchNameToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(211, 115);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(126, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Patients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(213, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Manage Patient Details";
            // 
            // btnViewPatients
            // 
            this.btnViewPatients.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnViewPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPatients.Location = new System.Drawing.Point(217, 186);
            this.btnViewPatients.Name = "btnViewPatients";
            this.btnViewPatients.Size = new System.Drawing.Size(151, 37);
            this.btnViewPatients.TabIndex = 3;
            this.btnViewPatients.Text = "View Patients";
            this.btnViewPatients.UseVisualStyleBackColor = true;
            this.btnViewPatients.Click += new System.EventHandler(this.btnViewPatients_Click);
            // 
            // btnUpdatePatients
            // 
            this.btnUpdatePatients.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnUpdatePatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePatients.Location = new System.Drawing.Point(646, 186);
            this.btnUpdatePatients.Name = "btnUpdatePatients";
            this.btnUpdatePatients.Size = new System.Drawing.Size(151, 37);
            this.btnUpdatePatients.TabIndex = 4;
            this.btnUpdatePatients.Text = "Update Patients";
            this.btnUpdatePatients.UseVisualStyleBackColor = true;
            // 
            // btnDeletePatients
            // 
            this.btnDeletePatients.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDeletePatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePatients.Location = new System.Drawing.Point(857, 186);
            this.btnDeletePatients.Name = "btnDeletePatients";
            this.btnDeletePatients.Size = new System.Drawing.Size(151, 37);
            this.btnDeletePatients.TabIndex = 5;
            this.btnDeletePatients.Text = "Delete Patients";
            this.btnDeletePatients.UseVisualStyleBackColor = true;
            // 
            // btnCreatePatients
            // 
            this.btnCreatePatients.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCreatePatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePatients.Location = new System.Drawing.Point(420, 186);
            this.btnCreatePatients.Name = "btnCreatePatients";
            this.btnCreatePatients.Size = new System.Drawing.Size(151, 37);
            this.btnCreatePatients.TabIndex = 6;
            this.btnCreatePatients.Text = "Create Patients";
            this.btnCreatePatients.UseVisualStyleBackColor = true;
            // 
            // pnlViewPatients
            // 
            this.pnlViewPatients.Controls.Add(this.dataGridView1);
            this.pnlViewPatients.Controls.Add(this.grpViewFilters);
            this.pnlViewPatients.Location = new System.Drawing.Point(217, 251);
            this.pnlViewPatients.Name = "pnlViewPatients";
            this.pnlViewPatients.Size = new System.Drawing.Size(881, 447);
            this.pnlViewPatients.TabIndex = 7;
            // 
            // grpViewFilters
            // 
            this.grpViewFilters.BackColor = System.Drawing.SystemColors.Control;
            this.grpViewFilters.Controls.Add(this.btnSearchPatients);
            this.grpViewFilters.Controls.Add(this.txtSearchPatients);
            this.grpViewFilters.Controls.Add(this.lblSearchPatients);
            this.grpViewFilters.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpViewFilters.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpViewFilters.Location = new System.Drawing.Point(23, 17);
            this.grpViewFilters.Name = "grpViewFilters";
            this.grpViewFilters.Size = new System.Drawing.Size(838, 112);
            this.grpViewFilters.TabIndex = 0;
            this.grpViewFilters.TabStop = false;
            this.grpViewFilters.Text = "Patients";
            // 
            // lblSearchPatients
            // 
            this.lblSearchPatients.AutoSize = true;
            this.lblSearchPatients.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchPatients.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSearchPatients.Location = new System.Drawing.Point(6, 30);
            this.lblSearchPatients.Name = "lblSearchPatients";
            this.lblSearchPatients.Size = new System.Drawing.Size(215, 21);
            this.lblSearchPatients.TabIndex = 1;
            this.lblSearchPatients.Text = "Search Patient (Patient Name)";
            this.lblSearchPatients.Click += new System.EventHandler(this.lblSearchAppointments_Click);
            // 
            // txtSearchPatients
            // 
            this.txtSearchPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchPatients.Location = new System.Drawing.Point(10, 63);
            this.txtSearchPatients.Name = "txtSearchPatients";
            this.txtSearchPatients.Size = new System.Drawing.Size(244, 34);
            this.txtSearchPatients.TabIndex = 2;
            // 
            // btnSearchPatients
            // 
            this.btnSearchPatients.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearchPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPatients.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPatients.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchPatients.Location = new System.Drawing.Point(275, 63);
            this.btnSearchPatients.Name = "btnSearchPatients";
            this.btnSearchPatients.Size = new System.Drawing.Size(75, 34);
            this.btnSearchPatients.TabIndex = 3;
            this.btnSearchPatients.Text = "Search";
            this.btnSearchPatients.UseVisualStyleBackColor = true;
            this.btnSearchPatients.Click += new System.EventHandler(this.btnSearchPatients_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patientIDDataGridViewTextBoxColumn,
            this.patientFirstNameDataGridViewTextBoxColumn,
            this.patientLastNameDataGridViewTextBoxColumn,
            this.patientPhoneNumberDataGridViewTextBoxColumn,
            this.patientStreetDataGridViewTextBoxColumn,
            this.patientSuburbDataGridViewTextBoxColumn,
            this.patientCityDataGridViewTextBoxColumn,
            this.patientCodeDataGridViewTextBoxColumn,
            this.patientEmailDataGridViewTextBoxColumn,
            this.patientAllergiesDataGridViewTextBoxColumn,
            this.patientDOBDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(23, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(838, 281);
            this.dataGridView1.TabIndex = 1;
            // 
            // searchNameToolStrip
            // 
            this.searchNameToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.searchNameToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.searchNameToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstNameToolStripLabel1,
            this.firstNameToolStripTextBox1,
            this.searchNameToolStripButton});
            this.searchNameToolStrip.Location = new System.Drawing.Point(0, 0);
            this.searchNameToolStrip.Name = "searchNameToolStrip";
            this.searchNameToolStrip.Size = new System.Drawing.Size(1133, 34);
            this.searchNameToolStrip.TabIndex = 11;
            this.searchNameToolStrip.Text = "searchNameToolStrip";
            this.searchNameToolStrip.Visible = false;
            // 
            // firstNameToolStripLabel1
            // 
            this.firstNameToolStripLabel1.Name = "firstNameToolStripLabel1";
            this.firstNameToolStripLabel1.Size = new System.Drawing.Size(96, 29);
            this.firstNameToolStripLabel1.Text = "FirstName:";
            // 
            // firstNameToolStripTextBox1
            // 
            this.firstNameToolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.firstNameToolStripTextBox1.Name = "firstNameToolStripTextBox1";
            this.firstNameToolStripTextBox1.Size = new System.Drawing.Size(100, 34);
            // 
            // searchNameToolStripButton
            // 
            this.searchNameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.searchNameToolStripButton.Name = "searchNameToolStripButton";
            this.searchNameToolStripButton.Size = new System.Drawing.Size(115, 29);
            this.searchNameToolStripButton.Text = "SearchName";
            this.searchNameToolStripButton.Click += new System.EventHandler(this.searchNameToolStripButton_Click);
            // 
            // patientIDDataGridViewTextBoxColumn
            // 
            this.patientIDDataGridViewTextBoxColumn.DataPropertyName = "Patient_ID";
            this.patientIDDataGridViewTextBoxColumn.HeaderText = "Patient_ID";
            this.patientIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientIDDataGridViewTextBoxColumn.Name = "patientIDDataGridViewTextBoxColumn";
            this.patientIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientFirstNameDataGridViewTextBoxColumn
            // 
            this.patientFirstNameDataGridViewTextBoxColumn.DataPropertyName = "Patient_First_Name";
            this.patientFirstNameDataGridViewTextBoxColumn.HeaderText = "Patient_First_Name";
            this.patientFirstNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientFirstNameDataGridViewTextBoxColumn.Name = "patientFirstNameDataGridViewTextBoxColumn";
            this.patientFirstNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientLastNameDataGridViewTextBoxColumn
            // 
            this.patientLastNameDataGridViewTextBoxColumn.DataPropertyName = "Patient_Last_Name";
            this.patientLastNameDataGridViewTextBoxColumn.HeaderText = "Patient_Last_Name";
            this.patientLastNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientLastNameDataGridViewTextBoxColumn.Name = "patientLastNameDataGridViewTextBoxColumn";
            this.patientLastNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientPhoneNumberDataGridViewTextBoxColumn
            // 
            this.patientPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "Patient_Phone_Number";
            this.patientPhoneNumberDataGridViewTextBoxColumn.HeaderText = "Patient_Phone_Number";
            this.patientPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientPhoneNumberDataGridViewTextBoxColumn.Name = "patientPhoneNumberDataGridViewTextBoxColumn";
            this.patientPhoneNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientStreetDataGridViewTextBoxColumn
            // 
            this.patientStreetDataGridViewTextBoxColumn.DataPropertyName = "Patient_Street";
            this.patientStreetDataGridViewTextBoxColumn.HeaderText = "Patient_Street";
            this.patientStreetDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientStreetDataGridViewTextBoxColumn.Name = "patientStreetDataGridViewTextBoxColumn";
            this.patientStreetDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientSuburbDataGridViewTextBoxColumn
            // 
            this.patientSuburbDataGridViewTextBoxColumn.DataPropertyName = "Patient_Suburb";
            this.patientSuburbDataGridViewTextBoxColumn.HeaderText = "Patient_Suburb";
            this.patientSuburbDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientSuburbDataGridViewTextBoxColumn.Name = "patientSuburbDataGridViewTextBoxColumn";
            this.patientSuburbDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientCityDataGridViewTextBoxColumn
            // 
            this.patientCityDataGridViewTextBoxColumn.DataPropertyName = "Patient_City";
            this.patientCityDataGridViewTextBoxColumn.HeaderText = "Patient_City";
            this.patientCityDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientCityDataGridViewTextBoxColumn.Name = "patientCityDataGridViewTextBoxColumn";
            this.patientCityDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientCodeDataGridViewTextBoxColumn
            // 
            this.patientCodeDataGridViewTextBoxColumn.DataPropertyName = "Patient_Code";
            this.patientCodeDataGridViewTextBoxColumn.HeaderText = "Patient_Code";
            this.patientCodeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientCodeDataGridViewTextBoxColumn.Name = "patientCodeDataGridViewTextBoxColumn";
            this.patientCodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientEmailDataGridViewTextBoxColumn
            // 
            this.patientEmailDataGridViewTextBoxColumn.DataPropertyName = "Patient_Email";
            this.patientEmailDataGridViewTextBoxColumn.HeaderText = "Patient_Email";
            this.patientEmailDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientEmailDataGridViewTextBoxColumn.Name = "patientEmailDataGridViewTextBoxColumn";
            this.patientEmailDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientAllergiesDataGridViewTextBoxColumn
            // 
            this.patientAllergiesDataGridViewTextBoxColumn.DataPropertyName = "Patient_Allergies";
            this.patientAllergiesDataGridViewTextBoxColumn.HeaderText = "Patient_Allergies";
            this.patientAllergiesDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientAllergiesDataGridViewTextBoxColumn.Name = "patientAllergiesDataGridViewTextBoxColumn";
            this.patientAllergiesDataGridViewTextBoxColumn.Width = 150;
            // 
            // patientDOBDataGridViewTextBoxColumn
            // 
            this.patientDOBDataGridViewTextBoxColumn.DataPropertyName = "Patient_DOB";
            this.patientDOBDataGridViewTextBoxColumn.HeaderText = "Patient_DOB";
            this.patientDOBDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.patientDOBDataGridViewTextBoxColumn.Name = "patientDOBDataGridViewTextBoxColumn";
            this.patientDOBDataGridViewTextBoxColumn.Width = 150;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Patient";
            this.bindingSource1.DataSource = this.dsDentist;
            // 
            // dsDentist
            // 
            this.dsDentist.DataSetName = "dsDentist";
            this.dsDentist.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patientTableAdapter1
            // 
            this.patientTableAdapter1.ClearBeforeFill = true;
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dental_Practice_Management_System.Properties.Resources.System_Background;
            this.ClientSize = new System.Drawing.Size(1133, 708);
            this.Controls.Add(this.searchNameToolStrip);
            this.Controls.Add(this.pnlViewPatients);
            this.Controls.Add(this.btnCreatePatients);
            this.Controls.Add(this.btnDeletePatients);
            this.Controls.Add(this.btnUpdatePatients);
            this.Controls.Add(this.btnViewPatients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Name = "Patients";
            this.Text = "Patients";
            this.Load += new System.EventHandler(this.Patients_Load);
            this.pnlViewPatients.ResumeLayout(false);
            this.grpViewFilters.ResumeLayout(false);
            this.grpViewFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.searchNameToolStrip.ResumeLayout(false);
            this.searchNameToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDentist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewPatients;
        private System.Windows.Forms.Button btnUpdatePatients;
        private System.Windows.Forms.Button btnDeletePatients;
        private System.Windows.Forms.Button btnCreatePatients;
        private System.Windows.Forms.Panel pnlViewPatients;
        private System.Windows.Forms.GroupBox grpViewFilters;
        private System.Windows.Forms.Label lblSearchPatients;
        private System.Windows.Forms.TextBox txtSearchPatients;
        private System.Windows.Forms.Button btnSearchPatients;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientPhoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientStreetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientSuburbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientCityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientEmailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientAllergiesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientDOBDataGridViewTextBoxColumn;
        private dsDentist dsDentist;
        private dsDentistTableAdapters.PatientTableAdapter patientTableAdapter1;
        private System.Windows.Forms.ToolStrip searchNameToolStrip;
        private System.Windows.Forms.ToolStripLabel firstNameToolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox firstNameToolStripTextBox1;
        private System.Windows.Forms.ToolStripButton searchNameToolStripButton;
    }
}