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
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                MessageBox.Show("Enter society name to proceed", "Add Society");txtName.Focus(); return;
            }
            List<string> param = new List<string>();
            param.Add(txtName.Text.Trim());
            param.Add(cmbOrg.SelectedValue.ToString());
            param.Add(cmbStation.SelectedValue.ToString());

            long insertId = 0;
            Sql.InsertQuery("INSERT INTO `societies`(`name`,`organisation_id`,`station_id`) VALUES(@1,@2,@3);", param, out insertId);
            if (!Sql.result) { return; }

            MessageBox.Show("Society successfully added", "Add Society");
            txtName.Clear();
            cmbOrg.SelectedIndex = 0;
            cmbStation.SelectedIndex = 0;
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

        private void cmbStation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
