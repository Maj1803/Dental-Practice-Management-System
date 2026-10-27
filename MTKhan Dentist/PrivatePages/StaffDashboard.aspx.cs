using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace MTKhan_Dentist
{
    public partial class StaffDashboard : Page
    {
        private string GetRole()
        {
            if (User.IsInRole("Dentist")) return "Dentist";
            if (User.IsInRole("Receptionist")) return "Receptionist";
            if (Session["Role"] != null) return Session["Role"].ToString();
            return null;
        }

        private string GetEmployeeName(out int empId)
        {
            empId = 0; string name = null;
            string email = User.Identity.Name;
            if (string.IsNullOrEmpty(email)) return null;
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                string sql = "SELECT Employee_ID, Employee_First_Name + ' ' + Employee_Last_Name FROM Employee WHERE Employee_Email = @email";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) { empId = Convert.ToInt32(dr[0]); name = dr[1].ToString(); }
                    }
                }
            }
            return name;
        }

        private void LoadDentists()
        {
            ddlDentist.Items.Clear();
            ddlDentist.Items.Add(new System.Web.UI.WebControls.ListItem("All Dentists", ""));
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = "SELECT Employee_ID, Employee_First_Name + ' ' + Employee_Last_Name FROM Employee WHERE Employee_Role = 'Dentist' ORDER BY Employee_First_Name";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ddlDentist.Items.Add(new System.Web.UI.WebControls.ListItem(dr[1].ToString(), dr[0].ToString()));
                        }
                    }
                }
            }
        }

        private void BindTodayAppointments(int empId, string role, string searchPatient, string searchStatus, string dentistId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = @"
SELECT p.Patient_First_Name + ' ' + p.Patient_Last_Name AS Patient,
       e.Employee_First_Name + ' ' + e.Employee_Last_Name AS Dentist,
       a.Appointment_Date,
       CONVERT(VARCHAR(5), t.Slot_Start_Time, 108) AS Slot_Start_Time,
       a.Appointment_Status
FROM Appointment a
JOIN Patient p ON a.Patient_ID = p.Patient_ID
JOIN Employee e ON a.Employee_ID = e.Employee_ID
JOIN Timeslot t ON a.Timeslot_ID = t.Timeslot_ID
WHERE CAST(a.Appointment_Date AS DATE) = CAST(GETDATE() AS DATE)
";
                if (role == "Dentist")
                    sql += " AND a.Employee_ID = @empId ";
                else if (!string.IsNullOrEmpty(dentistId))
                    sql += " AND a.Employee_ID = @dentistId ";

                if (!string.IsNullOrEmpty(searchPatient))
                    sql += " AND (p.Patient_First_Name LIKE @search OR p.Patient_Last_Name LIKE @search) ";
                if (!string.IsNullOrEmpty(searchStatus))
                    sql += " AND a.Appointment_Status = @status ";

                sql += " ORDER BY t.Slot_Start_Time";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (role == "Dentist")
                        cmd.Parameters.AddWithValue("@empId", empId);
                    else if (!string.IsNullOrEmpty(dentistId))
                        cmd.Parameters.AddWithValue("@dentistId", dentistId);

                    if (!string.IsNullOrEmpty(searchPatient))
                        cmd.Parameters.AddWithValue("@search", "%" + searchPatient + "%");
                    if (!string.IsNullOrEmpty(searchStatus))
                        cmd.Parameters.AddWithValue("@status", searchStatus);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable(); da.Fill(dt);
                        GVToday.DataSource = dt; GVToday.DataBind();

                        if (dt.Rows.Count == 0)
                            lblSearchInfo.Text = (!string.IsNullOrEmpty(searchPatient) || !string.IsNullOrEmpty(searchStatus) || !string.IsNullOrEmpty(dentistId)) ? "No results for your filter on today's schedule." : "No appointments for today.";
                        else
                            lblSearchInfo.Text = dt.Rows.Count + " appointment(s) for today.";
                    }
                }
            }
        }

        private void BindCounts(int empId, string role)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                string baseWhere = " WHERE CAST(Appointment_Date AS DATE) = CAST(GETDATE() AS DATE) ";
                if (role == "Dentist") baseWhere += " AND Employee_ID = @empId ";

                string sql1 = "SELECT COUNT(*) FROM Appointment " + baseWhere + " AND Appointment_Status <> 'Cancelled'";
                string sql2 = "SELECT COUNT(*) FROM Appointment " + baseWhere + " AND Appointment_Status = 'Scheduled'";
                string sql3 = "SELECT COUNT(*) FROM Appointment " + baseWhere + " AND Appointment_Status = 'Cancelled'";

                int c1 = 0, c2 = 0, c3 = 0;
                using (SqlCommand cmd = new SqlCommand(sql1, con)) { if (role == "Dentist") cmd.Parameters.AddWithValue("@empId", empId); c1 = (int)cmd.ExecuteScalar(); }
                using (SqlCommand cmd = new SqlCommand(sql2, con)) { if (role == "Dentist") cmd.Parameters.AddWithValue("@empId", empId); c2 = (int)cmd.ExecuteScalar(); }
                using (SqlCommand cmd = new SqlCommand(sql3, con)) { if (role == "Dentist") cmd.Parameters.AddWithValue("@empId", empId); c3 = (int)cmd.ExecuteScalar(); }

                lblTodayPatients.Text = c1.ToString();
                lblRemaining.Text = c2.ToString();
                lblCancellations.Text = c3.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empId; string displayName = GetEmployeeName(out empId);
                if (string.IsNullOrEmpty(displayName)) displayName = User.Identity.Name;
                lblWelcome.Text = "Welcome back, " + displayName;
                string role = GetRole();
                if (!string.IsNullOrEmpty(role)) lblRole.Text = role;
                ViewState["empId"] = empId; ViewState["role"] = role;

                LoadDentists();
                divDentistFilter.Visible = (role != "Dentist");
                divManageSchedule.Visible = (role == "Dentist");

                BindTodayAppointments(empId, role, null, null, null);
                BindCounts(empId, role);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int empId = ViewState["empId"] != null ? (int)ViewState["empId"] : 0;
            string role = ViewState["role"] as string;
            BindTodayAppointments(empId, role, txtSearch.Text.Trim(), ddlStatus.SelectedValue, ddlDentist.SelectedValue);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = ""; ddlStatus.SelectedIndex = 0; ddlDentist.SelectedIndex = 0;
            int empId = ViewState["empId"] != null ? (int)ViewState["empId"] : 0;
            string role = ViewState["role"] as string;
            BindTodayAppointments(empId, role, null, null, null);
        }
    }
}