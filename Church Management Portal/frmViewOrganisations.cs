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
    public partial class frmViewOrganisations : Form
    {

        SQLConfig Sql = new SQLConfig();
        string organisation_id = "";


        public frmViewOrganisations()
        {
            InitializeComponent();
        }

        private void frmViewOrganisations_Load(object sender, EventArgs e)
        {
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
            if (MessageBox.Show("Are you sure you want to delete " + listOrganisations.SelectedItem.ToString(), "Delete Organisation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Sql.Execute_Query("DELETE FROM `organisation` WHERE `organisation_id`='" + organisation_id + "';");
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
            Sql.Execute_Query("UPDATE `organisation` SET `short_name`='"+ txtShortName.Text + "',`long_name`='" + txtLongname.Text + "' WHERE `organisation_id`='" + organisation_id + "';");
            MessageBox.Show("Record successfully updated", "View Organisations");
            refresh();
        }
    }
}
