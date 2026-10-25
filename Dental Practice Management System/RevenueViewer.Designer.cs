namespace Dental_Practice_Management_System
{
    partial class RevenueViewer
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
            this.cmbDentistFilter = new System.Windows.Forms.ComboBox();
            this.cmbMethodFilter = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            //
            // cmbDentistFilter
            //
            this.cmbDentistFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.cmbDentistFilter.FormattingEnabled = true;
            this.cmbDentistFilter.Location = new System.Drawing.Point(113, 22);
            this.cmbDentistFilter.Name = "cmbDentistFilter";
            this.cmbDentistFilter.Size = new System.Drawing.Size(220, 34);
            this.cmbDentistFilter.TabIndex = 0;
            //
            // cmbMethodFilter
            //
            this.cmbMethodFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.cmbMethodFilter.FormattingEnabled = true;
            this.cmbMethodFilter.Location = new System.Drawing.Point(420, 22);
            this.cmbMethodFilter.Name = "cmbMethodFilter";
            this.cmbMethodFilter.Size = new System.Drawing.Size(130, 34);
            this.cmbMethodFilter.TabIndex = 1;
            //
            // dtpStart
            //
            this.dtpStart.CustomFormat = "yyyy/MM/dd";
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(660, 22);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(170, 32);
            this.dtpStart.TabIndex = 2;
            //
            // dtpEnd
            //
            this.dtpEnd.CustomFormat = "yyyy/MM/dd";
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(900, 22);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(170, 32);
            this.dtpEnd.TabIndex = 3;
            //
            // btnGenerate
            //
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(1100, 13);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(140, 54);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            //
            // crystalReportViewer1
            //
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(20, 80);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1240, 660);
            this.crystalReportViewer1.TabIndex = 5;
            this.crystalReportViewer1.ToolPanelWidth = 267;
            //
            // RevenueViewer
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.cmbMethodFilter);
            this.Controls.Add(this.cmbDentistFilter);
            this.Location = new System.Drawing.Point(20, 90);
            this.Name = "RevenueViewer";
            this.Text = "RevenueViewer";
            this.Load += new System.EventHandler(this.RevenueViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDentistFilter;
        private System.Windows.Forms.ComboBox cmbMethodFilter;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnGenerate;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}
