namespace XRent
{
    partial class Kurallar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kurallar));
            this.geri_btn = new System.Windows.Forms.Button();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.picBtnMinimize = new System.Windows.Forms.PictureBox();
            this.picBtnHome = new System.Windows.Forms.PictureBox();
            this.panelDivider = new System.Windows.Forms.Panel();
            this.txtRulesDisplay = new System.Windows.Forms.RichTextBox();
            this.panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // geri_btn
            // 
            this.geri_btn.Location = new System.Drawing.Point(10, 365);
            this.geri_btn.Margin = new System.Windows.Forms.Padding(5);
            this.geri_btn.Name = "geri_btn";
            this.geri_btn.Size = new System.Drawing.Size(125, 37);
            this.geri_btn.TabIndex = 29;
            this.geri_btn.Text = " Geri";
            this.geri_btn.UseVisualStyleBackColor = true;
            this.geri_btn.Click += new System.EventHandler(this.geri_btn_Click);
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.DimGray;
            this.panelTopBar.BackgroundImage = global::XRent.Properties.Resources.panel_background2;
            this.panelTopBar.Controls.Add(this.picBtnMinimize);
            this.panelTopBar.Controls.Add(this.picBtnHome);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(735, 33);
            this.panelTopBar.TabIndex = 30;
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
            // picBtnHome
            // 
            this.picBtnHome.BackgroundImage = global::XRent.Properties.Resources.panel_background2;
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
            this.panelDivider.Size = new System.Drawing.Size(735, 2);
            this.panelDivider.TabIndex = 31;
            this.panelDivider.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDivider_Paint);
            // 
            // txtRulesDisplay
            // 
            this.txtRulesDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRulesDisplay.Location = new System.Drawing.Point(10, 41);
            this.txtRulesDisplay.Name = "txtRulesDisplay";
            this.txtRulesDisplay.ReadOnly = true;
            this.txtRulesDisplay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRulesDisplay.Size = new System.Drawing.Size(713, 316);
            this.txtRulesDisplay.TabIndex = 32;
            this.txtRulesDisplay.Text = "";
            this.txtRulesDisplay.TextChanged += new System.EventHandler(this.txtRulesDisplay_TextChanged);
            // 
            // Kurallar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::XRent.Properties.Resources.panel_background2;
            this.ClientSize = new System.Drawing.Size(735, 413);
            this.Controls.Add(this.txtRulesDisplay);
            this.Controls.Add(this.panelDivider);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.geri_btn);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Kurallar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "XRent";
            this.Load += new System.EventHandler(this.Kurallar_Load);
            this.panelTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button geri_btn;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.PictureBox picBtnMinimize;
        private System.Windows.Forms.PictureBox picBtnHome;
        private System.Windows.Forms.Panel panelDivider;
        private System.Windows.Forms.RichTextBox txtRulesDisplay;
    }
}