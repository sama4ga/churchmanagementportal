﻿using System;
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
        public string user_status = "";
        string society_id ="";
        string old_code_name = "";

        public frmViewPiousSocieties()
        {
            InitializeComponent();
        }

        private void frmViewPiousSocieties_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDelete.Hide(); groupBox2.Hide();
            }
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
            if (MessageBox.Show("Are you sure you want to delete " + Sql.ds.Tables["pious_society"].Rows[listPiousSocieties.SelectedIndex].ItemArray[1].ToString(), "Delete Pious Society", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Sql.Execute_Query("DELETE FROM `pious_societies` WHERE `pious_society_id`='" + society_id + "';");
                if (!Sql.result) { return; }
                Sql.Execute_Query("DROP TABLE `" + old_code_name + "`;");
                if (!Sql.result) { return; }
                MessageBox.Show("Record successfully deleted", "View Pious Society Record");
                refresh();
            }
        }

        private void refresh()
        {
            Sql.fiil_listBox("SELECT * FROM `pious_societies`;", listPiousSocieties,"pious_society");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                MessageBox.Show("Enter name of society to proceed", "View Society Records"); txtName.Focus(); return;
            }
            List<string> param = new List<string>();
            param.Add(txtName.Text.Trim());
            param.Add(txtSlogan.Text.Trim());
            param.Add(society_id);

            Sql.UpdateQuery("UPDATE `pious_societies` SET `name`=@1,`slogan`=@2 WHERE `pious_society_id`=@3;", param);
            if (!Sql.result) { return; }
            MessageBox.Show("Record successfully updated", "VIew Pious Society Record");
            refresh();
        }
    }
}
