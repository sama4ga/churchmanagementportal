using System;
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
            if (MessageBox.Show("Are you sure you want to delete " + listSocieties.SelectedItem.ToString(),"Delete Society",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                Sql.Execute_Query("SELECT * FROM `societies` WHERE `society_id`='"+ society_id +"';");
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
            Sql.Execute_Query("UPDATE `societies` SET `name`='"+ txtName.Text +"' WHERE `society_id`='" + society_id + "';");
            if (!Sql.result) { return; }
            MessageBox.Show("Record successfully update", "View Society Records");
            refresh();
        }
    }
}
