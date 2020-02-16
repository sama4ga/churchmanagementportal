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
    public partial class frmAddNewUser : Form
    {
        SQLConfig Sql = new SQLConfig();
        int parishioner_id = 0;

        public frmAddNewUser()
        {
            InitializeComponent();
        }

        private void rdParishioner_CheckedChanged(object sender, EventArgs e)
        {
            if (rdParishioner.Checked == true)
            {
                this.Width = 800;
                Sql.Load_DTG("select p.`parishioner_id`,p.`name` as 'Name',st.`name` as 'Station' from `parishioners` p left join `stations` st on p.`station`=st.`station_id` WHERE p.`status`<>'dead';", dgvParishionerList);
                dgvParishionerList.Columns[0].Visible = false;
            }
            else
            {
                this.Width = 448;
            }
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            this.Width = 448;
            cmbPriviledge.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(txtCPassword.Text) == false)
            {
                MessageBox.Show("Password mismatch","Error");
                txtCPassword.Clear();
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Username required", "Error");
                txtUsername.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password required", "Error");
                txtPassword.Focus();
            }
            else
            {
                Sql.Execute_Insert("INSERT INTO `users`(`username`,`password`,`parishioner_id`,`priviledge`) VALUES('"+ txtUsername.Text + "','" + txtPassword.Text + "','" + parishioner_id + "','" + cmbPriviledge.SelectedItem.ToString() + "');");
                MessageBox.Show("Success", "Add New User");
            }
        }

        private void dgvParishionerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            parishioner_id = int.Parse(dgvParishionerList.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
