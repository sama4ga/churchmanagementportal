namespace Church_Management_Portal
{
    partial class frmCreateNewRecord
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
            this.btnSociety = new System.Windows.Forms.Button();
            this.btnPiousSociety = new System.Windows.Forms.Button();
            this.btnStation = new System.Windows.Forms.Button();
            this.btnOrganisation = new System.Windows.Forms.Button();
            this.btnOtherGroups = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSociety
            // 
            this.btnSociety.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSociety.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSociety.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSociety.Location = new System.Drawing.Point(45, 48);
            this.btnSociety.Name = "btnSociety";
            this.btnSociety.Size = new System.Drawing.Size(174, 100);
            this.btnSociety.TabIndex = 0;
            this.btnSociety.Text = "Society";
            this.btnSociety.UseVisualStyleBackColor = false;
            this.btnSociety.Click += new System.EventHandler(this.btnSociety_Click);
            // 
            // btnPiousSociety
            // 
            this.btnPiousSociety.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPiousSociety.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPiousSociety.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPiousSociety.Location = new System.Drawing.Point(275, 48);
            this.btnPiousSociety.Name = "btnPiousSociety";
            this.btnPiousSociety.Size = new System.Drawing.Size(174, 100);
            this.btnPiousSociety.TabIndex = 1;
            this.btnPiousSociety.Text = "Pious Society";
            this.btnPiousSociety.UseVisualStyleBackColor = false;
            this.btnPiousSociety.Click += new System.EventHandler(this.btnPiousSociety_Click);
            // 
            // btnStation
            // 
            this.btnStation.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStation.Location = new System.Drawing.Point(519, 48);
            this.btnStation.Name = "btnStation";
            this.btnStation.Size = new System.Drawing.Size(174, 100);
            this.btnStation.TabIndex = 2;
            this.btnStation.Text = "Station";
            this.btnStation.UseVisualStyleBackColor = false;
            this.btnStation.Click += new System.EventHandler(this.btnStation_Click);
            // 
            // btnOrganisation
            // 
            this.btnOrganisation.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOrganisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrganisation.Location = new System.Drawing.Point(175, 202);
            this.btnOrganisation.Name = "btnOrganisation";
            this.btnOrganisation.Size = new System.Drawing.Size(174, 100);
            this.btnOrganisation.TabIndex = 3;
            this.btnOrganisation.Text = "Organisation";
            this.btnOrganisation.UseVisualStyleBackColor = false;
            this.btnOrganisation.Click += new System.EventHandler(this.btnOrganisation_Click);
            // 
            // btnOtherGroups
            // 
            this.btnOtherGroups.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOtherGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOtherGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtherGroups.Location = new System.Drawing.Point(405, 202);
            this.btnOtherGroups.Name = "btnOtherGroups";
            this.btnOtherGroups.Size = new System.Drawing.Size(174, 100);
            this.btnOtherGroups.TabIndex = 4;
            this.btnOtherGroups.Text = "Other Groups";
            this.btnOtherGroups.UseVisualStyleBackColor = false;
            this.btnOtherGroups.Click += new System.EventHandler(this.btnOtherGroups_Click);
            // 
            // frmCreateNewRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(756, 325);
            this.Controls.Add(this.btnOtherGroups);
            this.Controls.Add(this.btnOrganisation);
            this.Controls.Add(this.btnStation);
            this.Controls.Add(this.btnPiousSociety);
            this.Controls.Add(this.btnSociety);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCreateNewRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Record";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSociety;
        private System.Windows.Forms.Button btnPiousSociety;
        private System.Windows.Forms.Button btnStation;
        private System.Windows.Forms.Button btnOrganisation;
        private System.Windows.Forms.Button btnOtherGroups;
    }
}