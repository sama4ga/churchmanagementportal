﻿namespace Church_Management_Portal
{
    partial class frmBaptismRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaptismRecord));
            this.dgvBaptismRegister = new System.Windows.Forms.DataGridView();
            this.panelAddNewParishioner = new System.Windows.Forms.Panel();
            this.gbListOfParishioners = new System.Windows.Forms.GroupBox();
            this.dgvListOfParishioners = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMinister = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.rdNewParishioner = new System.Windows.Forms.RadioButton();
            this.rdExistingParishioner = new System.Windows.Forms.RadioButton();
            this.txtVenue = new System.Windows.Forms.TextBox();
            this.txtSponsor = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewRecord = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaptismRegister)).BeginInit();
            this.panelAddNewParishioner.SuspendLayout();
            this.gbListOfParishioners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfParishioners)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBaptismRegister
            // 
            this.dgvBaptismRegister.AllowUserToAddRows = false;
            this.dgvBaptismRegister.AllowUserToDeleteRows = false;
            this.dgvBaptismRegister.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBaptismRegister.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaptismRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaptismRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBaptismRegister.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvBaptismRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBaptismRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaptismRegister.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBaptismRegister.Location = new System.Drawing.Point(6, 66);
            this.dgvBaptismRegister.Name = "dgvBaptismRegister";
            this.dgvBaptismRegister.ReadOnly = true;
            this.dgvBaptismRegister.RowHeadersVisible = false;
            this.dgvBaptismRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaptismRegister.ShowEditingIcon = false;
            this.dgvBaptismRegister.Size = new System.Drawing.Size(553, 590);
            this.dgvBaptismRegister.TabIndex = 0;
            // 
            // panelAddNewParishioner
            // 
            this.panelAddNewParishioner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAddNewParishioner.BackColor = System.Drawing.Color.DarkGreen;
            this.panelAddNewParishioner.Controls.Add(this.gbListOfParishioners);
            this.panelAddNewParishioner.Controls.Add(this.btnSave);
            this.panelAddNewParishioner.Controls.Add(this.btnClear);
            this.panelAddNewParishioner.Controls.Add(this.groupBox2);
            this.panelAddNewParishioner.Location = new System.Drawing.Point(575, 0);
            this.panelAddNewParishioner.Name = "panelAddNewParishioner";
            this.panelAddNewParishioner.Size = new System.Drawing.Size(794, 616);
            this.panelAddNewParishioner.TabIndex = 1;
            this.panelAddNewParishioner.Visible = false;
            // 
            // gbListOfParishioners
            // 
            this.gbListOfParishioners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListOfParishioners.Controls.Add(this.dgvListOfParishioners);
            this.gbListOfParishioners.ForeColor = System.Drawing.Color.White;
            this.gbListOfParishioners.Location = new System.Drawing.Point(354, 24);
            this.gbListOfParishioners.Name = "gbListOfParishioners";
            this.gbListOfParishioners.Size = new System.Drawing.Size(429, 580);
            this.gbListOfParishioners.TabIndex = 4;
            this.gbListOfParishioners.TabStop = false;
            this.gbListOfParishioners.Text = "List of Parishioners";
            this.gbListOfParishioners.Visible = false;
            this.gbListOfParishioners.VisibleChanged += new System.EventHandler(this.gbListOfParishioners_VisibleChanged);
            // 
            // dgvListOfParishioners
            // 
            this.dgvListOfParishioners.AllowUserToAddRows = false;
            this.dgvListOfParishioners.AllowUserToDeleteRows = false;
            this.dgvListOfParishioners.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListOfParishioners.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListOfParishioners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListOfParishioners.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListOfParishioners.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListOfParishioners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListOfParishioners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListOfParishioners.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListOfParishioners.Location = new System.Drawing.Point(6, 20);
            this.dgvListOfParishioners.Name = "dgvListOfParishioners";
            this.dgvListOfParishioners.ReadOnly = true;
            this.dgvListOfParishioners.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvListOfParishioners.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListOfParishioners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListOfParishioners.Size = new System.Drawing.Size(420, 554);
            this.dgvListOfParishioners.TabIndex = 0;
            this.dgvListOfParishioners.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListOfParishioners_CellContentClick);
            this.dgvListOfParishioners.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListOfParishioners_CellContentDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(18, 532);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 46);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save Record";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClear.BackColor = System.Drawing.Color.ForestGreen;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(200, 532);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 46);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMinister);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpDate);
            this.groupBox2.Controls.Add(this.rdNewParishioner);
            this.groupBox2.Controls.Add(this.rdExistingParishioner);
            this.groupBox2.Controls.Add(this.txtVenue);
            this.groupBox2.Controls.Add(this.txtSponsor);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(18, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 477);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add New Record";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtMinister
            // 
            this.txtMinister.Location = new System.Drawing.Point(87, 277);
            this.txtMinister.Name = "txtMinister";
            this.txtMinister.Size = new System.Drawing.Size(224, 23);
            this.txtMinister.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Minister";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sponsor";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(87, 229);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(224, 23);
            this.dtpDate.TabIndex = 9;
            // 
            // rdNewParishioner
            // 
            this.rdNewParishioner.AutoSize = true;
            this.rdNewParishioner.Location = new System.Drawing.Point(182, 42);
            this.rdNewParishioner.Name = "rdNewParishioner";
            this.rdNewParishioner.Size = new System.Drawing.Size(129, 21);
            this.rdNewParishioner.TabIndex = 7;
            this.rdNewParishioner.TabStop = true;
            this.rdNewParishioner.Text = "New Parishioner";
            this.rdNewParishioner.UseVisualStyleBackColor = true;
            this.rdNewParishioner.CheckedChanged += new System.EventHandler(this.rdNewParishioner_CheckedChanged);
            // 
            // rdExistingParishioner
            // 
            this.rdExistingParishioner.AutoSize = true;
            this.rdExistingParishioner.Location = new System.Drawing.Point(26, 42);
            this.rdExistingParishioner.Name = "rdExistingParishioner";
            this.rdExistingParishioner.Size = new System.Drawing.Size(150, 21);
            this.rdExistingParishioner.TabIndex = 6;
            this.rdExistingParishioner.TabStop = true;
            this.rdExistingParishioner.Text = "Existing Parishioner";
            this.rdExistingParishioner.UseVisualStyleBackColor = true;
            this.rdExistingParishioner.CheckedChanged += new System.EventHandler(this.rdExistingParishioner_CheckedChanged);
            // 
            // txtVenue
            // 
            this.txtVenue.Location = new System.Drawing.Point(87, 130);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.Size = new System.Drawing.Size(224, 23);
            this.txtVenue.TabIndex = 5;
            // 
            // txtSponsor
            // 
            this.txtSponsor.Location = new System.Drawing.Point(87, 181);
            this.txtSponsor.Name = "txtSponsor";
            this.txtSponsor.Size = new System.Drawing.Size(224, 23);
            this.txtSponsor.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(87, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(224, 23);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Venue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // btnAddNewRecord
            // 
            this.btnAddNewRecord.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddNewRecord.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddNewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewRecord.ForeColor = System.Drawing.Color.White;
            this.btnAddNewRecord.Location = new System.Drawing.Point(775, 622);
            this.btnAddNewRecord.Name = "btnAddNewRecord";
            this.btnAddNewRecord.Size = new System.Drawing.Size(179, 46);
            this.btnAddNewRecord.TabIndex = 0;
            this.btnAddNewRecord.Text = "&Add New Record";
            this.btnAddNewRecord.UseVisualStyleBackColor = false;
            this.btnAddNewRecord.Click += new System.EventHandler(this.btnAddNewRecord_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBack.BackColor = System.Drawing.Color.ForestGreen;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1024, 622);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(146, 46);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.DarkGreen;
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.dgvBaptismRegister);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 675);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Existing Baptism Record";
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(425, 21);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(62, 39);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cmbSearchBy);
            this.groupBox3.Controls.Add(this.txtSearch);
            this.groupBox3.Location = new System.Drawing.Point(6, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(417, 46);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Search List By";
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Items.AddRange(new object[] {
            "Name",
            "Minister",
            "Venue",
            "Sponsor"});
            this.cmbSearchBy.Location = new System.Drawing.Point(84, 16);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(83, 21);
            this.cmbSearchBy.TabIndex = 9;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(168, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(239, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(490, 21);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 39);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmBaptismRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1370, 675);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddNewRecord);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panelAddNewParishioner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaptismRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baptism Record";
            this.Load += new System.EventHandler(this.frmBaptismRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaptismRegister)).EndInit();
            this.panelAddNewParishioner.ResumeLayout(false);
            this.gbListOfParishioners.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfParishioners)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBaptismRegister;
        private System.Windows.Forms.Panel panelAddNewParishioner;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddNewRecord;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbListOfParishioners;
        private System.Windows.Forms.DataGridView dgvListOfParishioners;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.RadioButton rdNewParishioner;
        private System.Windows.Forms.RadioButton rdExistingParishioner;
        private System.Windows.Forms.TextBox txtVenue;
        private System.Windows.Forms.TextBox txtSponsor;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinister;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnExport;
    }
}