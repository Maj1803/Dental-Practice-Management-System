namespace Dental_Practice_Management_System
{
    partial class MainMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMDI));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.btnStaffForm = new System.Windows.Forms.Button();
            this.btnReportsForm = new System.Windows.Forms.Button();
            this.btnBillingForm = new System.Windows.Forms.Button();
            this.btnTreatmentMedicineForm = new System.Windows.Forms.Button();
            this.btnAppointmentsForm = new System.Windows.Forms.Button();
            this.btnPatientsForm = new System.Windows.Forms.Button();
            this.btnDashboardForm = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.pnlSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(155)))));
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.lblRole);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1582, 78);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(235)))), ((int)(((byte)(211)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnLogout.Location = new System.Drawing.Point(1419, 24);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(137, 39);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(159, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dr MT Khan Dental Practice";
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(22)))), ((int)(((byte)(53)))));
            this.pnlSideBar.Controls.Add(this.btnStaffForm);
            this.pnlSideBar.Controls.Add(this.btnReportsForm);
            this.pnlSideBar.Controls.Add(this.btnBillingForm);
            this.pnlSideBar.Controls.Add(this.btnTreatmentMedicineForm);
            this.pnlSideBar.Controls.Add(this.btnAppointmentsForm);
            this.pnlSideBar.Controls.Add(this.btnPatientsForm);
            this.pnlSideBar.Controls.Add(this.btnDashboardForm);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 78);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(150, 775);
            this.pnlSideBar.TabIndex = 2;
            // 
            // btnStaffForm
            // 
            this.btnStaffForm.FlatAppearance.BorderSize = 0;
            this.btnStaffForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnStaffForm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStaffForm.Location = new System.Drawing.Point(3, 662);
            this.btnStaffForm.Name = "btnStaffForm";
            this.btnStaffForm.Size = new System.Drawing.Size(150, 113);
            this.btnStaffForm.TabIndex = 8;
            this.btnStaffForm.Text = "Staff";
            this.btnStaffForm.UseVisualStyleBackColor = false;
            this.btnStaffForm.Click += new System.EventHandler(this.btnStaffForm_Click);
            // 
            // btnReportsForm
            // 
            this.btnReportsForm.FlatAppearance.BorderSize = 0;
            this.btnReportsForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportsForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnReportsForm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReportsForm.Location = new System.Drawing.Point(0, 542);
            this.btnReportsForm.Name = "btnReportsForm";
            this.btnReportsForm.Size = new System.Drawing.Size(150, 100);
            this.btnReportsForm.TabIndex = 7;
            this.btnReportsForm.Text = "Reports";
            this.btnReportsForm.UseVisualStyleBackColor = false;
            this.btnReportsForm.Click += new System.EventHandler(this.btnReportsForm_Click);
            // 
            // btnBillingForm
            // 
            this.btnBillingForm.FlatAppearance.BorderSize = 0;
            this.btnBillingForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillingForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnBillingForm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBillingForm.Location = new System.Drawing.Point(0, 436);
            this.btnBillingForm.Name = "btnBillingForm";
            this.btnBillingForm.Size = new System.Drawing.Size(150, 100);
            this.btnBillingForm.TabIndex = 6;
            this.btnBillingForm.Text = "Billing";
            this.btnBillingForm.UseVisualStyleBackColor = false;
            this.btnBillingForm.Click += new System.EventHandler(this.btnBillingForm_Click_1);
            // 
            // btnTreatmentMedicineForm
            // 
            this.btnTreatmentMedicineForm.FlatAppearance.BorderSize = 0;
            this.btnTreatmentMedicineForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTreatmentMedicineForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTreatmentMedicineForm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTreatmentMedicineForm.Location = new System.Drawing.Point(0, 318);
            this.btnTreatmentMedicineForm.Name = "btnTreatmentMedicineForm";
            this.btnTreatmentMedicineForm.Size = new System.Drawing.Size(150, 112);
            this.btnTreatmentMedicineForm.TabIndex = 5;
            this.btnTreatmentMedicineForm.Text = "Treatment and  Medicine";
            this.btnTreatmentMedicineForm.UseVisualStyleBackColor = false;
            this.btnTreatmentMedicineForm.Click += new System.EventHandler(this.btnTreatmentMedicineForm_Click_1);
            // 
            // btnAppointmentsForm
            // 
            this.btnAppointmentsForm.FlatAppearance.BorderSize = 0;
            this.btnAppointmentsForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointmentsForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAppointmentsForm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAppointmentsForm.Location = new System.Drawing.Point(0, 212);
            this.btnAppointmentsForm.Name = "btnAppointmentsForm";
            this.btnAppointmentsForm.Size = new System.Drawing.Size(150, 100);
            this.btnAppointmentsForm.TabIndex = 4;
            this.btnAppointmentsForm.Text = "Appointments";
            this.btnAppointmentsForm.UseVisualStyleBackColor = false;
            this.btnAppointmentsForm.Click += new System.EventHandler(this.btnAppointmentsForm_Click_1);
            // 
            // btnPatientsForm
            // 
            this.btnPatientsForm.FlatAppearance.BorderSize = 0;
            this.btnPatientsForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientsForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPatientsForm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPatientsForm.Location = new System.Drawing.Point(0, 106);
            this.btnPatientsForm.Name = "btnPatientsForm";
            this.btnPatientsForm.Size = new System.Drawing.Size(150, 100);
            this.btnPatientsForm.TabIndex = 3;
            this.btnPatientsForm.Text = "Patients";
            this.btnPatientsForm.UseVisualStyleBackColor = false;
            this.btnPatientsForm.Click += new System.EventHandler(this.btnPatientsForm_Click_1);
            // 
            // btnDashboardForm
            // 
            this.btnDashboardForm.FlatAppearance.BorderSize = 0;
            this.btnDashboardForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboardForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDashboardForm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDashboardForm.Location = new System.Drawing.Point(0, 0);
            this.btnDashboardForm.Name = "btnDashboardForm";
            this.btnDashboardForm.Size = new System.Drawing.Size(150, 100);
            this.btnDashboardForm.TabIndex = 0;
            this.btnDashboardForm.Text = "Dashboard";
            this.btnDashboardForm.UseVisualStyleBackColor = false;
            this.btnDashboardForm.Click += new System.EventHandler(this.btnDashboardForm_Click_1);
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblRole.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRole.Location = new System.Drawing.Point(1062, 31);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(0, 26);
            this.lblRole.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 78);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MainMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.pnlSideBar);
            this.Controls.Add(this.pnlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "MainMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dr MT Khan Dental Practice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Button btnDashboardForm;
        private System.Windows.Forms.Button btnPatientsForm;
        private System.Windows.Forms.Button btnStaffForm;
        private System.Windows.Forms.Button btnReportsForm;
        private System.Windows.Forms.Button btnBillingForm;
        private System.Windows.Forms.Button btnTreatmentMedicineForm;
        private System.Windows.Forms.Button btnAppointmentsForm;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}