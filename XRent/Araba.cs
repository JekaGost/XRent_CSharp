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

namespace XRent
{
    public partial class Araba: Form
    {

        public string CurrentUsername { get; set; }
        public NavigationSource OpenedFrom { get; set; } = NavigationSource.UserMenu;
        public enum NavigationSource
        {
            UserMenu,
            AdminMenu
        }
        public Araba()
        {
            InitializeComponent();
            this.lstCars.DoubleClick += new System.EventHandler(this.lstCars_DoubleClick);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string brandToSearch = txtSearch.Text.Trim();

            StringBuilder queryBuilder = new StringBuilder("SELECT id, brand, model FROM cars WHERE brand LIKE @brand_param");

            if (this.OpenedFrom == NavigationSource.UserMenu)
            {
                queryBuilder.Append(" AND status = 0");
            }

            string finalQuery = queryBuilder.ToString();

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(finalQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@brand_param", "%" + brandToSearch + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            lstCars.Items.Clear();
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string brandFromDb = reader.GetString("brand");
                                string modelFromDb = reader.GetString("model");
                                string display = $"{brandFromDb} {modelFromDb}";

                                lstCars.Items.Add(new ListItem(display, id));
                            }

                            if (lstCars.Items.Count == 0)
                            {

                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Veritabanında araç ararken hata oluştu: " + ex.Message, "Veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Arama sırasında beklenmedik bir hata oluştu: " + ex.Message, "Genel hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Araba_Load(object sender, EventArgs e)
        {

        }

        public static int SelectedCarId = -1;


        private void lstCars_DoubleClick(object sender, EventArgs e)
        {

            if (lstCars.SelectedItem is ListItem selectedItem)
            {
                int selectedId = selectedItem.Value;

                if (this.OpenedFrom == NavigationSource.UserMenu)
                {
                    Arabalar_Listesi arabalarListesi = new Arabalar_Listesi();
                    arabalarListesi.SelectedCarId = selectedId;
                    arabalarListesi.CurrentUsername = this.CurrentUsername;
                    arabalarListesi.PreviousForm = this;

                    arabalarListesi.StartPosition = FormStartPosition.Manual;
                    arabalarListesi.Location = this.Location;

                    arabalarListesi.Show();
                    this.Hide();
                }
                else if (this.OpenedFrom == NavigationSource.AdminMenu)
                {
                    Car_Manager carManager = new Car_Manager();

                    carManager.SelectedCarId = selectedId;

                    carManager.StartPosition = FormStartPosition.Manual;
                    carManager.Location = this.Location;

                    carManager.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Geçiş kaynağı belirlenemedi.", "Navigasyon hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstCars_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            if (this.OpenedFrom == NavigationSource.UserMenu)
            {
                User_Menu userMenu = new User_Menu();

                userMenu.StartPosition = FormStartPosition.Manual;
                userMenu.Location = this.Location;

                userMenu.Show();
            }
            else if (this.OpenedFrom == NavigationSource.AdminMenu)
            {
                Admin adminMenu = new Admin();

                adminMenu.StartPosition = FormStartPosition.Manual;
                adminMenu.Location = this.Location;

                adminMenu.Show();
            }
            else
            {
                MessageBox.Show("Önceki menü belirlenemedi. Kullanıcı menüsüne geri dön.", "Navigasyon hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                User_Menu userMenu = new User_Menu();

                userMenu.StartPosition = FormStartPosition.Manual;
                userMenu.Location = this.Location;

                userMenu.Show();
            }
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
