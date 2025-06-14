using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;
using System.IO;

namespace XRent
{
    public partial class User_Profile_As_Admin: Form
    {

        public int SelectedUserId { get; set; }
        public string CurrentUsername { get; set; }

        private bool isDragging = false;
        private Point dragStartPoint = new Point(0, 0);

        public User_Profile_As_Admin(int selectedUserId, string currentUsername)
        {
            SelectedUserId = selectedUserId;
            CurrentUsername = currentUsername;
            InitializeComponent();
            SetupCustomTitleBar();
        }

        private void SetupCustomTitleBar()
        {
            this.picBtnMinimize.Click += new System.EventHandler(this.picBtnMinimize_Click);
            this.picBtnMinimize.MouseEnter += new System.EventHandler(this.picBtnMinimize_MouseEnter);
            this.picBtnMinimize.MouseLeave += new System.EventHandler(this.picBtnMinimize_MouseLeave);

            this.picBtnHome.Click += new System.EventHandler(this.picBtnHome_Click);
            this.picBtnHome.MouseEnter += new System.EventHandler(this.picBtnHome_MouseEnter);
            this.picBtnHome.MouseLeave += new System.EventHandler(this.picBtnHome_MouseLeave);

            this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
            this.panelTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseMove);
            this.panelTopBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseUp);

            try
            {
                this.picBtnMinimize.Image = Properties.Resources.minimize_normal;
                this.picBtnHome.Image = Properties.Resources.home_normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Proje kaynaklarından düğmeler için simgeler yüklenemedi.\n" + ex.Message, "Kaynak hatası");
            }
        }


        private void LoadReservedCarInfo()
        {
            if (txtCarName != null)
            {
                txtCarName.Text = "";
            }

            if (picCar != null && picCar.Image != null)
            {
                picCar.Image.Dispose();
                picCar.Image = null;
            }

            if (string.IsNullOrEmpty(this.CurrentUsername))
            {
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, brand, model FROM cars WHERE reserved_by = @Username LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", this.CurrentUsername);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int carId = reader.GetInt32("id");
                                string brand = reader["brand"]?.ToString() ?? "";
                                string model = reader["model"]?.ToString() ?? "";
                                txtCarName.Text = $"{brand} {model}".Trim();

                                Image imageToDisplay = null;
                                string carGalleryFolderName = $"Car_{carId}";
                                string relativeImagePath = Path.Combine("Resources", "CarGalleries", carGalleryFolderName, "1.jpg");
                                string fullPath = Path.Combine(Application.StartupPath, relativeImagePath);

                                if (File.Exists(fullPath))
                                {
                                    try
                                    {
                                        byte[] imageData = File.ReadAllBytes(fullPath);
                                        using (MemoryStream ms = new MemoryStream(imageData))
                                        {
                                            imageToDisplay = Image.FromStream(ms);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(this,
                                            $"Rezervasyona ait araç resmi yüklenirken bir hata oluştu.\nDosya: {Path.GetFileName(fullPath)}\n\nHata: {ex.Message}",
                                            "Resim Yükleme Hatası",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                                    }
                                }

                                Image oldImage = picCar.Image;
                                picCar.Image = imageToDisplay;
                                if (oldImage != null) { oldImage.Dispose(); }
                                if (picCar.Image != null) { picCar.SizeMode = PictureBoxSizeMode.Zoom; }
                            }
                            else
                            {
                                txtCarName.Text = "Kullanıcının rezerve ettiği araç yok.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Rezerve edilen araç bilgileri yüklenirken bir hata oluştu: " + ex.Message, "Genel Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCarName.Text = "Veri Yüklenemedi";
                if (picCar.Image != null) { picCar.Image.Dispose(); picCar.Image = null; }
            }
        }

        private void User_Profile_As_Admin_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT username, first_name, last_name, email, phone_number FROM users WHERE id = @UserId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", SelectedUserId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUsername.Text = reader["username"].ToString();
                                txtFirst.Text = reader["first_name"].ToString();
                                txtSurname.Text = reader["last_name"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtPhone.Text = reader["phone_number"].ToString();
                            }
                            else
                            {
                                MessageBox.Show(this, "Kullanıcı bulunamadı.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Veri yüklenirken hata oluştu: " + ex.Message);
            }

            LoadReservedCarInfo();
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            User_Search userSearch = new User_Search();

            userSearch.StartPosition = FormStartPosition.Manual;
            userSearch.Location = this.Location;

            userSearch.Show();
            this.Close();
        }

        private void Username_Label_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
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

        private void Password_Label_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void picCar_Click(object sender, EventArgs e)
        {

        }

        private void btnUsernameUpdate_Click(object sender, EventArgs e)
        {
            string newUsername = Prompt.ShowDialog(this, "Yeni kullanıcı adı giriniz:", "Kullanıcı adı güncelleniyor");

            if (newUsername == null) return;

            if (string.IsNullOrWhiteSpace(newUsername))
            {
                MessageBox.Show(this, "Kullanıcı adı alanı boş bırakılamaz.");
                return;
            }
            if (newUsername == this.CurrentUsername)
            {
                return;
            }
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string checkReservationQuery = "SELECT COUNT(*) FROM cars WHERE reserved_by = @UsernameToCheck";
                    using (var reservationCmd = new MySqlCommand(checkReservationQuery, conn))
                    {
                        reservationCmd.Parameters.AddWithValue("@UsernameToCheck", this.CurrentUsername);
                        if (Convert.ToInt32(reservationCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show(this, $"Kullanıcı '{this.CurrentUsername}' aktif araç rezervasyonlarına sahiptir. Kullanıcının adını değiştirmek için lütfen önce kullanıcının rezervasyonu iptal edin.");
                            return;
                        }
                    }
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @Username AND id != @UserId";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", newUsername);
                        checkCmd.Parameters.AddWithValue("@UserId", this.SelectedUserId);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show(this, "Bu kullanıcı adı kullanımda. Lütfen başka bir kullanıcı adı seçin.");
                            return;
                        }
                    }
                    string updateQuery = "UPDATE users SET username = @Username WHERE id = @UserId";
                    using (var updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Username", newUsername);
                        updateCmd.Parameters.AddWithValue("@UserId", this.SelectedUserId);
                        updateCmd.ExecuteNonQuery();
                        txtUsername.Text = newUsername;
                        this.CurrentUsername = newUsername;
                        MessageBox.Show(this, "Kullanıcı adı başarıyla güncellendi.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Kullanıcı adı güncelleme sırasında veritabanı hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Kullanıcı adı güncelleme sırasında hata: " + ex.Message);
            }
        }

        private void btnPasswordUpdate_Click(object sender, EventArgs e)
        {
            string newPassword = Prompt.ShowDialog(this, "Yeni şifre giriniz:", "Şifre güncellenmesi");

            if (newPassword == null) return;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show(this, "Şifre alanı boş bırakılamaz.");
                return;
            }
            if (newPassword.Length < 8 || !Regex.IsMatch(newPassword, @"[A-Za-z]") || !Regex.IsMatch(newPassword, @"\d"))
            {
                MessageBox.Show(this, "Şifre en az 8 karakterden oluşmalı ve en az bir harf ve bir rakam içermelidir.");
                return;
            }
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string updateQuery = "UPDATE users SET password = @Password WHERE id = @UserId";
                    using (var updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Password", hashedPassword);
                        updateCmd.Parameters.AddWithValue("@UserId", this.SelectedUserId);
                        updateCmd.ExecuteNonQuery();
                        txtPassword.Text = "********";
                        MessageBox.Show(this, "Şifre başarıyla güncellendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Şifre güncelleme hatası: " + ex.Message);
            }
        }

        private void btnNameUpdate_Click(object sender, EventArgs e)
        {
            string newFirstName = Prompt.ShowDialog(this, "Yeni ismi giriniz:", "İsim güncellenmesi");

            if (newFirstName == null) return;

            if (string.IsNullOrWhiteSpace(newFirstName))
            {
                MessageBox.Show(this, "İsim alanı boş bırakılamaz.");
                return;
            }
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string updateQuery = "UPDATE users SET first_name = @FirstName WHERE id = @UserId";
                    using (var updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@FirstName", newFirstName);
                        updateCmd.Parameters.AddWithValue("@UserId", this.SelectedUserId);
                        updateCmd.ExecuteNonQuery();
                        txtFirst.Text = newFirstName;
                        MessageBox.Show(this, "İsim başarıyla güncellendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "İsim güncellenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnSurnameUpdate_Click(object sender, EventArgs e)
        {
            string newLastName = Prompt.ShowDialog(this, "Yeni bir soyadı giriniz:", "Soyad alanı güncellenmesi");

            if (newLastName == null) return;

            if (string.IsNullOrWhiteSpace(newLastName))
            {
                MessageBox.Show(this, "Soyadı alanı boş bırakılamaz.");
                return;
            }
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string updateQuery = "UPDATE users SET last_name = @LastName WHERE id = @UserId";
                    using (var updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@LastName", newLastName);
                        updateCmd.Parameters.AddWithValue("@UserId", this.SelectedUserId);
                        updateCmd.ExecuteNonQuery();
                        txtSurname.Text = newLastName;
                        MessageBox.Show(this, "Soyadı başarıyla güncellendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Soyadı güncelleme hatası: " + ex.Message);
            }
        }

        private void btnEmailUpdate_Click(object sender, EventArgs e)
        {
            string newEmail = Prompt.ShowDialog(this, "Yeni e-posta adresini giriniz:", "E-posta güncellenmesi");

            if (newEmail == null) return;

            if (string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show(this, "E-posta alanı boş bırakılamaz.");
                return;
            }
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(newEmail, emailPattern))
            {
                MessageBox.Show(this, "E-posta biçimi geçersiz. Lütfen geçerli bir e-posta girin.");
                return;
            }
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @Email AND id != @UserId";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", newEmail);
                        checkCmd.Parameters.AddWithValue("@UserId", this.SelectedUserId);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show(this, "Bu e-posta kullanımda. Lütfen başka bir e-posta giriniz.");
                            return;
                        }
                    }
                    string updateQuery = "UPDATE users SET email = @Email WHERE id = @UserId";
                    using (var updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Email", newEmail);
                        updateCmd.Parameters.AddWithValue("@UserId", this.SelectedUserId);
                        updateCmd.ExecuteNonQuery();
                        txtEmail.Text = newEmail;
                        MessageBox.Show(this, "E-posta başarıyla güncellendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "E-posta güncellenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnPhoneUpdate_Click(object sender, EventArgs e)
        {
            string newPhoneNumber = Prompt.ShowDialog(this, "Yeni telefon numaranyı giriniz:", "Telefon numarası güncellenmesi");

            if (newPhoneNumber == null) return;

            if (string.IsNullOrWhiteSpace(newPhoneNumber))
            {
                MessageBox.Show(this, "Telefon numarası boş bırakılamaz.");
                return;
            }
            string phonePattern = @"^\+\d{12}$"; // Изменил на 12 цифр, как мы обсуждали
            if (!Regex.IsMatch(newPhoneNumber, phonePattern))
            {
                MessageBox.Show(this, "Telefon numarası formatı yanlış. Örnek: +905123456789");
                return;
            }
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE phone_number = @PhoneNumber AND id != @UserId";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@PhoneNumber", newPhoneNumber);
                        checkCmd.Parameters.AddWithValue("@UserId", this.SelectedUserId);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show(this, "Bu numara kullanımda. Lütfen başka bir numara seçiniz.");
                            return;
                        }
                    }
                    string updateQuery = "UPDATE users SET phone_number = @PhoneNumber WHERE id = @UserId";
                    using (var updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@PhoneNumber", newPhoneNumber);
                        updateCmd.Parameters.AddWithValue("@UserId", this.SelectedUserId);
                        updateCmd.ExecuteNonQuery();
                        txtPhone.Text = newPhoneNumber;
                        MessageBox.Show(this, "Telefon numarası başarıyla güncellendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Numara güncelleme hatası: " + ex.Message);
            }
        }

        private void txtCarName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChangeCarStatus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, $"'{this.CurrentUsername}' kullanıcısının rezervasyonunu iptal etmek istediğinizden emin misiniz?", "İşlem Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string updateQuery = "UPDATE cars SET status = 0, reserved_by = NULL, reserved_at = NULL WHERE reserved_by = @Username";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Username", this.CurrentUsername);
                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(this, "Kullanıcının araç rezervasyonu başarıyla iptal edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadReservedCarInfo();
                        }
                        else
                        {
                            MessageBox.Show(this, "Kullanıcının aktif bir rezervasyonu bulunmuyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Veritabanı hatası oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Beklenmeyen bir hata oluştu: " + ex.Message, "Genel Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelTopBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picBtnMinimize_Click(object sender, EventArgs e)
        {
            AppNavigator.MinimizeWindow(this);
        }

        private void picBtnHome_Click(object sender, EventArgs e)
        {
            AppNavigator.GoToUserMenu(this);
        }

        private void picBtnMinimize_MouseEnter(object sender, EventArgs e)
        {
            AppNavigator.HandleMouseEnter(sender, Properties.Resources.minimize_hover);
        }

        private void picBtnMinimize_MouseLeave(object sender, EventArgs e)
        {
            AppNavigator.HandleMouseLeave(sender, Properties.Resources.minimize_normal);
        }

        private void picBtnHome_MouseEnter(object sender, EventArgs e)
        {
            AppNavigator.HandleMouseEnter(sender, Properties.Resources.home_hover);
        }

        private void picBtnHome_MouseLeave(object sender, EventArgs e)
        {
            AppNavigator.HandleMouseLeave(sender, Properties.Resources.home_normal);
        }

        private void panelTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            AppNavigator.HandleMouseDown(e, ref isDragging, ref dragStartPoint);
        }

        private void panelTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            AppNavigator.HandleMouseMove(this, e, isDragging, dragStartPoint);
        }

        private void panelTopBar_MouseUp(object sender, MouseEventArgs e)
        {
            AppNavigator.HandleMouseUp(ref isDragging);
        }

        private void panelDivider_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
