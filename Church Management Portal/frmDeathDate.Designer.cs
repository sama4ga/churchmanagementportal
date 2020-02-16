namespace Church_Management_Portal
{
    partial class frmDeathDate
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBurialDate = new System.Windows.Forms.DateTimePicker();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.chkNotYetBuried = new System.Windows.Forms.CheckBox();
            this.dtpDeathDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Burial Date:";
            this.label1.Visible = false;
            // 
            // dtpBurialDate
            // 
            this.dtpBurialDate.Location = new System.Drawing.Point(132, 106);
            this.dtpBurialDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBurialDate.Name = "dtpBurialDate";
            this.dtpBurialDate.Size = new System.Drawing.Size(298, 22);
            this.dtpBurialDate.TabIndex = 1;
            this.dtpBurialDate.Visible = false;
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.ForestGreen;
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Location = new System.Drawing.Point(132, 164);
            this.OK.Margin = new System.Windows.Forms.Padding(4);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(112, 31);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.ForestGreen;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.Location = new System.Drawing.Point(324, 164);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(112, 31);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // chkNotYetBuried
            // 
            this.chkNotYetBuried.AutoSize = true;
            this.chkNotYetBuried.Checked = true;
            this.chkNotYetBuried.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotYetBuried.Location = new System.Drawing.Point(138, 78);
            this.chkNotYetBuried.Margin = new System.Windows.Forms.Padding(4);
            this.chkNotYetBuried.Name = "chkNotYetBuried";
            this.chkNotYetBuried.Size = new System.Drawing.Size(124, 20);
            this.chkNotYetBuried.TabIndex = 4;
            this.chkNotYetBuried.Text = "Not yet buried";
            this.chkNotYetBuried.UseVisualStyleBackColor = true;
            this.chkNotYetBuried.CheckedChanged += new System.EventHandler(this.chkNotYetBuried_CheckedChanged);
            // 
            // dtpDeathDate
            // 
            this.dtpDeathDate.Location = new System.Drawing.Point(132, 36);
            this.dtpDeathDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDeathDate.Name = "dtpDeathDate";
            this.dtpDeathDate.Size = new System.Drawing.Size(298, 22);
            this.dtpDeathDate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Death Date:";
            // 
            // frmDeathDate
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(504, 208);
            this.Controls.Add(this.dtpDeathDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkNotYetBuried);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.dtpBurialDate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDeathDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Death Date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBurialDate;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.CheckBox chkNotYetBuried;
        private System.Windows.Forms.DateTimePicker dtpDeathDate;
        private System.Windows.Forms.Label label2;
    }
}