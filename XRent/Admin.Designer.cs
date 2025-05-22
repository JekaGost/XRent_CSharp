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
            this.Settings_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Users_btn = new System.Windows.Forms.Button();
            this.Cars_btn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings_btn
            // 
            this.Settings_btn.Location = new System.Drawing.Point(3, 3);
            this.Settings_btn.Name = "Settings_btn";
            this.Settings_btn.Size = new System.Drawing.Size(116, 69);
            this.Settings_btn.TabIndex = 0;
            this.Settings_btn.Text = "Ayarlar";
            this.Settings_btn.UseVisualStyleBackColor = true;
            this.Settings_btn.Click += new System.EventHandler(this.Settings_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.Cars_btn);
            this.panel1.Controls.Add(this.Users_btn);
            this.panel1.Controls.Add(this.Settings_btn);
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 528);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Users_btn
            // 
            this.Users_btn.Location = new System.Drawing.Point(125, 3);
            this.Users_btn.Name = "Users_btn";
            this.Users_btn.Size = new System.Drawing.Size(116, 69);
            this.Users_btn.TabIndex = 1;
            this.Users_btn.Text = "Kullanıcılar";
            this.Users_btn.UseVisualStyleBackColor = true;
            this.Users_btn.Click += new System.EventHandler(this.Users_btn_Click);
            // 
            // Cars_btn
            // 
            this.Cars_btn.Location = new System.Drawing.Point(0, 78);
            this.Cars_btn.Name = "Cars_btn";
            this.Cars_btn.Size = new System.Drawing.Size(116, 69);
            this.Cars_btn.TabIndex = 2;
            this.Cars_btn.Text = "Arabalar";
            this.Cars_btn.UseVisualStyleBackColor = true;
            this.Cars_btn.Click += new System.EventHandler(this.Cars_btn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(609, 456);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 69);
            this.button4.TabIndex = 3;
            this.button4.Text = "Kullanıcılar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(609, 381);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 69);
            this.button5.TabIndex = 4;
            this.button5.Text = "Kullanıcılar";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(487, 456);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(116, 69);
            this.button6.TabIndex = 5;
            this.button6.Text = "Kullanıcılar";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Admin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Settings_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Cars_btn;
        private System.Windows.Forms.Button Users_btn;
    }
}