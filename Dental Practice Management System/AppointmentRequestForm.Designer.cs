namespace Dental_Practice_Management_System
{
    partial class AppointmentRequestForm
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
            this.lblRefHeader = new System.Windows.Forms.Label();
            this.lblRef = new System.Windows.Forms.Label();
            this.lblPatientHeader = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblRequestedHeader = new System.Windows.Forms.Label();
            this.lblRequested = new System.Windows.Forms.Label();
            this.lblReasonHeader = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Incoming Appointment Request";
            // 
            // lblRefHeader
            // 
            this.lblRefHeader.AutoSize = true;
            this.lblRefHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefHeader.ForeColor = System.Drawing.Color.DimGray;
            this.lblRefHeader.Location = new System.Drawing.Point(20, 70);
            this.lblRefHeader.Name = "lblRefHeader";
            this.lblRefHeader.Size = new System.Drawing.Size(83, 20);
            this.lblRefHeader.TabIndex = 1;
            this.lblRefHeader.Text = "Reference:";
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRef.ForeColor = System.Drawing.Color.Black;
            this.lblRef.Location = new System.Drawing.Point(120, 70);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(0, 23);
            this.lblRef.TabIndex = 2;
            // 
            // lblPatientHeader
            // 
            this.lblPatientHeader.AutoSize = true;
            this.lblPatientHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientHeader.ForeColor = System.Drawing.Color.DimGray;
            this.lblPatientHeader.Location = new System.Drawing.Point(20, 110);
            this.lblPatientHeader.Name = "lblPatientHeader";
            this.lblPatientHeader.Size = new System.Drawing.Size(63, 20);
            this.lblPatientHeader.TabIndex = 3;
            this.lblPatientHeader.Text = "Patient:";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.ForeColor = System.Drawing.Color.Black;
            this.lblPatient.Location = new System.Drawing.Point(120, 110);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(0, 23);
            this.lblPatient.TabIndex = 4;
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRequestedHeader
            // 
            this.lblRequestedHeader.AutoSize = true;
            this.lblRequestedHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestedHeader.ForeColor = System.Drawing.Color.DimGray;
            this.lblRequestedHeader.Location = new System.Drawing.Point(20, 150);
            this.lblRequestedHeader.Name = "lblRequestedHeader";
            this.lblRequestedHeader.Size = new System.Drawing.Size(113, 20);
            this.lblRequestedHeader.TabIndex = 5;
            this.lblRequestedHeader.Text = "Requested for:";
            // 
            // lblRequested
            // 
            this.lblRequested.AutoSize = true;
            this.lblRequested.ForeColor = System.Drawing.Color.Black;
            this.lblRequested.Location = new System.Drawing.Point(120, 150);
            this.lblRequested.Name = "lblRequested";
            this.lblRequested.Size = new System.Drawing.Size(0, 16);
            this.lblRequested.TabIndex = 6;
            // 
            // lblReasonHeader
            // 
            this.lblReasonHeader.AutoSize = true;
            this.lblReasonHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReasonHeader.ForeColor = System.Drawing.Color.DimGray;
            this.lblReasonHeader.Location = new System.Drawing.Point(20, 190);
            this.lblReasonHeader.Name = "lblReasonHeader";
            this.lblReasonHeader.Size = new System.Drawing.Size(64, 20);
            this.lblReasonHeader.TabIndex = 7;
            this.lblReasonHeader.Text = "Reason:";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.ForeColor = System.Drawing.Color.Black;
            this.lblReason.Location = new System.Drawing.Point(20, 215);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(2, 22);
            this.lblReason.TabIndex = 8;
            // 
            // btnDecline
            // 
            this.btnDecline.BackColor = System.Drawing.Color.DarkRed;
            this.btnDecline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecline.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDecline.ForeColor = System.Drawing.Color.White;
            this.btnDecline.Location = new System.Drawing.Point(260, 340);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(130, 45);
            this.btnDecline.TabIndex = 9;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseVisualStyleBackColor = false;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(20, 340);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(220, 45);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirm Appointment";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.Gray;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCloseForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseForm.Location = new System.Drawing.Point(410, 340);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(120, 45);
            this.btnCloseForm.TabIndex = 11;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // AppointmentRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 413);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblReasonHeader);
            this.Controls.Add(this.lblRequested);
            this.Controls.Add(this.lblRequestedHeader);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.lblPatientHeader);
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.lblRefHeader);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Appointment Request";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRefHeader;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Label lblPatientHeader;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblRequestedHeader;
        private System.Windows.Forms.Label lblRequested;
        private System.Windows.Forms.Label lblReasonHeader;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCloseForm;
    }
}