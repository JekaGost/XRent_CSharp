using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace XRent
{
    public static class AppNavigator
    {
        public static void GoToUserMenu(Form currentForm)
        {

            Point previousFormLocation = currentForm.Location;

            User_Menu userMenuInstance = Application.OpenForms.OfType<User_Menu>().FirstOrDefault();

            if (userMenuInstance != null)
            {
                userMenuInstance.StartPosition = FormStartPosition.Manual;
                userMenuInstance.Location = previousFormLocation;
                userMenuInstance.WindowState = FormWindowState.Normal;
                userMenuInstance.Show();
                userMenuInstance.BringToFront();
            }
            else
            {
                User_Menu newUserMenu = new User_Menu();
                newUserMenu.StartPosition = FormStartPosition.Manual;
                newUserMenu.Location = previousFormLocation;
                newUserMenu.Show();
            }

            if (currentForm != null)
            {
                currentForm.Close();
            }
        }

        public static void Logout()
        {
            if (MessageBox.Show("Hesabınızdan çıkmak istediğinizden emin misiniz?", "Hesaptan çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        public static void MinimizeWindow(Form form)
        {
            form.WindowState = FormWindowState.Minimized;
        }

        public static void ExitApplicationSilently()
        {
            Application.Exit();
        }


        public static void HandleMouseDown(MouseEventArgs e, ref bool isDragging, ref Point dragStartPoint)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = new Point(e.X, e.Y);
            }
        }

        public static void HandleMouseUp(ref bool isDragging)
        {
            isDragging = false;
        }

        public static void HandleMouseMove(Form form, MouseEventArgs e, bool isDragging, Point dragStartPoint)
        {
            if (isDragging)
            {
                Point p = form.PointToScreen(e.Location);
                form.Location = new Point(p.X - dragStartPoint.X, p.Y - dragStartPoint.Y);
            }
        }


        public static void HandleMouseEnter(object sender, Image hoverImage)
        {
            if (sender is PictureBox pb)
            {
                pb.Image = hoverImage;
            }
        }

        public static void HandleMouseLeave(object sender, Image normalImage)
        {
            if (sender is PictureBox pb)
            {
                pb.Image = normalImage;
            }
        }
    }
}