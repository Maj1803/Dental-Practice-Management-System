using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MTKhan_Dentist
{
    public partial class ManageSchedule : Page
    {
        private int employeeId;
        private string employeeRole;
        private string employeeName;
        private bool pageReady;

        private class DentistInfo
        {
            public int Id;
            public string Display;
            public string Initials;
        }

        private static string ConnString
        {
            get { return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        }

        private bool IsDentist
        {
            get { return string.Equals(employeeRole, "Dentist", StringComparison.OrdinalIgnoreCase); }
        }

        private bool IsReceptionist
        {
            get { return string.Equals(employeeRole, "Receptionist", StringComparison.OrdinalIgnoreCase); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bool found;
            try
            {
                found = ResolveEmployee();
            }
            catch (SqlException)
            {
                phMain.Visible = false;
                ShowPageError("The database could not be reached. Check your connection and refresh the page.");
                return;
            }

            if (!found || !(IsDentist || IsReceptionist))
            {
                Response.Redirect("~/");
                return;
            }

            pnlMarkUnavailable.Visible = IsDentist;
            pageReady = true;

            if (!IsPostBack)
            {
                calSchedule.SelectedDate = DateTime.Today;
                calSchedule.VisibleDate = DateTime.Today;
                try
                {
                    LoadPractitioners();
                    LoadTimeslotOptions();
                    LoadReasonLimit();
                }
                catch (SqlException)
                {
                    ShowPageError("Some schedule options could not be loaded. Check your connection and refresh the page.");
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!pageReady) return;
            try
            {
                BindCounts();
                BindSchedule();
                BindMyOverrides();
            }
            catch (SqlException)
            {
                ShowPageError("Some schedule data could not be loaded. Check your connection and refresh the page.");
            }
        }

        protected void calSchedule_SelectionChanged(object sender, EventArgs e)
        {
            pnlConflict.Visible = false;
            ClearPending();
            lblOverrideMsg.Text = "";
            try
            {
                LoadTimeslotOptions();
            }
            catch (SqlException)
            {
                ShowPageError("Timeslots could not be loaded. Check your connection and refresh the page.");
            }
        }

        protected void btnMarkUnavailable_Click(object sender, EventArgs e)
        {
            if (!IsDentist) return;

            DateTime date = GetSelectedDate();
            bool full = chkFullDay.Checked;
            int? slotId = null;

            if (!full)
            {
                int parsed;
                if (!int.TryParse(ddlTimeslot.SelectedValue, out parsed))
                {
                    ShowOverrideMessage("Select a timeslot or tick Full day.", false);
                    return;
                }
                slotId = parsed;
            }

            ProcessBlock(date, full, slotId, txtReason.Text.Trim(), false);
        }

        protected void btnConfirmBlock_Click(object sender, EventArgs e)
        {
            if (!IsDentist) return;

            object pendingDate = ViewState["PendingDate"];
            if (pendingDate == null)
            {
                pnlConflict.Visible = false;
                return;
            }

            DateTime date = (DateTime)pendingDate;
            bool full = (bool)ViewState["PendingFull"];
            int slotValue = (int)ViewState["PendingSlot"];
            string reason = Convert.ToString(ViewState["PendingReason"]);

            ProcessBlock(date, full, slotValue > 0 ? (int?)slotValue : null, reason, true);
        }

        protected void btnCancelBlock_Click(object sender, EventArgs e)
        {
            pnlConflict.Visible = false;
            ClearPending();
            ShowOverrideMessage("Nothing was changed.", true);
        }

        protected void rptMyOverrides_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (!IsDentist || e.CommandName != "Remove") return;

            int overrideId;
            if (!int.TryParse(Convert.ToString(e.CommandArgument), out overrideId)) return;

            try
            {
                int removed;
                const string sql = "DELETE FROM Availability_Override WHERE Override_ID = @id AND Employee_ID = @emp AND Target_Date >= @today";
                using (SqlConnection con = new SqlConnection(ConnString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = overrideId;
                    cmd.Parameters.Add("@emp", SqlDbType.Int).Value = employeeId;
                    cmd.Parameters.Add("@today", SqlDbType.Date).Value = DateTime.Today;
                    con.Open();
                    removed = cmd.ExecuteNonQuery();
                }

                if (removed > 0) ShowOverrideMessage("Unavailability removed.", true);
                else ShowOverrideMessage("That entry could not be removed.", false);
            }
            catch (SqlException)
            {
                ShowOverrideMessage("The entry could not be removed. Check your connection and try again.", false);
            }
        }

        private bool ResolveEmployee()
        {
            employeeId = 0;
            employeeRole = null;
            employeeName = null;

            if (!User.Identity.IsAuthenticated) return false;
            string loginName = User.Identity.Name;
            if (string.IsNullOrEmpty(loginName)) return false;

            const string sql = @"SELECT TOP 1 e.Employee_ID, e.Employee_Role, e.Employee_First_Name, e.Employee_Last_Name
                                 FROM Employee e
                                 LEFT JOIN AspNetUsers u ON u.Id = e.AspNetUserId
                                 WHERE e.Employee_Email = @login OR u.UserName = @login OR u.Email = @login";

            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@login", SqlDbType.NVarChar, 256).Value = loginName;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read()) return false;
                    employeeId = Convert.ToInt32(dr["Employee_ID"]);
                    employeeRole = Convert.ToString(dr["Employee_Role"]).Trim();
                    employeeName = (Convert.ToString(dr["Employee_First_Name"]) + " " + Convert.ToString(dr["Employee_Last_Name"])).Trim();
                }
            }
            return true;
        }

        private List<DentistInfo> GetDentists()
        {
            List<DentistInfo> list = new List<DentistInfo>();
            const string sql = "SELECT Employee_ID, Employee_First_Name, Employee_Last_Name FROM Employee WHERE Employee_Role = 'Dentist' ORDER BY Employee_Last_Name, Employee_First_Name";

            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string first = Convert.ToString(dr["Employee_First_Name"]).Trim();
                        string last = Convert.ToString(dr["Employee_Last_Name"]).Trim();
                        string initials = (first.Length > 0 ? first.Substring(0, 1) : "") + (last.Length > 0 ? last.Substring(0, 1) : "");

                        DentistInfo info = new DentistInfo();
                        info.Id = Convert.ToInt32(dr["Employee_ID"]);
                        info.Display = "Dr. " + last;
                        info.Initials = initials.ToUpperInvariant();
                        list.Add(info);
                    }
                }
            }
            return list;
        }

        private void LoadPractitioners()
        {
            ddlPractitioner.Items.Clear();
            ddlPractitioner.Items.Add(new ListItem("All Practitioners", "0"));
            foreach (DentistInfo d in GetDentists())
            {
                ddlPractitioner.Items.Add(new ListItem(d.Display, d.Id.ToString()));
            }

            if (IsDentist)
            {
                ListItem own = ddlPractitioner.Items.FindByValue(employeeId.ToString());
                if (own != null)
                {
                    ddlPractitioner.ClearSelection();
                    own.Selected = true;
                }
            }
        }

        private void LoadTimeslotOptions()
        {
            ddlTimeslot.Items.Clear();
            ddlTimeslot.Items.Add(new ListItem("Select a timeslot", ""));

            const string sql = "SELECT Timeslot_ID, Slot_Start_Time FROM Timeslot WHERE Is_Active = 1 AND Day_Of_Week = @dow ORDER BY Slot_Start_Time";
            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@dow", SqlDbType.Int).Value = WeekdayCode(GetSelectedDate());
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TimeSpan start = (TimeSpan)dr["Slot_Start_Time"];
                        ddlTimeslot.Items.Add(new ListItem(start.ToString(@"hh\:mm"), Convert.ToString(dr["Timeslot_ID"])));
                    }
                }
            }
        }

        private void LoadReasonLimit()
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand("SELECT COL_LENGTH('dbo.Availability_Override', 'Reason')", con))
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    int bytes = Convert.ToInt32(result);
                    if (bytes > 0) txtReason.MaxLength = bytes / 2;
                }
            }
        }

        private static int WeekdayCode(DateTime date)
        {
            return (int)date.DayOfWeek + 1;
        }

        private DateTime GetSelectedDate()
        {
            return calSchedule.SelectedDate == DateTime.MinValue ? DateTime.Today : calSchedule.SelectedDate.Date;
        }

        private int GetPractitionerFilter()
        {
            int id;
            return int.TryParse(ddlPractitioner.SelectedValue, out id) ? id : 0;
        }

        private static bool IsTrue(object value)
        {
            return value != null && value != DBNull.Value && Convert.ToBoolean(value);
        }

        private static bool SameTime(object value, TimeSpan time)
        {
            return value is TimeSpan && (TimeSpan)value == time;
        }

        private static DataTable Fill(string sql, Action<SqlCommand> addParameters)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                addParameters(cmd);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }
            }
            return table;
        }

        private static void AddSlotParameter(SqlCommand cmd, int? slotId)
        {
            cmd.Parameters.Add("@slot", SqlDbType.Int).Value = slotId.HasValue ? (object)slotId.Value : DBNull.Value;
        }

        private void ShowPageError(string message)
        {
            lblPageError.Text = Server.HtmlEncode(message);
            lblPageError.Visible = true;
        }

        private void ShowOverrideMessage(string message, bool success)
        {
            lblOverrideMsg.Text = Server.HtmlEncode(message);
            lblOverrideMsg.CssClass = "small mt-2 d-block " + (success ? "text-success" : "text-danger");
        }

        private void ClearPending()
        {
            ViewState.Remove("PendingDate");
            ViewState.Remove("PendingFull");
            ViewState.Remove("PendingSlot");
            ViewState.Remove("PendingReason");
        }

        private void BindCounts()
        {
            int practitionerId = GetPractitionerFilter();
            string sql = "SELECT COUNT(*), " +
                         "ISNULL(SUM(CASE WHEN Appointment_Status = 'Completed' THEN 1 ELSE 0 END), 0), " +
                         "ISNULL(SUM(CASE WHEN Appointment_Status = 'Cancelled' THEN 1 ELSE 0 END), 0) " +
                         "FROM Appointment WHERE Appointment_Date = @today";
            if (practitionerId > 0) sql += " AND Employee_ID = @emp";

            int total = 0;
            int completed = 0;
            int cancelled = 0;

            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@today", SqlDbType.Date).Value = DateTime.Today;
                if (practitionerId > 0) cmd.Parameters.Add("@emp", SqlDbType.Int).Value = practitionerId;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        total = Convert.ToInt32(dr[0]);
                        completed = Convert.ToInt32(dr[1]);
                        cancelled = Convert.ToInt32(dr[2]);
                    }
                }
            }

            lblTodayCount.Text = total.ToString();
            lblCompleted.Text = completed.ToString();
            lblCancelled.Text = cancelled.ToString();
            lblScheduled.Text = Math.Max(total - completed - cancelled, 0).ToString();
        }

        private DataTable LoadAppointments(DateTime date)
        {
            const string sql = @"SELECT a.Employee_ID, a.Appointment_Status, ts.Slot_Start_Time,
                                        p.Patient_First_Name + ' ' + p.Patient_Last_Name AS PatientName,
                                        (SELECT TOP 1 tr.TreatmentName
                                         FROM PatientTreatment pt
                                         INNER JOIN Treatment tr ON tr.TreatmentID = pt.TreatmentID
                                         WHERE pt.Appointment_ID = a.Appointment_ID
                                         ORDER BY pt.PatientTreatment_ID) AS TreatmentName
                                 FROM Appointment a
                                 INNER JOIN Patient p ON p.Patient_ID = a.Patient_ID
                                 INNER JOIN Timeslot ts ON ts.Timeslot_ID = a.Timeslot_ID
                                 WHERE a.Appointment_Date = @date";
            return Fill(sql, cmd => cmd.Parameters.Add("@date", SqlDbType.Date).Value = date);
        }

        private DataTable LoadOverrides(DateTime date)
        {
            const string sql = @"SELECT o.Override_ID, o.Employee_ID, o.Timeslot_ID, o.Is_Full_Day, o.Reason, ts.Slot_Start_Time
                                 FROM Availability_Override o
                                 LEFT JOIN Timeslot ts ON ts.Timeslot_ID = o.Timeslot_ID
                                 WHERE o.Target_Date = @date";
            return Fill(sql, cmd => cmd.Parameters.Add("@date", SqlDbType.Date).Value = date);
        }

        private SortedSet<TimeSpan> LoadSlotTimes(DateTime date, DataTable appointments, DataTable overrides)
        {
            SortedSet<TimeSpan> times = new SortedSet<TimeSpan>();

            const string sql = "SELECT Slot_Start_Time FROM Timeslot WHERE Is_Active = 1 AND Day_Of_Week = @dow";
            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@dow", SqlDbType.Int).Value = WeekdayCode(date);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        times.Add((TimeSpan)dr["Slot_Start_Time"]);
                    }
                }
            }

            foreach (DataRow row in appointments.Rows)
            {
                if (row["Slot_Start_Time"] is TimeSpan) times.Add((TimeSpan)row["Slot_Start_Time"]);
            }
            foreach (DataRow row in overrides.Rows)
            {
                if (row["Slot_Start_Time"] is TimeSpan) times.Add((TimeSpan)row["Slot_Start_Time"]);
            }

            return times;
        }

        private void BindSchedule()
        {
            DateTime date = GetSelectedDate();
            lblSelectedDate.Text = date.ToString("dddd, dd MMMM yyyy", CultureInfo.InvariantCulture);

            int practitionerId = GetPractitionerFilter();
            List<DentistInfo> dentists = new List<DentistInfo>();
            foreach (DentistInfo d in GetDentists())
            {
                if (practitionerId == 0 || d.Id == practitionerId) dentists.Add(d);
            }

            DataTable appointments = LoadAppointments(date);
            DataTable overrides = LoadOverrides(date);
            SortedSet<TimeSpan> times = LoadSlotTimes(date, appointments, overrides);

            Dictionary<int, string> fullDay = new Dictionary<int, string>();
            foreach (DataRow row in overrides.Rows)
            {
                if (row["Employee_ID"] == DBNull.Value || !IsTrue(row["Is_Full_Day"])) continue;
                int id = Convert.ToInt32(row["Employee_ID"]);
                if (!fullDay.ContainsKey(id)) fullDay.Add(id, Convert.ToString(row["Reason"]));
            }

            StringBuilder headers = new StringBuilder();
            StringBuilder badges = new StringBuilder();
            for (int i = 0; i < dentists.Count; i++)
            {
                DentistInfo d = dentists[i];
                string avatarClass = i % 2 == 0 ? "bg-success" : "bg-secondary";
                headers.Append("<th><div class=\"doctor-header\"><div class=\"doctor-avatar " + avatarClass + "\">" +
                               Server.HtmlEncode(d.Initials) + "</div><span class=\"fw-semibold small\">" +
                               Server.HtmlEncode(d.Display) + "</span></div></th>");

                if (fullDay.ContainsKey(d.Id))
                {
                    string reason = fullDay[d.Id];
                    badges.Append("<span class=\"badge bg-secondary ms-1\">" + Server.HtmlEncode(d.Display) +
                                  " \u2014 Unavailable all day" +
                                  (reason.Length > 0 ? " (" + Server.HtmlEncode(reason) + ")" : "") + "</span>");
                }
            }
            litDoctorHeaders.Text = headers.ToString();
            litOverrideBadges.Text = badges.ToString();

            StringBuilder rows = new StringBuilder();
            int appointmentCount = 0;

            if (times.Count == 0)
            {
                rows.Append("<tr><td colspan=\"" + (dentists.Count + 1) + "\" class=\"text-muted small\">No timeslots for this date.</td></tr>");
            }

            foreach (TimeSpan time in times)
            {
                rows.Append("<tr class=\"border-bottom\"><td class=\"text-muted small\">" + time.ToString(@"hh\:mm") + "</td>");

                foreach (DentistInfo d in dentists)
                {
                    rows.Append("<td>");

                    foreach (DataRow a in appointments.Select("Employee_ID = " + d.Id))
                    {
                        if (!SameTime(a["Slot_Start_Time"], time)) continue;

                        string status = Convert.ToString(a["Appointment_Status"]);
                        string treatment = Convert.ToString(a["TreatmentName"]);
                        string css = "bg-success bg-opacity-25";
                        if (string.Equals(status, "Completed", StringComparison.OrdinalIgnoreCase)) css = "bg-secondary bg-opacity-25";
                        else if (string.Equals(status, "Cancelled", StringComparison.OrdinalIgnoreCase)) css = "bg-danger bg-opacity-25";

                        string detail = treatment.Length > 0 ? treatment + " \u00B7 " + status : status;
                        rows.Append("<div class=\"appt-block " + css + "\">" + Server.HtmlEncode(Convert.ToString(a["PatientName"])) +
                                    "<br><small class=\"text-muted\">" + Server.HtmlEncode(detail) + "</small></div>");
                        appointmentCount++;
                    }

                    string unavailableReason = null;
                    if (fullDay.ContainsKey(d.Id))
                    {
                        unavailableReason = fullDay[d.Id];
                    }
                    else
                    {
                        foreach (DataRow o in overrides.Select("Employee_ID = " + d.Id))
                        {
                            if (!IsTrue(o["Is_Full_Day"]) && SameTime(o["Slot_Start_Time"], time))
                            {
                                unavailableReason = Convert.ToString(o["Reason"]);
                                break;
                            }
                        }
                    }

                    if (unavailableReason != null)
                    {
                        rows.Append("<div class=\"appt-block bg-warning bg-opacity-25\">Unavailable" +
                                    (unavailableReason.Length > 0 ? "<br><small class=\"text-muted\">" + Server.HtmlEncode(unavailableReason) + "</small>" : "") +
                                    "</div>");
                    }

                    rows.Append("</td>");
                }

                rows.Append("</tr>");
            }

            litScheduleRows.Text = rows.ToString();
            lblSearchInfo.Text = appointmentCount + " appointment(s) on " + date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture) + ".";
        }

        private void BindMyOverrides()
        {
            if (!IsDentist) return;

            DateTime date = GetSelectedDate();
            lblBlockDate.Text = "Date: " + date.ToString("dddd, dd MMMM yyyy", CultureInfo.InvariantCulture);

            const string sql = @"SELECT o.Override_ID, o.Is_Full_Day, o.Reason, ts.Slot_Start_Time
                                 FROM Availability_Override o
                                 LEFT JOIN Timeslot ts ON ts.Timeslot_ID = o.Timeslot_ID
                                 WHERE o.Employee_ID = @emp AND o.Target_Date = @date
                                 ORDER BY ts.Slot_Start_Time";

            DataTable source = Fill(sql, cmd =>
            {
                cmd.Parameters.Add("@emp", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = date;
            });

            DataTable list = new DataTable();
            list.Columns.Add("Override_ID", typeof(int));
            list.Columns.Add("Label", typeof(string));

            foreach (DataRow row in source.Rows)
            {
                string when = "Full day";
                if (!IsTrue(row["Is_Full_Day"]) && row["Slot_Start_Time"] is TimeSpan)
                {
                    when = ((TimeSpan)row["Slot_Start_Time"]).ToString(@"hh\:mm");
                }

                string reason = Convert.ToString(row["Reason"]);
                string label = reason.Length > 0 ? when + " \u2014 " + reason : when;
                list.Rows.Add(Convert.ToInt32(row["Override_ID"]), label);
            }

            rptMyOverrides.DataSource = list;
            rptMyOverrides.DataBind();
            phMyOverrides.Visible = list.Rows.Count > 0;
        }

        private bool TryGetSlotTime(int slotId, DateTime date, out TimeSpan time)
        {
            time = TimeSpan.Zero;
            const string sql = "SELECT Slot_Start_Time FROM Timeslot WHERE Timeslot_ID = @id AND Is_Active = 1 AND Day_Of_Week = @dow";

            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = slotId;
                cmd.Parameters.Add("@dow", SqlDbType.Int).Value = WeekdayCode(date);
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return false;
                time = (TimeSpan)result;
                return true;
            }
        }

        private bool OverrideExists(DateTime date, int? slotId)
        {
            const string sql = @"SELECT COUNT(*) FROM Availability_Override
                                 WHERE Employee_ID = @emp AND Target_Date = @date
                                 AND (Is_Full_Day = 1 OR (@slot IS NOT NULL AND Timeslot_ID = @slot))";

            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@emp", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = date;
                AddSlotParameter(cmd, slotId);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private List<string> GetClashingAppointments(DateTime date, int? slotId)
        {
            List<string> clashes = new List<string>();
            const string sql = @"SELECT ts.Slot_Start_Time, p.Patient_First_Name + ' ' + p.Patient_Last_Name AS PatientName
                                 FROM Appointment a
                                 INNER JOIN Patient p ON p.Patient_ID = a.Patient_ID
                                 INNER JOIN Timeslot ts ON ts.Timeslot_ID = a.Timeslot_ID
                                 WHERE a.Employee_ID = @emp AND a.Appointment_Date = @date
                                 AND ISNULL(a.Appointment_Status, '') NOT IN ('Cancelled', 'Completed')
                                 AND (@slot IS NULL OR a.Timeslot_ID = @slot)
                                 ORDER BY ts.Slot_Start_Time";

            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@emp", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = date;
                AddSlotParameter(cmd, slotId);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TimeSpan start = (TimeSpan)dr["Slot_Start_Time"];
                        clashes.Add(start.ToString(@"hh\:mm") + " " + Convert.ToString(dr["PatientName"]));
                    }
                }
            }
            return clashes;
        }

        private void InsertOverride(DateTime date, bool full, int? slotId, string reason)
        {
            const string sql = "INSERT INTO Availability_Override (Target_Date, Timeslot_ID, Is_Full_Day, Reason, Employee_ID) VALUES (@date, @slot, @full, @reason, @emp)";

            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = date;
                AddSlotParameter(cmd, slotId);
                cmd.Parameters.Add("@full", SqlDbType.Bit).Value = full;
                cmd.Parameters.Add("@reason", SqlDbType.NVarChar, 4000).Value = reason;
                cmd.Parameters.Add("@emp", SqlDbType.Int).Value = employeeId;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private bool NotifyReceptionist(string period, DateTime date, int clashCount, string reason)
        {
            string text = date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture) + " " + period + ": " + clashCount +
                          " booked appointment(s) need rescheduling. Reason: " + reason;
            if (text.Length > 180) text = text.Substring(0, 177) + "...";

            const string sql = "INSERT INTO StaffMessage (Sender_Name, Message_Text, Sent_At) VALUES (@name, @text, GETDATE())";
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = employeeName;
                    cmd.Parameters.Add("@text", SqlDbType.NVarChar, 4000).Value = text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        private void ProcessBlock(DateTime date, bool full, int? slotId, string reason, bool confirmed)
        {
            pnlConflict.Visible = false;
            ClearPending();

            if (date < DateTime.Today)
            {
                ShowOverrideMessage("Availability can only be changed for today or a future date.", false);
                return;
            }
            if (reason.Length == 0)
            {
                ShowOverrideMessage("Enter a reason.", false);
                return;
            }
            if (txtReason.MaxLength > 0 && reason.Length > txtReason.MaxLength)
            {
                ShowOverrideMessage("The reason is too long. Please shorten it.", false);
                return;
            }

            try
            {
                string period = "full day";
                if (!full)
                {
                    TimeSpan slotTime;
                    if (!TryGetSlotTime(slotId.Value, date, out slotTime))
                    {
                        ShowOverrideMessage("That timeslot is not available for the selected date.", false);
                        return;
                    }
                    period = slotTime.ToString(@"hh\:mm");
                }

                if (OverrideExists(date, full ? (int?)null : slotId))
                {
                    ShowOverrideMessage("That time is already marked unavailable.", false);
                    return;
                }

                List<string> clashes = GetClashingAppointments(date, full ? (int?)null : slotId);
                if (clashes.Count > 0 && !confirmed)
                {
                    ViewState["PendingDate"] = date;
                    ViewState["PendingFull"] = full;
                    ViewState["PendingSlot"] = slotId.HasValue ? slotId.Value : -1;
                    ViewState["PendingReason"] = reason;

                    string names = string.Join(", ", clashes.GetRange(0, Math.Min(clashes.Count, 5)));
                    lblConflict.Text = Server.HtmlEncode(clashes.Count + " booked appointment(s) fall in this period: " + names +
                                                         (clashes.Count > 5 ? " and more" : "") + ".") +
                                       "<br />Block it anyway? The receptionist will be notified on the staff noticeboard to reschedule them.";
                    pnlConflict.Visible = true;
                    return;
                }

                InsertOverride(date, full, full ? (int?)null : slotId, reason);

                string message = "Marked unavailable: " + date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture) + " (" + period + ").";
                bool success = true;
                if (clashes.Count > 0)
                {
                    if (NotifyReceptionist(period, date, clashes.Count, reason))
                    {
                        message += " The receptionist has been notified to reschedule " + clashes.Count + " appointment(s).";
                    }
                    else
                    {
                        message += " The receptionist could not be notified. Please tell her directly.";
                        success = false;
                    }
                }

                txtReason.Text = "";
                chkFullDay.Checked = false;
                if (ddlTimeslot.Items.Count > 0) ddlTimeslot.SelectedIndex = 0;
                ShowOverrideMessage(message, success);
            }
            catch (SqlException)
            {
                ShowOverrideMessage("The change could not be saved. Check your connection and try again.", false);
            }
        }
    }
}