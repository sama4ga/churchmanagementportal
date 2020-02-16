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
    public partial class frmAddSociety : Form
    {
        usableFunction UF = new usableFunction();
        SQLConfig Sql = new SQLConfig();

        public frmAddSociety()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sql.Execute_CUD("INSERT INTO `societies`(`name`,`organisation_id`,`station_id`) VALUES('"+ txtName.Text +"','" + cmbOrg.SelectedValue.ToString() +"','" + cmbStation.SelectedValue.ToString() +"');", "Could not add new society","Society successfully added");
        }

        private void frmAddSociety_Load(object sender, EventArgs e)
        {
            Sql.fiil_CBO("SELECT * FROM `stations`", cmbStation);
            Sql.fiil_CBO("SELECT * FROM `organisation`", cmbOrg);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
