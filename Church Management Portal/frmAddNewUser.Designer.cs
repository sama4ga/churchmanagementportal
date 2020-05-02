namespace Church_Management_Portal
{
    partial class frmAddNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewUser));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbPriviledge = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtCPassword = new System.Windows.Forms.TextBox();
            this.rdParishioner = new System.Windows.Forms.RadioButton();
            this.rdNonParishioner = new System.Windows.Forms.RadioButton();
            this.dgvParishionerList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParishionerList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(136, 322);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 30);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(276, 322);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbPriviledge
            // 
            this.cmbPriviledge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriviledge.FormattingEnabled = true;
            this.cmbPriviledge.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbPriviledge.Items.AddRange(new object[] {
            "Admin",
            "Secretary",
            "User"});
            this.cmbPriviledge.Location = new System.Drawing.Point(140, 191);
            this.cmbPriviledge.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPriviledge.Name = "cmbPriviledge";
            this.cmbPriviledge.Size = new System.Drawing.Size(249, 25);
            this.cmbPriviledge.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Priviledge";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(140, 61);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(249, 23);
            this.txtUsername.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(140, 105);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '#';
            this.txtPassword.Size = new System.Drawing.Size(249, 23);
            this.txtPassword.TabIndex = 8;
            // 
            // txtCPassword
            // 
            this.txtCPassword.Location = new System.Drawing.Point(140, 148);
            this.txtCPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPassword.Name = "txtCPassword";
            this.txtCPassword.PasswordChar = '#';
            this.txtCPassword.Size = new System.Drawing.Size(249, 23);
            this.txtCPassword.TabIndex = 9;
            // 
            // rdParishioner
            // 
            this.rdParishioner.AutoSize = true;
            this.rdParishioner.Location = new System.Drawing.Point(291, 251);
            this.rdParishioner.Margin = new System.Windows.Forms.Padding(4);
            this.rdParishioner.Name = "rdParishioner";
            this.rdParishioner.Size = new System.Drawing.Size(98, 21);
            this.rdParishioner.TabIndex = 10;
            this.rdParishioner.Text = "Parishioner";
            this.rdParishioner.UseVisualStyleBackColor = true;
            this.rdParishioner.CheckedChanged += new System.EventHandler(this.rdParishioner_CheckedChanged);
            // 
            // rdNonParishioner
            // 
            this.rdNonParishioner.AutoSize = true;
            this.rdNonParishioner.Checked = true;
            this.rdNonParishioner.Location = new System.Drawing.Point(140, 251);
            this.rdNonParishioner.Margin = new System.Windows.Forms.Padding(4);
            this.rdNonParishioner.Name = "rdNonParishioner";
            this.rdNonParishioner.Size = new System.Drawing.Size(128, 21);
            this.rdNonParishioner.TabIndex = 11;
            this.rdNonParishioner.TabStop = true;
            this.rdNonParishioner.Text = "Non Parishioner";
            this.rdNonParishioner.UseVisualStyleBackColor = true;
            // 
            // dgvParishionerList
            // 
            this.dgvParishionerList.AllowUserToAddRows = false;
            this.dgvParishionerList.AllowUserToDeleteRows = false;
            this.dgvParishionerList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvParishionerList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParishionerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParishionerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParishionerList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvParishionerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvParishionerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParishionerList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParishionerList.Location = new System.Drawing.Point(420, -1);
            this.dgvParishionerList.Name = "dgvParishionerList";
            this.dgvParishionerList.ReadOnly = true;
            this.dgvParishionerList.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvParishionerList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvParishionerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParishionerList.Size = new System.Drawing.Size(381, 366);
            this.dgvParishionerList.TabIndex = 12;
            this.dgvParishionerList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParishionerList_CellContentClick);
            // 
            // frmAddNewUser
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.dgvParishionerList);
            this.Controls.Add(this.rdNonParishioner);
            this.Controls.Add(this.rdParishioner);
            this.Controls.Add(this.txtCPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPriviledge);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddNewUser";
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.frmAddNewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParishionerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbPriviledge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCPassword;
        private System.Windows.Forms.RadioButton rdParishioner;
        private System.Windows.Forms.RadioButton rdNonParishioner;
        private System.Windows.Forms.DataGridView dgvParishionerList;
    }
}