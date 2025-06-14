namespace XRent
{
    partial class Main_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelDivider = new System.Windows.Forms.Panel();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.picBtnMinimize = new System.Windows.Forms.PictureBox();
            this.picBtnClose = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btn_kvkk = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::XRent.Properties.Resources.login_background_3_jpg;
            this.panel2.Controls.Add(this.panelDivider);
            this.panel2.Controls.Add(this.panelTopBar);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.btnRegister);
            this.panel2.Controls.Add(this.btn_kvkk);
            this.panel2.Location = new System.Drawing.Point(-3, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 450);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panelDivider
            // 
            this.panelDivider.BackColor = System.Drawing.Color.DimGray;
            this.panelDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDivider.Location = new System.Drawing.Point(0, 33);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(705, 2);
            this.panelDivider.TabIndex = 9;
            this.panelDivider.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDivider_Paint);
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.DimGray;
            this.panelTopBar.BackgroundImage = global::XRent.Properties.Resources.login_background_3_jpg;
            this.panelTopBar.Controls.Add(this.picBtnMinimize);
            this.panelTopBar.Controls.Add(this.picBtnClose);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(705, 33);
            this.panelTopBar.TabIndex = 8;
            this.panelTopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // picBtnMinimize
            // 
            this.picBtnMinimize.BackgroundImage = global::XRent.Properties.Resources.login_background_2;
            this.picBtnMinimize.Cursor = System.Windows.Forms.Cursors.Default;
            this.picBtnMinimize.Image = global::XRent.Properties.Resources.minimize_normal;
            this.picBtnMinimize.Location = new System.Drawing.Point(632, 5);
            this.picBtnMinimize.Name = "picBtnMinimize";
            this.picBtnMinimize.Size = new System.Drawing.Size(22, 22);
            this.picBtnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBtnMinimize.TabIndex = 6;
            this.picBtnMinimize.TabStop = false;
            this.picBtnMinimize.Click += new System.EventHandler(this.picBtnMinimize_Click_1);
            // 
            // picBtnClose
            // 
            this.picBtnClose.BackgroundImage = global::XRent.Properties.Resources.login_background_2;
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
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(160, 290);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(333, 65);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(160, 365);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(333, 65);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Kayıt Ol";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btn_kvkk
            // 
            this.btn_kvkk.Location = new System.Drawing.Point(554, 401);
            this.btn_kvkk.Margin = new System.Windows.Forms.Padding(5);
            this.btn_kvkk.Name = "btn_kvkk";
            this.btn_kvkk.Size = new System.Drawing.Size(103, 39);
            this.btn_kvkk.TabIndex = 4;
            this.btn_kvkk.Text = "KVKK";
            this.btn_kvkk.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_kvkk.UseVisualStyleBackColor = true;
            this.btn_kvkk.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Main_Form";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XRent";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panelTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btn_kvkk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picBtnMinimize;
        private System.Windows.Forms.PictureBox picBtnClose;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Panel panelDivider;
    }
}

