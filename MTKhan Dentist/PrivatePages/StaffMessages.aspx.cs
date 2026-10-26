
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MTKhan_Dentist
{
    public partial class StaffMessages : Page
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

        private int GetEmployeeId()
        {
            if (Session["EmployeeId"] != null)
            {
                int sessionId;
                if (int.TryParse(Session["EmployeeId"].ToString(), out sessionId)
                    && sessionId > 0)
                    return sessionId;
            }

            if (Context.User == null || !Context.User.Identity.IsAuthenticated)
                return 0;

            string email = Context.User.Identity.Name;

            if (string.IsNullOrWhiteSpace(email))
                return 0;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Employee_ID
                  FROM dbo.Employee
                  WHERE Employee_Email = @Email", con))
            {
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 256).Value = email;
                con.Open();

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToInt32(result);
            }
        }

        private bool IsStaffAuthorized()
        {
            bool allowed =
                User.IsInRole("Dentist") ||
                User.IsInRole("Receptionist") ||
                Convert.ToString(Session["Role"]) == "Dentist" ||
                Convert.ToString(Session["Role"]) == "Receptionist";

            return allowed && GetEmployeeId() > 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsStaffAuthorized())
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                ViewState["EmployeeID"] = GetEmployeeId();
                LoadConversations();
            }
        }

        private void LoadConversations()
        {
            DataTable dt = new DataTable();

            string sql = @"
                SELECT
                    m.Patient_ID,
                    LTRIM(RTRIM(
                        ISNULL(p.Patient_First_Name, '') + ' ' +
                        ISNULL(p.Patient_Last_Name, '')
                    )) AS PatientName,
                    (
                        SELECT TOP 1 m2.Message_Text
                        FROM dbo.PatientStaffMessage m2
                        WHERE m2.Patient_ID = m.Patient_ID
                        ORDER BY m2.Sent_At DESC, m2.Message_ID DESC
                    ) AS LastMessage,
                    (
                        SELECT MAX(m3.Sent_At)
                        FROM dbo.PatientStaffMessage m3
                        WHERE m3.Patient_ID = m.Patient_ID
                    ) AS LastMessageAt,
                    (
                        SELECT COUNT(*)
                        FROM dbo.PatientStaffMessage m4
                        WHERE m4.Patient_ID = m.Patient_ID
                          AND m4.Sender_Type = 'Patient'
                          AND m4.Is_Read = 0
                    ) AS UnreadCount
                FROM dbo.PatientStaffMessage m
                INNER JOIN dbo.Patient p ON p.Patient_ID = m.Patient_ID
                GROUP BY m.Patient_ID, p.Patient_First_Name, p.Patient_Last_Name
                ORDER BY LastMessageAt DESC";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            gvConversations.DataSource = dt;
            gvConversations.DataBind();

            pnlNoConversations.Visible = dt.Rows.Count == 0;
        }

        protected void gvConversations_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (!IsStaffAuthorized())
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            int patientId = Convert.ToInt32(
                gvConversations.SelectedDataKey.Value);

            ViewState["SelectedPatientID"] = patientId;

            LoadConversation(patientId);
        }

        private void LoadConversation(int patientId)
        {
            string patientNameSql = @"
                SELECT LTRIM(RTRIM(
                    ISNULL(Patient_First_Name, '') + ' ' +
                    ISNULL(Patient_Last_Name, '')
                ))
                FROM dbo.Patient
                WHERE Patient_ID = @PatientID";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd =
                    new SqlCommand(patientNameSql, con))
                {
                    cmd.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientId;

                    object name = cmd.ExecuteScalar();

                    if (name == null || name == DBNull.Value)
                    {
                        lblStatus.CssClass = "alert alert-danger d-block";
                        lblStatus.Text = "The selected patient could not be found.";
                        pnlConversation.Visible = false;
                        return;
                    }

                    lblSelectedPatient.Text = HttpUtility.HtmlEncode(name.ToString());
                }

                string readSql = @"
                    UPDATE dbo.PatientStaffMessage
                    SET Is_Read = 1
                    WHERE Patient_ID = @PatientID
                      AND Sender_Type = 'Patient'
                      AND Is_Read = 0";

                using (SqlCommand cmd = new SqlCommand(readSql, con))
                {
                    cmd.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientId;
                    cmd.ExecuteNonQuery();
                }
            }

            DataTable dt = new DataTable();

            string conversationSql = @"
                SELECT Sender_Type, Message_Text, Sent_At
                FROM dbo.PatientStaffMessage
                WHERE Patient_ID = @PatientID
                ORDER BY Sent_At ASC, Message_ID ASC";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(conversationSql, con))
            {
                cmd.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientId;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            rptConversation.DataSource = dt;
            rptConversation.DataBind();
            pnlConversation.Visible = true;

            LoadConversations();
        }

        protected void btnSendReply_Click(object sender, EventArgs e)
        {
            if (!IsStaffAuthorized())
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (ViewState["SelectedPatientID"] == null)
            {
                lblStatus.CssClass = "alert alert-warning d-block";
                lblStatus.Text = "Please open a patient conversation first.";
                return;
            }

            int patientId = Convert.ToInt32(ViewState["SelectedPatientID"]);
            int employeeId = GetEmployeeId();
            string reply = txtReply.Text.Trim();

            if (string.IsNullOrWhiteSpace(reply))
            {
                lblStatus.CssClass = "alert alert-warning d-block";
                lblStatus.Text = "Please type a reply before sending.";
                return;
            }

            if (reply.Length > 1000)
            {
                lblStatus.CssClass = "alert alert-warning d-block";
                lblStatus.Text = "Your reply cannot exceed 1000 characters.";
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                string insertSql = @"
                    INSERT INTO dbo.PatientStaffMessage
                        (Patient_ID, Sender_Type, Sender_Employee_ID,
                         Message_Text, Sent_At, Is_Read)
                    VALUES
                        (@PatientID, 'Staff', @EmployeeID,
                         @Message, SYSDATETIME(), 0)";

                using (SqlCommand cmd = new SqlCommand(insertSql, con))
                {
                    cmd.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientId;
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employeeId;
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000).Value = reply;

                    cmd.ExecuteNonQuery();
                }
            }

            txtReply.Text = "";
            lblStatus.CssClass = "alert alert-success d-block";
            lblStatus.Text = "Your reply has been sent.";

            LoadConversation(patientId);
        }

        protected void btnCloseConversation_Click(object sender, EventArgs e)
        {
            pnlConversation.Visible = false;
            ViewState["SelectedPatientID"] = null;
            txtReply.Text = "";
        }
    }
}
