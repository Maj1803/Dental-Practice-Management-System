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

        // ==================== PANEL TOGGLE ====================

        protected void BtnSelectPatient_Click(object sender, EventArgs e)
        {
            PatientPanel.Visible = true;
            StaffPanel.Visible = false;

            BtnSelectPatient.CssClass = "btn btn-info";
            BtnSelectStaff.CssClass = "btn btn-outline-info";
        }

        protected void BtnSelectStaff_Click(object sender, EventArgs e)
        {
            PatientPanel.Visible = false;
            StaffPanel.Visible = true;

            BtnSelectPatient.CssClass = "btn btn-outline-info";
            BtnSelectStaff.CssClass = "btn btn-info";
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

        // ==================== REGISTER STAFF ====================

        protected void BtnRegisterStaff_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO Employee 
                        (Employee_First_Name, Employee_Last_Name, Employee_Role, 
                         Employee_Phone_Number, Employee_Email, Employee_Username, 
                         Employee_Password, Employee_National_ID, Employee_Age)
                        VALUES 
                        (@FirstName, @LastName, @Role, 
                         @Phone, @Email, @Username, 
                         @Password, @NationalID, @Age)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", StaffFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", StaffLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", StaffRole.SelectedValue);
                    cmd.Parameters.AddWithValue("@Phone", StaffPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", StaffEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", StaffUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", StaffPassword.Text);
                    cmd.Parameters.AddWithValue("@NationalID", StaffNationalID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(StaffAge.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

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
