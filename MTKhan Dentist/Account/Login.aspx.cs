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
        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Determine which role was selected
                string selectedRole;

                if (rbPatient.Checked)
                {
                    selectedRole = "Patient";
                }
                else if (rbDentist.Checked)
                {
                    selectedRole = "Dentist";
                }
                else
                {
                    selectedRole = "Receptionist";
                }

                // Get User Manager
                var manager = Context.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();

                // Get Sign In Manager
                var signinManager = Context.GetOwinContext()
                    .GetUserManager<ApplicationSignInManager>();

                // Validate username and password
                var result = signinManager.PasswordSignIn(
                    Email.Text,
                    Password.Text,
                    RememberMe.Checked,
                    shouldLockout: false
                );

                switch (result)
                {
                    case SignInStatus.Success:

                        // Get the user
                        var user = manager.FindByEmail(Email.Text);

                        if (user == null)
                        {
                            FailureText.Text = "User account could not be found.";
                            ErrorMessage.Visible = true;
                            return;
                        }

                        // Check whether the user has the selected role
                        bool isInRole = manager.IsInRole(user.Id, selectedRole);

                        if (isInRole)
                        {
                            Session["UserId"] = user.Id;
                            Session["UserEmail"] = user.Email;
                            Session["UserRole"] = selectedRole;
                            Session["UserType"] = (selectedRole == "Patient") ? "Patient" : "Staff";

                            // Look up Employee record for staff
                            if (selectedRole != "Patient")
                            {
                                using (var db = new ApplicationDbContext())
                                {
                                    var emp = db.Employees
                                        .FirstOrDefault(x => x.AspNetUserId == user.Id);

                                    if (emp != null)
                                    {
                                        Session["EmployeeId"] = emp.Employee_ID;
                                        Session["EmployeeName"] = emp.Employee_First_Name
                                                                  + " " + emp.Employee_Last_Name;
                                        Session["EmployeeRole"] = emp.Employee_Role;
                                    }
                                }
                            }

                            if (selectedRole == "Patient")
                            {
                                Response.Redirect("~/PrivatePages/PatientDashboard.aspx");
                            }
                            else if (selectedRole == "Dentist")
                            {
                                Response.Redirect("~/PrivatePages/StaffDashboard.aspx");
                            }
                            else if (selectedRole == "Receptionist")
                            {
                                Response.Redirect("~/PrivatePages/StaffDashboard.aspx");
                            }
                        }
                        else
                        {
                            // Password was correct but the selected role
                            // does not match the user's assigned role.

                            Context.GetOwinContext()
                                .Authentication
                                .SignOut(
                                    DefaultAuthenticationTypes.ApplicationCookie
                                );

                            FailureText.Text =
                                "You are not authorized to login as "
                                + selectedRole + ".";

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

                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                        
                
                }
            }
        }
    }
}