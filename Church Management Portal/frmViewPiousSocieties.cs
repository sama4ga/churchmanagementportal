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
    public partial class frmViewPiousSocieties : Form
    {

        SQLConfig Sql = new SQLConfig();
        string society_id ="";
        string old_code_name = "";

        public frmViewPiousSocieties()
        {
            InitializeComponent();
        }

        private void frmViewPiousSocieties_Load(object sender, EventArgs e)
        {
            refresh();
        }


        private void listPiousSocieties_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = Sql.ds.Tables["pious_society"].Rows[listPiousSocieties.SelectedIndex].ItemArray[1].ToString();
            txtSlogan.Text = Sql.ds.Tables["pious_society"].Rows[listPiousSocieties.SelectedIndex].ItemArray[3].ToString();
            old_code_name = Sql.ds.Tables["pious_society"].Rows[listPiousSocieties.SelectedIndex].ItemArray[2].ToString();
            society_id = listPiousSocieties.SelectedValue.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + listPiousSocieties.SelectedItem.ToString(), "Delete Pious Society", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Sql.Execute_Query("DELETE FROM `pious_societies` WHERE `pious_society_id`='" + society_id + "';");
                Sql.Execute_Query("DROP TABLE `" + old_code_name + "`;");
                MessageBox.Show("Record successfully deleted", "VIew Pious Society Record");
                refresh();
            }
        }

        private void refresh()
        {
            Sql.fiil_listBox("SELECT * FROM `pious_societies`;", listPiousSocieties,"pious_society");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Sql.Execute_Query("UPDATE `pious_societies` SET `name`='"+ txtName.Text + "',`slogan`='" + txtSlogan.Text + "' WHERE `pious_society_id`='" + society_id + "';");
            MessageBox.Show("Record successfully updated", "VIew Pious Society Record");
            refresh();
        }
    }
}
