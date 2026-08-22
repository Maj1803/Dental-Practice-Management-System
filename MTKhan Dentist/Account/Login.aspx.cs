using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MTKhan_Dentist.Models;
using Microsoft.Owin.Security;

namespace MTKhan_Dentist.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Patient is selected by default
                rbPatient.Checked = true;

                // Staff roles are HIDDEN by default
                pnlStaffRoles.Visible = false;

                // Set default button styles
                SetButtonStyles();
            }

            // Forgot Password link
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";

            // Return URL
            var returnUrl = HttpUtility.UrlEncode(
                Request.QueryString["ReturnUrl"]
            );
        }

        protected void UserType_Changed(object sender, EventArgs e)
        {
            // Show/hide staff roles based on selection
            if (rbStaff.Checked)
            {
                // Staff is selected - SHOW Receptionist/Dentist
                pnlStaffRoles.Visible = true;

                // Update button styles
                lblStaff.CssClass = "btn btn-info";
                lblPatient.CssClass = "btn btn-outline-info";

                // Set default staff role if none selected
                if (!rbReceptionist.Checked && !rbDentist.Checked)
                {
                    rbReceptionist.Checked = true;
                }
                SetStaffRoleStyles();
            }
            else
            {
                // Patient is selected - HIDE Receptionist/Dentist
                pnlStaffRoles.Visible = false;

                // Update button styles
                lblPatient.CssClass = "btn btn-info";
                lblStaff.CssClass = "btn btn-outline-info";
            }
        }

        protected void StaffRole_Changed(object sender, EventArgs e)
        {
            SetStaffRoleStyles();
        }

        private void SetButtonStyles()
        {
            // Set initial user type styles
            if (rbStaff.Checked)
            {
                lblStaff.CssClass = "btn btn-info";
                lblPatient.CssClass = "btn btn-outline-info";
                pnlStaffRoles.Visible = true;
            }
            else
            {
                lblPatient.CssClass = "btn btn-info";
                lblStaff.CssClass = "btn btn-outline-info";
                pnlStaffRoles.Visible = false;
            }

            // Set initial staff role styles
            SetStaffRoleStyles();
        }

        private void SetStaffRoleStyles()
        {
            if (rbReceptionist.Checked)
            {
                lblReceptionist.CssClass = "btn btn-secondary";
                lblDentist.CssClass = "btn btn-outline-secondary";
            }
            else if (rbDentist.Checked)
            {
                lblDentist.CssClass = "btn btn-secondary";
                lblReceptionist.CssClass = "btn btn-outline-secondary";
            }
        }

        protected async void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Get selected user type and role
                string userType = rbStaff.Checked ? "Staff" : "Patient";
                string selectedRole = "";

                if (userType == "Staff")
                {
                    selectedRole = rbDentist.Checked ? "Dentist" : "Receptionist";
                }
                else
                {
                    selectedRole = "Patient";
                }

                // Get User Manager
                var manager =
                    Context.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();

                // Get Sign In Manager
                var signinManager =
                    Context.GetOwinContext()
                    .GetUserManager<ApplicationSignInManager>();

                // Check login details
                var result =
                    await signinManager.PasswordSignInAsync(
                        Email.Text,
                        Password.Text,
                        RememberMe.Checked,
                        shouldLockout: false
                    );

                switch (result)
                {
                    case SignInStatus.Success:
                        // Get the user
                        var user = await manager.FindByEmailAsync(Email.Text);

                        // Check if user has the selected role
                        bool isInRole = await manager.IsInRoleAsync(user.Id, selectedRole);

                        if (isInRole)
                        {
                            // Store user info in session
                            Session["UserId"] = user.Id;
                            Session["UserEmail"] = user.Email;
                            Session["UserRole"] = selectedRole;
                            Session["UserType"] = userType;

                            // Redirect based on role
                            if (selectedRole == "Dentist")
                            {
                                Response.Redirect("~/Dentist/Dashboard.aspx");
                            }
                            else if (selectedRole == "Receptionist")
                            {
                                Response.Redirect("~/Receptionist/Dashboard.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Patient/Dashboard.aspx");
                            }
                        }
                        else
                        {
                            // User doesn't have the selected role - sign out
                            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                            FailureText.Text = "You are not authorized to login as " + selectedRole;
                            ErrorMessage.Visible = true;
                        }
                        break;

                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;

                    case SignInStatus.RequiresVerification:
                        Response.Redirect(
                            String.Format(
                                "/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                Request.QueryString["ReturnUrl"],
                                RememberMe.Checked
                            ),
                            true
                        );
                        break;

                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt.";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}