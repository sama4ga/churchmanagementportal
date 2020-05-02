namespace Church_Management_Portal
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.gbUpdatePassword = new System.Windows.Forms.GroupBox();
            this.gbNewPassword = new System.Windows.Forms.GroupBox();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConfirmPassword = new System.Windows.Forms.Button();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbUpdatePassword.SuspendLayout();
            this.gbNewPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUpdatePassword
            // 
            this.gbUpdatePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUpdatePassword.Controls.Add(this.gbNewPassword);
            this.gbUpdatePassword.Controls.Add(this.btnConfirmPassword);
            this.gbUpdatePassword.Controls.Add(this.txtOldPassword);
            this.gbUpdatePassword.Controls.Add(this.label2);
            this.gbUpdatePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.gbUpdatePassword.ForeColor = System.Drawing.Color.White;
            this.gbUpdatePassword.Location = new System.Drawing.Point(12, 12);
            this.gbUpdatePassword.Name = "gbUpdatePassword";
            this.gbUpdatePassword.Size = new System.Drawing.Size(443, 270);
            this.gbUpdatePassword.TabIndex = 44;
            this.gbUpdatePassword.TabStop = false;
            this.gbUpdatePassword.Text = "Change Password";
            // 
            // gbNewPassword
            // 
            this.gbNewPassword.Controls.Add(this.btnUpdatePassword);
            this.gbNewPassword.Controls.Add(this.txtConfirmNewPassword);
            this.gbNewPassword.Controls.Add(this.txtNewPassword);
            this.gbNewPassword.Controls.Add(this.label5);
            this.gbNewPassword.Controls.Add(this.label6);
            this.gbNewPassword.Location = new System.Drawing.Point(7, 100);
            this.gbNewPassword.Name = "gbNewPassword";
            this.gbNewPassword.Size = new System.Drawing.Size(424, 154);
            this.gbNewPassword.TabIndex = 41;
            this.gbNewPassword.TabStop = false;
            this.gbNewPassword.Visible = false;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePassword.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePassword.Location = new System.Drawing.Point(322, 108);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(86, 30);
            this.btnUpdatePassword.TabIndex = 34;
            this.btnUpdatePassword.Text = "Update";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(159, 63);
            this.txtConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = '#';
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(249, 23);
            this.txtConfirmNewPassword.TabIndex = 39;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(159, 19);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '#';
            this.txtNewPassword.Size = new System.Drawing.Size(249, 23);
            this.txtNewPassword.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Confirm New Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "New Password";
            // 
            // btnConfirmPassword
            // 
            this.btnConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPassword.Location = new System.Drawing.Point(334, 62);
            this.btnConfirmPassword.Name = "btnConfirmPassword";
            this.btnConfirmPassword.Size = new System.Drawing.Size(79, 34);
            this.btnConfirmPassword.TabIndex = 40;
            this.btnConfirmPassword.Text = "Change";
            this.btnConfirmPassword.UseVisualStyleBackColor = true;
            this.btnConfirmPassword.Click += new System.EventHandler(this.btnConfirmPassword_Click);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(177, 30);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '#';
            this.txtOldPassword.Size = new System.Drawing.Size(249, 23);
            this.txtOldPassword.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Current Password";
            // 
            // frmChangepASSWORD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(477, 294);
            this.Controls.Add(this.gbUpdatePassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChangepASSWORD";
            this.Text = "Change Password";
            this.gbUpdatePassword.ResumeLayout(false);
            this.gbUpdatePassword.PerformLayout();
            this.gbNewPassword.ResumeLayout(false);
            this.gbNewPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUpdatePassword;
        private System.Windows.Forms.GroupBox gbNewPassword;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfirmPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label label2;
    }
}