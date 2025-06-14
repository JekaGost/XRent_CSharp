namespace XRent
{
    partial class KVKK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KVKK));
            this.txtRulesDisplay = new System.Windows.Forms.RichTextBox();
            this.geri_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRulesDisplay
            // 
            this.txtRulesDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRulesDisplay.Location = new System.Drawing.Point(12, 12);
            this.txtRulesDisplay.Name = "txtRulesDisplay";
            this.txtRulesDisplay.ReadOnly = true;
            this.txtRulesDisplay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRulesDisplay.Size = new System.Drawing.Size(681, 299);
            this.txtRulesDisplay.TabIndex = 33;
            this.txtRulesDisplay.Text = "";
            this.txtRulesDisplay.TextChanged += new System.EventHandler(this.txtRulesDisplay_TextChanged);
            // 
            // geri_btn
            // 
            this.geri_btn.Location = new System.Drawing.Point(14, 399);
            this.geri_btn.Margin = new System.Windows.Forms.Padding(5);
            this.geri_btn.Name = "geri_btn";
            this.geri_btn.Size = new System.Drawing.Size(125, 37);
            this.geri_btn.TabIndex = 34;
            this.geri_btn.Text = " Geri";
            this.geri_btn.UseVisualStyleBackColor = true;
            this.geri_btn.Click += new System.EventHandler(this.geri_btn_Click);
            // 
            // KVKK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::XRent.Properties.Resources.login_background_3_jpg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.geri_btn);
            this.Controls.Add(this.txtRulesDisplay);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "KVKK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "XRent";
            this.Load += new System.EventHandler(this.KVKK_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtRulesDisplay;
        private System.Windows.Forms.Button geri_btn;
    }
}