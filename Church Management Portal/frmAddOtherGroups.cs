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
    public partial class frmAddOtherGroups : Form
    {

        usableFunction UF = new usableFunction();
        public string user_status = "";
        SQLConfig Sql = new SQLConfig();


        public frmAddOtherGroups()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // group code name
            string codename = "";
            if (!string.IsNullOrWhiteSpace(txtGroupName.Text.Trim()))
            {
                if (txtGroupName.Text.Trim().Contains(" "))
                {
                    string[] split = txtGroupName.Text.Split(' ');
                
                    foreach (string item in split)
                    {
                        codename += item.Substring(0, 1);
                    }
                }
                else
                {
                    codename = txtGroupName.Text;
                }

            }
            else
            {
                MessageBox.Show("Group name is a required field", "Error - unsupplied data");
                txtGroupName.Focus();
                    return;
            }

            codename.ToUpper();


            List<string> param = new List<string>();
            long insertId = 0;
            param.Add(txtGroupName.Text.Trim());
            param.Add(codename);
            param.Add(txtSlogan.Text.Trim());
            Sql.InsertQuery("INSERT INTO `other_groups`(`name`,`code_name`,`slogan`) VALUES(@1,@2,@3);",param, out insertId);
            if (!Sql.result) { return; }

            Sql.Execute_CUD("CREATE TABLE IF NOT EXISTS `" + codename + "`(`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY UNIQUE,`member_id` INT);",
                "Could not add new group", "New Group successfully added");

            refresh();
        }

        private void frmAddOtherGroups_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnAdd.Hide();
            }
            refresh();
        }


        private void refresh()
        {
            Sql.fiil_listBox("SELECT * FROM `other_groups`;", listGroups);
        }
    }
}
