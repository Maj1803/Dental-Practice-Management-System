using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MTKhan_Dentist.Models;

namespace MTKhan_Dentist.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Register link
            //RegisterHyperLink.NavigateUrl = "Register";

            // Forgot Password link
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";

            // Return URL
            var returnUrl = HttpUtility.UrlEncode(
                Request.QueryString["ReturnUrl"]
            );

            //if (!String.IsNullOrEmpty(returnUrl))
           // {
              //  RegisterHyperLink.NavigateUrl +=
               //     "?ReturnUrl=" + returnUrl;
            //}
        }


        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
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
                    signinManager.PasswordSignIn(
                        Email.Text,
                        Password.Text,
                        RememberMe.Checked,
                        shouldLockout: false
                    );


                switch (result)
                {
                    case SignInStatus.Success:

                        IdentityHelper.RedirectToReturnUrl(
                            Request.QueryString["ReturnUrl"],
                            Response
                        );

                        break;


                    case SignInStatus.LockedOut:

                        Response.Redirect(
                            "/Account/Lockout"
                        );

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

                        FailureText.Text =
                            "Invalid login attempt.";

                        ErrorMessage.Visible = true;

                        break;
                }
            }
        }
    }
}