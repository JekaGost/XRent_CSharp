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
    public partial class Main_Form: Form
    {

        private bool isDragging = false;
        private Point dragStartPoint = new Point(0, 0);

        public Main_Form()
        {
            InitializeComponent();

            this.picBtnClose.Click += new System.EventHandler(this.picBtnClose_Click);
            this.picBtnClose.MouseEnter += new System.EventHandler(this.picBtnClose_MouseEnter);
            this.picBtnClose.MouseLeave += new System.EventHandler(this.picBtnClose_MouseLeave);

            this.picBtnMinimize.Click += new System.EventHandler(this.picBtnMinimize_Click_1);
            this.picBtnMinimize.MouseEnter += new System.EventHandler(this.picBtnMinimize_MouseEnter);
            this.picBtnMinimize.MouseLeave += new System.EventHandler(this.picBtnMinimize_MouseLeave);

            this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
            this.panelTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseMove);
            this.panelTopBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseUp);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.StartPosition = FormStartPosition.Manual;
                loginForm.Location = this.Location;
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    User_Menu userMenu = new User_Menu();
                    userMenu.StartPosition = FormStartPosition.Manual;
                    userMenu.Location = this.Location;
                    userMenu.Show();
                    this.Hide();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            RegisterForm registerForm = new RegisterForm();
            registerForm.StartPosition = FormStartPosition.Manual;
            registerForm.Location = this.Location;
            registerForm.ShowDialog();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            using (KVKK kvkk = new KVKK())
            {
                kvkk.StartPosition = FormStartPosition.Manual;
                kvkk.Location = this.Location;
                kvkk.ShowDialog(this);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picBtnClose_Click(object sender, EventArgs e)
        {
            AppNavigator.ExitApplicationSilently();
        }

        private void picBtnClose_MouseEnter(object sender, EventArgs e)
        {
            AppNavigator.HandleMouseEnter(sender, Properties.Resources.close_hover);
        }

        private void picBtnClose_MouseLeave(object sender, EventArgs e)
        {
            AppNavigator.HandleMouseLeave(sender, Properties.Resources.close_normal);
        }

        private void picBtnMinimize_MouseEnter(object sender, EventArgs e)
        {
            AppNavigator.HandleMouseEnter(sender, Properties.Resources.minimize_hover);
        }

        private void picBtnMinimize_MouseLeave(object sender, EventArgs e)
        {
            AppNavigator.HandleMouseLeave(sender, Properties.Resources.minimize_normal);
        }

        private void picBtnMinimize_Click_1(object sender, EventArgs e)
        {
            AppNavigator.MinimizeWindow(this);
        }

        private void panelDivider_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void paneDivider2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            AppNavigator.HandleMouseDown(e, ref isDragging, ref dragStartPoint);
        }

        private void panelTopBar_MouseUp(object sender, MouseEventArgs e)
        {
            AppNavigator.HandleMouseUp(ref isDragging);
        }

        private void panelTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            AppNavigator.HandleMouseMove(this, e, isDragging, dragStartPoint);
        }
    }
}
