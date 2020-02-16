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
    public partial class frmAddOrganisation : Form
    {

        SQLConfig Sql = new SQLConfig();
        usableFunction UF = new usableFunction();
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
            listOrganisations.DataSource = null;
            Sql.fiil_listBox("SELECT * FROM `organisation`;", listOrganisations);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLongname.Text.Trim() != "" && txtShortName.Text.Trim() != "")
            {
                Sql.Execute_CUD("INSERT INTO `organisations`(`short_name`,`long_name`) VALUES('" + txtShortName.Text + "','" + txtLongname.Text + "');",
                "Could not add new organisation","New Organisation successfully added");
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
