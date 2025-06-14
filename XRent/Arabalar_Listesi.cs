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
using System.IO;
using static XRent.Araba;

namespace XRent
{
    public partial class Arabalar_Listesi: Form
    {

        public int SelectedCarId { get; set; }

        public string CurrentUsername { get; set; }

        public Form PreviousForm { get; set; }

        private DateTimePicker dateTimeReservation;

        private bool _isCurrentCarReservedByThisUser = false;
        private bool _currentUserHasAnotherReservation = false;


        public Arabalar_Listesi()
        {
            InitializeComponent();

            dateTimeReservation = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm",
                Location = new Point(507, 279),
                Size = new Size(200, 30)
            };

            this.Controls.Add(dateTimeReservation);
        }



        private void Arabalar_Listesi_Load(object sender, EventArgs e)
        {

            txtMarka.Text = "";
            txtModel.Text = "";
            txtCekis.Text = "";
            txtHizlanma.Text = "";
            txtMotorTuru.Text = "";
            txtTuketim.Text = "";
            txtVites.Text = "";
            txtEngineCapacity.Text = "";
            txtFuelType.Text = "";
            txtHorsePower.Text = "";
            txtMesafe.Text = "-";

            if (picCar.Image != null)
            {
                picCar.Image.Dispose();
                picCar.Image = null;
            }

            btnRezerve.Enabled = false;
            dateTimeReservation.Enabled = false;

            if (btnBosalt != null)
            {
                btnBosalt.Enabled = false;
            }

            if (this.SelectedCarId <= 0)
            {
                MessageBox.Show(this, "Araç kimliği bu forma aktarılmamıştır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (string.IsNullOrEmpty(Session.Username))
            {
                MessageBox.Show(this, "Rezervasyonları kontrol etmek için mevcut kullanıcı belirlenemedi.", "Oturum hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            string query = "SELECT * FROM cars WHERE id = @id";

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    string checkOtherReservationsQuery = "SELECT COUNT(*) FROM cars WHERE reserved_by = @currentUsername AND status = 1 AND id != @selectedCarId";
                    using (var checkCmd = new MySqlCommand(checkOtherReservationsQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@currentUsername", Session.Username);
                        checkCmd.Parameters.AddWithValue("@selectedCarId", this.SelectedCarId);
                        _currentUserHasAnotherReservation = (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0);
                    }

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", this.SelectedCarId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtMarka.Text = reader["brand"]?.ToString() ?? "";
                                txtModel.Text = reader["model"]?.ToString() ?? "";
                                txtVites.Text = reader["transmission"]?.ToString() ?? "";
                                txtCekis.Text = reader["drive_type"]?.ToString() ?? "";
                                txtMotorTuru.Text = reader["engine_type"]?.ToString() ?? "";

                                string engineCapacityValue = reader["engine_capacity"]?.ToString();
                                if (!string.IsNullOrEmpty(engineCapacityValue)) txtEngineCapacity.Text = $"{engineCapacityValue} L"; else txtEngineCapacity.Text = "-";

                                string horsepowerValue = reader["horsepower"]?.ToString();
                                if (!string.IsNullOrEmpty(horsepowerValue)) txtHorsePower.Text = $"{horsepowerValue} BG"; else txtHorsePower.Text = "-";

                                string accelerationValue = reader["acceleration"]?.ToString();
                                if (!string.IsNullOrEmpty(accelerationValue)) txtHizlanma.Text = $"{accelerationValue} sn"; else txtHizlanma.Text = "-";

                                if (reader["electric_range"] != DBNull.Value && !string.IsNullOrEmpty(reader["electric_range"].ToString())) txtMesafe.Text = $"{reader["electric_range"]} km"; else txtMesafe.Text = "-";

                                string fuelType = reader["fuel_type"]?.ToString() ?? "";
                                string fuelConsumptionValue = reader["fuel_consumption"]?.ToString();
                                txtFuelType.Text = fuelType;

                                if (!string.IsNullOrEmpty(fuelConsumptionValue))
                                {
                                    if (fuelType.IndexOf("elektrik", StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        txtTuketim.Text = $"{fuelConsumptionValue} kWh/100 km";
                                    }
                                    else
                                    {
                                        txtTuketim.Text = $"{fuelConsumptionValue} L/100 km";
                                    }
                                }
                                else
                                {
                                    txtTuketim.Text = "-";
                                }

                                int currentCarStatus = reader["status"] != DBNull.Value ? Convert.ToInt32(reader["status"]) : 0;
                                string currentCarReservedBy = reader["reserved_by"] != DBNull.Value ? reader["reserved_by"].ToString() : null;

                                if (currentCarStatus == 1)
                                {
                                    if (currentCarReservedBy == Session.Username)
                                    {
                                        _isCurrentCarReservedByThisUser = true;
                                        if (btnBosalt != null) { btnBosalt.Enabled = true; }
                                    }
                                    else
                                    {
                                        _isCurrentCarReservedByThisUser = false;
                                        MessageBox.Show(this, $"Bu araç başka bir kullanıcı tarafından rezerve edilmiştir.", "Araç meşgul", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    _isCurrentCarReservedByThisUser = false;
                                    if (btnBosalt != null) { btnBosalt.Enabled = false; }
                                    if (_currentUserHasAnotherReservation)
                                    {
                                        MessageBox.Show(this, "Bu araç müsait, ancak başka bir araç için rezervasyon yaptınız. Aynı anda yalnızca bir rezervasyon yapabilirsiniz.", "Rezervasyon sınırı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        btnRezerve.Enabled = true;
                                        dateTimeReservation.Enabled = true;
                                    }
                                }

                                Image imageToDisplay = null;
                                string carGalleryFolderName = $"Car_{this.SelectedCarId}";
                                string relativeImagePathForPicCar = Path.Combine("Resources", "CarGalleries", carGalleryFolderName, "1.jpg");
                                string fullPathToPicCarImage = Path.Combine(Application.StartupPath, relativeImagePathForPicCar);
                                try
                                {
                                    if (File.Exists(fullPathToPicCarImage))
                                    {
                                        byte[] imageData = File.ReadAllBytes(fullPathToPicCarImage);
                                        using (MemoryStream ms = new MemoryStream(imageData)) { imageToDisplay = Image.FromStream(ms); }
                                    }
                                }
                                catch (OutOfMemoryException) { MessageBox.Show(this, $"Aracın ana resmi (1.jpg) yüklenemedi.\nDosya çok büyük veya bozuk.", "Bellek hatası", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                catch (ArgumentException ex) { MessageBox.Show(this, $"Ana görüntünün formatında hata var (1.jpg).\nDosya bozuk veya format yanlış.\nDetaylar: {ex.Message}", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                catch (Exception ex) { MessageBox.Show(this, $"Ana görüntünün yüklenmesinde genel hata (1.jpg).\nDetaylar: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                                Image oldImage = picCar.Image;
                                picCar.Image = imageToDisplay;
                                if (oldImage != null) { oldImage.Dispose(); }
                                if (picCar.Image != null) { picCar.SizeMode = PictureBoxSizeMode.StretchImage; }
                            }
                            else
                            {
                                MessageBox.Show(this, "Belirtilen kimlik numarasına sahip araç bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Veritabanına bağlanırken veya veritabanına sorgu gönderirken hata oluştu: " + ex.Message, "Veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Araç verilerini yüklerken beklenmedik bir hata oluştu: " + ex.Message, "Genel hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void picCar_Click(object sender, EventArgs e)
        {

        }

        private void btnViewGallery_Click(object sender, EventArgs e)
        {
            if (this.SelectedCarId > 0)
            {
                Gallery galleryForm = new Gallery(this.SelectedCarId, this);

                galleryForm.StartPosition = FormStartPosition.Manual;
                galleryForm.Location = this.Location;

                galleryForm.StartPosition = FormStartPosition.Manual;
                galleryForm.Location = this.Location;

                galleryForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(this, "Öncelikle aracı seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void marka_Click(object sender, EventArgs e)
        {

        }

        private void txtMarka_Click(object sender, EventArgs e)
        {

        }

        private void model_Click(object sender, EventArgs e)
        {

        }

        private void txtModel_Click(object sender, EventArgs e)
        {

        }

        private void vites_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtVites_Click(object sender, EventArgs e)
        {

        }

        private void engineCapacity_Click(object sender, EventArgs e)
        {

        }

        private void txtEngineCapacity_Click(object sender, EventArgs e)
        {

        }

        private void fuelType_Click(object sender, EventArgs e)
        {

        }

        private void txtFuelType_Click(object sender, EventArgs e)
        {

        }

        private void horsePower_Click(object sender, EventArgs e)
        {

        }

        private void txtHorsePower_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cekisTuru_Click(object sender, EventArgs e)
        {

        }

        private void Hizlanma_Click(object sender, EventArgs e)
        {

        }

        private void txtCekis_Click(object sender, EventArgs e)
        {

        }

        private void txtHizlanma_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void motoTuru_Click(object sender, EventArgs e)
        {

        }

        private void txtMotorTuru_Click(object sender, EventArgs e)
        {

        }

        private void tuketim_Click(object sender, EventArgs e)
        {

        }

        private void txtTuketim_Click(object sender, EventArgs e)
        {

        }

        private void mesafe_Click(object sender, EventArgs e)
        {

        }

        private void txtMesafe_Click(object sender, EventArgs e)
        {

        }

        private void btnRezerve_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session.Username))
            {
                MessageBox.Show(this, "Geçerli kullanıcı belirlenemedi. Lütfen sisteme yeniden giriş yapın.", "Oturum hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool canReserve = false;
            int currentCarStatusCheck = 0;
            string currentCarReservedByCheck = null;
            bool userHasOtherReservationCheck = false;

            try
            {
                using (var connCheck = Database.GetConnection())
                {
                    connCheck.Open();
                    string checkOtherQuery = "SELECT COUNT(*) FROM cars WHERE reserved_by = @currentUsername AND status = 1 AND id != @selectedCarId";
                    using (var cmdOther = new MySqlCommand(checkOtherQuery, connCheck))
                    {
                        cmdOther.Parameters.AddWithValue("@currentUsername", Session.Username);
                        cmdOther.Parameters.AddWithValue("@selectedCarId", this.SelectedCarId);
                        userHasOtherReservationCheck = (Convert.ToInt32(cmdOther.ExecuteScalar()) > 0);
                    }

                    string checkCurrentQuery = "SELECT status, reserved_by FROM cars WHERE id = @selectedCarId";
                    using (var cmdCurrent = new MySqlCommand(checkCurrentQuery, connCheck))
                    {
                        cmdCurrent.Parameters.AddWithValue("@selectedCarId", this.SelectedCarId);
                        using (var readerCurrent = cmdCurrent.ExecuteReader())
                        {
                            if (readerCurrent.Read())
                            {
                                currentCarStatusCheck = readerCurrent["status"] != DBNull.Value ? Convert.ToInt32(readerCurrent["status"]) : 0;
                                currentCarReservedByCheck = readerCurrent["reserved_by"] != DBNull.Value ? readerCurrent["reserved_by"].ToString() : null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Rezervasyon durumunu yeniden kontrol ederken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (currentCarStatusCheck == 1)
            {
                MessageBox.Show(this, "Bu araç zaten rezerve edilmiştir. Muhtemelen başka biri sizden önce davranmıştır.", "Araç dolu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnRezerve.Enabled = false;
                dateTimeReservation.Enabled = false;
                return;
            }
            if (userHasOtherReservationCheck)
            {
                MessageBox.Show(this, "Başka bir araç için rezervasyon yaptınız. Aynı anda yalnızca bir aktif rezervasyonunuz olabilir.", "Rezervasyon sınırı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnRezerve.Enabled = false;
                dateTimeReservation.Enabled = false;
                return;
            }


            DateTime selectedDateTime = dateTimeReservation.Value;
            DateTime now = DateTime.Now;

            if (selectedDateTime <= now)
            {
                MessageBox.Show(this, "Geçmiş tarih/saat seçilemez.");
                return;
            }

            if ((selectedDateTime - now).TotalHours < 1) {
                MessageBox.Show(this, "Bir saatten az kalan süre seçilemez.");
                return;
            }
            if ((selectedDateTime - now).TotalHours > 48) {
                MessageBox.Show(this, "48 saatten fazla kalan süre seçilemez.");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string preCheckQuery = "SELECT status FROM cars WHERE id = @id";
                    using (var preCmd = new MySqlCommand(preCheckQuery, conn))
                    {
                        preCmd.Parameters.AddWithValue("@id", SelectedCarId);
                        object statusResult = preCmd.ExecuteScalar();
                        if (statusResult != null && Convert.ToInt32(statusResult) == 1)
                        {
                            MessageBox.Show(this, "Üzgünüm, bu araç başka bir kullanıcı tarafından az önce rezerve edildi.", "Araç dolu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Arabalar_Listesi_Load(null, null);
                            return;
                        }
                    }


                    string query = "UPDATE cars SET status = 1, reserved_by = @username, reserved_at = @reservedUntil WHERE id = @id AND (status = 0 OR status IS NULL)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", Session.Username);
                        cmd.Parameters.AddWithValue("@reservedUntil", selectedDateTime);
                        cmd.Parameters.AddWithValue("@id", SelectedCarId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(this, "Araç başarıyla rezerve edildi!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Arabalar_Listesi_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show(this, "Aracı rezerve edemedik. Muhtemelen araç zaten rezerve edilmiş veya bir hata meydana gelmiştir.", "Rezervasyon hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Arabalar_Listesi_Load(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Araç rezervasyonu sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBosalt_Click(object sender, EventArgs e)
        {
            if (!_isCurrentCarReservedByThisUser)
            {
                MessageBox.Show(this, "Sadece kendi rezervasyonunuzu iptal edebilirsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(this, "Bu araç için yaptığınız rezervasyonu iptal etmek istediğinizden emin misiniz?",
                                "Rezervasyon İptalini Onayla",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = Database.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE cars SET status = 0, reserved_by = NULL, reserved_at = NULL WHERE id = @carId AND reserved_by = @username";

                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@carId", this.SelectedCarId);
                            cmd.Parameters.AddWithValue("@username", Session.Username);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(this, "Rezervasyonunuz başarıyla iptal edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Arabalar_Listesi_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show(this, "Rezervasyon iptal edilemedi. Muhtemelen daha önce iptal edilmiş.", "İptal Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Arabalar_Listesi_Load(sender, e);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Rezervasyon iptali sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

    }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            if (this.PreviousForm != null)
            {
                Point currentLocation = this.Location;
                this.PreviousForm.StartPosition = FormStartPosition.Manual;
                this.PreviousForm.Location = currentLocation;
                this.PreviousForm.Show();
            }
            else
            {
                User_Menu fallbackMenu = new User_Menu();
                fallbackMenu.StartPosition = FormStartPosition.Manual;
                fallbackMenu.Location = this.Location;
                fallbackMenu.Show();
                MessageBox.Show(this, "Önceki form belirlenemedi. Kullanıcı menüsüne geri dön.", "Navigasyon hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }
    }
}
