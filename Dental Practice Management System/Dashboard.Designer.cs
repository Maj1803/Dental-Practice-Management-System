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
            this.pnlPatients = new System.Windows.Forms.Panel();
            this.pnlInvoices = new System.Windows.Forms.Panel();
            this.lblAppointmentsCount = new System.Windows.Forms.Label();
            this.lblAppointmentsText = new System.Windows.Forms.Label();
            this.lblPatientsCount = new System.Windows.Forms.Label();
            this.lblPatientsText = new System.Windows.Forms.Label();
            this.lblInvoicesCount = new System.Windows.Forms.Label();
            this.lblInvoicesText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lBLScheduleHeader = new System.Windows.Forms.Label();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAppointments.SuspendLayout();
            this.pnlPatients.SuspendLayout();
            this.pnlInvoices.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(67, 145);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(19, 20);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "0";
            
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.BackColor = System.Drawing.Color.White;
            this.pnlAppointments.Controls.Add(this.lblAppointmentsText);
            this.pnlAppointments.Controls.Add(this.lblAppointmentsCount);
            this.pnlAppointments.Location = new System.Drawing.Point(71, 199);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(237, 95);
            this.pnlAppointments.TabIndex = 2;
            // 
            // pnlPatients
            // 
            this.pnlPatients.BackColor = System.Drawing.Color.White;
            this.pnlPatients.Controls.Add(this.lblPatientsText);
            this.pnlPatients.Controls.Add(this.lblPatientsCount);
            this.pnlPatients.Location = new System.Drawing.Point(403, 199);
            this.pnlPatients.Name = "pnlPatients";
            this.pnlPatients.Size = new System.Drawing.Size(237, 95);
            this.pnlPatients.TabIndex = 3;
            // 
            // pnlInvoices
            // 
            this.pnlInvoices.BackColor = System.Drawing.Color.White;
            this.pnlInvoices.Controls.Add(this.lblInvoicesText);
            this.pnlInvoices.Controls.Add(this.lblInvoicesCount);
            this.pnlInvoices.Location = new System.Drawing.Point(727, 199);
            this.pnlInvoices.Name = "pnlInvoices";
            this.pnlInvoices.Size = new System.Drawing.Size(237, 95);
            this.pnlInvoices.TabIndex = 4;
            // 
            // lblAppointmentsCount
            // 
            this.lblAppointmentsCount.AutoSize = true;
            this.lblAppointmentsCount.Location = new System.Drawing.Point(3, 11);
            this.lblAppointmentsCount.Name = "lblAppointmentsCount";
            this.lblAppointmentsCount.Size = new System.Drawing.Size(18, 20);
            this.lblAppointmentsCount.TabIndex = 0;
            this.lblAppointmentsCount.Text = "0";
            // 
            // lblAppointmentsText
            // 
            this.lblAppointmentsText.AutoSize = true;
            this.lblAppointmentsText.Location = new System.Drawing.Point(3, 64);
            this.lblAppointmentsText.Name = "lblAppointmentsText";
            this.lblAppointmentsText.Size = new System.Drawing.Size(155, 20);
            this.lblAppointmentsText.TabIndex = 0;
            this.lblAppointmentsText.Text = "Appointments Today";
            // 
            // lblPatientsCount
            // 
            this.lblPatientsCount.AutoSize = true;
            this.lblPatientsCount.Location = new System.Drawing.Point(16, 11);
            this.lblPatientsCount.Name = "lblPatientsCount";
            this.lblPatientsCount.Size = new System.Drawing.Size(18, 20);
            this.lblPatientsCount.TabIndex = 0;
            this.lblPatientsCount.Text = "0";
            // 
            // lblPatientsText
            // 
            this.lblPatientsText.AutoSize = true;
            this.lblPatientsText.Location = new System.Drawing.Point(16, 64);
            this.lblPatientsText.Name = "lblPatientsText";
            this.lblPatientsText.Size = new System.Drawing.Size(149, 20);
            this.lblPatientsText.TabIndex = 1;
            this.lblPatientsText.Text = "Registered Patients";
            // 
            // lblInvoicesCount
            // 
            this.lblInvoicesCount.AutoSize = true;
            this.lblInvoicesCount.Location = new System.Drawing.Point(17, 11);
            this.lblInvoicesCount.Name = "lblInvoicesCount";
            this.lblInvoicesCount.Size = new System.Drawing.Size(18, 20);
            this.lblInvoicesCount.TabIndex = 0;
            this.lblInvoicesCount.Text = "0";
            // 
            // lblInvoicesText
            // 
            this.lblInvoicesText.AutoSize = true;
            this.lblInvoicesText.Location = new System.Drawing.Point(17, 64);
            this.lblInvoicesText.Name = "lblInvoicesText";
            this.lblInvoicesText.Size = new System.Drawing.Size(122, 20);
            this.lblInvoicesText.TabIndex = 1;
            this.lblInvoicesText.Text = "Unpaid Invoices";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.lBLScheduleHeader);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(71, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 56);
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
            // dgvSchedule
            // 
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colPatient});
            this.dgvSchedule.Location = new System.Drawing.Point(71, 433);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RowHeadersWidth = 62;
            this.dgvSchedule.RowTemplate.Height = 28;
            this.dgvSchedule.Size = new System.Drawing.Size(893, 226);
            this.dgvSchedule.TabIndex = 6;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.MinimumWidth = 8;
            this.colTime.Name = "colTime";
            this.colTime.Width = 150;
            // 
            // colPatient
            // 
            this.colPatient.HeaderText = "Patient Nmae";
            this.colPatient.MinimumWidth = 8;
            this.colPatient.Name = "colPatient";
            this.colPatient.Width = 150;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 671);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlInvoices);
            this.Controls.Add(this.pnlPatients);
            this.Controls.Add(this.pnlAppointments);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
           
            this.pnlAppointments.ResumeLayout(false);
            this.pnlAppointments.PerformLayout();
            this.pnlPatients.ResumeLayout(false);
            this.pnlPatients.PerformLayout();
            this.pnlInvoices.ResumeLayout(false);
            this.pnlInvoices.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
    }
}