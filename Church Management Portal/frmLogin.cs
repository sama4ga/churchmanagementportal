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
    public partial class frmLogin : Form        
    {

        SQLConfig Sql = new SQLConfig();
        usableFunction UF = new usableFunction();

        public frmLogin()
        {
            InitializeComponent();
        }

        int maxrow = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals("sama4ga") & txtPassword.Text.Equals("sama4ga5782"))
            {
                frmChurchDetails frm = new frmChurchDetails();
                frm.ShowDialog();
                Hide();
            }
            else
            {
                maxrow = Sql.maxrow("SELECT IFNULL(`parishioner_id`,0) `parishioner_id`,`priviledge` FROM `users` WHERE `username`='" + txtUsername.Text + "' AND password=sha1('" + txtPassword.Text + "');", "users");
                if (maxrow == 1)
                {
                    int parishioner_id = 0;
                    parishioner_id = int.Parse((Sql.ds.Tables["users"].Rows[0].ItemArray[0].ToString()));
                    string priviledge = (Sql.ds.Tables["users"].Rows[0].ItemArray[1].ToString());

                    Form1 frm = new Form1();
                    frm.user_id = parishioner_id;
                    frm.user_status = priviledge;
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid login credentials entered", "Login Error");
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
