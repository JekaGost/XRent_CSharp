namespace XRent
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDivider = new System.Windows.Forms.Panel();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.picBtnMinimize = new System.Windows.Forms.PictureBox();
            this.picBtnHome = new System.Windows.Forms.PictureBox();
            this.geri_btn = new System.Windows.Forms.Button();
            this.btnCarAdd = new System.Windows.Forms.Button();
            this.Cars_btn = new System.Windows.Forms.Button();
            this.Users_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::XRent.Properties.Resources.login_background_4;
            this.panel1.Controls.Add(this.panelDivider);
            this.panel1.Controls.Add(this.panelTopBar);
            this.panel1.Controls.Add(this.geri_btn);
            this.panel1.Controls.Add(this.btnCarAdd);
            this.panel1.Controls.Add(this.Cars_btn);
            this.panel1.Controls.Add(this.Users_btn);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 555);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelDivider
            // 
            this.panelDivider.BackColor = System.Drawing.Color.DimGray;
            this.panelDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDivider.Location = new System.Drawing.Point(0, 33);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(750, 2);
            this.panelDivider.TabIndex = 32;
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.DimGray;
            this.panelTopBar.BackgroundImage = global::XRent.Properties.Resources.login_background_4;
            this.panelTopBar.Controls.Add(this.picBtnMinimize);
            this.panelTopBar.Controls.Add(this.picBtnHome);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(750, 33);
            this.panelTopBar.TabIndex = 31;
            this.panelTopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTopBar_Paint);
            // 
            // picBtnMinimize
            // 
            this.picBtnMinimize.BackgroundImage = global::XRent.Properties.Resources.login_background_4;
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
            // picBtnHome
            // 
            this.picBtnHome.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picBtnHome.BackgroundImage = global::XRent.Properties.Resources.login_background_4;
            this.picBtnHome.Cursor = System.Windows.Forms.Cursors.Default;
            this.picBtnHome.Image = global::XRent.Properties.Resources.home_normal;
            this.picBtnHome.Location = new System.Drawing.Point(670, 5);
            this.picBtnHome.Name = "picBtnHome";
            this.picBtnHome.Size = new System.Drawing.Size(22, 22);
            this.picBtnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBtnHome.TabIndex = 7;
            this.picBtnHome.TabStop = false;
            this.picBtnHome.Click += new System.EventHandler(this.picBtnHome_Click);
            // 
            // geri_btn
            // 
            this.geri_btn.Location = new System.Drawing.Point(13, 499);
            this.geri_btn.Margin = new System.Windows.Forms.Padding(5);
            this.geri_btn.Name = "geri_btn";
            this.geri_btn.Size = new System.Drawing.Size(125, 37);
            this.geri_btn.TabIndex = 29;
            this.geri_btn.Text = " Geri";
            this.geri_btn.UseVisualStyleBackColor = true;
            this.geri_btn.Click += new System.EventHandler(this.geri_btn_Click);
            // 
            // btnCarAdd
            // 
            this.btnCarAdd.Location = new System.Drawing.Point(621, 469);
            this.btnCarAdd.Name = "btnCarAdd";
            this.btnCarAdd.Size = new System.Drawing.Size(116, 69);
            this.btnCarAdd.TabIndex = 4;
            this.btnCarAdd.Text = "Araba Ekle";
            this.btnCarAdd.UseVisualStyleBackColor = true;
            this.btnCarAdd.Click += new System.EventHandler(this.btnCarAdd_Click);
            // 
            // Cars_btn
            // 
            this.Cars_btn.Location = new System.Drawing.Point(499, 469);
            this.Cars_btn.Name = "Cars_btn";
            this.Cars_btn.Size = new System.Drawing.Size(116, 69);
            this.Cars_btn.TabIndex = 2;
            this.Cars_btn.Text = "Arabalar";
            this.Cars_btn.UseVisualStyleBackColor = true;
            this.Cars_btn.Click += new System.EventHandler(this.Cars_btn_Click);
            // 
            // Users_btn
            // 
            this.Users_btn.Location = new System.Drawing.Point(377, 469);
            this.Users_btn.Name = "Users_btn";
            this.Users_btn.Size = new System.Drawing.Size(116, 69);
            this.Users_btn.TabIndex = 1;
            this.Users_btn.Text = "Kullanıcılar";
            this.Users_btn.UseVisualStyleBackColor = true;
            this.Users_btn.Click += new System.EventHandler(this.Users_btn_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::XRent.Properties.Resources.login_background_4;
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "XRent";
            this.panel1.ResumeLayout(false);
            this.panelTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCarAdd;
        private System.Windows.Forms.Button Cars_btn;
        private System.Windows.Forms.Button Users_btn;
        private System.Windows.Forms.Button geri_btn;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.PictureBox picBtnMinimize;
        private System.Windows.Forms.PictureBox picBtnHome;
        private System.Windows.Forms.Panel panelDivider;
    }
}