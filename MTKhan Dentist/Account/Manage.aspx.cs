using System;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MTKhan_Dentist.Models;

namespace MTKhan_Dentist.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage { get; private set; }

        private ApplicationUserManager Manager =>
            Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["PatientId"] == null)
            {
                Response.Redirect("~/Account/Login");
                return;
            }
            if (!Session["Role"].ToString().Equals("Patient", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/PrivatePages/StaffDashboard.aspx");
                return;
            }

            if (IsPostBack) return;

            LoadProfile();

            var uid = GetIdentityUserId();
            bool hasPassword = uid != null && Manager.HasPassword(uid);
            ChangePassword.Visible = hasPassword;
            CreatePassword.Visible = !hasPassword;

            var message = Request.QueryString["m"];
            if (message != null)
            {
                Form.Action = ResolveUrl("~/Account/Manage");
                SuccessMessage =
                    message == "ChangePwdSuccess" ? "Your password has been changed."
                    : message == "SetPwdSuccess" ? "Your password has been set."
                    : String.Empty;
                successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
            }
        }

        private string GetIdentityUserId()
        {
            int pid = Convert.ToInt32(Session["PatientId"]);
            using (var db = new DSEntity())
            {
                return db.Patients.Where(p => p.Patient_ID == pid)
                                  .Select(p => p.AspNetUserId)
                                  .FirstOrDefault();
            }
        }

        private void LoadProfile()
        {
            int pid = Convert.ToInt32(Session["PatientId"]);
            using (var db = new DSEntity())
            {
                var p = db.Patients.FirstOrDefault(x => x.Patient_ID == pid);
                if (p == null) return;
                txtEmail.Text = p.Patient_Email;
                txtPhone.Text = p.Patient_Phone_Number;   // check the real column name (cut off in your diagram)
            }
        }

        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            var uid = GetIdentityUserId();
            var user = uid == null ? null : Manager.FindById(uid);
            if (user == null) { Response.Redirect("~/Account/Login"); return; }

            // Don't let two accounts share an email
            var existing = Manager.FindByEmail(email);
            if (existing != null && existing.Id != user.Id)
            {
                ShowStatus("That email address is already in use.", false);
                return;
            }

            user.Email = email;
            user.PhoneNumber = phone;
            user.UserName = email;   // only if patients log in with their email

            var result = Manager.Update(user);
            if (!result.Succeeded)
            {
                ShowStatus(string.Join(" ", result.Errors), false);
                return;
            }

            try
            {
                int pid = Convert.ToInt32(Session["PatientId"]);
                using (var db = new DSEntity())
                {
                    var p = db.Patients.First(x => x.Patient_ID == pid);
                    p.Patient_Email = email;
                    p.Patient_Phone_Number = phone;   // check the real column name
                    db.SaveChanges();
                }
                ShowStatus("Your details were updated.", true);
            }
            catch (Exception)
            {
                ShowStatus("We couldn't save your details. Please try again or contact reception.", false);
            }
        }

        private void ShowStatus(string msg, bool ok)
        {
            lblStatus.Text = msg;
            lblStatus.CssClass = "d-block mb-3 alert " + (ok ? "alert-success" : "alert-danger");
        }
    }
}