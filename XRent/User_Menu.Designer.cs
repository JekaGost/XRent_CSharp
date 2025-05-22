namespace XRent
{
    partial class User_Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.ayarlar_btn = new System.Windows.Forms.Button();
            this.profil_btn = new System.Windows.Forms.Button();
            this.kurarlar_btn = new System.Windows.Forms.Button();
            this.Fiyat_btn = new System.Windows.Forms.Button();
            this.arabalar_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::XRent.Properties.Resources.panel_background2;
            this.panel1.Controls.Add(this.logout_btn);
            this.panel1.Controls.Add(this.ayarlar_btn);
            this.panel1.Controls.Add(this.profil_btn);
            this.panel1.Controls.Add(this.kurarlar_btn);
            this.panel1.Controls.Add(this.Fiyat_btn);
            this.panel1.Controls.Add(this.arabalar_btn);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 413);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // logout_btn
            // 
            this.logout_btn.Location = new System.Drawing.Point(302, 357);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(100, 53);
            this.logout_btn.TabIndex = 5;
            this.logout_btn.Text = "Çıkış Yap";
            this.logout_btn.UseVisualStyleBackColor = true;
            // 
            // ayarlar_btn
            // 
            this.ayarlar_btn.Location = new System.Drawing.Point(11, 12);
            this.ayarlar_btn.Name = "ayarlar_btn";
            this.ayarlar_btn.Size = new System.Drawing.Size(87, 50);
            this.ayarlar_btn.TabIndex = 4;
            this.ayarlar_btn.Text = "Ayarlar";
            this.ayarlar_btn.UseVisualStyleBackColor = true;
            // 
            // profil_btn
            // 
            this.profil_btn.Location = new System.Drawing.Point(636, 12);
            this.profil_btn.Name = "profil_btn";
            this.profil_btn.Size = new System.Drawing.Size(87, 50);
            this.profil_btn.TabIndex = 3;
            this.profil_btn.Text = "Profil Ayarları";
            this.profil_btn.UseVisualStyleBackColor = true;
            // 
            // kurarlar_btn
            // 
            this.kurarlar_btn.Location = new System.Drawing.Point(408, 295);
            this.kurarlar_btn.Name = "kurarlar_btn";
            this.kurarlar_btn.Size = new System.Drawing.Size(119, 53);
            this.kurarlar_btn.TabIndex = 2;
            this.kurarlar_btn.Text = "Rezervasyon Kuralları";
            this.kurarlar_btn.UseVisualStyleBackColor = true;
            // 
            // Fiyat_btn
            // 
            this.Fiyat_btn.Location = new System.Drawing.Point(196, 295);
            this.Fiyat_btn.Name = "Fiyat_btn";
            this.Fiyat_btn.Size = new System.Drawing.Size(100, 53);
            this.Fiyat_btn.TabIndex = 1;
            this.Fiyat_btn.Text = "Fiyatlar Listesi";
            this.Fiyat_btn.UseVisualStyleBackColor = true;
            // 
            // arabalar_btn
            // 
            this.arabalar_btn.Location = new System.Drawing.Point(302, 295);
            this.arabalar_btn.Name = "arabalar_btn";
            this.arabalar_btn.Size = new System.Drawing.Size(100, 53);
            this.arabalar_btn.TabIndex = 0;
            this.arabalar_btn.Text = "Arabalara Göz At";
            this.arabalar_btn.UseVisualStyleBackColor = true;
            // 
            // User_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "User_Menu";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "Menü";
            this.Load += new System.EventHandler(this.User_Menu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Fiyat_btn;
        private System.Windows.Forms.Button arabalar_btn;
        private System.Windows.Forms.Button kurarlar_btn;
        private System.Windows.Forms.Button profil_btn;
        private System.Windows.Forms.Button ayarlar_btn;
        private System.Windows.Forms.Button logout_btn;
    }
}