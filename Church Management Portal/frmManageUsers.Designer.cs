namespace Church_Management_Portal
{
    partial class frmManageUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUsers));
            this.dgvUsersList = new System.Windows.Forms.DataGridView();
            this.gbListOfUsers = new System.Windows.Forms.GroupBox();
            this.gbUpdateUsername = new System.Windows.Forms.GroupBox();
            this.btnUpdateUsername = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnChangeUserPriviledge = new System.Windows.Forms.Button();
            this.btnChangeUsername = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUpdatePriviledge = new System.Windows.Forms.Button();
            this.btnConfirmPassword = new System.Windows.Forms.Button();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPriviledge = new System.Windows.Forms.ComboBox();
            this.gbUpdatePriviledge = new System.Windows.Forms.GroupBox();
            this.gbUpdatePassword = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbNewPassword = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).BeginInit();
            this.gbListOfUsers.SuspendLayout();
            this.gbUpdateUsername.SuspendLayout();
            this.gbUpdatePriviledge.SuspendLayout();
            this.gbUpdatePassword.SuspendLayout();
            this.gbNewPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsersList
            // 
            this.dgvUsersList.AllowUserToAddRows = false;
            this.dgvUsersList.AllowUserToDeleteRows = false;
            this.dgvUsersList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUsersList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsersList.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsersList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsersList.Location = new System.Drawing.Point(6, 19);
            this.dgvUsersList.Name = "dgvUsersList";
            this.dgvUsersList.ReadOnly = true;
            this.dgvUsersList.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvUsersList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsersList.Size = new System.Drawing.Size(463, 434);
            this.dgvUsersList.TabIndex = 13;
            this.dgvUsersList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsersList_CellClick);
            this.dgvUsersList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsersList_CellContentClick);
            // 
            // gbListOfUsers
            // 
            this.gbListOfUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListOfUsers.Controls.Add(this.dgvUsersList);
            this.gbListOfUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbListOfUsers.ForeColor = System.Drawing.Color.White;
            this.gbListOfUsers.Location = new System.Drawing.Point(12, 12);
            this.gbListOfUsers.Name = "gbListOfUsers";
            this.gbListOfUsers.Size = new System.Drawing.Size(475, 459);
            this.gbListOfUsers.TabIndex = 14;
            this.gbListOfUsers.TabStop = false;
            this.gbListOfUsers.Text = "List of Users";
            // 
            // gbUpdateUsername
            // 
            this.gbUpdateUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUpdateUsername.Controls.Add(this.btnUpdateUsername);
            this.gbUpdateUsername.Controls.Add(this.label1);
            this.gbUpdateUsername.Controls.Add(this.txtUsername);
            this.gbUpdateUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbUpdateUsername.ForeColor = System.Drawing.Color.White;
            this.gbUpdateUsername.Location = new System.Drawing.Point(493, 12);
            this.gbUpdateUsername.Name = "gbUpdateUsername";
            this.gbUpdateUsername.Size = new System.Drawing.Size(421, 94);
            this.gbUpdateUsername.TabIndex = 15;
            this.gbUpdateUsername.TabStop = false;
            this.gbUpdateUsername.Text = "Update Username";
            this.gbUpdateUsername.Visible = false;
            // 
            // btnUpdateUsername
            // 
            this.btnUpdateUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUsername.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUsername.Location = new System.Drawing.Point(325, 49);
            this.btnUpdateUsername.Name = "btnUpdateUsername";
            this.btnUpdateUsername.Size = new System.Drawing.Size(75, 32);
            this.btnUpdateUsername.TabIndex = 41;
            this.btnUpdateUsername.Text = "Update";
            this.btnUpdateUsername.UseVisualStyleBackColor = true;
            this.btnUpdateUsername.Click += new System.EventHandler(this.btnUpdateUsername_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(151, 19);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(249, 23);
            this.txtUsername.TabIndex = 33;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddNewUser.ForeColor = System.Drawing.Color.White;
            this.btnAddNewUser.Location = new System.Drawing.Point(637, 490);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(123, 31);
            this.btnAddNewUser.TabIndex = 0;
            this.btnAddNewUser.Text = "Add New User";
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(93, 490);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(135, 31);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(238, 490);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 31);
            this.btnDeleteUser.TabIndex = 16;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnChangeUserPriviledge
            // 
            this.btnChangeUserPriviledge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeUserPriviledge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeUserPriviledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnChangeUserPriviledge.ForeColor = System.Drawing.Color.White;
            this.btnChangeUserPriviledge.Location = new System.Drawing.Point(322, 490);
            this.btnChangeUserPriviledge.Name = "btnChangeUserPriviledge";
            this.btnChangeUserPriviledge.Size = new System.Drawing.Size(149, 31);
            this.btnChangeUserPriviledge.TabIndex = 17;
            this.btnChangeUserPriviledge.Text = "Change User Priviledge";
            this.btnChangeUserPriviledge.UseVisualStyleBackColor = true;
            this.btnChangeUserPriviledge.Click += new System.EventHandler(this.btnChangeUserPriviledge_Click);
            // 
            // btnChangeUsername
            // 
            this.btnChangeUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnChangeUsername.ForeColor = System.Drawing.Color.White;
            this.btnChangeUsername.Location = new System.Drawing.Point(479, 490);
            this.btnChangeUsername.Name = "btnChangeUsername";
            this.btnChangeUsername.Size = new System.Drawing.Size(142, 31);
            this.btnChangeUsername.TabIndex = 18;
            this.btnChangeUsername.Text = "Change Username";
            this.btnChangeUsername.UseVisualStyleBackColor = true;
            this.btnChangeUsername.Click += new System.EventHandler(this.btnChangeUsername_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(776, 490);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUpdatePriviledge
            // 
            this.btnUpdatePriviledge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePriviledge.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePriviledge.Location = new System.Drawing.Point(325, 59);
            this.btnUpdatePriviledge.Name = "btnUpdatePriviledge";
            this.btnUpdatePriviledge.Size = new System.Drawing.Size(75, 28);
            this.btnUpdatePriviledge.TabIndex = 42;
            this.btnUpdatePriviledge.Text = "Update";
            this.btnUpdatePriviledge.UseVisualStyleBackColor = true;
            this.btnUpdatePriviledge.Click += new System.EventHandler(this.btnUpdatePriviledge_Click);
            // 
            // btnConfirmPassword
            // 
            this.btnConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPassword.Location = new System.Drawing.Point(325, 51);
            this.btnConfirmPassword.Name = "btnConfirmPassword";
            this.btnConfirmPassword.Size = new System.Drawing.Size(79, 29);
            this.btnConfirmPassword.TabIndex = 40;
            this.btnConfirmPassword.Text = "Change";
            this.btnConfirmPassword.UseVisualStyleBackColor = true;
            this.btnConfirmPassword.Click += new System.EventHandler(this.btnConfirmPassword_Click);
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePassword.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePassword.Location = new System.Drawing.Point(302, 96);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(79, 30);
            this.btnUpdatePassword.TabIndex = 34;
            this.btnUpdatePassword.Text = "Update";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(159, 62);
            this.txtConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = '#';
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(222, 23);
            this.txtConfirmNewPassword.TabIndex = 39;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(159, 19);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '#';
            this.txtNewPassword.Size = new System.Drawing.Size(222, 23);
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
            this.label6.Location = new System.Drawing.Point(55, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "New Password";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(172, 21);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '#';
            this.txtOldPassword.Size = new System.Drawing.Size(232, 23);
            this.txtOldPassword.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "Priviledge";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Current Password";
            // 
            // cmbPriviledge
            // 
            this.cmbPriviledge.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbPriviledge.FormattingEnabled = true;
            this.cmbPriviledge.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbPriviledge.Items.AddRange(new object[] {
            "Admin",
            "Secretary",
            "User"});
            this.cmbPriviledge.Location = new System.Drawing.Point(151, 26);
            this.cmbPriviledge.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPriviledge.Name = "cmbPriviledge";
            this.cmbPriviledge.Size = new System.Drawing.Size(249, 24);
            this.cmbPriviledge.TabIndex = 29;
            // 
            // gbUpdatePriviledge
            // 
            this.gbUpdatePriviledge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUpdatePriviledge.Controls.Add(this.cmbPriviledge);
            this.gbUpdatePriviledge.Controls.Add(this.btnUpdatePriviledge);
            this.gbUpdatePriviledge.Controls.Add(this.label4);
            this.gbUpdatePriviledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbUpdatePriviledge.ForeColor = System.Drawing.Color.White;
            this.gbUpdatePriviledge.Location = new System.Drawing.Point(493, 122);
            this.gbUpdatePriviledge.Name = "gbUpdatePriviledge";
            this.gbUpdatePriviledge.Size = new System.Drawing.Size(421, 99);
            this.gbUpdatePriviledge.TabIndex = 42;
            this.gbUpdatePriviledge.TabStop = false;
            this.gbUpdatePriviledge.Text = "Update Priviledge";
            this.gbUpdatePriviledge.Visible = false;
            // 
            // gbUpdatePassword
            // 
            this.gbUpdatePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUpdatePassword.Controls.Add(this.label3);
            this.gbUpdatePassword.Controls.Add(this.gbNewPassword);
            this.gbUpdatePassword.Controls.Add(this.btnConfirmPassword);
            this.gbUpdatePassword.Controls.Add(this.txtOldPassword);
            this.gbUpdatePassword.Controls.Add(this.label2);
            this.gbUpdatePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbUpdatePassword.ForeColor = System.Drawing.Color.White;
            this.gbUpdatePassword.Location = new System.Drawing.Point(493, 240);
            this.gbUpdatePassword.Name = "gbUpdatePassword";
            this.gbUpdatePassword.Size = new System.Drawing.Size(421, 231);
            this.gbUpdatePassword.TabIndex = 43;
            this.gbUpdatePassword.TabStop = false;
            this.gbUpdatePassword.Text = "Change Password";
            this.gbUpdatePassword.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(372, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "This action will change the password for the selected user";
            // 
            // gbNewPassword
            // 
            this.gbNewPassword.Controls.Add(this.btnUpdatePassword);
            this.gbNewPassword.Controls.Add(this.txtConfirmNewPassword);
            this.gbNewPassword.Controls.Add(this.txtNewPassword);
            this.gbNewPassword.Controls.Add(this.label5);
            this.gbNewPassword.Controls.Add(this.label6);
            this.gbNewPassword.Location = new System.Drawing.Point(13, 83);
            this.gbNewPassword.Name = "gbNewPassword";
            this.gbNewPassword.Size = new System.Drawing.Size(397, 135);
            this.gbNewPassword.TabIndex = 41;
            this.gbNewPassword.TabStop = false;
            this.gbNewPassword.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(12, 490);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 31);
            this.btnRefresh.TabIndex = 44;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(924, 530);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gbUpdatePassword);
            this.Controls.Add(this.gbUpdatePriviledge);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnChangeUsername);
            this.Controls.Add(this.btnChangeUserPriviledge);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.gbUpdateUsername);
            this.Controls.Add(this.gbListOfUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmManageUsers";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).EndInit();
            this.gbListOfUsers.ResumeLayout(false);
            this.gbUpdateUsername.ResumeLayout(false);
            this.gbUpdateUsername.PerformLayout();
            this.gbUpdatePriviledge.ResumeLayout(false);
            this.gbUpdatePriviledge.PerformLayout();
            this.gbUpdatePassword.ResumeLayout(false);
            this.gbUpdatePassword.PerformLayout();
            this.gbNewPassword.ResumeLayout(false);
            this.gbNewPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsersList;
        private System.Windows.Forms.GroupBox gbListOfUsers;
        private System.Windows.Forms.GroupBox gbUpdateUsername;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnChangeUserPriviledge;
        private System.Windows.Forms.Button btnUpdateUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnChangeUsername;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnUpdatePriviledge;
        private System.Windows.Forms.Button btnConfirmPassword;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPriviledge;
        private System.Windows.Forms.GroupBox gbUpdatePriviledge;
        private System.Windows.Forms.GroupBox gbUpdatePassword;
        private System.Windows.Forms.GroupBox gbNewPassword;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label3;
    }
}