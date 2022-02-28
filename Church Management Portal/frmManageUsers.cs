using System;
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
            //txtOldPassword.Enabled = true;
            //txtOldPassword.Clear();
            //gbNewPassword.Hide();
            txtOldPassword.Hide();
            label2.Hide();
            gbNewPassword.Show();
            btnConfirmPassword.Hide();
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
            // this does not allows trigger. I'm now using the cell_click event listener which always triggers
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.currentLoggedInUser != int.Parse(user_id)) {
                if (MessageBox.Show("Are you sure you want to delete user " + dgvUsersList.CurrentRow.Cells["Username"].Value.ToString(), "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql.Execute_Query("DELETE FROM `users` WHERE `user_id`='" + user_id + "';");
                    if (!sql.result) { return; }
                    MessageBox.Show("Success", "Delete User");
                    refresh();
                }
            }
            else
            {
                MessageBox.Show("You cannot delete the current logged in user. Logout and login as another admin to do this","Delete User");
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

        private void dgvUsersList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            user_id = dgvUsersList.CurrentRow.Cells[0].Value.ToString();
            txtUsername.Text = dgvUsersList.CurrentRow.Cells["Username"].Value.ToString();
            cmbPriviledge.SelectedItem = dgvUsersList.CurrentRow.Cells["Priviledge"].Value;
        }

        private void forceLogin()
        {
            // will be used to force the user to login again after password change
        }
    }
}
