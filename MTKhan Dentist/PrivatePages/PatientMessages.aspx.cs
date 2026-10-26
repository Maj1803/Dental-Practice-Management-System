
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace MTKhan_Dentist
{
    public partial class PatientMessages : Page
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
            }
        }

        private int GetPatientId()
        {
            if (Session["PatientId"] == null)
                return 0;

            int patientId;

            if (!int.TryParse(
                Session["PatientId"].ToString(), out patientId))
                return 0;

            return patientId;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int patientId = GetPatientId();

            if (patientId <= 0)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadConversation(patientId);
            }
        }

        private void LoadConversation(int patientId)
        {
            using (SqlConnection con =
                new SqlConnection(ConnectionString))
            {
                string sql = @"
                    SELECT Message_ID, Sender_Type,
                           Message_Text, Sent_At
                    FROM dbo.PatientStaffMessage
                    WHERE Patient_ID = @PatientID
                    ORDER BY Sent_At ASC, Message_ID ASC";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(
                        "@PatientID", SqlDbType.Int).Value = patientId;

                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    rptConversation.DataSource = dt;
                    rptConversation.DataBind();

                    pnlNoMessages.Visible = (dt.Rows.Count == 0);
                }

                string updateSql = @"
                    UPDATE dbo.PatientStaffMessage
                    SET Is_Read = 1
                    WHERE Patient_ID = @PatientID
                      AND Sender_Type = 'Staff'
                      AND Is_Read = 0";

                using (SqlCommand cmd =
                    new SqlCommand(updateSql, con))
                {
                    cmd.Parameters.Add(
                        "@PatientID", SqlDbType.Int).Value = patientId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            int patientId = GetPatientId();

            if (patientId <= 0)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            string message = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
            {
                lblStatus.CssClass = "alert alert-warning d-block";
                lblStatus.Text = "Please enter a message before sending.";
                return;
            }

            if (message.Length > 1000)
            {
                lblStatus.CssClass = "alert alert-warning d-block";
                lblStatus.Text = "Your message cannot exceed 1000 characters.";
                return;
            }

            using (SqlConnection con =
                new SqlConnection(ConnectionString))
            {
                con.Open();

                string checkSql = @"
                    SELECT COUNT(*)
                    FROM dbo.Patient
                    WHERE Patient_ID = @PatientID";

                using (SqlCommand checkCmd =
                    new SqlCommand(checkSql, con))
                {
                    checkCmd.Parameters.Add(
                        "@PatientID", SqlDbType.Int).Value = patientId;

                    int patientExists =
                        Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (patientExists == 0)
                    {
                        lblStatus.CssClass = "alert alert-danger d-block";
                        lblStatus.Text =
                            "Your patient account could not be verified. Please log in again.";
                        return;
                    }
                }

                string insertSql = @"
                    INSERT INTO dbo.PatientStaffMessage
                        (Patient_ID, Sender_Type, Sender_Employee_ID,
                         Message_Text, Sent_At, Is_Read)
                    VALUES
                        (@PatientID, 'Patient', NULL,
                         @Message, SYSDATETIME(), 0)";

                using (SqlCommand cmd =
                    new SqlCommand(insertSql, con))
                {
                    cmd.Parameters.Add(
                        "@PatientID", SqlDbType.Int).Value = patientId;

                    cmd.Parameters.Add(
                        "@Message", SqlDbType.NVarChar, 1000).Value = message;

                    cmd.ExecuteNonQuery();
                }
            }

            txtMessage.Text = "";

            lblStatus.CssClass = "alert alert-success d-block";
            lblStatus.Text = "Your message has been sent to the practice.";

            LoadConversation(patientId);
        }
    }
}
