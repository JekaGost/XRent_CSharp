using MySql.Data.MySqlClient;
//using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace XRent
{
    public partial class RegisterForm: Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string first_name = txtFirst.Text;
            string last_name = txtSurname.Text;
            string email = txtEmail.Text;
            string phone_number = txtPhone.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(first_name) || string.IsNullOrEmpty(last_name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone_number))
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Tüm Yerler Doldurmalıdır!");
                    return;
                }

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Проверка, существует ли пользователь
                MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @username", conn);
                checkCmd.Parameters.AddWithValue("@username", username);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Nickname ismi dolu.");
                    return;
                }

                // Хеширование пароля (можно использовать SHA256, но здесь пример простой)
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                // Добавление пользователя
                MySqlCommand cmd = new MySqlCommand("INSERT INTO users (username, password, first_name, last_name, email, phone_number) VALUES (@username, @password, @first_name, @last_name, @email, @phone_number)", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone_number", phone_number);
                cmd.ExecuteNonQuery();

                Console.WriteLine("REGISTER HASH: " + hashedPassword);

                MessageBox.Show("Başarıyla kayıt oldunuz!");
            }
        }

        // Метод для хеширования пароля
      /*  private string GetSha256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        } */

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
