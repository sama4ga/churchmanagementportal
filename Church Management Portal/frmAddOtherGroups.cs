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
            if (txtGroupName.Text.Contains(" "))
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

            codename.ToUpper();



            Sql.Execute_Query("INSERT INTO `other_groups`(`name`,`code_name`,`slogan`) VALUES('" + txtGroupName.Text + "','" + codename + "','" + txtSlogan.Text + "');");


            Sql.Execute_CUD("CREATE TABLE IF NOT EXISTS `" + codename + "`(`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY UNIQUE,`member_id` INT);",
                "Could not add new group", "New Group successfully added");

            refresh();
        }

        private void frmAddOtherGroups_Load(object sender, EventArgs e)
        {
            refresh();
        }


        private void refresh()
        {
            Sql.fiil_listBox("SELECT * FROM `other_groups`;", listGroups);
        }
    }
}
