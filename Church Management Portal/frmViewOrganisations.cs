using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Church_Management_Portal
{
    public partial class frmViewOrganisations : Form
    {

        SQLConfig Sql = new SQLConfig();
        string organisation_id = "";
        public string user_status = "";


        public frmViewOrganisations()
        {
            InitializeComponent();
        }

        private void frmViewOrganisations_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDelete.Hide(); groupBox2.Hide();
            }
            refresh();
        }

        private void listOrganisations_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtShortName.Text = Sql.ds.Tables["organisation"].Rows[listOrganisations.SelectedIndex].ItemArray[1].ToString();
            txtLongname.Text = Sql.ds.Tables["organisation"].Rows[listOrganisations.SelectedIndex].ItemArray[2].ToString();
            organisation_id = listOrganisations.SelectedValue.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + Sql.ds.Tables["organisation"].Rows[listOrganisations.SelectedIndex].ItemArray[1].ToString(), "Delete Organisation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Sql.Execute_Query("DELETE FROM `organisation` WHERE `organisation_id`='" + organisation_id + "';");
                if (!Sql.result) { return; }
                MessageBox.Show("Record successfully deleted", "View Organisations");
                refresh();
            }
        }

        private void refresh()
        {
            Sql.fiil_listBox("SELECT * FROM `organisation`", listOrganisations,"organisation");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLongname.Text.Trim()))
            {
                MessageBox.Show("Enter full name of Organisation to proceed", "View Organisations");txtLongname.Focus(); return;
            }else if (string.IsNullOrWhiteSpace(txtShortName.Text.Trim()))
            {
                MessageBox.Show("Enter Organisation short name to proceed", "View Organisations"); txtShortName.Focus(); return;
            }
            List<string> param = new List<string>();
            param.Add(txtShortName.Text.Trim());
            param.Add(txtLongname.Text.Trim());
            param.Add(organisation_id);

            Sql.UpdateQuery("UPDATE `organisation` SET `short_name`=@1,`long_name`=@2 WHERE `organisation_id`=@3;", param);
            if (!Sql.result) { return; }
            MessageBox.Show("Record successfully updated", "View Organisations");
            refresh();
        }
    }
}
