namespace Church_Management_Portal
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnChangeBackgroundPic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangeBackgroundPic
            // 
            this.btnChangeBackgroundPic.Location = new System.Drawing.Point(12, 25);
            this.btnChangeBackgroundPic.Name = "btnChangeBackgroundPic";
            this.btnChangeBackgroundPic.Size = new System.Drawing.Size(135, 79);
            this.btnChangeBackgroundPic.TabIndex = 0;
            this.btnChangeBackgroundPic.Text = "Change Backgroung Picture";
            this.btnChangeBackgroundPic.UseVisualStyleBackColor = true;
            this.btnChangeBackgroundPic.Click += new System.EventHandler(this.btnChangeBackgroundPic_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 353);
            this.Controls.Add(this.btnChangeBackgroundPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChangeBackgroundPic;
    }
}