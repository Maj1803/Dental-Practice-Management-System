namespace Dental_Practice_Management_System
{
    partial class Dashboard
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
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.lblAppointmentsText = new System.Windows.Forms.Label();
            this.lblAppointmentsCount = new System.Windows.Forms.Label();
            this.pnlPatients = new System.Windows.Forms.Panel();
            this.lblPatientsText = new System.Windows.Forms.Label();
            this.lblPatientsCount = new System.Windows.Forms.Label();
            this.pnlInvoices = new System.Windows.Forms.Panel();
            this.lblInvoicesText = new System.Windows.Forms.Label();
            this.lblInvoicesCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lBLScheduleHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTreatment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAppointments.SuspendLayout();
            this.pnlPatients.SuspendLayout();
            this.pnlInvoices.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(103, 123);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(24, 25);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "0";
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.BackColor = System.Drawing.Color.White;
            this.pnlAppointments.Controls.Add(this.panel2);
            this.pnlAppointments.Controls.Add(this.lblAppointmentsText);
            this.pnlAppointments.Controls.Add(this.lblAppointmentsCount);
            this.pnlAppointments.Location = new System.Drawing.Point(20, 71);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(315, 134);
            this.pnlAppointments.TabIndex = 2;
            // 
            // lblAppointmentsText
            // 
            this.lblAppointmentsText.AutoSize = true;
            this.lblAppointmentsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsText.Location = new System.Drawing.Point(79, 97);
            this.lblAppointmentsText.Name = "lblAppointmentsText";
            this.lblAppointmentsText.Size = new System.Drawing.Size(193, 22);
            this.lblAppointmentsText.TabIndex = 0;
            this.lblAppointmentsText.Text = "Appointments Today";
            // 
            // lblAppointmentsCount
            // 
            this.lblAppointmentsCount.AutoSize = true;
            this.lblAppointmentsCount.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsCount.Location = new System.Drawing.Point(157, 37);
            this.lblAppointmentsCount.Name = "lblAppointmentsCount";
            this.lblAppointmentsCount.Size = new System.Drawing.Size(33, 39);
            this.lblAppointmentsCount.TabIndex = 0;
            this.lblAppointmentsCount.Text = "0";
            // 
            // pnlPatients
            // 
            this.pnlPatients.BackColor = System.Drawing.Color.White;
            this.pnlPatients.Controls.Add(this.panel3);
            this.pnlPatients.Controls.Add(this.lblPatientsText);
            this.pnlPatients.Controls.Add(this.lblPatientsCount);
            this.pnlPatients.Location = new System.Drawing.Point(614, 71);
            this.pnlPatients.Name = "pnlPatients";
            this.pnlPatients.Size = new System.Drawing.Size(311, 134);
            this.pnlPatients.TabIndex = 3;
            // 
            // lblPatientsText
            // 
            this.lblPatientsText.AutoSize = true;
            this.lblPatientsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsText.Location = new System.Drawing.Point(87, 97);
            this.lblPatientsText.Name = "lblPatientsText";
            this.lblPatientsText.Size = new System.Drawing.Size(186, 22);
            this.lblPatientsText.TabIndex = 1;
            this.lblPatientsText.Text = "Registered Patients";
            // 
            // lblPatientsCount
            // 
            this.lblPatientsCount.AutoSize = true;
            this.lblPatientsCount.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsCount.Location = new System.Drawing.Point(150, 37);
            this.lblPatientsCount.Name = "lblPatientsCount";
            this.lblPatientsCount.Size = new System.Drawing.Size(33, 39);
            this.lblPatientsCount.TabIndex = 0;
            this.lblPatientsCount.Text = "0";
            // 
            // pnlInvoices
            // 
            this.pnlInvoices.BackColor = System.Drawing.Color.White;
            this.pnlInvoices.Controls.Add(this.panel4);
            this.pnlInvoices.Controls.Add(this.lblInvoicesText);
            this.pnlInvoices.Controls.Add(this.lblInvoicesCount);
            this.pnlInvoices.Location = new System.Drawing.Point(1177, 71);
            this.pnlInvoices.Name = "pnlInvoices";
            this.pnlInvoices.Size = new System.Drawing.Size(294, 134);
            this.pnlInvoices.TabIndex = 4;
            // 
            // lblInvoicesText
            // 
            this.lblInvoicesText.AutoSize = true;
            this.lblInvoicesText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoicesText.Location = new System.Drawing.Point(96, 97);
            this.lblInvoicesText.Name = "lblInvoicesText";
            this.lblInvoicesText.Size = new System.Drawing.Size(152, 22);
            this.lblInvoicesText.TabIndex = 1;
            this.lblInvoicesText.Text = "Unpaid Invoices";
            // 
            // lblInvoicesCount
            // 
            this.lblInvoicesCount.AutoSize = true;
            this.lblInvoicesCount.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoicesCount.Location = new System.Drawing.Point(153, 37);
            this.lblInvoicesCount.Name = "lblInvoicesCount";
            this.lblInvoicesCount.Size = new System.Drawing.Size(33, 39);
            this.lblInvoicesCount.TabIndex = 0;
            this.lblInvoicesCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.lBLScheduleHeader);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(20, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1462, 56);
            this.panel1.TabIndex = 5;
            // 
            // lBLScheduleHeader
            // 
            this.lBLScheduleHeader.AutoSize = true;
            this.lBLScheduleHeader.BackColor = System.Drawing.Color.Transparent;
            this.lBLScheduleHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBLScheduleHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(143)))));
            this.lBLScheduleHeader.Location = new System.Drawing.Point(16, 15);
            this.lBLScheduleHeader.Name = "lBLScheduleHeader";
            this.lBLScheduleHeader.Size = new System.Drawing.Size(208, 22);
            this.lBLScheduleHeader.TabIndex = 0;
            this.lBLScheduleHeader.Text = "TODAY\'S SCHEDULE";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(47, 134);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(47, 134);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(47, 134);
            this.panel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlAppointments);
            this.groupBox1.Controls.Add(this.pnlPatients);
            this.groupBox1.Controls.Add(this.pnlInvoices);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(100, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1506, 248);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QuickView Stats";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSchedule);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(100, 476);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1506, 403);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QuickView  Appointment Information";
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatient,
            this.colTime,
            this.colTreatment,
            this.colStatus});
            this.dgvSchedule.Location = new System.Drawing.Point(20, 126);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RowHeadersWidth = 62;
            this.dgvSchedule.RowTemplate.Height = 28;
            this.dgvSchedule.Size = new System.Drawing.Size(1462, 226);
            this.dgvSchedule.TabIndex = 7;
            // 
            // colPatient
            // 
            this.colPatient.HeaderText = "Patient Name";
            this.colPatient.MinimumWidth = 8;
            this.colPatient.Name = "colPatient";
            this.colPatient.Width = 150;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.MinimumWidth = 8;
            this.colTime.Name = "colTime";
            this.colTime.Width = 150;
            // 
            // colTreatment
            // 
            this.colTreatment.HeaderText = "Treatment";
            this.colTreatment.MinimumWidth = 8;
            this.colTreatment.Name = "colTreatment";
            this.colTreatment.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Appointment status";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 150;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1644, 797);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.pnlAppointments.ResumeLayout(false);
            this.pnlAppointments.PerformLayout();
            this.pnlPatients.ResumeLayout(false);
            this.pnlPatients.PerformLayout();
            this.pnlInvoices.ResumeLayout(false);
            this.pnlInvoices.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlAppointments;
        private System.Windows.Forms.Panel pnlPatients;
        private System.Windows.Forms.Panel pnlInvoices;
        private System.Windows.Forms.Label lblAppointmentsText;
        private System.Windows.Forms.Label lblAppointmentsCount;
        private System.Windows.Forms.Label lblPatientsCount;
        private System.Windows.Forms.Label lblPatientsText;
        private System.Windows.Forms.Label lblInvoicesText;
        private System.Windows.Forms.Label lblInvoicesCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lBLScheduleHeader;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTreatment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}