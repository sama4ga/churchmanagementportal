namespace Church_Management_Portal
{
    partial class frmConfirmationRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmationRecord));
            this.btnAddNewRecord = new System.Windows.Forms.Button();
            this.panelAddNewParishioner = new System.Windows.Forms.Panel();
            this.gbEditRecord = new System.Windows.Forms.GroupBox();
            this.txtMinisterUpdate = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDateUpdate = new System.Windows.Forms.DateTimePicker();
            this.txtVenueUpdate = new System.Windows.Forms.TextBox();
            this.txtSponsorUpdate = new System.Windows.Forms.TextBox();
            this.txtNameUpdate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gbListOfParishioners = new System.Windows.Forms.GroupBox();
            this.dgvListOfParishioners = new System.Windows.Forms.DataGridView();
            this.gbAddNewRecord = new System.Windows.Forms.GroupBox();
            this.txtMinister = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRowNo = new System.Windows.Forms.TextBox();
            this.txtRowCount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvConfirmationRegister = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnEditRecord = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelAddNewParishioner.SuspendLayout();
            this.gbEditRecord.SuspendLayout();
            this.gbListOfParishioners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfParishioners)).BeginInit();
            this.gbAddNewRecord.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirmationRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewRecord
            // 
            this.btnAddNewRecord.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddNewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewRecord.ForeColor = System.Drawing.Color.White;
            this.btnAddNewRecord.Location = new System.Drawing.Point(584, 713);
            this.btnAddNewRecord.Name = "btnAddNewRecord";
            this.btnAddNewRecord.Size = new System.Drawing.Size(150, 30);
            this.btnAddNewRecord.TabIndex = 7;
            this.btnAddNewRecord.Text = "&Add New Record";
            this.btnAddNewRecord.UseVisualStyleBackColor = true;
            this.btnAddNewRecord.Click += new System.EventHandler(this.btnAddNewRecord_Click);
            // 
            // panelAddNewParishioner
            // 
            this.panelAddNewParishioner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAddNewParishioner.BackColor = System.Drawing.Color.DarkGreen;
            this.panelAddNewParishioner.Controls.Add(this.gbEditRecord);
            this.panelAddNewParishioner.Controls.Add(this.gbListOfParishioners);
            this.panelAddNewParishioner.Controls.Add(this.gbAddNewRecord);
            this.panelAddNewParishioner.Location = new System.Drawing.Point(574, 6);
            this.panelAddNewParishioner.Name = "panelAddNewParishioner";
            this.panelAddNewParishioner.Size = new System.Drawing.Size(794, 701);
            this.panelAddNewParishioner.TabIndex = 9;
            // 
            // gbEditRecord
            // 
            this.gbEditRecord.Controls.Add(this.txtMinisterUpdate);
            this.gbEditRecord.Controls.Add(this.btnUpdate);
            this.gbEditRecord.Controls.Add(this.label7);
            this.gbEditRecord.Controls.Add(this.label8);
            this.gbEditRecord.Controls.Add(this.label9);
            this.gbEditRecord.Controls.Add(this.dtpDateUpdate);
            this.gbEditRecord.Controls.Add(this.txtVenueUpdate);
            this.gbEditRecord.Controls.Add(this.txtSponsorUpdate);
            this.gbEditRecord.Controls.Add(this.txtNameUpdate);
            this.gbEditRecord.Controls.Add(this.label10);
            this.gbEditRecord.Controls.Add(this.label11);
            this.gbEditRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEditRecord.ForeColor = System.Drawing.Color.White;
            this.gbEditRecord.Location = new System.Drawing.Point(18, 364);
            this.gbEditRecord.Name = "gbEditRecord";
            this.gbEditRecord.Size = new System.Drawing.Size(349, 288);
            this.gbEditRecord.TabIndex = 14;
            this.gbEditRecord.TabStop = false;
            this.gbEditRecord.Text = "Update Record";
            this.gbEditRecord.Visible = false;
            // 
            // txtMinisterUpdate
            // 
            this.txtMinisterUpdate.Location = new System.Drawing.Point(94, 201);
            this.txtMinisterUpdate.Name = "txtMinisterUpdate";
            this.txtMinisterUpdate.Size = new System.Drawing.Size(237, 22);
            this.txtMinisterUpdate.TabIndex = 13;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(181, 237);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(147, 29);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Update Record";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Minister";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Sponsor";
            // 
            // dtpDateUpdate
            // 
            this.dtpDateUpdate.Location = new System.Drawing.Point(94, 162);
            this.dtpDateUpdate.Name = "dtpDateUpdate";
            this.dtpDateUpdate.Size = new System.Drawing.Size(237, 22);
            this.dtpDateUpdate.TabIndex = 9;
            // 
            // txtVenueUpdate
            // 
            this.txtVenueUpdate.Location = new System.Drawing.Point(94, 77);
            this.txtVenueUpdate.Name = "txtVenueUpdate";
            this.txtVenueUpdate.Size = new System.Drawing.Size(237, 22);
            this.txtVenueUpdate.TabIndex = 5;
            // 
            // txtSponsorUpdate
            // 
            this.txtSponsorUpdate.Location = new System.Drawing.Point(94, 118);
            this.txtSponsorUpdate.Name = "txtSponsorUpdate";
            this.txtSponsorUpdate.Size = new System.Drawing.Size(237, 22);
            this.txtSponsorUpdate.TabIndex = 4;
            // 
            // txtNameUpdate
            // 
            this.txtNameUpdate.Location = new System.Drawing.Point(94, 34);
            this.txtNameUpdate.Name = "txtNameUpdate";
            this.txtNameUpdate.Size = new System.Drawing.Size(237, 22);
            this.txtNameUpdate.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Venue";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Name";
            // 
            // gbListOfParishioners
            // 
            this.gbListOfParishioners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListOfParishioners.Controls.Add(this.dgvListOfParishioners);
            this.gbListOfParishioners.ForeColor = System.Drawing.Color.White;
            this.gbListOfParishioners.Location = new System.Drawing.Point(373, 10);
            this.gbListOfParishioners.Name = "gbListOfParishioners";
            this.gbListOfParishioners.Size = new System.Drawing.Size(411, 688);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListOfParishioners.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListOfParishioners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListOfParishioners.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListOfParishioners.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListOfParishioners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListOfParishioners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListOfParishioners.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListOfParishioners.Location = new System.Drawing.Point(6, 19);
            this.dgvListOfParishioners.Name = "dgvListOfParishioners";
            this.dgvListOfParishioners.ReadOnly = true;
            this.dgvListOfParishioners.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvListOfParishioners.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListOfParishioners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListOfParishioners.Size = new System.Drawing.Size(399, 663);
            this.dgvListOfParishioners.TabIndex = 1;
            this.dgvListOfParishioners.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListOfParishioners_CellContentDoubleClick);
            // 
            // gbAddNewRecord
            // 
            this.gbAddNewRecord.Controls.Add(this.txtMinister);
            this.gbAddNewRecord.Controls.Add(this.btnClear);
            this.gbAddNewRecord.Controls.Add(this.btnSave);
            this.gbAddNewRecord.Controls.Add(this.label6);
            this.gbAddNewRecord.Controls.Add(this.label5);
            this.gbAddNewRecord.Controls.Add(this.label4);
            this.gbAddNewRecord.Controls.Add(this.dtpDate);
            this.gbAddNewRecord.Controls.Add(this.rdNewParishioner);
            this.gbAddNewRecord.Controls.Add(this.rdExistingParishioner);
            this.gbAddNewRecord.Controls.Add(this.txtVenue);
            this.gbAddNewRecord.Controls.Add(this.txtSponsor);
            this.gbAddNewRecord.Controls.Add(this.txtName);
            this.gbAddNewRecord.Controls.Add(this.label3);
            this.gbAddNewRecord.Controls.Add(this.label1);
            this.gbAddNewRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddNewRecord.ForeColor = System.Drawing.Color.White;
            this.gbAddNewRecord.Location = new System.Drawing.Point(18, 8);
            this.gbAddNewRecord.Name = "gbAddNewRecord";
            this.gbAddNewRecord.Size = new System.Drawing.Size(349, 323);
            this.gbAddNewRecord.TabIndex = 0;
            this.gbAddNewRecord.TabStop = false;
            this.gbAddNewRecord.Text = "Add New Record";
            this.gbAddNewRecord.Visible = false;
            this.gbAddNewRecord.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtMinister
            // 
            this.txtMinister.Location = new System.Drawing.Point(94, 238);
            this.txtMinister.Name = "txtMinister";
            this.txtMinister.Size = new System.Drawing.Size(237, 22);
            this.txtMinister.TabIndex = 13;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(187, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 29);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(13, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save Record";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Minister";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sponsor";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(94, 199);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(237, 22);
            this.dtpDate.TabIndex = 9;
            // 
            // rdNewParishioner
            // 
            this.rdNewParishioner.AutoSize = true;
            this.rdNewParishioner.Location = new System.Drawing.Point(207, 31);
            this.rdNewParishioner.Name = "rdNewParishioner";
            this.rdNewParishioner.Size = new System.Drawing.Size(124, 20);
            this.rdNewParishioner.TabIndex = 7;
            this.rdNewParishioner.TabStop = true;
            this.rdNewParishioner.Text = "New Parishioner";
            this.rdNewParishioner.UseVisualStyleBackColor = true;
            this.rdNewParishioner.CheckedChanged += new System.EventHandler(this.rdNewParishioner_CheckedChanged);
            // 
            // rdExistingParishioner
            // 
            this.rdExistingParishioner.AutoSize = true;
            this.rdExistingParishioner.Location = new System.Drawing.Point(40, 32);
            this.rdExistingParishioner.Name = "rdExistingParishioner";
            this.rdExistingParishioner.Size = new System.Drawing.Size(143, 20);
            this.rdExistingParishioner.TabIndex = 6;
            this.rdExistingParishioner.TabStop = true;
            this.rdExistingParishioner.Text = "Existing Parishioner";
            this.rdExistingParishioner.UseVisualStyleBackColor = true;
            this.rdExistingParishioner.CheckedChanged += new System.EventHandler(this.rdExistingParishioner_CheckedChanged);
            // 
            // txtVenue
            // 
            this.txtVenue.Location = new System.Drawing.Point(94, 114);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.Size = new System.Drawing.Size(237, 22);
            this.txtVenue.TabIndex = 5;
            // 
            // txtSponsor
            // 
            this.txtSponsor.Location = new System.Drawing.Point(94, 155);
            this.txtSponsor.Name = "txtSponsor";
            this.txtSponsor.Size = new System.Drawing.Size(237, 22);
            this.txtSponsor.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(94, 71);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 22);
            this.txtName.TabIndex = 3;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Venue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.DarkGreen;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.dgvConfirmationRegister);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 737);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Existing Cofirmation Record";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.txtRowNo);
            this.panel1.Controls.Add(this.txtRowCount);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Location = new System.Drawing.Point(166, 693);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 41);
            this.panel1.TabIndex = 17;
            // 
            // txtRowNo
            // 
            this.txtRowNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtRowNo.Location = new System.Drawing.Point(93, 9);
            this.txtRowNo.Name = "txtRowNo";
            this.txtRowNo.Size = new System.Drawing.Size(35, 26);
            this.txtRowNo.TabIndex = 6;
            this.txtRowNo.TextChanged += new System.EventHandler(this.txtRowNo_TextChanged);
            this.txtRowNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRowNo_KeyPress);
            // 
            // txtRowCount
            // 
            this.txtRowCount.Enabled = false;
            this.txtRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtRowCount.Location = new System.Drawing.Point(149, 8);
            this.txtRowCount.Name = "txtRowCount";
            this.txtRowCount.Size = new System.Drawing.Size(35, 26);
            this.txtRowCount.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(132, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "/";
            // 
            // btnLast
            // 
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(233, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(35, 30);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(195, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 30);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(49, 6);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(35, 30);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(10, 6);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(35, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new System.Drawing.Point(502, 22);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(56, 39);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Location = new System.Drawing.Point(441, 22);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(58, 39);
            this.btnPrint.TabIndex = 11;
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
            this.groupBox3.Location = new System.Drawing.Point(6, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 46);
            this.groupBox3.TabIndex = 11;
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
            this.cmbSearchBy.Location = new System.Drawing.Point(87, 16);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(95, 21);
            this.cmbSearchBy.TabIndex = 9;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(183, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(239, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvConfirmationRegister
            // 
            this.dgvConfirmationRegister.AllowUserToAddRows = false;
            this.dgvConfirmationRegister.AllowUserToDeleteRows = false;
            this.dgvConfirmationRegister.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvConfirmationRegister.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConfirmationRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConfirmationRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConfirmationRegister.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvConfirmationRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConfirmationRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConfirmationRegister.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvConfirmationRegister.Location = new System.Drawing.Point(6, 68);
            this.dgvConfirmationRegister.Name = "dgvConfirmationRegister";
            this.dgvConfirmationRegister.ReadOnly = true;
            this.dgvConfirmationRegister.RowHeadersVisible = false;
            this.dgvConfirmationRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConfirmationRegister.ShowEditingIcon = false;
            this.dgvConfirmationRegister.Size = new System.Drawing.Size(553, 624);
            this.dgvConfirmationRegister.TabIndex = 10;
            this.dgvConfirmationRegister.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConfirmationRegister_CellContentClick);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1149, 713);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(141, 30);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEditRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRecord.ForeColor = System.Drawing.Color.White;
            this.btnEditRecord.Location = new System.Drawing.Point(773, 713);
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Size = new System.Drawing.Size(150, 30);
            this.btnEditRecord.TabIndex = 11;
            this.btnEditRecord.Text = "&Edit Record";
            this.btnEditRecord.UseVisualStyleBackColor = true;
            this.btnEditRecord.Click += new System.EventHandler(this.btnEditRecord_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(964, 713);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 30);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "&Delete Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmConfirmationRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditRecord);
            this.Controls.Add(this.btnAddNewRecord);
            this.Controls.Add(this.panelAddNewParishioner);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfirmationRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation Record";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConfirmationRecord_Load);
            this.panelAddNewParishioner.ResumeLayout(false);
            this.gbEditRecord.ResumeLayout(false);
            this.gbEditRecord.PerformLayout();
            this.gbListOfParishioners.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfParishioners)).EndInit();
            this.gbAddNewRecord.ResumeLayout(false);
            this.gbAddNewRecord.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirmationRegister)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewRecord;
        private System.Windows.Forms.Panel panelAddNewParishioner;
        private System.Windows.Forms.GroupBox gbListOfParishioners;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbAddNewRecord;
        private System.Windows.Forms.TextBox txtMinister;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvListOfParishioners;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvConfirmationRegister;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox gbEditRecord;
        private System.Windows.Forms.TextBox txtMinisterUpdate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDateUpdate;
        private System.Windows.Forms.TextBox txtVenueUpdate;
        private System.Windows.Forms.TextBox txtSponsorUpdate;
        private System.Windows.Forms.TextBox txtNameUpdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnEditRecord;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRowNo;
        private System.Windows.Forms.TextBox txtRowCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
    }
}