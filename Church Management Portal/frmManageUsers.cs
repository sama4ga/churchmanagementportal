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
    public partial class frmManageUsers : Form
    {
        SQLConfig sql = new SQLConfig();


        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Clear();
            gbUpdatePassword.Show();
            txtOldPassword.Enabled = true;
            txtOldPassword.Clear();
            gbNewPassword.Hide();
        }


        private void Clear()
        {
            gbUpdatePassword.Hide();
            gbUpdatePriviledge.Hide();
            gbUpdateUsername.Hide();
        }

        private string user_id;
        private void dgvUsersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            user_id = dgvUsersList.CurrentRow.Cells[0].Value.ToString();
            txtUsername.Text = dgvUsersList.CurrentRow.Cells["Username"].Value.ToString();
            cmbPriviledge.SelectedItem = dgvUsersList.CurrentRow.Cells["Priviledge"].Value;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete user "+ dgvUsersList.CurrentRow.Cells["Username"].Value.ToString(),"Delete User",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql.Execute_Query("DELETE FROM `users` WHERE `user_id`='"+ user_id +"';");
                if (!sql.result) { return; }
                MessageBox.Show("Success", "Delete User");
                refresh();
            }
        }

        private void btnChangeUserPriviledge_Click(object sender, EventArgs e)
        {
            Clear();
            gbUpdatePriviledge.Show();
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            Clear();
            gbUpdateUsername.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdateUsername_Click(object sender, EventArgs e)
        {
            sql.Execute_Query("UPDATE `users` SET `username`='" + txtUsername.Text + "' WHERE `user_id`='" + user_id + "';");
            if (!sql.result) { return; }
            MessageBox.Show("Success","Change Username");
            refresh();
        }

        private void btnUpdatePriviledge_Click(object sender, EventArgs e)
        {
            sql.Execute_Query("UPDATE `users` SET `priviledge`='" + cmbPriviledge.SelectedItem.ToString() + "' WHERE `user_id`='" + user_id + "';");
            if (!sql.result) { return; }
            MessageBox.Show("Success", "Change Priviledge");
            refresh();
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
                MessageBox.Show("Incorrect password entered for user "+ dgvUsersList.CurrentRow.Cells["Username"].Value.ToString(),"Change Password");
                gbNewPassword.Hide();
            }
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            sql.Load_DTG("SELECT `user_id`,`username` AS 'Username',`priviledge` AS 'Priviledge' FROM `users`", dgvUsersList);
            if (!sql.result) { return; }
            //dgvUsersList.Rows[0].Visible = false;
            dgvUsersList.Columns[0].Visible = false;
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Equals(txtConfirmNewPassword.Text))
            {
                sql.Execute_Query("UPDATE `users` SET `password`=sha1('" + txtNewPassword.Text + "') WHERE `user_id`='" + user_id + "';");
                if (!sql.result) { return; }
                MessageBox.Show("Success", "Change Password");
                refresh();
            }
            else
            {
                MessageBox.Show("Password mismatch", "Change Password");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
