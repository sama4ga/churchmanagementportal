using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Church_Management_Portal
{
    public partial class frmChangePassword : Form
    {
        SQLConfig sql = new SQLConfig();
        public int user_id;

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnConfirmPassword_Click(object sender, EventArgs e)
        {
            int no_record = sql.maxrow("SELECT * FROM `users` WHERE `password`=sha1('" + txtOldPassword.Text + "');");
            if (no_record == 1)
            {
                gbNewPassword.Show();
                txtOldPassword.Enabled = false;
            }
            else
            {
                MessageBox.Show("Incorrect password entered", "Change Password");
                gbNewPassword.Hide();
            }
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Equals(txtConfirmNewPassword.Text))
            {
                sql.Execute_Query("UPDATE `users` SET `password`=sha1('" + txtNewPassword.Text + "') WHERE `user_id`='" + user_id + "';");
                if (!sql.result) { return; }
                MessageBox.Show("Success", "Change Password");
                Close();
            }
            else
            {
                MessageBox.Show("Password mismatch", "Change Password");
            }
        }
    }
}
