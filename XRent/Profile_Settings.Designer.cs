namespace XRent
{
    partial class Profile_Settings
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
            this.FirstLabel = new System.Windows.Forms.Label();
            this.Last_Label = new System.Windows.Forms.Label();
            this.Email_Label = new System.Windows.Forms.Label();
            this.PhoneNumber = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.Label();
            this.Username_Label = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.Update_btn = new System.Windows.Forms.Button();
            this.geri_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstLabel
            // 
            this.FirstLabel.AutoSize = true;
            this.FirstLabel.Location = new System.Drawing.Point(445, 75);
            this.FirstLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.FirstLabel.Name = "FirstLabel";
            this.FirstLabel.Size = new System.Drawing.Size(39, 21);
            this.FirstLabel.TabIndex = 15;
            this.FirstLabel.Text = "İsim";
            this.FirstLabel.Click += new System.EventHandler(this.FirstLabel_Click);
            // 
            // Last_Label
            // 
            this.Last_Label.AutoSize = true;
            this.Last_Label.Location = new System.Drawing.Point(601, 75);
            this.Last_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Last_Label.Name = "Last_Label";
            this.Last_Label.Size = new System.Drawing.Size(63, 21);
            this.Last_Label.TabIndex = 16;
            this.Last_Label.Text = "Soyisim";
            this.Last_Label.Click += new System.EventHandler(this.Last_Label_Click);
            // 
            // Email_Label
            // 
            this.Email_Label.AutoSize = true;
            this.Email_Label.Location = new System.Drawing.Point(445, 154);
            this.Email_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Email_Label.Name = "Email_Label";
            this.Email_Label.Size = new System.Drawing.Size(69, 21);
            this.Email_Label.TabIndex = 17;
            this.Email_Label.Text = "E-posta";
            this.Email_Label.Click += new System.EventHandler(this.Email_Label_Click);
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSize = true;
            this.PhoneNumber.Location = new System.Drawing.Point(445, 221);
            this.PhoneNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Size = new System.Drawing.Size(143, 21);
            this.PhoneNumber.TabIndex = 18;
            this.PhoneNumber.Text = "Telefon Numarası";
            this.PhoneNumber.Click += new System.EventHandler(this.PhoneNumber_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.Location = new System.Drawing.Point(89, 221);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(41, 21);
            this.txtPassword.TabIndex = 19;
            this.txtPassword.Text = "Şifre";
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Location = new System.Drawing.Point(89, 154);
            this.Username_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(88, 21);
            this.Username_Label.TabIndex = 20;
            this.Username_Label.Text = "Username";
            this.Username_Label.Click += new System.EventHandler(this.Username_Label_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(93, 180);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(247, 27);
            this.txtUsername.TabIndex = 21;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(93, 247);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(5);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(247, 27);
            this.maskedTextBox1.TabIndex = 22;
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(449, 101);
            this.txtFirst.Margin = new System.Windows.Forms.Padding(5);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(93, 27);
            this.txtFirst.TabIndex = 23;
            this.txtFirst.TextChanged += new System.EventHandler(this.txtFirst_TextChanged);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(571, 101);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(5);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(93, 27);
            this.txtSurname.TabIndex = 24;
            this.txtSurname.TextChanged += new System.EventHandler(this.txtSurname_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(449, 180);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(215, 27);
            this.txtEmail.TabIndex = 25;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(449, 247);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(215, 27);
            this.txtPhone.TabIndex = 26;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // Update_btn
            // 
            this.Update_btn.Location = new System.Drawing.Point(93, 294);
            this.Update_btn.Margin = new System.Windows.Forms.Padding(5);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(571, 105);
            this.Update_btn.TabIndex = 27;
            this.Update_btn.Text = "Güncelle";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // geri_btn
            // 
            this.geri_btn.Location = new System.Drawing.Point(14, 14);
            this.geri_btn.Margin = new System.Windows.Forms.Padding(5);
            this.geri_btn.Name = "geri_btn";
            this.geri_btn.Size = new System.Drawing.Size(125, 37);
            this.geri_btn.TabIndex = 28;
            this.geri_btn.Text = "Geri";
            this.geri_btn.UseVisualStyleBackColor = true;
            this.geri_btn.Click += new System.EventHandler(this.geri_btn_Click);
            // 
            // Profile_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(735, 413);
            this.Controls.Add(this.geri_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.Username_Label);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.PhoneNumber);
            this.Controls.Add(this.Email_Label);
            this.Controls.Add(this.Last_Label);
            this.Controls.Add(this.FirstLabel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Profile_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profil Ayarları";
            this.Load += new System.EventHandler(this.Profile_Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstLabel;
        private System.Windows.Forms.Label Last_Label;
        private System.Windows.Forms.Label Email_Label;
        private System.Windows.Forms.Label PhoneNumber;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.Label Username_Label;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button Update_btn;
        private System.Windows.Forms.Button geri_btn;
    }
}