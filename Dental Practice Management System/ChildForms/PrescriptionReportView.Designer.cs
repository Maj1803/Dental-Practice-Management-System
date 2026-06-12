namespace Dental_Practice_Management_System
{
    partial class PrescriptionReportView
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
            this.crystalReportViewerPrescription = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerPrescription
            // 
            this.crystalReportViewerPrescription.ActiveViewIndex = -1;
            this.crystalReportViewerPrescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerPrescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerPrescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerPrescription.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerPrescription.Name = "crystalReportViewerPrescription";
            this.crystalReportViewerPrescription.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewerPrescription.TabIndex = 0;
            // 
            // PrescriptionReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewerPrescription);
            this.Name = "PrescriptionReportView";
            this.Text = "PrescriptionReportView";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerPrescription;
    }
}