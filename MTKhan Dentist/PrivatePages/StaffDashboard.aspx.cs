using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace MTKhan_Dentist
{
    public partial class StaffDashboard : Page
    {
        private int employeeId;
        private string employeeRole;
        private bool pageReady;

        private string GetRole()
        {
            if (User.IsInRole("Dentist")) return "Dentist";
            if (User.IsInRole("Receptionist")) return "Receptionist";
            if (Session["Role"] != null) return Session["Role"].ToString();
            return null;
        }

        private static string NormaliseRole(string role)
        {
            if (string.Equals(role, "Dentist", StringComparison.OrdinalIgnoreCase)) return "Dentist";
            if (string.Equals(role, "Receptionist", StringComparison.OrdinalIgnoreCase)) return "Receptionist";
            return null;
        }

        private string GetEmployeeName(out int empId, out string dbRole)
        {
            empId = 0; dbRole = null; string name = null;
            string email = User.Identity.Name;
            if (string.IsNullOrEmpty(email)) return null;
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                string sql = @"SELECT TOP 1 e.Employee_ID, e.Employee_First_Name + ' ' + e.Employee_Last_Name, e.Employee_Role
                               FROM Employee e
                               LEFT JOIN AspNetUsers u ON u.Id = e.AspNetUserId
                               WHERE e.Employee_Email = @email OR u.UserName = @email OR u.Email = @email";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            empId = Convert.ToInt32(dr[0]);
                            name = dr[1].ToString();
                            dbRole = dr[2].ToString().Trim();
                        }
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

                string sql1 = "SELECT COUNT(DISTINCT Patient_ID) FROM Appointment " + baseWhere + " AND Appointment_Status <> 'Cancelled'";
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

        private void ShowError()
        {
            lblPageError.Text = "The database could not be reached. Check your connection and refresh the page.";
            lblPageError.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string displayName;
            try
            {
                string dbRole;
                displayName = GetEmployeeName(out employeeId, out dbRole);
                employeeRole = NormaliseRole(GetRole()) ?? NormaliseRole(dbRole);
            }
            catch (SqlException)
            {
                ShowError();
                return;
            }

            if (employeeId == 0 || employeeRole == null)
            {
                Response.Redirect("~/");
                return;
            }

            pageReady = true;
            divDentistFilter.Visible = (employeeRole != "Dentist");
            divManageSchedule.Visible = (employeeRole == "Dentist");

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(displayName)) displayName = User.Identity.Name;
                lblWelcome.Text = "Welcome back, " + displayName;
                lblRole.Text = employeeRole;

                try
                {
                    LoadDentists();
                    BindTodayAppointments(employeeId, employeeRole, null, null, null);
                    BindCounts(employeeId, employeeRole);
                }
                catch (SqlException)
                {
                    ShowError();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!pageReady) return;
            try
            {
                BindTodayAppointments(employeeId, employeeRole, txtSearch.Text.Trim(), ddlStatus.SelectedValue, ddlDentist.SelectedValue);
            }
            catch (SqlException)
            {
                ShowError();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (!pageReady) return;
            txtSearch.Text = ""; ddlStatus.SelectedIndex = 0; ddlDentist.SelectedIndex = 0;
            try
            {
                BindTodayAppointments(employeeId, employeeRole, null, null, null);
            }
            catch (SqlException)
            {
                ShowError();
            }
        }
    }
}