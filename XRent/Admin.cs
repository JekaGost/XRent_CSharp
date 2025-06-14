using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static XRent.Araba;
using System.IO;
using MySql.Data.MySqlClient;

namespace XRent
{
    public partial class Admin: Form
    {

        private bool isDragging = false;
        private Point dragStartPoint = new Point(0, 0);

        public Admin()
        {
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
                MessageBox.Show(this, "Proje kaynaklarından düğme simgeleri yüklenemedi.\n" + ex.Message, "Kaynak hatası");
            }
        }

        private bool IsValidImageFile(string filePath)
        {
            try
            {
                using (Image img = Image.FromFile(filePath))
                {
                    return true;
                }
            }
            catch { return false; }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Users_btn_Click(object sender, EventArgs e)
        {
            User_Search userSearch = new User_Search();

            userSearch.StartPosition = FormStartPosition.Manual;
            userSearch.Location = this.Location;

            userSearch.Show();
            this.Close();
        }

        private void Cars_btn_Click(object sender, EventArgs e)
        {
            Araba araba = new Araba();

            araba.CurrentUsername = Session.Username;
            araba.OpenedFrom = NavigationSource.AdminMenu;

            araba.StartPosition = FormStartPosition.Manual;
            araba.Location = this.Location;

            araba.Show();
            this.Close();
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            User_Menu userMenu = new User_Menu();
            userMenu.StartPosition = FormStartPosition.Manual;
            userMenu.Location = this.Location;
            userMenu.Show();
            this.Hide();
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            int newCarId = -1;

            using (AddNewCarDetailsDialog detailsDialog = new AddNewCarDetailsDialog())
            {
                detailsDialog.StartPosition = FormStartPosition.Manual;
                detailsDialog.Location = this.Location;

                if (detailsDialog.ShowDialog(this) == DialogResult.OK)
                {
                    newCarId = detailsDialog.NewCarId;
                }
                else
                {
                    MessageBox.Show("Araç ekleme işlemi, ayrıntıların girilmesi aşamasında iptal edildi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (newCarId == -1)
            {
                MessageBox.Show("Detayları girdikten sonra yeni aracın kimlik numarasını alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string carGalleryRootFolder = Path.Combine(Application.StartupPath, "Resources", "CarGalleries");
            string currentCarGalleryFolderPath = Path.Combine(carGalleryRootFolder, $"Car_{newCarId}");
            string profileImageRelativePath = "";

            try
            {
                if (!Directory.Exists(currentCarGalleryFolderPath))
                {
                    Directory.CreateDirectory(currentCarGalleryFolderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Araç galerisi için klasör oluşturulamadı (ID: {newCarId}): {ex.Message}", "Klasör oluşturma hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OpenFileDialog profileImageDialog = new OpenFileDialog())
            {
                profileImageDialog.Title = "Profil resmini seçiniz (1.jpg)";
                profileImageDialog.Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png";
                profileImageDialog.Multiselect = false;

                if (profileImageDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string selectedProfileImagePath = profileImageDialog.FileName;
                    if (!IsValidImageFile(selectedProfileImagePath))
                    {
                        MessageBox.Show("Seçilen profil resmi dosyası geçerli bir resim değil veya desteklenmeyen bir formatta.", "Dosya hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string fileExtension = Path.GetExtension(selectedProfileImagePath);
                    string destinationProfileImagePath = Path.Combine(currentCarGalleryFolderPath, $"1{fileExtension}");

                    try
                    {
                        File.Copy(selectedProfileImagePath, destinationProfileImagePath, true);
                        profileImageRelativePath = Path.Combine("Resources", "CarGalleries", $"Car_{newCarId}", $"1{fileExtension}");

                        using (var conn = Database.GetConnection())
                        {
                            conn.Open();
                            string updateQuery = "UPDATE cars SET image_path = @imagePath WHERE id = @id";
                            using (var cmd = new MySqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@imagePath", profileImageRelativePath);
                                cmd.Parameters.AddWithValue("@id", newCarId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Profil resmini kaydedilemedi: {ex.Message}", "Kaydetme hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Profil resmi seçilmedi. Araç ekleme işlemi bu resim olmadan devam edecek (daha sonra eklenebilir).", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            using (OpenFileDialog galleryImagesDialog = new OpenFileDialog())
            {
                galleryImagesDialog.Title = "Galeri için resimleri seçin (birkaç tane de olabilir)";
                galleryImagesDialog.Filter = "Image Files(*.JPG;*.JPEG;*.PNG)|*.JPG;*.JPEG;*.PNG";
                galleryImagesDialog.Multiselect = true;

                if (galleryImagesDialog.ShowDialog(this) == DialogResult.OK)
                {
                    int nextImageNumber = 2;
                    string[] existingGalleryFiles = Directory.GetFiles(currentCarGalleryFolderPath, "*.*")
                        .Where(f => Path.GetFileNameWithoutExtension(f) != "1" &&
                                    (f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)))
                        .ToArray();
                    if (existingGalleryFiles.Any())
                    {
                        List<int> existingNumbers = existingGalleryFiles
                                   .Select(path => int.TryParse(Path.GetFileNameWithoutExtension(path), out int num) ? num : 0)
                                   .Where(num => num > 0)
                                   .ToList();
                        if (existingNumbers.Any()) nextImageNumber = existingNumbers.Max() + 1;
                    }


                    foreach (string selectedFilePath in galleryImagesDialog.FileNames)
                    {
                        if (!IsValidImageFile(selectedFilePath))
                        {
                            MessageBox.Show($"'{Path.GetFileName(selectedFilePath)}' dosya, resim değildir veya bozuktur ve galeriye eklenmeyecektir.", "Dosya atlama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        try
                        {
                            string extension = Path.GetExtension(selectedFilePath).ToLower();
                            string newFileName = $"{nextImageNumber}{extension}";
                            string destinationPath = Path.Combine(currentCarGalleryFolderPath, newFileName);
                            File.Copy(selectedFilePath, destinationPath, true);
                            nextImageNumber++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Galeri dosyası eklenemedi '{Path.GetFileName(selectedFilePath)}': {ex.Message}", "Galeriye ekleme hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    MessageBox.Show("Galeri için resimler işlendi.", "Galeri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Galeri için resim seçilmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            MessageBox.Show($"Araba (ID: {newCarId}) başarıyla eklendi! Şimdi yönetim formu açılacak.", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Car_Manager carManagerForm = new Car_Manager();
            carManagerForm.SelectedCarId = newCarId;
            carManagerForm.Show();
            this.Close();
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

        private void panelTopBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
