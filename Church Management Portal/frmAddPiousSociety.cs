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
    public partial class frmAddPiousSociety : Form
    {

        usableFunction UF = new usableFunction();
        SQLConfig Sql = new SQLConfig();


        public frmAddPiousSociety()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSocietyName.Text.Trim()))
            {
                MessageBox.Show("Enter name of pious society to proceed", "Add Pious Society");txtSocietyName.Focus();return;
            }
            // society code name
            string[] split = txtSocietyName.Text.Split(' ');
            string codename = "";
            foreach (string item in split)
            {
                codename += item.Substring(0, 1);
            }

            codename.ToUpper();

            List<string> param = new List<string>();
            param.Add(txtSocietyName.Text.Trim());
            param.Add(codename);
            param.Add(txtSlogan.Text.Trim());

            long insertId = 0;
            Sql.InsertQuery("INSERT INTO `pious_societies`(`name`,`code_name`,`slogan`) VALUES(@1,@2,@3);", param, out insertId);
            if (!Sql.result) { return; }

            Sql.Execute_CUD("CREATE TABLE IF NOT EXISTS `"+ codename +"`(`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY UNIQUE,`member_id` INT);",
                "Could not add new Pious Society", "New Pious Society successfully added");
            refresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddPiousSociety_Load(object sender, EventArgs e)
        {
            refresh();
        }


        private void refresh() {
            Sql.fiil_listBox("SELECT * FROM `pious_societies`;", listSocieties);
        }

    }
}
