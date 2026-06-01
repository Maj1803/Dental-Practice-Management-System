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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tsNavigation = new System.Windows.Forms.ToolStrip();
            this.btnDashboard = new System.Windows.Forms.ToolStripButton();
            this.btnPatients = new System.Windows.Forms.ToolStripButton();
            this.btnAppointments = new System.Windows.Forms.ToolStripButton();
            this.btnTreatments = new System.Windows.Forms.ToolStripButton();
            this.btnBilling = new System.Windows.Forms.ToolStripButton();
            this.btnReports = new System.Windows.Forms.ToolStripButton();
            this.btnStaff = new System.Windows.Forms.ToolStripButton();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tsNavigation.SuspendLayout();
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
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1186, 63);
            this.pnlHeader.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 63);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblRole.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRole.Location = new System.Drawing.Point(796, 25);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(0, 22);
            this.lblRole.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(235)))), ((int)(((byte)(211)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnLogout.Location = new System.Drawing.Point(1064, 11);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(103, 41);
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
            this.label1.Location = new System.Drawing.Point(141, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dr MT Khan Dental Practice";
            // 
            // tsNavigation
            // 
            this.tsNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(22)))), ((int)(((byte)(53)))));
            this.tsNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsNavigation.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.tsNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDashboard,
            this.btnPatients,
            this.btnAppointments,
            this.btnTreatments,
            this.btnBilling,
            this.btnReports,
            this.btnStaff});
            this.tsNavigation.Location = new System.Drawing.Point(0, 63);
            this.tsNavigation.Name = "tsNavigation";
            this.tsNavigation.Size = new System.Drawing.Size(149, 630);
            this.tsNavigation.TabIndex = 4;
            // 
            // btnDashboard
            // 
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2, 5, 0, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(144, 29);
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnPatients
            // 
            this.btnPatients.ForeColor = System.Drawing.Color.White;
            this.btnPatients.Image = ((System.Drawing.Image)(resources.GetObject("btnPatients.Image")));
            this.btnPatients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatients.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPatients.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(144, 29);
            this.btnPatients.Text = "Patients";
            this.btnPatients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.ForeColor = System.Drawing.Color.White;
            this.btnAppointments.Image = ((System.Drawing.Image)(resources.GetObject("btnAppointments.Image")));
            this.btnAppointments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAppointments.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(144, 29);
            this.btnAppointments.Text = "Appointments";
            this.btnAppointments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // btnTreatments
            // 
            this.btnTreatments.ForeColor = System.Drawing.Color.White;
            this.btnTreatments.Image = ((System.Drawing.Image)(resources.GetObject("btnTreatments.Image")));
            this.btnTreatments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTreatments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTreatments.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.btnTreatments.Name = "btnTreatments";
            this.btnTreatments.Size = new System.Drawing.Size(144, 29);
            this.btnTreatments.Text = "Treatments";
            this.btnTreatments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTreatments.Click += new System.EventHandler(this.btnTreatments_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.ForeColor = System.Drawing.Color.White;
            this.btnBilling.Image = ((System.Drawing.Image)(resources.GetObject("btnBilling.Image")));
            this.btnBilling.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilling.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBilling.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(144, 29);
            this.btnBilling.Text = "Billing";
            this.btnBilling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnReports
            // 
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReports.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(144, 29);
            this.btnReports.Text = "Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Image = ((System.Drawing.Image)(resources.GetObject("btnStaff.Image")));
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStaff.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(144, 29);
            this.btnStaff.Text = "Staff";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // MainMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1186, 693);
            this.Controls.Add(this.tsNavigation);
            this.Controls.Add(this.pnlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1027, 591);
            this.Name = "MainMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dr MT Khan Dental Practice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tsNavigation.ResumeLayout(false);
            this.tsNavigation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip tsNavigation;
        private System.Windows.Forms.ToolStripButton btnDashboard;
        private System.Windows.Forms.ToolStripButton btnPatients;
        private System.Windows.Forms.ToolStripButton btnAppointments;
        private System.Windows.Forms.ToolStripButton btnTreatments;
        private System.Windows.Forms.ToolStripButton btnBilling;
        private System.Windows.Forms.ToolStripButton btnReports;
        private System.Windows.Forms.ToolStripButton btnStaff;
    }
}