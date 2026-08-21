using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MTKhan_Dentist.Models;
using System;
using System.Web;
using System.Web.UI;

namespace MTKhan_Dentist.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void Forgot(object sender, EventArgs e)
        {
            // Check validation
            if (!IsValid)
            {
                return;
            }


            // Check that passwords match
            if (NewPassword.Text != ConfirmPassword.Text)
            {
                FailureText.Text =
                    "The passwords do not match.";

                ErrorMessage.Visible = true;

                return;
            }


            // Get ASP.NET Identity User Manager
            var manager =
                Context.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();


            // Find user by email
            ApplicationUser user =
                manager.FindByName(Email.Text);


            // Check if user exists
            if (user == null)
            {
                FailureText.Text =
                    "No account was found with this email address.";

                ErrorMessage.Visible = true;

                return;
            }


            // Generate a password reset token
            string code =
                manager.GeneratePasswordResetToken(
                    user.Id
                );


            // Reset the password
            IdentityResult result =
                manager.ResetPassword(
                    user.Id,
                    code,
                    NewPassword.Text
                );


            // Check whether reset was successful
            if (result.Succeeded)
            {
                // Hide reset form
                loginForm.Visible = false;

                // Show success message
                DisplayEmail.Visible = true;
            }
            else
            {
                // Display errors
                FailureText.Text =
                    string.Join(
                        "<br />",
                        result.Errors
                    );

                ErrorMessage.Visible = true;
            }
        }
    }
}