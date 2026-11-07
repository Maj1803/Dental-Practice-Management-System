using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MTKhan_Dentist.Models;

namespace MTKhan_Dentist.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // ==================== REGISTER PATIENT ====================
        // 1. Create the login account (ASP.NET Identity). The email is used as the username,
        //    to match Login. Identity stores only a hash of the password, never the password itself.
        // 2. Give the account the "Patient" role, so Login sends it to the Patient Dashboard.
        // 3. Insert the Patient row, linked to the account through AspNetUserId.
        // If step 2 or 3 fails, the account from step 1 is deleted so nothing is left half-created.

        protected void BtnRegisterPatient_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            string email = PatientEmail.Text.Trim();

            // Friendly check before creating anything (the email is both the username and the email)
            if (manager.FindByEmail(email) != null || manager.FindByName(email) != null)
            {
                ShowError("An account with this email address already exists. Try logging in, or use Forgot Password.");
                return;
            }

            DateTime dob;
            if (!DateTime.TryParse(PatientDOB.Text, out dob) || dob.Date > DateTime.Today)
            {
                ShowError("Please enter a valid date of birth.");
                return;
            }

            // STEP 1: create the login account
            var user = new ApplicationUser
            {
                UserName = email,   // Login signs in with the email as the username
                Email = email,
                PhoneNumber = PatientPhone.Text.Trim()
            };

            IdentityResult createResult = manager.Create(user, PatientPassword.Text);
            if (!createResult.Succeeded)
            {
                // e.g. password does not meet the rules in IdentityConfig.cs
                ShowError(string.Join(" ", createResult.Errors));
                return;
            }

            try
            {
                // STEP 2: give the account the Patient role
                IdentityResult roleResult = manager.AddToRole(user.Id, "Patient");
                if (!roleResult.Succeeded)
                {
                    throw new InvalidOperationException(string.Join(" ", roleResult.Errors));
                }

                // STEP 3: save the patient's details, linked to the new account
                string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO Patient
                        (Patient_First_Name, Patient_Last_Name, Patient_Phone_Number,
                         Patient_Email, Patient_DOB, Patient_Allergies,
                         Patient_Street, Patient_Suburb, Patient_City, Patient_Code,
                         AspNetUserId)
                        VALUES
                        (@FirstName, @LastName, @Phone,
                         @Email, @DOB, @Allergies,
                         @Street, @Suburb, @City, @Code,
                         @AspNetUserId)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", PatientFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", PatientLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", PatientPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@DOB", dob.Date);
                        cmd.Parameters.AddWithValue("@Allergies", PatientAllergies.Text.Trim());
                        cmd.Parameters.AddWithValue("@Street", PatientStreet.Text.Trim());
                        cmd.Parameters.AddWithValue("@Suburb", PatientSuburb.Text.Trim());
                        cmd.Parameters.AddWithValue("@City", PatientCity.Text.Trim());
                        cmd.Parameters.AddWithValue("@Code", PatientCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@AspNetUserId", user.Id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Undo step 1 so the person can try again with the same email
                try { manager.Delete(user); } catch { /* nothing more we can do here */ }

                string detail = Request.IsLocal ? " (" + ex.Message + ")" : "";
                ShowError("We couldn't finish creating your account. Please try again, or contact reception." + detail);
                return;
            }

            // Confirmation message (M4: confirm every insert)
            litNewUsername.Text = email;
            pnlForm.Visible = false;
            ErrorMessage.Visible = false;
            pnlSuccess.Visible = true;
        }

        private void ShowError(string message)
        {
            FailureText.Text = HttpUtility.HtmlEncode(message);
            ErrorMessage.Visible = true;
        }
    }
}
