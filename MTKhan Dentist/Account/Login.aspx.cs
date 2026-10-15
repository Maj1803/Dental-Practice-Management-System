using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MTKhan_Dentist.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MTKhan_Dentist.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (!IsValid) return;

            var manager = Context.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();
            var signinManager = Context.GetOwinContext()
                .GetUserManager<ApplicationSignInManager>();

            // STEP 1: does the email exist?
            var user = manager.FindByEmail(Email.Text);
            if (user == null)
            {
                FailureText.Text = "Invalid username / email.";
                ErrorMessage.Visible = true;
                return;
            }

            // STEP 2: is the password correct?
            if (!manager.CheckPassword(user, Password.Text))
            {
                FailureText.Text = "Incorrect password.";
                ErrorMessage.Visible = true;
                return;
            }

            // STEP 3: sign in
            var result = signinManager.PasswordSignIn(
                Email.Text, Password.Text, isPersistent: false, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:

                    string dbRole = manager.GetRoles(user.Id).FirstOrDefault();
                    if (string.IsNullOrEmpty(dbRole))
                    {
                        SignOut();
                        FailureText.Text = "No role is assigned to this account. Contact admin.";
                        ErrorMessage.Visible = true;
                        return;
                    }

                    dbRole = dbRole.Trim();

                    Session["UserId"] = user.Id;
                    Session["UserEmail"] = user.Email;
                    Session["Role"] = dbRole;

                    string displayName = user.Email;

                    using (var db = new DSEntity())
                    {
                        if (dbRole.Equals("Patient", StringComparison.OrdinalIgnoreCase))
                        {
                            var patient = db.Patients
                                .FirstOrDefault(p => p.AspNetUserId == user.Id);

                            if (patient == null)
                            {
                                SignOut();
                                FailureText.Text =
                                    "No patient record is linked to this account. " +
                                    "Please contact reception.";
                                ErrorMessage.Visible = true;
                                return;
                            }

                            Session["PatientId"] = patient.Patient_ID;
                            displayName = (patient.Patient_First_Name + " " +
                                           patient.Patient_Last_Name).Trim();
                            Session["DisplayName"] = displayName;

                            Response.Redirect("~/PrivatePages/PatientDashboard.aspx");
                            return;
                        }
                        else if (dbRole.Equals("Receptionist", StringComparison.OrdinalIgnoreCase) ||
                                 dbRole.Equals("Dentist", StringComparison.OrdinalIgnoreCase))
                        {
                            var emp = db.Employees
                                .FirstOrDefault(x => x.AspNetUserId == user.Id);

                            if (emp == null)
                            {
                                SignOut();
                                FailureText.Text =
                                    "No employee record is linked to this account. " +
                                    "Please contact admin.";
                                ErrorMessage.Visible = true;
                                return;
                            }

                            Session["EmployeeId"] = emp.Employee_ID;
                            displayName = (emp.Employee_First_Name + " " +
                                           emp.Employee_Last_Name).Trim();
                            Session["DisplayName"] = displayName;

                            Response.Redirect("~/PrivatePages/StaffDashboard.aspx");
                            return;
                        }
                        else
                        {
                            SignOut();
                            FailureText.Text = "Unknown role: " + dbRole;
                            ErrorMessage.Visible = true;
                            return;
                        }
                    }

                case SignInStatus.LockedOut:
                    Response.Redirect("/Account/Lockout");
                    break;

                case SignInStatus.RequiresVerification:
                    Response.Redirect(String.Format(
                        "/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                        Request.QueryString["ReturnUrl"], false), true);
                    break;

                case SignInStatus.Failure:
                default:
                    FailureText.Text = "Unable to log you in. Please try again.";
                    ErrorMessage.Visible = true;
                    break;
            }
        }

        private void SignOut()
        {
            Context.GetOwinContext()
                .Authentication
                .SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}