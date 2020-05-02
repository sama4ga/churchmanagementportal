using System;
using System.Windows.Forms;

namespace Church_Management_Portal
{
    public partial class frmViewOtherGroups : Form
    {

        SQLConfig Sql = new SQLConfig();
        public string user_status = "";
        string society_id = "";
        string code_name = "";


        public frmViewOtherGroups()
        {
            InitializeComponent();
        }

        private void frmViewOtherGroups_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDelete.Hide(); groupBox2.Hide();
            }
            refresh();
        }

        private void refresh()
        {
            Sql.fiil_listBox("SELECT * FROM `other_groups`;", listGroups,"other_groups");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + Sql.ds.Tables["other_groups"].Rows[listGroups.SelectedIndex].ItemArray[1].ToString() +
                "\n\n This will delete all records in the group", "Delete Other Groups", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Sql.Execute_Query("DELETE FROM `other_groups` WHERE `group_id`='" + society_id + "';");
                if (!Sql.result) { return; }
                Sql.Execute_Query("DROP TABLE `" + code_name + "`;");
                if (!Sql.result) { return; }
                MessageBox.Show("Record successfully deleted", "View Other Groups Record");
                refresh();
            }
        }

        private void listGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = Sql.ds.Tables["other_groups"].Rows[listGroups.SelectedIndex].ItemArray[1].ToString();
            code_name = Sql.ds.Tables["other_groups"].Rows[listGroups.SelectedIndex].ItemArray[2].ToString();
            txtSlogan.Text = Sql.ds.Tables["other_groups"].Rows[listGroups.SelectedIndex].ItemArray[3].ToString();
            society_id = listGroups.SelectedValue.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Sql.Execute_Query("UPDATE `other_groups` SET `name`='" + txtName.Text + "',`slogan`='" + txtSlogan.Text + "' WHERE `group_id`='" + society_id + "';");
            if (!Sql.result) { return; }
            MessageBox.Show("Record successfully updated", "VIew Other Groups Record");
            refresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
