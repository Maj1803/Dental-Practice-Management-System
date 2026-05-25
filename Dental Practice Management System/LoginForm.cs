using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class LoginForm : Form
    {
        private string selectedRole = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnReceptionist_Click(object sender, EventArgs e)
        {
            selectedRole = "Receptionist";
            HighlightButton(btnReceptionist, btnDentist);
        }

        private void btnDentist_Click(object sender, EventArgs e)
        {
            selectedRole = "Dentist";
            HighlightButton(btnDentist, btnReceptionist);
        }

        private void HighlightButton(Button selected, Button other)
        {
            selected.BackColor = Color.FromArgb(26, 58, 143);
            selected.ForeColor = Color.White;
            other.BackColor = Color.White;
            other.ForeColor = Color.FromArgb(26, 58, 143);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (selectedRole == "")
            {
                MessageBox.Show("Please select Receptionist or Dentist first.",
                    "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your username and password.",
                    "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT Employee_ID, Employee_First_Name, Employee_Last_Name, Employee_Role
                                     FROM Employee
                                     WHERE Employee_Username = @Username
                                     AND Employee_Password = @Password
                                     AND Employee_Role = @Role";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", selectedRole);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fullName = reader["Employee_First_Name"].ToString() + " " + reader["Employee_Last_Name"].ToString();
                        string role = reader["Employee_Role"].ToString();

                        MessageBox.Show("Login Successful!\n\nWelcome, " + fullName + "!\nLogged in as: " + role,
                            "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // I Will Uncomment once MDIParent is ready. 
                        //For now there is success messages.
                        // MDIParent mainForm = new MDIParent(fullName, role);
                        // mainForm.Show();
                        // this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username, password, or role. Please try again.",
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}