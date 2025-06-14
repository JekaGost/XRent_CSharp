using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static XRent.Araba;

namespace XRent
{
    public partial class Car_Manager: Form
    {

        public int SelectedCarId { get; set; }

        private int _currentCarStatus;
        private string _currentCarReservedBy;

        private List<string> carGalleryImagePaths;
        private int currentCarGalleryImageIndex;
        private string currentCarGalleryFolderPath;

        private bool UpdateCarField(string dbColumnName, object newValue)
        {
            if (string.IsNullOrWhiteSpace(dbColumnName)) return false;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = $"UPDATE cars SET `{dbColumnName}` = @newValue WHERE id = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newValue", newValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", this.SelectedCarId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(this, "Veriler başarıyla güncellendi!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show(this, "Veriler güncellenemedi. Araç bulunamadı veya değer değişmedi.", "Güncelleme hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Alan güncelleme hatası '{dbColumnName}': {ex.Message}", "Veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Car_Manager()
        {
            InitializeComponent();
        }

        private void Car_Manager_Load(object sender, EventArgs e)
        {
            if (this.SelectedCarId <= 0)
            {
                MessageBox.Show(this, "Araç kimliği bu forma doğru şekilde aktarılmamıştır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (this.SelectedCarId <= 0)
            {
                MessageBox.Show(this, "Araç kimliği bu forma doğru şekilde aktarılmamıştır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadCarDetailsForManagement();

            carGalleryImagePaths = new List<string>();
            currentCarGalleryImageIndex = -1;
            string relativeFolderPath = Path.Combine("Resources", "CarGalleries", $"Car_{this.SelectedCarId}");
            currentCarGalleryFolderPath = Path.Combine(Application.StartupPath, relativeFolderPath);

            LoadCarGalleryImagesInternal();
            ShowCurrentCarGalleryImageInternal();

        }

        private void LoadCarGalleryImagesInternal()
        {
            carGalleryImagePaths.Clear();

            if (Directory.Exists(currentCarGalleryFolderPath))
            {
                string[] files = Directory.GetFiles(currentCarGalleryFolderPath, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                Array.Sort(files, (s1, s2) => {
                    int n1 = int.TryParse(Path.GetFileNameWithoutExtension(s1), out int res1) ? res1 : -1;
                    int n2 = int.TryParse(Path.GetFileNameWithoutExtension(s2), out int res2) ? res2 : -1;
                    return n1.CompareTo(n2);
                });

                carGalleryImagePaths.AddRange(files);

                if (carGalleryImagePaths.Any())
                {
                    currentCarGalleryImageIndex = 0;
                }
                else
                {
                    currentCarGalleryImageIndex = -1;
                }
            }

            UpdateGalleryButtonStates();
        }

        private void ShowCurrentCarGalleryImageInternal()
        {
            Image imageToDisplay = null;

            if (carGalleryImagePaths != null && currentCarGalleryImageIndex >= 0 && currentCarGalleryImageIndex < carGalleryImagePaths.Count)
            {
                string imagePath = carGalleryImagePaths[currentCarGalleryImageIndex];
                try
                {
                    if (File.Exists(imagePath))
                    {
                        byte[] imageData = File.ReadAllBytes(imagePath);
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            imageToDisplay = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, $"Galeri resim dosyası bulunamadı: {Path.GetFileName(imagePath)}", "Dosya bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show(this, $"Galeri görüntüsü yüklenemedi: {Path.GetFileName(imagePath)}.\nBelki de dosya çok büyüktür, bozulmuştur ya da sistemin belleği tükeniyordur.", "Görüntü Hatası (Yetersiz Bellek)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, $"Galeri görüntüsü yüklenirken bir hata oluştu: {Path.GetFileName(imagePath)}.\nDosya bozuk veya yanlış formatta olabilir.\nAyrıntılar: {ex.Message}", "Dosya biçimi hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Galeri görüntüsü yüklenirken genel bir hata: {Path.GetFileName(imagePath)}\nAyrıntılar: {ex.Message}", "Görüntü hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Image oldImage = picCarManageGallery.Image;
            picCarManageGallery.Image = imageToDisplay;
            if (oldImage != null)
            {
                oldImage.Dispose();
            }

            if (picCarManageGallery.Image != null)
            {
                picCarManageGallery.SizeMode = PictureBoxSizeMode.Zoom;
            }
            UpdateGalleryButtonStates();
        }

        private void UpdateGalleryButtonStates()
        {
            btnOnceki.Enabled = carGalleryImagePaths != null && carGalleryImagePaths.Count > 1;
            btnSonraki.Enabled = carGalleryImagePaths != null && carGalleryImagePaths.Count > 1;
        }



        private void LoadCarDetailsForManagement()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM cars WHERE id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", this.SelectedCarId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtBrand.Text = reader["brand"]?.ToString() ?? "";
                                txtModel.Text = reader["model"]?.ToString() ?? "";
                                txtVites.Text = reader["transmission"]?.ToString() ?? "";
                                txtCekis.Text = reader["drive_type"]?.ToString() ?? "";
                                txtMotor.Text = reader["engine_type"]?.ToString() ?? "";

                                string engineCapacityValue = reader["engine_capacity"]?.ToString();
                                if (!string.IsNullOrEmpty(engineCapacityValue)) txtEngine.Text = $"{engineCapacityValue} L"; else txtEngine.Text = "-";

                                string horsepowerValue = reader["horsepower"]?.ToString();
                                if (!string.IsNullOrEmpty(horsepowerValue)) txtHorse.Text = $"{horsepowerValue} BG"; else txtHorse.Text = "-";

                                string accelerationValue = reader["acceleration"]?.ToString();
                                if (!string.IsNullOrEmpty(accelerationValue)) txtHizlanma.Text = $"{accelerationValue} sn"; else txtHizlanma.Text = "-";

                                if (reader["electric_range"] != DBNull.Value && !string.IsNullOrEmpty(reader["electric_range"].ToString())) txtMesafe.Text = $"{reader["electric_range"]} km"; else txtMesafe.Text = "-";

                                string fuelType = reader["fuel_type"]?.ToString() ?? "";
                                string fuelConsumptionValue = reader["fuel_consumption"]?.ToString();
                                txtFuel.Text = fuelType;

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

                                _currentCarStatus = reader["status"] != DBNull.Value ? Convert.ToInt32(reader["status"]) : 0;
                                _currentCarReservedBy = reader["reserved_by"] != DBNull.Value ? reader["reserved_by"].ToString() : null;

                                UpdateReservationStatusUI();
                                LoadMainCarImageForManagement();
                            }
                            else
                            {
                                MessageBox.Show(this, $"ID'si {this.SelectedCarId} olan araç veritabanında bulunamadı.", "Araç bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Veritabanından araç verileri yüklenirken hata oluştu: " + ex.Message, "Veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Araç verileri yüklenirken beklenmeyen bir hata: " + ex.Message, "Genel hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void UpdateReservationStatusUI()
        {
            if (_currentCarStatus == 1)
            {
                if (_currentCarReservedBy == "Araç Denetim Altında")
                {
                    txtRezerve.Text = "Denetimde";
                }
                else if (!string.IsNullOrEmpty(_currentCarReservedBy))
                {
                    txtRezerve.Text = $"Rezerve edildi ({_currentCarReservedBy} tarafından)";
                }
                else
                {
                    txtRezerve.Text = "Rezerve edildi";
                }
                btnRezerveUpdate.Text = "Serbest Bırakmak";
            }
            else
            {
                txtRezerve.Text = "Serbest";
                btnRezerveUpdate.Text = "Denetime Almak";
            }
        }

        private void LoadMainCarImageForManagement()
        {
            Image imageToDisplay = null;
            string carGalleryFolderName = $"Car_{this.SelectedCarId}";
            string relativeImagePath = Path.Combine("Resources", "CarGalleries", carGalleryFolderName, "1.jpg");
            string fullPathToImage = Path.Combine(Application.StartupPath, relativeImagePath);

            if (picCarManage == null) return; 

            try
            {
                if (File.Exists(fullPathToImage))
                {
                    byte[] imageData = File.ReadAllBytes(fullPathToImage);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        imageToDisplay = Image.FromStream(ms);
                    }
                }
            }
            catch (OutOfMemoryException) {  }
            catch (ArgumentException ex) {  }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Image oldImage = picCarManage.Image;
            picCarManage.Image = imageToDisplay;
            if (oldImage != null) { oldImage.Dispose(); }
            if (picCarManage.Image != null) { picCarManage.SizeMode = PictureBoxSizeMode.Zoom; }
        }



        private void geri_btn_Click(object sender, EventArgs e)
        {
            Araba araba = new Araba();
            araba.CurrentUsername = Session.Username;
            araba.OpenedFrom = NavigationSource.AdminMenu;

            araba.StartPosition = FormStartPosition.Manual;
            araba.Location = this.Location;

            araba.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnViewGallery_Click(object sender, EventArgs e)
        {

        }

        private void labelRezerve_Click(object sender, EventArgs e)
        {

        }

        private void txtRezerve_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRezerveUpdate_Click(object sender, EventArgs e)
        {
            object newReservedByValueForDB;
            object reservedAtValueForDB;
            int newStatus;
            string successMessage;
            string confirmMessage;

            if (_currentCarStatus == 1)
            {
                confirmMessage = $"Aracı serbest bırakmak istediğinizden emin misiniz? (ID: {this.SelectedCarId})";
                newStatus = 0;
                newReservedByValueForDB = DBNull.Value;
                reservedAtValueForDB = DBNull.Value;
                successMessage = "Araç başarıyla serbest bırakıldı.";
            }
            else
            {
                confirmMessage = $"Bu aracı (ID: {this.SelectedCarId}) denetim için ayırmak istediğinizden emin misiniz?";
                newStatus = 1;
                newReservedByValueForDB = "Araç Denetim Altında";
                reservedAtValueForDB = DateTime.Now;
                successMessage = "Araç denetim için ayrıldı.";
            }

            if (MessageBox.Show(this, confirmMessage, "İşlem Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = Database.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE cars SET status = @status, reserved_by = @reserved_by, reserved_at = @reserved_at WHERE id = @id";
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@status", newStatus);
                            cmd.Parameters.AddWithValue("@id", this.SelectedCarId);
                            cmd.Parameters.AddWithValue("@reserved_by", newReservedByValueForDB);
                            cmd.Parameters.AddWithValue("@reserved_at", reservedAtValueForDB);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(this, successMessage, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadCarDetailsForManagement();
                            }
                            else
                            {
                                MessageBox.Show(this, "Araç durumu güncellenemedi. Veri başka bir kullanıcı tarafından değiştirilmiş olabilir.", "Güncelleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Araç durumu güncellenirken bir veritabanı hatası oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mesafe_Click(object sender, EventArgs e)
        {

        }

        private void txtMesafe_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMesafeUpdate_Click(object sender, EventArgs e)
        {
            string input = Prompt.ShowDialog(this, "Elektrik gidiş menzili hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (int.TryParse(input, out int newMenzil))
                {
                    if (UpdateCarField("electric_range", newMenzil))
                    {
                        txtMesafe.Text = newMenzil.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Yanlış biçim. Lütfen tam sayı girin.", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void vites_Click(object sender, EventArgs e)
        {

        }

        private void txtVites_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVitesUpgradge_Click(object sender, EventArgs e)
        {
            string newVitesTuru = Prompt.ShowDialog(this, "Vites türü hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(newVitesTuru))
            {
                if (UpdateCarField("transmission", newVitesTuru))
                {
                    txtVites.Text = newVitesTuru;
                }
            }
        }

        private void engineCapacity_Click(object sender, EventArgs e)
        {

        }

        private void txtEngnine_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEngineUpdate_Click(object sender, EventArgs e)
        {
            string input = Prompt.ShowDialog(this, "Motor Kapasitesi hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (decimal.TryParse(input.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal newCapacity))
                {
                    if (UpdateCarField("engine_capacity", newCapacity))
                    {
                        txtEngine.Text = newCapacity.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Yanlış biçim. Lütfen sayıyı girin (örneğin, 1.6).", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void labelBrand_Click(object sender, EventArgs e)
        {

        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newMarka = Prompt.ShowDialog(this, "Marka hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(newMarka))
            {
                if (UpdateCarField("brand", newMarka))
                {
                    txtBrand.Text = newMarka;
                }
            }
        }

        private void labelModel_Click(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newModel = Prompt.ShowDialog(this, "Model hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(newModel))
            {
                if (UpdateCarField("model", newModel))
                {
                    txtModel.Text = newModel;
                }
            }
        }

        private void fuelType_Click(object sender, EventArgs e)
        {

        }

        private void txtFuel_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFuelUpgradge_Click(object sender, EventArgs e)
        {
            string newValue = Prompt.ShowDialog(this, "Yakıt türü hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(newValue))
            {
                if (UpdateCarField("fuel_type", newValue))
                {
                    txtFuel.Text = newValue;
                }
            }
        }

        private void horsePower_Click(object sender, EventArgs e)
        {

        }

        private void txtHorse_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHorseUpgradge_Click(object sender, EventArgs e)
        {
            string input = Prompt.ShowDialog(this, "At gücü hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (int.TryParse(input, out int newHorsepower))
                {
                    if (UpdateCarField("horsepower", newHorsepower))
                    {
                        txtHorse.Text = newHorsepower.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Yanlış biçim. Lütfen tam sayı girin.", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cekisTuru_Click(object sender, EventArgs e)
        {

        }

        private void txtCekis_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCekisUpgradge_Click(object sender, EventArgs e)
        {
            string newCekis = Prompt.ShowDialog(this, "Tahrik hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(newCekis))
            {
                if (UpdateCarField("drive_type", newCekis))
                {
                    txtCekis.Text = newCekis;
                }
            }
        }

        private void Hizlanma_Click(object sender, EventArgs e)
        {

        }

        private void txtHizlanma_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHizlanmaUpgradge_Click(object sender, EventArgs e)
        {
            string input = Prompt.ShowDialog(this, "Aracın hızlanma hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (decimal.TryParse(input.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal newHizlanma))
                {
                    if (UpdateCarField("engine_capacity", newHizlanma))
                    {
                        txtHizlanma.Text = newHizlanma.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Yanlış biçim. Lütfen sayıyı girin (örneğin, 1.6).", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void motoTuru_Click(object sender, EventArgs e)
        {

        }

        private void txtMotor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMotorUpgradge_Click(object sender, EventArgs e)
        {
            string newMotorTuru = Prompt.ShowDialog(this, "Motor hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(newMotorTuru))
            {
                if (UpdateCarField("engine_type", newMotorTuru))
                {
                    txtMotor.Text = newMotorTuru;
                }
            }
        }

        private void tuketim_Click(object sender, EventArgs e)
        {

        }

        private void txtTuketim_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTuketimUpgradge_Click(object sender, EventArgs e)
        {
            string input = Prompt.ShowDialog(this, "Tüketim hakkında güncellenmiş bilgileri giriniz:", "Bilgiler güncellenmesi");

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (decimal.TryParse(input.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal newTuketim))
                {
                    if (UpdateCarField("fuel_consumption", newTuketim))
                    {
                        txtTuketim.Text = newTuketim.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Yanlış biçim. Lütfen sayıyı girin (örneğin, 1.6).", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void picCarManageGallery_Click(object sender, EventArgs e)
        {

        }

        private void btnOnceki_Click(object sender, EventArgs e)
        {
            if (carGalleryImagePaths == null || !carGalleryImagePaths.Any()) return;

            currentCarGalleryImageIndex--;
            if (currentCarGalleryImageIndex < 0)
            {
                currentCarGalleryImageIndex = carGalleryImagePaths.Count - 1;
            }
            ShowCurrentCarGalleryImageInternal();
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            if (carGalleryImagePaths == null || !carGalleryImagePaths.Any()) return;

            currentCarGalleryImageIndex++;
            if (currentCarGalleryImageIndex >= carGalleryImagePaths.Count)
            {
                currentCarGalleryImageIndex = 0;
            }
            ShowCurrentCarGalleryImageInternal();
        }

        private void btnAddCarImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Galeriye eklenecek resimleri seçin";

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (!Directory.Exists(currentCarGalleryFolderPath))
                    {
                        try
                        {
                            Directory.CreateDirectory(currentCarGalleryFolderPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, $"Galeri klasörü oluşturulamadı: {ex.Message}", "Klasör oluşturma hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    int nextImageNumber = 1;
                    if (carGalleryImagePaths.Any())
                    {
                        List<int> existingNumbers = new List<int>();
                        foreach (string path in carGalleryImagePaths)
                        {
                            if (int.TryParse(Path.GetFileNameWithoutExtension(path), out int num))
                            {
                                existingNumbers.Add(num);
                            }
                        }
                        if (existingNumbers.Any())
                        {
                            nextImageNumber = existingNumbers.Max() + 1;
                        }
                    }

                    bool imagesAdded = false;
                    foreach (string selectedFilePath in openFileDialog.FileNames)
                    {
                        try
                        {
                            using (Image tempImage = Image.FromFile(selectedFilePath))
                            {
                            }

                            string extension = Path.GetExtension(selectedFilePath).ToLower();
                            string newFileName = $"{nextImageNumber}{extension}";
                            string destinationPath = Path.Combine(currentCarGalleryFolderPath, newFileName);

                            File.Copy(selectedFilePath, destinationPath, true);
                            imagesAdded = true;
                            nextImageNumber++;
                        }
                        catch (ArgumentException argEx)
                        {
                            MessageBox.Show(this, $"Dosya '{Path.GetFileName(selectedFilePath)}' yanlış bir biçime sahiptir veya bozulmuştur ve eklenmeyecektir.\nAyrıntılar: {argEx.Message}", "Dosya biçimi hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, $"Dosya eklenemedi '{Path.GetFileName(selectedFilePath)}': {ex.Message}", "Ekleme hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (imagesAdded)
                    {
                        LoadCarGalleryImagesInternal();
                        currentCarGalleryImageIndex = carGalleryImagePaths.Count - 1;
                        if (currentCarGalleryImageIndex < 0 && carGalleryImagePaths.Any()) currentCarGalleryImageIndex = 0;

                        ShowCurrentCarGalleryImageInternal();
                        MessageBox.Show("Görseller galeriye başarıyla eklendi!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnResimSil_Click(object sender, EventArgs e)
        {
            if (carGalleryImagePaths == null || !carGalleryImagePaths.Any() || currentCarGalleryImageIndex < 0)
            {
                MessageBox.Show(this, "Silinmek üzere seçilmiş bir görüntü yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string imagePathToDelete = carGalleryImagePaths[currentCarGalleryImageIndex];
            string fileNameToDelete = Path.GetFileName(imagePathToDelete);

            if (MessageBox.Show(this, $"'{fileNameToDelete}' resmi silmek istediğinizden emin misiniz ?",
                                "Silme işleminin onaylanması",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (picCarManageGallery.Image != null)
                    {
                        Image temp = picCarManageGallery.Image;
                        picCarManageGallery.Image = null;
                        temp?.Dispose();
                    }

                    File.Delete(imagePathToDelete);

                    List<string> remainingFiles = Directory.GetFiles(currentCarGalleryFolderPath, "*.*", SearchOption.TopDirectoryOnly)
                        .Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                    s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                    s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                        .OrderBy(f => int.TryParse(Path.GetFileNameWithoutExtension(f), out int res) ? res : int.MaxValue)
                        .ToList();

                    for (int i = 0; i < remainingFiles.Count; i++)
                    {
                        string currentFilePath = remainingFiles[i];
                        string currentFileExt = Path.GetExtension(currentFilePath);
                        string targetFileName = $"{i + 1}{currentFileExt}";
                        string targetFilePath = Path.Combine(currentCarGalleryFolderPath, targetFileName);

                        if (currentFilePath.Equals(targetFilePath, StringComparison.OrdinalIgnoreCase))
                            continue;

                        File.Move(currentFilePath, targetFilePath);
                    }


                    MessageBox.Show(this, $"'{fileNameToDelete}' görüntüsü silindi. Galeri güncellendi.", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadMainCarImageForManagementGallery();

                    if (currentCarGalleryImageIndex >= carGalleryImagePaths.Count)
                    {
                        currentCarGalleryImageIndex = carGalleryImagePaths.Count - 1;
                    }
                    ShowCurrentCarGalleryImageInternal();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Görüntü silinirken bir hata oluştu: {ex.Message}", "Silme hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    LoadMainCarImageForManagementGallery();
                    ShowCurrentCarGalleryImageInternal();
                }
            }
        }

        private void LoadMainCarImageForManagementGallery()
        {
            Image imageToDisplay = null;
            string carGalleryFolderName = $"Car_{this.SelectedCarId}";
            string relativeImagePath = Path.Combine("Resources", "CarGalleries", carGalleryFolderName, "1.jpg");
            string fullPathToImage = Path.Combine(Application.StartupPath, relativeImagePath);

            if (picCarManageGallery == null) return;

            try
            {
                if (File.Exists(fullPathToImage))
                {
                    byte[] imageData = File.ReadAllBytes(fullPathToImage);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        imageToDisplay = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Ana resim yüklenirken bir hata oluştu {fullPathToImage}: {ex.Message}"); }

            Image oldImage = picCarManageGallery.Image;
            picCarManageGallery.Image = imageToDisplay;
            if (oldImage != null) { oldImage.Dispose(); }
            if (picCarManageGallery.Image != null) { picCarManageGallery.SizeMode = PictureBoxSizeMode.Zoom; }
        }
    }
}
