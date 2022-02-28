using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Church_Management_Portal
{
    public partial class frmAddOrganisation : Form
    {

        SQLConfig Sql = new SQLConfig();
        usableFunction UF = new usableFunction();
        public string user_status = "";
        //int maxrow = 0;

        public frmAddOrganisation()
        {
            InitializeComponent();
        }

        private void frmAddOrganisation_Load(object sender, EventArgs e)
        {
            //maxrow = Sql.maxrow("SELECT `long_name` as 'Full Name', `short_name` as 'Short Name' FROM `organisation`");
            //if (maxrow > 0)
            //{
            //    listOrganisations.DataSource = Sql.dt;
            //    maxrow = 0;
            //}
            if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnAdd.Hide();
            }

            listOrganisations.DataSource = null;
            Sql.fiil_listBox("SELECT * FROM `organisation`;", listOrganisations);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLongname.Text.Trim()) && string.IsNullOrWhiteSpace(txtShortName.Text.Trim()))
            {
                List<string> param = new List<string>();
                long insertId = 0;
                param.Add(txtShortName.Text.Trim());
                param.Add(txtLongname.Text.Trim());
                Sql.InsertQuery("INSERT INTO `organisations`(`short_name`,`long_name`) VALUES(@1,@2);", param, out insertId);
            }
            else
            {
                MessageBox.Show("Full name and short are required fields","Error - Unsupplied Data");
            }
            

            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
