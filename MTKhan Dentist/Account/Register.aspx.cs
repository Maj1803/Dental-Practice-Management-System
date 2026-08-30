using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace MTKhan_Dentist.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // ==================== REGISTER PATIENT ====================

        protected void BtnRegisterPatient_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO Patient 
                        (Patient_First_Name, Patient_Last_Name, Patient_Phone_Number, 
                         Patient_Email, Patient_DOB, Patient_Allergies, 
                         Patient_Street, Patient_Suburb, Patient_City, Patient_Code)
                        VALUES 
                        (@FirstName, @LastName, @Phone, 
                         @Email, @DOB, @Allergies, 
                         @Street, @Suburb, @City, @Code)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", PatientFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", PatientLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", PatientPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", PatientEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(PatientDOB.Text));
                    cmd.Parameters.AddWithValue("@Allergies", PatientAllergies.Text.Trim());
                    cmd.Parameters.AddWithValue("@Street", PatientStreet.Text.Trim());
                    cmd.Parameters.AddWithValue("@Suburb", PatientSuburb.Text.Trim());
                    cmd.Parameters.AddWithValue("@City", PatientCity.Text.Trim());
                    cmd.Parameters.AddWithValue("@Code", PatientCode.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Redirect to login after successful registration
                Response.Redirect("~/Account/Login");
            }
            catch (Exception ex)
            {
                FailureText.Text = "Registration failed: " + ex.Message;
                ErrorMessage.Visible = true;
            }
        }
    }
}
