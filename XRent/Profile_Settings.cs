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
using System.Text.RegularExpressions;

namespace XRent
{
    public partial class Profile_Settings: Form
    {
        public Profile_Settings()
        {
            InitializeComponent();
        }

        private void Profile_Settings_Load(object sender, EventArgs e)
        {

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT username, first_name, last_name, email, phone_number FROM users WHERE username = @username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", Session.Username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["username"].ToString();
                            txtFirst.Text = reader["first_name"].ToString();
                            txtSurname.Text = reader["last_name"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtPhone.Text = reader["phone_number"].ToString();
                        }
                    }
                }
            }

        }

        private void Update_btn_Click(object sender, EventArgs e)
        {

            string newUsername = txtUsername.Text.Trim();
            string newFirstName = txtFirst.Text.Trim();
            string newLastName = txtSurname.Text.Trim();
            string newEmail = txtEmail.Text.Trim();
            string newPhone = txtPhone.Text.Trim();

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrWhiteSpace(newEmail) && !Regex.IsMatch(newEmail, emailPattern))
            {
                MessageBox.Show(this, "Lütfen geçerli bir e-posta adresi giriniz (örn. user@example.com).", "Geçersiz E-posta formatı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phonePattern = @"^\+\d{12}$";
            if (!string.IsNullOrWhiteSpace(newPhone) && !Regex.IsMatch(newPhone, phonePattern))
            {
                MessageBox.Show(this, "Lütfen geçerli bir telefon numarası girin (örn. +901234567890, toplam 13 karakter).", "Yanlış telefon formatı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newFirstName) ||
                string.IsNullOrWhiteSpace(newLastName) || string.IsNullOrWhiteSpace(newEmail) ||
                string.IsNullOrWhiteSpace(newPhone))
            {
                MessageBox.Show(this, "Tüm alanlar doldurulmalıdır.", "Boş alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    string checkReservationQuery = "SELECT COUNT(*) FROM cars WHERE reserved_by = @username AND status = 1";
                    using (var checkCmd = new MySqlCommand(checkReservationQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", Session.Username);
                        int reservedCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (reservedCount > 0)
                        {
                            MessageBox.Show(this, "Aktif bir rezervasyonunuz var. Profilinizi güncellemeden önce araç rezervasyonunuzu iptal edin.", "Aktif rezervasyon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (newUsername != Session.Username)
                    {
                        string checkUserQuery = "SELECT COUNT(*) FROM users WHERE username = @newUsername";
                        using (var cmdUser = new MySqlCommand(checkUserQuery, conn))
                        {
                            cmdUser.Parameters.AddWithValue("@newUsername", newUsername);
                            if (Convert.ToInt32(cmdUser.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show(this, "Bu kullanıcı adı kullanımda.", "Teklik hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    string currentDbEmail = "";
                    MySqlCommand getCurrentEmailCmd = new MySqlCommand("SELECT email FROM users WHERE username = @currentUsername", conn);
                    getCurrentEmailCmd.Parameters.AddWithValue("@currentUsername", Session.Username);
                    object emailResult = getCurrentEmailCmd.ExecuteScalar();
                    if (emailResult != null) currentDbEmail = emailResult.ToString();

                    if (newEmail != currentDbEmail)
                    {
                        string checkEmailQuery = "SELECT COUNT(*) FROM users WHERE email = @newEmail";
                        using (var cmdEmail = new MySqlCommand(checkEmailQuery, conn))
                        {
                            cmdEmail.Parameters.AddWithValue("@newEmail", newEmail);
                            if (Convert.ToInt32(cmdEmail.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show(this, "Bu e-posta kullanımda.", "Teklik hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    string currentDbPhone = "";
                    MySqlCommand getCurrentPhoneCmd = new MySqlCommand("SELECT phone_number FROM users WHERE username = @currentUsername", conn);
                    getCurrentPhoneCmd.Parameters.AddWithValue("@currentUsername", Session.Username);
                    object phoneResult = getCurrentPhoneCmd.ExecuteScalar();
                    if (phoneResult != null) currentDbPhone = phoneResult.ToString();

                    if (newPhone != currentDbPhone)
                    {
                        string checkPhoneQuery = "SELECT COUNT(*) FROM users WHERE phone_number = @newPhone";
                        using (var cmdPhone = new MySqlCommand(checkPhoneQuery, conn))
                        {
                            cmdPhone.Parameters.AddWithValue("@newPhone", newPhone);
                            if (Convert.ToInt32(cmdPhone.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show(this, "Bu telefon numarası kullanımda.", "Teklik hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }


                    string updateQuery = @"
                     UPDATE users SET
                     username = @newUsername,
                     first_name = @newFirst,
                     last_name = @newLast,
                     email = @newEmail,
                     phone_number = @newPhone
                     WHERE username = @currentUsername";

                    using (var updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@newUsername", newUsername);
                        updateCmd.Parameters.AddWithValue("@newFirst", newFirstName);
                        updateCmd.Parameters.AddWithValue("@newLast", newLastName);
                        updateCmd.Parameters.AddWithValue("@newEmail", newEmail);
                        updateCmd.Parameters.AddWithValue("@newPhone", newPhone);
                        updateCmd.Parameters.AddWithValue("@currentUsername", Session.Username);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(this, "Veriler başarıyla güncellendi!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Session.Username = newUsername;
                            Profile_Settings_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show(this, "Veriler güncellenemedi. Kullanıcı bulunamamış veya veriler değişmemiş olabilir.", "Güncelleme hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Veritabanı hatası: " + ex.Message, "Veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Öngörülemeyen bir hata meydana geldi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            User_Menu userMenu = new User_Menu();

            userMenu.StartPosition = FormStartPosition.Manual;
            userMenu.Location = this.Location;

            userMenu.Show();
            this.Close();
        }

        private void Username_Label_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void FirstLabel_Click(object sender, EventArgs e)
        {

        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {

        }

        private void Last_Label_Click(object sender, EventArgs e)
        {

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_Label_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneNumber_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViewMyReservation_Click(object sender, EventArgs e)
        {
            int reservedCarId = -1;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id FROM cars WHERE reserved_by = @username AND status = 1 LIMIT 1";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", Session.Username);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            reservedCarId = Convert.ToInt32(result);
                        }
                    }
                }

                if (reservedCarId > 0)
                {
                    Arabalar_Listesi carDetailsForm = new Arabalar_Listesi();
                    carDetailsForm.SelectedCarId = reservedCarId;

                    carDetailsForm.CurrentUsername = Session.Username;
                    carDetailsForm.PreviousForm = this;

                    carDetailsForm.StartPosition = FormStartPosition.Manual;
                    carDetailsForm.Location = this.Location;

                    carDetailsForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(this, "Aktif olarak rezerve edilmiş herhangi bir aracınız yoktur.", "Rezervasyon bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Rezervasyon kontrol edilirken veritabanı hatası: " + ex.Message, "Veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Rezervasyonu kontrol ederken bir hata meydana geldi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
