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
        private PasswordAnimator loginPasswordAnimator;

        public LoginForm()
        {
            InitializeComponent();
            loginPasswordAnimator = new PasswordAnimator(this.txtPassword);
            this.FormClosed += (s, args) => loginPasswordAnimator?.Dispose();
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
            string password = loginPasswordAnimator.RealPassword;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(this, "Lütfen kullanıcı adınızı ve şifrenizi girdiniz.");
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT password FROM users WHERE username = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);


                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string hashedPassword = result.ToString();

                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        MessageBox.Show(this, "Giriş başarıyla gerçekleştirildi!");
                        Session.Username = username;
                        this.DialogResult = DialogResult.OK;


                        this.Close();

                    }
                    else
                    {


                        bool isValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

                        MessageBox.Show(this, "Geçersiz şifre.");
                    }
                }
                else
                {
                    MessageBox.Show(this, "Kullanıcı bulunamadı.");
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
