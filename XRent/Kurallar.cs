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
    public partial class Kurallar: Form
    {

        private bool isDragging = false;
        private Point dragStartPoint = new Point(0, 0);

        public Kurallar()
        {
            InitializeComponent();
            SetupCustomTitleBar();
        }

        private void Kurallar_Load(object sender, EventArgs e)
        {
            txtRulesDisplay.Text = Properties.Resources.KurallarText_TR;
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

        private void geri_btn_Click(object sender, EventArgs e)
        {
            User_Menu userMenu = new User_Menu();
            userMenu.StartPosition = FormStartPosition.Manual;
            userMenu.Location = this.Location;
            userMenu.Show();
            this.Hide();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRulesDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
