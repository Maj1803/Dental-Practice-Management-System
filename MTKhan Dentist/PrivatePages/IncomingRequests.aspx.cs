using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MTKhan_Dentist
{
    public partial class IncomingRequests : Page
    {
        private bool pageReady;

        private static string ConnString
        {
            get { return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("~/Account/Login");
                return;
            }

            // Receptionist only. Dentists and patients are sent home.
            if (!string.Equals(Session["Role"].ToString(), "Receptionist", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/");
                return;
            }

            pageReady = true;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!pageReady) return;
            try
            {
                BindRequests();
            }
            catch (SqlException)
            {
                phMain.Visible = false;
                lblPageError.Text = "The requests could not be loaded. Check your connection and refresh the page.";
                lblPageError.Visible = true;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            hfFilter.Value = b.CommandArgument;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            hfFilter.Value = "All";
        }

        private DataTable LoadRequests()
        {
            const string sql = @"SELECT s.Reference_No, s.Message_Text,
                                        a.Appointment_Date, a.Appointment_Status, t.Slot_Start_Time,
                                        p.Patient_First_Name + ' ' + p.Patient_Last_Name AS PatientName,
                                        CASE
                                          WHEN EXISTS (SELECT 1 FROM SystemLink r WHERE r.Reference_No = s.Reference_No AND r.Message_Type = 'AppointmentDeclined') THEN 'Declined'
                                          WHEN EXISTS (SELECT 1 FROM SystemLink r WHERE r.Reference_No = s.Reference_No AND r.Message_Type = 'AppointmentConfirmed') THEN 'Confirmed'
                                          ELSE 'Pending'
                                        END AS ReplyState
                                 FROM SystemLink s
                                 INNER JOIN Appointment a ON a.Appointment_ID = s.Appointment_ID
                                 LEFT JOIN Patient p ON p.Patient_ID = a.Patient_ID
                                 LEFT JOIN Timeslot t ON t.Timeslot_ID = a.Timeslot_ID
                                 WHERE s.Message_Type = 'AppointmentRequested'";

            DataTable raw = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(raw);
            }

            DataTable result = new DataTable();
            result.Columns.Add("Reference_No", typeof(string));
            result.Columns.Add("Message_Text", typeof(string));
            result.Columns.Add("Request_Status", typeof(string));
            result.Columns.Add("CardClass", typeof(string));
            result.Columns.Add("BadgeClass", typeof(string));
            result.Columns.Add("ReceivedText", typeof(string));
            result.Columns.Add("PatientName", typeof(string));
            result.Columns.Add("Rank", typeof(int));
            result.Columns.Add("SortDate", typeof(DateTime));

            foreach (DataRow r in raw.Rows)
            {
                string status = Convert.ToString(r["Appointment_Status"]).Trim();
                string reply = Convert.ToString(r["ReplyState"]);
                string label;
                string cardClass;
                string badgeClass;
                int rank;

                if (reply == "Declined" || string.Equals(status, "Declined", StringComparison.OrdinalIgnoreCase))
                {
                    label = "Declined"; cardClass = "request-card declined"; badgeClass = "badge bg-danger"; rank = 2;
                }
                else if (string.Equals(status, "Cancelled", StringComparison.OrdinalIgnoreCase))
                {
                    label = "Cancelled"; cardClass = "request-card"; badgeClass = "badge bg-secondary"; rank = 3;
                }
                else if (reply == "Confirmed")
                {
                    label = "Confirmed"; cardClass = "request-card confirmed"; badgeClass = "badge bg-success"; rank = 1;
                }
                else
                {
                    label = "Pending"; cardClass = "request-card pending"; badgeClass = "badge bg-warning text-dark"; rank = 0;
                }

                string patient = Convert.ToString(r["PatientName"]).Trim();
                DateTime date = r["Appointment_Date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["Appointment_Date"]).Date;

                string when = date == DateTime.MinValue ? "" : date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                if (label == "Confirmed" && when.Length > 0 && r["Slot_Start_Time"] is TimeSpan)
                {
                    when += " at " + ((TimeSpan)r["Slot_Start_Time"]).ToString(@"hh\:mm");
                }

                string received = "";
                if (patient.Length > 0) received = "Patient: " + patient;
                if (when.Length > 0) received += (received.Length > 0 ? " \u00B7 " : "") + "Appointment: " + when;

                result.Rows.Add(
                    Convert.ToString(r["Reference_No"]),
                    Convert.ToString(r["Message_Text"]),
                    label, cardClass, badgeClass, received, patient, rank, date);
            }

            return result;
        }

        private void BindRequests()
        {
            DataTable all = LoadRequests();

            int pending = 0, confirmed = 0, declined = 0;
            foreach (DataRow r in all.Rows)
            {
                string s = Convert.ToString(r["Request_Status"]);
                if (s == "Pending") pending++;
                else if (s == "Confirmed") confirmed++;
                else if (s == "Declined") declined++;
            }
            lblPending.Text = pending.ToString();
            lblConfirmed.Text = confirmed.ToString();
            lblDeclined.Text = declined.ToString();

            string filter = hfFilter.Value;
            if (string.IsNullOrEmpty(filter)) filter = "All";
            string search = txtSearch.Text.Trim();

            DataTable shown = all.Clone();
            foreach (DataRow r in all.Rows)
            {
                if (filter != "All" && Convert.ToString(r["Request_Status"]) != filter) continue;

                if (search.Length > 0)
                {
                    bool match = Convert.ToString(r["Reference_No"]).IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 Convert.ToString(r["PatientName"]).IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
                    if (!match) continue;
                }
                shown.ImportRow(r);
            }

            DataView view = new DataView(shown);
            view.Sort = "Rank ASC, SortDate DESC";
            rptRequests.DataSource = view;
            rptRequests.DataBind();

            lblEmpty.Visible = shown.Rows.Count == 0;
            lblResultInfo.Text = "Showing " + shown.Rows.Count + " of " + all.Rows.Count + " request(s).";

            btnAll.CssClass = "btn btn-sm " + (filter == "All" ? "btn-primary" : "btn-outline-primary");
            btnPending.CssClass = "btn btn-sm " + (filter == "Pending" ? "btn-primary" : "btn-outline-primary");
            btnConfirmed.CssClass = "btn btn-sm " + (filter == "Confirmed" ? "btn-primary" : "btn-outline-primary");
            btnDeclined.CssClass = "btn btn-sm " + (filter == "Declined" ? "btn-primary" : "btn-outline-primary");
        }
    }
}