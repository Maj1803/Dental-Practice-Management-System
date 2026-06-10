using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dental_Practice_Management_System
{
    public partial class LoginForm : Form
    {
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnLogin_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your username and password.",
                    "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dentistConnStr))
                {
                    conn.Open();

                    string query = @"SELECT Employee_First_Name, Employee_Last_Name, Employee_Role
                                     FROM Employee
                                     WHERE Employee_Username = @Username
                                     AND Employee_Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fullName = reader["Employee_First_Name"] + " " + reader["Employee_Last_Name"];
                                string role = reader["Employee_Role"].ToString();

                                if (role != "Dentist" && role != "Receptionist")
                                {
                                    MessageBox.Show("Your account does not have access to this system.",
                                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                MainMDI mainForm = new MainMDI(fullName, role);
                                mainForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect username or password. Please try again.",
                                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Clear();
                                txtPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Could not connect to the database. Please check your connection and try again.",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong. Please restart the application.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                ForgotPassword frm = new ForgotPassword();
                frm.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open the Forgot Password screen.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
                lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            }
            catch (Exception)
            {

            }
        }
    }
}