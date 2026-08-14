using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class Dashboard : Form
    {
        private string _senderName;

        public Dashboard(string senderName)
        {
            InitializeComponent();

            _senderName = senderName;

            lblDate.Text = "Today is - " +
                           DateTime.Now.ToString("dddd dd MMMM yyyy");

            LoadDashboardData();
        }

        
        // SIMPLE DATA HOLDER FOR A PATIENT'S OUTSTANDING BALANCE
       

        private class PatientBalance
        {
            public int PatientId { get; set; }
            public string PatientName { get; set; }
            public decimal TotalBalance { get; set; }
        }

        // LOAD DASHBOARD DATA
      

        private void LoadDashboardData()
        {
            try
            {
               
                // STAFF MESSAGES
               

                this.staffMessageTableAdapter.Fill(
                    this.dsDentist.StaffMessage);

                ScrollToBottom();


                using (SqlConnection conn =
                    new SqlConnection(
                        Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();


                  
                    // 1. APPOINTMENTS TODAY
                  

                    using (SqlCommand cmd1 = new SqlCommand(
                        @"SELECT COUNT(*)
                          FROM Appointment
                          WHERE CAST(Appointment_Date AS DATE)
                                = CAST(GETDATE() AS DATE)",
                        conn))
                    {
                        lblAppointmentsCount.Text =
                            cmd1.ExecuteScalar().ToString();
                    }


                   
                    // 2. MONTH-TO-DATE REVENUE
                  

                    using (SqlCommand cmd2 = new SqlCommand(
                        @"SELECT ISNULL(SUM(payment_amount), 0)
                          FROM Payment
                          WHERE payment_date >=
                                DATEFROMPARTS(
                                    YEAR(GETDATE()),
                                    MONTH(GETDATE()),
                                    1
                                )
                          AND payment_date <= GETDATE()",
                        conn))
                    {
                        decimal mtdRevenue =
                            Convert.ToDecimal(
                                cmd2.ExecuteScalar());

                        lblMTD.Text =
                            "R " + mtdRevenue.ToString("N2");
                    }


                

                    List<PatientBalance> owingPatients =
                        GetPatientsOwing(conn);

                    lblInvoicesCount.Text =
                        owingPatients.Count.ToString();


                  
                    // 4. TODAY'S SCHEDULE
                  

                    using (SqlCommand cmd4 = new SqlCommand(
                        @"SELECT
                              t.Slot_Start_Time,

                              p.Patient_First_Name + ' ' +
                              p.Patient_Last_Name AS PatientName,

                              tr.TreatmentName,

                              a.Appointment_Status

                          FROM Appointment a

                          INNER JOIN Patient p
                              ON a.Patient_ID =
                                 p.Patient_ID

                          INNER JOIN Timeslot t
                              ON a.Timeslot_ID =
                                 t.Timeslot_ID

                          LEFT JOIN PatientTreatment pt
                              ON a.Appointment_ID =
                                 pt.Appointment_ID

                          LEFT JOIN Treatment tr
                              ON pt.TreatmentID =
                                 tr.TreatmentID

                          WHERE CAST(a.Appointment_Date AS DATE)
                                = CAST(GETDATE() AS DATE)

                          ORDER BY t.Slot_Start_Time",
                        conn))
                    {
                        dgvSchedule.Rows.Clear();

                        using (SqlDataReader reader =
                            cmd4.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvSchedule.Rows.Add(

                                    reader["PatientName"].ToString(),

                                    reader["Slot_Start_Time"].ToString(),

                                    reader["TreatmentName"] == DBNull.Value
                                        ? "No Treatment"
                                        : reader["TreatmentName"].ToString(),

                                    reader["Appointment_Status"].ToString()
                                );
                            }
                        }
                    }

                    dgvSchedule.ClearSelection();
                    dgvSchedule.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading dashboard: " +
                    ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        

        private List<PatientBalance> GetPatientsOwing(SqlConnection conn)
        {
            var results = new List<PatientBalance>();

            using (SqlCommand cmd = new SqlCommand(
                @"SELECT
                      p.Patient_ID,

                      p.Patient_First_Name + ' ' +
                      p.Patient_Last_Name AS PatientName,

                      SUM(i.invoice_balance_due) AS TotalBalance

                  FROM Invoice i

                  INNER JOIN Appointment a
                      ON i.appointment_id =
                         a.Appointment_ID

                  INNER JOIN Patient p
                      ON a.Patient_ID =
                         p.Patient_ID

                  WHERE i.invoice_balance_due > 0

                  GROUP BY
                      p.Patient_ID,
                      p.Patient_First_Name,
                      p.Patient_Last_Name

                  ORDER BY
                      p.Patient_First_Name,
                      p.Patient_Last_Name",
                conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new PatientBalance
                        {
                            PatientId = Convert.ToInt32(reader["Patient_ID"]),
                            PatientName = reader["PatientName"].ToString(),
                            TotalBalance = Convert.ToDecimal(reader["TotalBalance"])
                        });
                    }
                }
            }

            return results;
        }


        // DASHBOARD LOAD
   

        private void Dashboard_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                this.staffMessageTableAdapter.Fill(
                    this.dsDentist.StaffMessage);

                lstMessages.SelectedIndex = -1;

                ScrollToBottom();

                dgvSchedule.ClearSelection();

                dgvSchedule.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading messages: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


       
        // SAVE STAFF MESSAGE
      

        private void staffMessageBindingNavigatorSaveItem_Click(
            object sender,
            EventArgs e)
        {
            this.Validate();

            this.staffMessageBindingSource.EndEdit();

            this.tableAdapterManager.UpdateAll(
                this.dsDentist);
        }


        // SEND MESSAGE
    

        private void btnSend_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessages.Text) ||
                txtMessages.Text ==
                "Type your message here...")
            {
                return;
            }

            try
            {
                this.staffMessageTableAdapter.Insert(
                    _senderName,
                    txtMessages.Text.Trim(),
                    DateTime.Now);

                this.staffMessageTableAdapter.Fill(
                    this.dsDentist.StaffMessage);

                txtMessages.Clear();

                ScrollToBottom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error sending message: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // SCROLL TO BOTTOM
     

        private void ScrollToBottom()
        {
            if (lstMessages.Items.Count > 0)
            {
                lstMessages.TopIndex =
                    lstMessages.Items.Count - 1;
            }
        }

        // MESSAGE TEXTBOX ENTER
     

        private void txtMessages_Enter(
            object sender,
            EventArgs e)
        {
            if (txtMessages.Text ==
                "Type your message here...")
            {
                txtMessages.Clear();

                txtMessages.ForeColor =
                    System.Drawing.Color.Black;
            }
        }


    
        // MESSAGE TEXTBOX LEAVE
   

        private void txtMessages_Leave(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtMessages.Text))
            {
                txtMessages.Text =
                    "Type your message here...";

                txtMessages.ForeColor =
                    System.Drawing.Color.Gray;
            }
        }


        // MESSAGE LIST
     

        private void lstMessages_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (lstMessages.SelectedIndex != -1)
            {
                lstMessages.SelectedIndex = -1;
            }
        }


  
        // GROUP BOX
  

        private void groupBox1_Enter(
            object sender,
            EventArgs e)
        {
        }


        private void lblInvoicesText_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                List<PatientBalance> owingPatients;

                using (SqlConnection conn =
                    new SqlConnection(
                        Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    owingPatients = GetPatientsOwing(conn);
                }


                // NO PATIENTS OWING
          

                if (owingPatients.Count == 0)
                {
                    MessageBox.Show(
                        "There are no patients who still need to pay.",
                        "Patients Owing",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }


             
                // BUILD MESSAGE
              

                var sb = new StringBuilder();
                decimal totalOutstanding = 0;

                foreach (PatientBalance patient in owingPatients)
                {
                    totalOutstanding += patient.TotalBalance;

                    sb.Append(patient.PatientName)
                      .Append(" - R")
                      .Append(patient.TotalBalance.ToString("N2"))
                      .Append(" remaining")
                      .Append(Environment.NewLine);
                }

                sb.Append(Environment.NewLine)
                  .Append("--------------------------------")
                  .Append(Environment.NewLine)
                  .Append("Total Outstanding: R")
                  .Append(totalOutstanding.ToString("N2"));

                // SHOW PATIENTS OWING
              

                MessageBox.Show(
                    sb.ToString(),
                    "Patients Who Still Need to Pay",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading patients owing: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}