using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Church_Management_Portal
{
    public partial class frmViewSocieties : Form
    {

        SQLConfig Sql = new SQLConfig();
        public string user_status = "";
        string society_id = "";


        public frmViewSocieties()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + txtName.Text,"Delete Society",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                Sql.Execute_Query("DELETE FROM `societies` WHERE `society_id`='"+ society_id +"';");
                if (!Sql.result) { return; }
                MessageBox.Show("Record successfully deleted","View Society Records");
                refresh();

            }
        }

        private void frmViewSocieties_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDelete.Hide(); groupBox2.Hide();
            }
            refresh();
        }


        private void refresh() {
            Sql.fiil_listBox("SELECT                                                               "+
                              "      so.`society_id`,                                               "+
                              "      so.`name` AS 'Name',                                           "+
                              "      st.`name` AS 'Station',                                        "+
                              "      o.`short_name` AS 'Organisation'                               "+
                              "  FROM                                                               "+
                              "      `societies` so                                                 "+
                              "          JOIN                                                       "+
                              "      `organisation` o ON so.`organisation_id` = o.`organisation_id` "+
                              "          JOIN                                                       "+
                              "      `stations` st ON so.`station_id` = st.`station_id`; ",listSocieties,"society");
            if (!Sql.result) { return; }
        }

        private void listSocieties_SelectedIndexChanged(object sender, EventArgs e)
        {
            society_id = listSocieties.SelectedValue.ToString();
            txtName.Text = Sql.ds.Tables["society"].Rows[listSocieties.SelectedIndex].ItemArray[1].ToString();
            txtStation.Text = Sql.ds.Tables["society"].Rows[listSocieties.SelectedIndex].ItemArray[2].ToString();
            txtOrganisation.Text = Sql.ds.Tables["society"].Rows[listSocieties.SelectedIndex].ItemArray[3].ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                MessageBox.Show("Enter name of society to proceed", "View Society Records"); txtName.Focus(); return;
            }
            List<string> param = new List<string>();
            param.Add(txtName.Text.Trim());
            param.Add(society_id);

            Sql.UpdateQuery("UPDATE `societies` SET `name`=@1 WHERE `society_id`=@2;", param);
            if (!Sql.result) { return; }
            MessageBox.Show("Record successfully update", "View Society Records");
            refresh();
        }
    }
}
