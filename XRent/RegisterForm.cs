using MySql.Data.MySqlClient;
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
using System.Text.RegularExpressions;

namespace XRent
{
    public partial class RegisterForm: Form
    {
        private PasswordAnimator registerPasswordAnimator;

        private bool IsValueInUse(MySqlConnection connection, string columnName, string value)
        {
            string query = $"SELECT COUNT(*) FROM users WHERE {columnName} = @value";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@value", value);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public RegisterForm()
        {
            InitializeComponent();

            registerPasswordAnimator = new PasswordAnimator(this.txtPassword);
            this.FormClosed += (s, args) => registerPasswordAnimator?.Dispose();
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = registerPasswordAnimator.RealPassword;
            string firstName = txtFirst.Text.Trim();
            string lastName = txtSurname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phoneNumber = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show(this, "Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8 || !password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                MessageBox.Show(this, "Parola en az 8 karakter uzunluğunda olmalı, en az bir harf ve bir rakam içermelidir.", "Geçersiz Parola", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show(this, "Lütfen geçerli bir e-posta adresi girin (örnek: kullanici@site.com).", "Geçersiz E-posta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phonePattern = @"^\+\d{12}$";
            if (!Regex.IsMatch(phoneNumber, phonePattern))
            {
                MessageBox.Show(this, "Lütfen geçerli bir telefon numarası girin (örnek: +901234567890).", "Geçersiz Telefon Numarası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    if (IsValueInUse(conn, "username", username))
                    {
                        MessageBox.Show(this, "Bu kullanıcı adı zaten kullanılıyor. Lütfen farklı bir kullanıcı adı seçin.", "Kullanıcı Adı Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (IsValueInUse(conn, "email", email))
                    {
                        MessageBox.Show(this, "Bu e-posta adresi zaten kayıtlı. Lütfen farklı bir e-posta adresi kullanın.", "E-posta Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (IsValueInUse(conn, "phone_number", phoneNumber))
                    {
                        MessageBox.Show(this, "Bu telefon numarası zaten kayıtlı. Lütfen farklı bir telefon numarası kullanın.", "Telefon Numarası Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    string insertQuery = "INSERT INTO users (username, password, first_name, last_name, email, phone_number, isAdmin) VALUES (@username, @password, @first_name, @last_name, @email, @phone_number, @isAdmin)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@first_name", firstName);
                        cmd.Parameters.AddWithValue("@last_name", lastName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone_number", phoneNumber);
                        cmd.Parameters.AddWithValue("@isAdmin", 0);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(this, "Başarıyla kayıt oldunuz! Şimdi giriş yapabilirsiniz.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Veritabanı hatası: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Beklenmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txt_kvkk.Text = Properties.Resources.kvkk_Uyari;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_kvkk_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
