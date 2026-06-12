using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsernameR.Text) ||
                string.IsNullOrWhiteSpace(txtEmployeeID.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show(
                    "Please complete all fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Password must be at least 8 characters
            if (txtNewPassword.Text.Length < 8)
            {
                MessageBox.Show(
                    "Password must be at least 8 characters long.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Password must contain at least one letter and one number
            bool hasLetter = false;
            bool hasNumber = false;

            foreach (char c in txtNewPassword.Text)
            {
                if (char.IsLetter(c))
                    hasLetter = true;

                if (char.IsDigit(c))
                    hasNumber = true;
            }

            if (!hasLetter || !hasNumber)
            {
                MessageBox.Show(
                    "Password must contain at least one letter and one number.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE Employee
                          SET Employee_Password = @Password
                          WHERE Employee_Username = @Username
                          AND Employee_ID = @EmployeeID",
                        conn);

                    cmd.Parameters.AddWithValue("@Username", txtUsernameR.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(txtEmployeeID.Text));
                    cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(
                            "Password reset successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid Username or Employee ID.",
                            "Reset Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Employee ID must be a number.",
                    "Invalid Employee ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.UseSystemPasswordChar)
            {
                txtNewPassword.UseSystemPasswordChar = false;
                btnShowPass.Text = "🕶";
            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = true;
                btnShowPass.Text = "👁";
            }
        }
    }
}