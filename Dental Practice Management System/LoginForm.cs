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
            SetupForm();
        }

        private void SetupForm()
        {
            groupBox1.Visible = true;
            CentrePanel();
            this.Resize += (s, e) => CentrePanel();
        }

        private void CentrePanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2 + 50;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void rdoReceptionist_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReceptionist.Checked)
                selectedRole = "Receptionist";
        }

        private void rdoDentist_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDentist.Checked)
                selectedRole = "Dentist";
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

                        MainMDI mainForm = new MainMDI(fullName, role);
                        mainForm.Show();
                        this.Hide();
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

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnTogglePassword.Text = "🕶";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnTogglePassword.Text = "👁";
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void llblForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact IT department to reset your password.",
                            "Forgot Password",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "IT SUPPORT CONSULTANTS:\n\n" +
                "• Mahdiya\n" +
                "• Jeslin\n" +
                "• Nihal\n" +
                "• Nashwah\n" +
                "• Raeesa\n" +
                "• Katelyn",
                "Development Team",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}