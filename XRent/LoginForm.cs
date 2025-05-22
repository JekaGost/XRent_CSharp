using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace XRent
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT password FROM users WHERE username = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("Password", password);


                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string hashedPassword = result.ToString();

                    // Сравнение хеша
                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        Console.WriteLine("LOGIN HASH: " + hashedPassword);
                        MessageBox.Show("Login successful!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        // тут можно открыть главное окно или что-то ещё
                    }
                    else
                    {
                        Console.WriteLine("LOGIN HASH: " + hashedPassword);

                        Console.WriteLine("LOGIN password from textbox: >" + password + "<");
                        Console.WriteLine("LOGIN hashed from db:        >" + hashedPassword + "<");

                        bool isValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                        Console.WriteLine("BCrypt.Verify result: " + isValid);

                        MessageBox.Show("Invalid password.");
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
