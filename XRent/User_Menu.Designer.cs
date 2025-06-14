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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Menu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDivider = new System.Windows.Forms.Panel();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.picBtnMinimize = new System.Windows.Forms.PictureBox();
            this.picBtnClose = new System.Windows.Forms.PictureBox();
            this.logout_btn = new System.Windows.Forms.Button();
            this.ayarlar_btn = new System.Windows.Forms.Button();
            this.profil_btn = new System.Windows.Forms.Button();
            this.kurarlar_btn = new System.Windows.Forms.Button();
            this.arabalar_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::XRent.Properties.Resources.panel_background2;
            this.panel1.Controls.Add(this.panelDivider);
            this.panel1.Controls.Add(this.panelTopBar);
            this.panel1.Controls.Add(this.logout_btn);
            this.panel1.Controls.Add(this.ayarlar_btn);
            this.panel1.Controls.Add(this.profil_btn);
            this.panel1.Controls.Add(this.kurarlar_btn);
            this.panel1.Controls.Add(this.arabalar_btn);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 413);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelDivider
            // 
            this.panelDivider.BackColor = System.Drawing.Color.DimGray;
            this.panelDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDivider.Location = new System.Drawing.Point(0, 33);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(735, 2);
            this.panelDivider.TabIndex = 10;
            this.panelDivider.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDivider_Paint);
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.DimGray;
            this.panelTopBar.BackgroundImage = global::XRent.Properties.Resources.panel_background2;
            this.panelTopBar.Controls.Add(this.picBtnMinimize);
            this.panelTopBar.Controls.Add(this.picBtnClose);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(735, 33);
            this.panelTopBar.TabIndex = 9;
            this.panelTopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTopBar_Paint);
            // 
            // picBtnMinimize
            // 
            this.picBtnMinimize.BackgroundImage = global::XRent.Properties.Resources.panel_background2;
            this.picBtnMinimize.Cursor = System.Windows.Forms.Cursors.Default;
            this.picBtnMinimize.Image = global::XRent.Properties.Resources.minimize_normal;
            this.picBtnMinimize.Location = new System.Drawing.Point(632, 5);
            this.picBtnMinimize.Name = "picBtnMinimize";
            this.picBtnMinimize.Size = new System.Drawing.Size(22, 22);
            this.picBtnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBtnMinimize.TabIndex = 6;
            this.picBtnMinimize.TabStop = false;
            this.picBtnMinimize.Click += new System.EventHandler(this.picBtnMinimize_Click);
            // 
            // picBtnClose
            // 
            this.picBtnClose.BackgroundImage = global::XRent.Properties.Resources.panel_background2;
            this.picBtnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.picBtnClose.Image = global::XRent.Properties.Resources.close_normal;
            this.picBtnClose.Location = new System.Drawing.Point(670, 5);
            this.picBtnClose.Name = "picBtnClose";
            this.picBtnClose.Size = new System.Drawing.Size(22, 22);
            this.picBtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBtnClose.TabIndex = 7;
            this.picBtnClose.TabStop = false;
            this.picBtnClose.Click += new System.EventHandler(this.picBtnClose_Click);
            // 
            // logout_btn
            // 
            this.logout_btn.Location = new System.Drawing.Point(302, 357);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(100, 53);
            this.logout_btn.TabIndex = 5;
            this.logout_btn.Text = "Çıkış Yap";
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // ayarlar_btn
            // 
            this.ayarlar_btn.Location = new System.Drawing.Point(11, 298);
            this.ayarlar_btn.Name = "ayarlar_btn";
            this.ayarlar_btn.Size = new System.Drawing.Size(87, 50);
            this.ayarlar_btn.TabIndex = 4;
            this.ayarlar_btn.Text = "Ayarlar";
            this.ayarlar_btn.UseVisualStyleBackColor = true;
            this.ayarlar_btn.Click += new System.EventHandler(this.ayarlar_btn_Click);
            // 
            // profil_btn
            // 
            this.profil_btn.Location = new System.Drawing.Point(636, 295);
            this.profil_btn.Name = "profil_btn";
            this.profil_btn.Size = new System.Drawing.Size(87, 50);
            this.profil_btn.TabIndex = 3;
            this.profil_btn.Text = "Profil Ayarları";
            this.profil_btn.UseVisualStyleBackColor = true;
            this.profil_btn.Click += new System.EventHandler(this.profil_btn_Click);
            // 
            // kurarlar_btn
            // 
            this.kurarlar_btn.Location = new System.Drawing.Point(177, 298);
            this.kurarlar_btn.Name = "kurarlar_btn";
            this.kurarlar_btn.Size = new System.Drawing.Size(119, 53);
            this.kurarlar_btn.TabIndex = 2;
            this.kurarlar_btn.Text = "Rezervasyon Kuralları";
            this.kurarlar_btn.UseVisualStyleBackColor = true;
            this.kurarlar_btn.Click += new System.EventHandler(this.kurarlar_btn_Click);
            // 
            // arabalar_btn
            // 
            this.arabalar_btn.Location = new System.Drawing.Point(408, 298);
            this.arabalar_btn.Name = "arabalar_btn";
            this.arabalar_btn.Size = new System.Drawing.Size(100, 53);
            this.arabalar_btn.TabIndex = 0;
            this.arabalar_btn.Text = "Arabalara Göz At";
            this.arabalar_btn.UseVisualStyleBackColor = true;
            this.arabalar_btn.Click += new System.EventHandler(this.arabalar_btn_Click);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "User_Menu";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "XRent";
            this.Load += new System.EventHandler(this.User_Menu_Load);
            this.panel1.ResumeLayout(false);
            this.panelTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button arabalar_btn;
        private System.Windows.Forms.Button kurarlar_btn;
        private System.Windows.Forms.Button profil_btn;
        private System.Windows.Forms.Button ayarlar_btn;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.PictureBox picBtnMinimize;
        private System.Windows.Forms.PictureBox picBtnClose;
        private System.Windows.Forms.Panel panelDivider;
    }
}