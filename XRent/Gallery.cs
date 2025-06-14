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

namespace XRent
{
    public partial class Gallery: Form
    {

        public int CarId { get; private set; }
        private Form ownerForm;

        private List<string> imagePaths;
        private int currentImageIndex;

        public Gallery(int carId, Form owner)
        {
            InitializeComponent();
            this.CarId = carId;
            this.ownerForm = owner;
            imagePaths = new List<string>();
            currentImageIndex = -1;
        }
        public Gallery()
        {
            InitializeComponent();
        }

        private void LoadImagesForCar()
        {
            string relativeFolderPath = Path.Combine("Resources", "CarGalleries", $"Car_{this.CarId}");
            string galleryFolderPath = Path.Combine(Application.StartupPath, relativeFolderPath);

            if (Directory.Exists(galleryFolderPath))
            {
                string[] files = Directory.GetFiles(galleryFolderPath, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                Array.Sort(files);

                imagePaths.AddRange(files);

                if (imagePaths.Any())
                {
                    currentImageIndex = 0;
                }
                else
                {
                    MessageBox.Show(this, $"'{galleryFolderPath}' klasöründe hiçbir resim bulunamadı.", "Galeri boş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentImageIndex = -1;
                }
            }
            else
            {
                MessageBox.Show(this, $"Araç resimlerini içeren (ID: {this.CarId}) klasör '{galleryFolderPath}' yolunda bulunamadı", "Galeri hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentImageIndex = -1;
            }
        }

        private void ShowCurrentImage()
        {
            Image imageToDisplay = null;

            if (currentImageIndex >= 0 && currentImageIndex < imagePaths.Count)
            {
                string imagePath = imagePaths[currentImageIndex];
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
                        MessageBox.Show(this, $"Resim dosyası bulunamadı: {Path.GetFileName(imagePath)}",
                                        "Dosya eksik",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show(this, $"Görüntü yüklenemedi: {Path.GetFileName(imagePath)}.\n" +
                                    "Dosya çok büyük, bozuk ya da sistemde bellek yetersizliği olabilir.",
                                    "Görüntü Hatası (Yetersiz Bellek)",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, $"Resim dosyası yüklenirken bir hata oluştu: {Path.GetFileName(imagePath)}.\n" +
                                    "Dosya bozuk olabilir, yanlış bir formata sahip olabilir (örneğin .jpg uzantılı bir WEBP dosyası) veya sistem tarafından desteklenmiyor olabilir.\n" +
                                    $"Ayrıntılar: {ex.Message}",
                                    "Biçim hatası veya dosya bozukluğu",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Görüntü dosyası yüklerken genel bir hata: {Path.GetFileName(imagePath)}\n" +
                                    $"Ayrıntılar: {ex.Message}",
                                    "Görüntü hatası",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                if (imagePaths != null)
                {
                    btnSonraki.Enabled = imagePaths.Any();
                    btnOnceki.Enabled = imagePaths.Any();
                }
                else
                {
                    btnSonraki.Enabled = false;
                    btnOnceki.Enabled = false;
                }
            }

            Image oldImage = pictureBox1.Image;

            pictureBox1.Image = imageToDisplay;

            if (oldImage != null)
            {
                oldImage.Dispose();
            }

            if (pictureBox1.Image != null)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            if (this.ownerForm != null)
            {
                this.ownerForm.Show();
            }
            this.Close();
        }

        private void Gallery_Load(object sender, EventArgs e)
        {
            LoadImagesForCar();
            ShowCurrentImage();
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            if (!imagePaths.Any()) return;

            currentImageIndex++;
            if (currentImageIndex >= imagePaths.Count)
            {
                currentImageIndex = 0;
            }
            ShowCurrentImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnOnceki_Click(object sender, EventArgs e)
        {
            if (!imagePaths.Any()) return;

            currentImageIndex--;
            if (currentImageIndex < 0)
            {
                currentImageIndex = imagePaths.Count - 1;
            }
            ShowCurrentImage();
        }
    }
}
