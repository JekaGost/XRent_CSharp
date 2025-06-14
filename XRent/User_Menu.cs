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
using static XRent.Araba;

namespace XRent
{
    public partial class User_Menu: Form
    {

        private bool isDragging = false;
        private Point dragStartPoint = new Point(0, 0);

        public User_Menu()
        {
            InitializeComponent();

            this.picBtnClose.Click += new System.EventHandler(this.picBtnClose_Click);
            this.picBtnClose.MouseEnter += new System.EventHandler(this.picBtnClose_MouseEnter);
            this.picBtnClose.MouseLeave += new System.EventHandler(this.picBtnClose_MouseLeave);

            this.picBtnMinimize.Click += new System.EventHandler(this.picBtnMinimize_Click);
            this.picBtnMinimize.MouseEnter += new System.EventHandler(this.picBtnMinimize_MouseEnter);
            this.picBtnMinimize.MouseLeave += new System.EventHandler(this.picBtnMinimize_MouseLeave);

            this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
            this.panelTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseMove);
            this.panelTopBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseUp);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void User_Menu_Load(object sender, EventArgs e)
        {
            ayarlar_btn.Visible = false;

            string currentUsername = Session.Username;

            if (string.IsNullOrEmpty(currentUsername))
            {
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT isAdmin FROM users WHERE username = @Username";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", currentUsername);

                        object isAdminResult = cmd.ExecuteScalar();

                        if (isAdminResult != null && isAdminResult != DBNull.Value)
                        {
                            try
                            {
                                int isAdminFlag = Convert.ToInt32(isAdminResult);

                                if (isAdminFlag == 1)
                                {
                                    ayarlar_btn.Visible = true;
                                }
                            }
                            catch (FormatException)
                            {
                                ayarlar_btn.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(this, "Yönetici hakları denetlenirken veritabanı hatası: " + ex.Message,
                                "Veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ayarlar_btn.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Yönetici hakları denetlenirken bir hata oluştu: " + ex.Message,
                                "Genel hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ayarlar_btn.Visible = false;
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            AppNavigator.Logout();
        }

        private void arabalar_btn_Click(object sender, EventArgs e)
        {

            Araba araba = new Araba();
            araba.CurrentUsername = Session.Username;
            araba.OpenedFrom = NavigationSource.UserMenu;
            araba.StartPosition = FormStartPosition.Manual;
            araba.Location = this.Location;
            araba.Show();
            this.Hide();
        }

        private void kurarlar_btn_Click(object sender, EventArgs e)
        {

            Kurallar kurallar = new Kurallar();
            kurallar.StartPosition = FormStartPosition.Manual;
            kurallar.Location = this.Location;
            kurallar.Show();
            this.Hide();
        }

        private void profil_btn_Click(object sender, EventArgs e)
        {

            Profile_Settings profileSettings = new Profile_Settings();
            profileSettings.StartPosition = FormStartPosition.Manual;
            profileSettings.Location = this.Location;
            profileSettings.Show();
            this.Hide();
        }

        private void ayarlar_btn_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.StartPosition = FormStartPosition.Manual;
            admin.Location = this.Location;
            admin.Show();
            this.Hide();
        }

        private void panelTopBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picBtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picBtnClose_Click(object sender, EventArgs e)
        {
            AppNavigator.ExitApplicationSilently();
        }

        private void picBtnClose_MouseEnter(object sender, EventArgs e)
        {
            picBtnClose.Image = Properties.Resources.close_hover;
        }

        private void picBtnClose_MouseLeave(object sender, EventArgs e)
        {
            picBtnClose.Image = Properties.Resources.close_normal;
        }

        private void picBtnMinimize_MouseEnter(object sender, EventArgs e)
        {
            picBtnMinimize.Image = Properties.Resources.minimize_hover;
        }

        private void picBtnMinimize_MouseLeave(object sender, EventArgs e)
        {
            picBtnMinimize.Image = Properties.Resources.minimize_normal;
        }

        private void panelDivider_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragStartPoint = new Point(e.X, e.Y);
        }

        private void panelTopBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void panelTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPoint = PointToScreen(e.Location);

                Location = new Point(currentScreenPoint.X - dragStartPoint.X,
                                      currentScreenPoint.Y - dragStartPoint.Y);
            }
        }
    }
}
