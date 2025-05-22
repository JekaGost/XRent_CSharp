namespace XRent
{
    partial class DashboardForm
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
            this.btnManageCars = new System.Windows.Forms.Button();
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnManageRentals = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnManageCars
            // 
            this.btnManageCars.Location = new System.Drawing.Point(171, 24);
            this.btnManageCars.Name = "btnManageCars";
            this.btnManageCars.Size = new System.Drawing.Size(109, 52);
            this.btnManageCars.TabIndex = 0;
            this.btnManageCars.Text = "Manage Cars";
            this.btnManageCars.UseVisualStyleBackColor = true;
            this.btnManageCars.Click += new System.EventHandler(this.btnManageCars_Click);
            // 
            // btnManageCustomers
            // 
            this.btnManageCustomers.Location = new System.Drawing.Point(321, 24);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(109, 52);
            this.btnManageCustomers.TabIndex = 1;
            this.btnManageCustomers.Text = "Manage Customers";
            this.btnManageCustomers.UseVisualStyleBackColor = true;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);
            // 
            // btnManageRentals
            // 
            this.btnManageRentals.Location = new System.Drawing.Point(471, 24);
            this.btnManageRentals.Name = "btnManageRentals";
            this.btnManageRentals.Size = new System.Drawing.Size(109, 52);
            this.btnManageRentals.TabIndex = 2;
            this.btnManageRentals.Text = "Manage Rentals";
            this.btnManageRentals.UseVisualStyleBackColor = true;
            this.btnManageRentals.Click += new System.EventHandler(this.btnManageRentals_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnManageCars);
            this.panel1.Controls.Add(this.btnManageRentals);
            this.panel1.Controls.Add(this.btnManageCustomers);
            this.panel1.Location = new System.Drawing.Point(-8, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 166);
            this.panel1.TabIndex = 3;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageCars;
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageRentals;
        private System.Windows.Forms.Panel panel1;
    }
}