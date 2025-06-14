namespace XRent
{
    partial class User_Profile_As_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Profile_As_Admin));
            this.geri_btn = new System.Windows.Forms.Button();
            this.Username_Label = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.FirstLabel = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.Last_Label = new System.Windows.Forms.Label();
            this.Email_Label = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.PhoneNumber = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.Password_Label = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picCar = new System.Windows.Forms.PictureBox();
            this.txtCarName = new System.Windows.Forms.TextBox();
            this.btnUsernameUpdate = new System.Windows.Forms.Button();
            this.btnPasswordUpdate = new System.Windows.Forms.Button();
            this.btnNameUpdate = new System.Windows.Forms.Button();
            this.btnSurnameUpdate = new System.Windows.Forms.Button();
            this.btnEmailUpdate = new System.Windows.Forms.Button();
            this.btnPhoneUpdate = new System.Windows.Forms.Button();
            this.btnChangeCarStatus = new System.Windows.Forms.Button();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.picBtnMinimize = new System.Windows.Forms.PictureBox();
            this.picBtnHome = new System.Windows.Forms.PictureBox();
            this.panelDivider = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).BeginInit();
            this.panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // geri_btn
            // 
            this.geri_btn.Location = new System.Drawing.Point(10, 403);
            this.geri_btn.Margin = new System.Windows.Forms.Padding(5);
            this.geri_btn.Name = "geri_btn";
            this.geri_btn.Size = new System.Drawing.Size(125, 37);
            this.geri_btn.TabIndex = 29;
            this.geri_btn.Text = " Geri";
            this.geri_btn.UseVisualStyleBackColor = true;
            this.geri_btn.Click += new System.EventHandler(this.geri_btn_Click);
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Location = new System.Drawing.Point(36, 59);
            this.Username_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(103, 21);
            this.Username_Label.TabIndex = 30;
            this.Username_Label.Text = "Kullanıcı Adı";
            this.Username_Label.Click += new System.EventHandler(this.Username_Label_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(45, 90);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(247, 27);
            this.txtUsername.TabIndex = 31;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // FirstLabel
            // 
            this.FirstLabel.AutoSize = true;
            this.FirstLabel.Location = new System.Drawing.Point(428, 59);
            this.FirstLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.FirstLabel.Name = "FirstLabel";
            this.FirstLabel.Size = new System.Drawing.Size(39, 21);
            this.FirstLabel.TabIndex = 32;
            this.FirstLabel.Text = "İsim";
            this.FirstLabel.Click += new System.EventHandler(this.FirstLabel_Click);
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(437, 90);
            this.txtFirst.Margin = new System.Windows.Forms.Padding(5);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.ReadOnly = true;
            this.txtFirst.Size = new System.Drawing.Size(93, 27);
            this.txtFirst.TabIndex = 33;
            this.txtFirst.TextChanged += new System.EventHandler(this.txtFirst_TextChanged);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(575, 90);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(5);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.ReadOnly = true;
            this.txtSurname.Size = new System.Drawing.Size(93, 27);
            this.txtSurname.TabIndex = 34;
            this.txtSurname.TextChanged += new System.EventHandler(this.txtSurname_TextChanged);
            // 
            // Last_Label
            // 
            this.Last_Label.AutoSize = true;
            this.Last_Label.Location = new System.Drawing.Point(600, 59);
            this.Last_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Last_Label.Name = "Last_Label";
            this.Last_Label.Size = new System.Drawing.Size(63, 21);
            this.Last_Label.TabIndex = 35;
            this.Last_Label.Text = "Soyisim";
            this.Last_Label.Click += new System.EventHandler(this.Last_Label_Click);
            // 
            // Email_Label
            // 
            this.Email_Label.AutoSize = true;
            this.Email_Label.Location = new System.Drawing.Point(428, 152);
            this.Email_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Email_Label.Name = "Email_Label";
            this.Email_Label.Size = new System.Drawing.Size(69, 21);
            this.Email_Label.TabIndex = 36;
            this.Email_Label.Text = "E-posta";
            this.Email_Label.Click += new System.EventHandler(this.Email_Label_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(437, 183);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(231, 27);
            this.txtEmail.TabIndex = 37;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSize = true;
            this.PhoneNumber.Location = new System.Drawing.Point(428, 255);
            this.PhoneNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Size = new System.Drawing.Size(143, 21);
            this.PhoneNumber.TabIndex = 38;
            this.PhoneNumber.Text = "Telefon Numarası";
            this.PhoneNumber.Click += new System.EventHandler(this.PhoneNumber_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(437, 286);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(231, 27);
            this.txtPhone.TabIndex = 39;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Location = new System.Drawing.Point(36, 138);
            this.Password_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(41, 21);
            this.Password_Label.TabIndex = 40;
            this.Password_Label.Text = "Şifre";
            this.Password_Label.Click += new System.EventHandler(this.Password_Label_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(45, 169);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(247, 27);
            this.txtPassword.TabIndex = 41;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // picCar
            // 
            this.picCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCar.Location = new System.Drawing.Point(45, 204);
            this.picCar.Name = "picCar";
            this.picCar.Size = new System.Drawing.Size(130, 77);
            this.picCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCar.TabIndex = 42;
            this.picCar.TabStop = false;
            this.picCar.Click += new System.EventHandler(this.picCar_Click);
            // 
            // txtCarName
            // 
            this.txtCarName.Location = new System.Drawing.Point(45, 286);
            this.txtCarName.Margin = new System.Windows.Forms.Padding(5);
            this.txtCarName.Name = "txtCarName";
            this.txtCarName.ReadOnly = true;
            this.txtCarName.Size = new System.Drawing.Size(130, 27);
            this.txtCarName.TabIndex = 43;
            this.txtCarName.TextChanged += new System.EventHandler(this.txtCarName_TextChanged);
            // 
            // btnUsernameUpdate
            // 
            this.btnUsernameUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUsernameUpdate.Location = new System.Drawing.Point(300, 90);
            this.btnUsernameUpdate.Name = "btnUsernameUpdate";
            this.btnUsernameUpdate.Size = new System.Drawing.Size(40, 27);
            this.btnUsernameUpdate.TabIndex = 44;
            this.btnUsernameUpdate.Text = "🗝️";
            this.btnUsernameUpdate.UseVisualStyleBackColor = true;
            this.btnUsernameUpdate.Click += new System.EventHandler(this.btnUsernameUpdate_Click);
            // 
            // btnPasswordUpdate
            // 
            this.btnPasswordUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPasswordUpdate.Location = new System.Drawing.Point(300, 169);
            this.btnPasswordUpdate.Name = "btnPasswordUpdate";
            this.btnPasswordUpdate.Size = new System.Drawing.Size(40, 27);
            this.btnPasswordUpdate.TabIndex = 45;
            this.btnPasswordUpdate.Text = "🗝️";
            this.btnPasswordUpdate.UseVisualStyleBackColor = true;
            this.btnPasswordUpdate.Click += new System.EventHandler(this.btnPasswordUpdate_Click);
            // 
            // btnNameUpdate
            // 
            this.btnNameUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNameUpdate.Location = new System.Drawing.Point(389, 88);
            this.btnNameUpdate.Name = "btnNameUpdate";
            this.btnNameUpdate.Size = new System.Drawing.Size(40, 27);
            this.btnNameUpdate.TabIndex = 46;
            this.btnNameUpdate.Text = "🗝️";
            this.btnNameUpdate.UseVisualStyleBackColor = true;
            this.btnNameUpdate.Click += new System.EventHandler(this.btnNameUpdate_Click);
            // 
            // btnSurnameUpdate
            // 
            this.btnSurnameUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSurnameUpdate.Location = new System.Drawing.Point(676, 90);
            this.btnSurnameUpdate.Name = "btnSurnameUpdate";
            this.btnSurnameUpdate.Size = new System.Drawing.Size(40, 27);
            this.btnSurnameUpdate.TabIndex = 47;
            this.btnSurnameUpdate.Text = "🗝️";
            this.btnSurnameUpdate.UseVisualStyleBackColor = true;
            this.btnSurnameUpdate.Click += new System.EventHandler(this.btnSurnameUpdate_Click);
            // 
            // btnEmailUpdate
            // 
            this.btnEmailUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmailUpdate.Location = new System.Drawing.Point(676, 183);
            this.btnEmailUpdate.Name = "btnEmailUpdate";
            this.btnEmailUpdate.Size = new System.Drawing.Size(40, 27);
            this.btnEmailUpdate.TabIndex = 48;
            this.btnEmailUpdate.Text = "🗝️";
            this.btnEmailUpdate.UseVisualStyleBackColor = true;
            this.btnEmailUpdate.Click += new System.EventHandler(this.btnEmailUpdate_Click);
            // 
            // btnPhoneUpdate
            // 
            this.btnPhoneUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPhoneUpdate.Location = new System.Drawing.Point(676, 286);
            this.btnPhoneUpdate.Name = "btnPhoneUpdate";
            this.btnPhoneUpdate.Size = new System.Drawing.Size(40, 27);
            this.btnPhoneUpdate.TabIndex = 49;
            this.btnPhoneUpdate.Text = "🗝️";
            this.btnPhoneUpdate.UseVisualStyleBackColor = true;
            this.btnPhoneUpdate.Click += new System.EventHandler(this.btnPhoneUpdate_Click);
            // 
            // btnChangeCarStatus
            // 
            this.btnChangeCarStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeCarStatus.Location = new System.Drawing.Point(183, 286);
            this.btnChangeCarStatus.Name = "btnChangeCarStatus";
            this.btnChangeCarStatus.Size = new System.Drawing.Size(40, 27);
            this.btnChangeCarStatus.TabIndex = 50;
            this.btnChangeCarStatus.Text = "🗝️";
            this.btnChangeCarStatus.UseVisualStyleBackColor = true;
            this.btnChangeCarStatus.Click += new System.EventHandler(this.btnChangeCarStatus_Click);
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
            this.panelTopBar.Size = new System.Drawing.Size(755, 33);
            this.panelTopBar.TabIndex = 51;
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
            // panelDivider
            // 
            this.panelDivider.BackColor = System.Drawing.Color.DimGray;
            this.panelDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDivider.Location = new System.Drawing.Point(0, 33);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(755, 2);
            this.panelDivider.TabIndex = 52;
            this.panelDivider.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDivider_Paint);
            // 
            // User_Profile_As_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::XRent.Properties.Resources.login_background_4;
            this.ClientSize = new System.Drawing.Size(755, 450);
            this.Controls.Add(this.panelDivider);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.btnChangeCarStatus);
            this.Controls.Add(this.btnPhoneUpdate);
            this.Controls.Add(this.btnEmailUpdate);
            this.Controls.Add(this.btnSurnameUpdate);
            this.Controls.Add(this.btnNameUpdate);
            this.Controls.Add(this.btnPasswordUpdate);
            this.Controls.Add(this.btnUsernameUpdate);
            this.Controls.Add(this.txtCarName);
            this.Controls.Add(this.picCar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.PhoneNumber);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.Email_Label);
            this.Controls.Add(this.Last_Label);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.FirstLabel);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.Username_Label);
            this.Controls.Add(this.geri_btn);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "User_Profile_As_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "XRent";
            this.Load += new System.EventHandler(this.User_Profile_As_Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).EndInit();
            this.panelTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button geri_btn;
        private System.Windows.Forms.Label Username_Label;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label FirstLabel;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label Last_Label;
        private System.Windows.Forms.Label Email_Label;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label PhoneNumber;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox picCar;
        private System.Windows.Forms.TextBox txtCarName;
        private System.Windows.Forms.Button btnUsernameUpdate;
        private System.Windows.Forms.Button btnPasswordUpdate;
        private System.Windows.Forms.Button btnNameUpdate;
        private System.Windows.Forms.Button btnSurnameUpdate;
        private System.Windows.Forms.Button btnEmailUpdate;
        private System.Windows.Forms.Button btnPhoneUpdate;
        private System.Windows.Forms.Button btnChangeCarStatus;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.PictureBox picBtnMinimize;
        private System.Windows.Forms.PictureBox picBtnHome;
        private System.Windows.Forms.Panel panelDivider;
    }
}