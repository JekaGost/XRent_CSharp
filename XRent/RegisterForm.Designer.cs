namespace XRent
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.Username_Label = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Last_Label = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.Email_Label = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.PhoneNumber = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.FirstLabel = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txt_kvkk = new System.Windows.Forms.RichTextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Location = new System.Drawing.Point(88, 86);
            this.Username_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(103, 21);
            this.Username_Label.TabIndex = 0;
            this.Username_Label.Text = "Kullanıcı Adı";
            this.Username_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(88, 129);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(247, 27);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(88, 186);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(41, 21);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Şifre";
            this.labelPassword.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(210, 402);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(125, 37);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Kayıt Ol";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(397, 402);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 37);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Geri";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Last_Label
            // 
            this.Last_Label.AutoSize = true;
            this.Last_Label.Location = new System.Drawing.Point(586, 86);
            this.Last_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Last_Label.Name = "Last_Label";
            this.Last_Label.Size = new System.Drawing.Size(63, 21);
            this.Last_Label.TabIndex = 8;
            this.Last_Label.Text = "Soyisim";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(551, 129);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(5);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(93, 27);
            this.txtSurname.TabIndex = 9;
            this.txtSurname.TextChanged += new System.EventHandler(this.txtSurname_TextChanged);
            // 
            // Email_Label
            // 
            this.Email_Label.AutoSize = true;
            this.Email_Label.Location = new System.Drawing.Point(398, 186);
            this.Email_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Email_Label.Name = "Email_Label";
            this.Email_Label.Size = new System.Drawing.Size(69, 21);
            this.Email_Label.TabIndex = 10;
            this.Email_Label.Text = "E-posta";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(397, 225);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(247, 27);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSize = true;
            this.PhoneNumber.Location = new System.Drawing.Point(88, 291);
            this.PhoneNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Size = new System.Drawing.Size(143, 21);
            this.PhoneNumber.TabIndex = 12;
            this.PhoneNumber.Text = "Telefon Numarası";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(88, 330);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(247, 27);
            this.txtPhone.TabIndex = 13;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // FirstLabel
            // 
            this.FirstLabel.AutoSize = true;
            this.FirstLabel.Location = new System.Drawing.Point(398, 86);
            this.FirstLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.FirstLabel.Name = "FirstLabel";
            this.FirstLabel.Size = new System.Drawing.Size(39, 21);
            this.FirstLabel.TabIndex = 14;
            this.FirstLabel.Text = "İsim";
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(397, 129);
            this.txtFirst.Margin = new System.Windows.Forms.Padding(5);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(93, 27);
            this.txtFirst.TabIndex = 15;
            this.txtFirst.TextChanged += new System.EventHandler(this.txtFirst_TextChanged);
            // 
            // txt_kvkk
            // 
            this.txt_kvkk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_kvkk.Location = new System.Drawing.Point(397, 261);
            this.txt_kvkk.Name = "txt_kvkk";
            this.txt_kvkk.ReadOnly = true;
            this.txt_kvkk.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txt_kvkk.Size = new System.Drawing.Size(247, 96);
            this.txt_kvkk.TabIndex = 16;
            this.txt_kvkk.Text = "";
            this.txt_kvkk.TextChanged += new System.EventHandler(this.txt_kvkk_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(88, 225);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(247, 27);
            this.txtPassword.TabIndex = 17;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::XRent.Properties.Resources.login_background_4;
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txt_kvkk);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.FirstLabel);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.PhoneNumber);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.Email_Label);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.Last_Label);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.Username_Label);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "RegisterForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "XRent";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Username_Label;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label Last_Label;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label Email_Label;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label PhoneNumber;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label FirstLabel;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.RichTextBox txt_kvkk;
        private System.Windows.Forms.TextBox txtPassword;
    }
}