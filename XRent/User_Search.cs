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
    public partial class User_Search: Form
    {

        public string CurrentUsername { get; set; }
        public User_Search()
        {
            InitializeComponent();
        }

        private void User_Search_Load(object sender, EventArgs e)
        {

        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.StartPosition = FormStartPosition.Manual;
            admin.Location = this.Location;
            admin.Show();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string usernameToSearch = txtSearch.Text.Trim();

            string query = "SELECT id, username FROM users WHERE username LIKE @usernameParam";

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usernameParam", "%" + usernameToSearch + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        lstUsers.Items.Clear();
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string displayUsername = reader.GetString("username");

                            lstUsers.Items.Add(new ListItem(displayUsername, id));
                        }
                    }
                }
            }

        }

        public static int SelectedUserId = -1;

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem is ListItem selectedItem)
            {
                int selectedUserId = selectedItem.Value;
                string selectedUserActualUsername = selectedItem.Text;

                User_Profile_As_Admin userProfileForm = new User_Profile_As_Admin(selectedUserId, selectedUserActualUsername);

                userProfileForm.StartPosition = FormStartPosition.Manual;
                userProfileForm.Location = this.Location;

                userProfileForm.Show();
                this.Close();
            }
        }

        private void lstCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstUsers.DoubleClick += new System.EventHandler(this.lstUsers_DoubleClick);
        }
    }
}
