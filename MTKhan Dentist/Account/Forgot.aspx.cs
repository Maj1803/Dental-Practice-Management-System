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
            if (IsValid)
            {
                // Get User Manager
                var manager =
                    Context.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();

                // Check passwords match
                if (NewPassword.Text != ConfirmPassword.Text)
                {
                    FailureText.Text = "Passwords do not match.";
                    ErrorMessage.Visible = true;
                    return;
                }

                // Find the user by email
                var user = manager.FindByEmail(Email.Text);

                if (user == null)
                {
                    FailureText.Text = "No account found with that email.";
                    ErrorMessage.Visible = true;
                    return;
                }

                // Remove the old password and set the new one
                var removeResult = manager.RemovePassword(user.Id);

                if (!removeResult.Succeeded)
                {
                    FailureText.Text = "Something went wrong. Please try again.";
                    ErrorMessage.Visible = true;
                    return;
                }

                var addResult = manager.AddPassword(user.Id, NewPassword.Text);

                if (!addResult.Succeeded)
                {
                    // AddPassword fails if the password doesn't meet Identity's
                    // configured requirements (length, complexity, etc.)
                    FailureText.Text = string.Join(" ", addResult.Errors);
                    ErrorMessage.Visible = true;
                    return;
                }

                // Success - show confirmation, hide the form
                loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }
    }
}