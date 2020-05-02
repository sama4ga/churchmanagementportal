namespace Church_Management_Portal
{
    partial class frmViewRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewRecords));
            this.btnOtherGroups = new System.Windows.Forms.Button();
            this.btnOrganisation = new System.Windows.Forms.Button();
            this.btnStation = new System.Windows.Forms.Button();
            this.btnPiousSociety = new System.Windows.Forms.Button();
            this.btnSociety = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOtherGroups
            // 
            this.btnOtherGroups.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOtherGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOtherGroups.ForeColor = System.Drawing.Color.White;
            this.btnOtherGroups.Location = new System.Drawing.Point(417, 195);
            this.btnOtherGroups.Name = "btnOtherGroups";
            this.btnOtherGroups.Size = new System.Drawing.Size(174, 100);
            this.btnOtherGroups.TabIndex = 9;
            this.btnOtherGroups.Text = "Other Groups";
            this.btnOtherGroups.UseVisualStyleBackColor = false;
            this.btnOtherGroups.Click += new System.EventHandler(this.btnOtherGroups_Click);
            // 
            // btnOrganisation
            // 
            this.btnOrganisation.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOrganisation.ForeColor = System.Drawing.Color.White;
            this.btnOrganisation.Location = new System.Drawing.Point(187, 195);
            this.btnOrganisation.Name = "btnOrganisation";
            this.btnOrganisation.Size = new System.Drawing.Size(174, 100);
            this.btnOrganisation.TabIndex = 8;
            this.btnOrganisation.Text = "Organisation";
            this.btnOrganisation.UseVisualStyleBackColor = false;
            this.btnOrganisation.Click += new System.EventHandler(this.btnOrganisation_Click);
            // 
            // btnStation
            // 
            this.btnStation.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStation.ForeColor = System.Drawing.Color.White;
            this.btnStation.Location = new System.Drawing.Point(531, 41);
            this.btnStation.Name = "btnStation";
            this.btnStation.Size = new System.Drawing.Size(174, 100);
            this.btnStation.TabIndex = 7;
            this.btnStation.Text = "Station";
            this.btnStation.UseVisualStyleBackColor = false;
            this.btnStation.Click += new System.EventHandler(this.btnStation_Click);
            // 
            // btnPiousSociety
            // 
            this.btnPiousSociety.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPiousSociety.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPiousSociety.ForeColor = System.Drawing.Color.White;
            this.btnPiousSociety.Location = new System.Drawing.Point(287, 41);
            this.btnPiousSociety.Name = "btnPiousSociety";
            this.btnPiousSociety.Size = new System.Drawing.Size(174, 100);
            this.btnPiousSociety.TabIndex = 6;
            this.btnPiousSociety.Text = "Pious Society";
            this.btnPiousSociety.UseVisualStyleBackColor = false;
            this.btnPiousSociety.Click += new System.EventHandler(this.btnPiousSociety_Click);
            // 
            // btnSociety
            // 
            this.btnSociety.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSociety.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSociety.ForeColor = System.Drawing.Color.White;
            this.btnSociety.Location = new System.Drawing.Point(57, 41);
            this.btnSociety.Name = "btnSociety";
            this.btnSociety.Size = new System.Drawing.Size(174, 100);
            this.btnSociety.TabIndex = 5;
            this.btnSociety.Text = "Society";
            this.btnSociety.UseVisualStyleBackColor = false;
            this.btnSociety.Click += new System.EventHandler(this.btnSociety_Click);
            // 
            // frmViewRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(785, 335);
            this.Controls.Add(this.btnOtherGroups);
            this.Controls.Add(this.btnOrganisation);
            this.Controls.Add(this.btnStation);
            this.Controls.Add(this.btnPiousSociety);
            this.Controls.Add(this.btnSociety);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Records";
            this.Load += new System.EventHandler(this.frmViewRecords_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOtherGroups;
        private System.Windows.Forms.Button btnOrganisation;
        private System.Windows.Forms.Button btnStation;
        private System.Windows.Forms.Button btnPiousSociety;
        private System.Windows.Forms.Button btnSociety;
    }
}