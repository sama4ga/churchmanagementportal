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
    public partial class frmAddParishioner : Form
    {
        usableFunction UF = new usableFunction();
        SQLConfig Sql = new SQLConfig();
        string passport = "";
        //int maxrows = 0;

        public frmAddParishioner()
        {
            InitializeComponent();
        }



        private void btnLoadPassport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "Images|*.jpeg;*.jpg;*.png";
            ofd.Title = "Choose Passport";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picPassport.Image = Image.FromFile(ofd.FileName);
                passport = ofd.FileName;
            }
            
        }



        private void frmAddParishioner_Load(object sender, EventArgs e)
        {
            Sql.fiil_CBO("SELECT * FROM `stations`;",cmbStation,"station");
            Sql.fiil_CBO("SELECT `organisation_id`,`short_name` FROM `organisation`;", cmbOrganisation,"organisation");
            //Sql.fiil_listBox("SELECT `organisation_id`,`short_name` FROM `organisation`;", listOrganisation, "organisation");
            Sql.fiil_listBox("SELECT `code_name`,`name` FROM `pious_societies`;", listPiousSocieties,"pious");
            Sql.fiil_listBox("SELECT `code_name`,`name` FROM `other_groups`;", listOtherGroups,"groups");

        }



        private void cmbStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrganisation.SelectedIndex >= 0)
            {
                string organisation_id = cmbOrganisation.SelectedValue.ToString();
                string station_id = cmbStation.SelectedValue.ToString();
                //MessageBox.Show("org id:" + organisation_id + ", station id:" + station_id);
                Sql.fiil_CBO("SELECT * FROM `societies` WHERE `organisation_id`='" + organisation_id + "' AND `station_id`='" + station_id + "';", cmbSociety);
            }
        }



        private void cmdSociety_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        //private void listOrganisation_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbStation.SelectedIndex >= 0)
        //    {
        //        string organisation_id = listOrganisation.SelectedValue.ToString();
        //        string station_id = cmbStation.SelectedValue.ToString();
        //        //MessageBox.Show("org id:"+organisation_id +", station id:"+station_id);
        //        Sql.fiil_CBO("SELECT * FROM `societies` WHERE `organisation_id`='" + organisation_id + "' AND `station_id`='" + station_id + "';", cmbSociety);

        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtSurname.Text.Trim() + ", " + txtOthernames.Text.Trim();
            string address = txtAddress.Text.Trim();
            string dob = dtpDOB.Value.ToString("yyyy-MM-dd");
            string station_id = cmbStation.SelectedValue.ToString();
            string organisation_id = cmbOrganisation.SelectedValue.ToString();
            string phone_no = txtPhoneNo.Text.Trim();
            string society_id = cmbSociety.SelectedIndex >= 0 ? cmbSociety.SelectedValue.ToString() : "";
            string gender = "";
            if (rdFemale.Checked)
            {
                gender = "Female";
            }
            else if (rdMale.Checked)
            {
                gender = "Male";
            }
            

            Dictionary<string,string> pious_societies = new Dictionary<string, string>();
            foreach (DataRowView selected in listPiousSocieties.CheckedItems)
            {
                pious_societies.Add(selected.Row.ItemArray[0].ToString(), selected.Row.ItemArray[1].ToString());
            }

            string baptism = "false";
            string confirmation = "false";
            string communion = "false";
            string married = "false";
            foreach (string selected in listSacrament.CheckedItems)
            {
               // MessageBox.Show(selected);
                if (selected == "Baptised")
                {
                    baptism = "true";
                }
                else if (selected == "Confirmed")
                {
                    confirmation = "true";
                }
                else if (selected == "Communicant")
                {
                    communion = "true";
                }
                else if (selected == "Married")
                {
                    married = "true";
                }
            }

            Dictionary<string,string> other_groups = new Dictionary<string, string>();
            foreach (DataRowView selected in listOtherGroups.CheckedItems)
            {
                other_groups.Add(selected.Row.ItemArray[0].ToString(), selected.Row.ItemArray[1].ToString());
            }

            string status = "active";


            // send the data to the database
            long parishoner_id = Sql.Execute_Insert("INSERT INTO `parishioners`(`name`,`station`,`organisation`,`society`,`address`,`status`,`gender`,`dob`,`baptised`,`communicant`,`confirmed`,`wedded`,`passport`,`phoneNo`) " +
                                 "VALUES('" + name + "','" + station_id + "','" + organisation_id + "','" + society_id + "','" + address + "','" + status + "','" + gender + "','" + dob + "','" + baptism + "','" + communion + "','" + confirmation + "','" + married + "','','"+ phone_no +"');");


            //upload the passport
            string passpor_location = System.IO.Directory.GetCurrentDirectory() + "/passport";
            System.IO.Directory.CreateDirectory(passpor_location);
            if (!string.IsNullOrWhiteSpace(passport))
            {
                passpor_location = ( passpor_location + "/parishioner_" + parishoner_id + ".jpg").Replace("\\","/");
                System.IO.File.Copy(passport, passpor_location, false);
                Sql.Execute_Query("UPDATE `parishioners` SET `passport`='"+ passpor_location +"' WHERE `parishioner_id`='"+ parishoner_id +"';");
            }

            // add pious societies
            if (other_groups.Count > 0)
            {
                foreach (KeyValuePair<string,string> og in other_groups)
                {
                    Sql.Execute_Query("INSERT INTO `" + og.Key + "`(`member_id`) VALUES('" + parishoner_id + "');");
                    Sql.Execute_Insert("INSERT INTO `parishioner_groups`(`parishioner_id`,`group_code_name`,`group_name`,`group_type`) VALUES('" + parishoner_id + "','" + og.Key + "','" + og.Value + "','other_groups');");
                }
            }

            // add other_groups
            if (pious_societies.Count > 0)
            {
                foreach (KeyValuePair<string,string> ps in pious_societies)
                {
                    Sql.Execute_Query("INSERT INTO `" + ps.Key + "`(`member_id`) VALUES('" + parishoner_id + "');");
                    Sql.Execute_Insert("INSERT INTO `parishioner_groups`(`parishioner_id`,`group_code_name`,`group_name`,`group_type`) VALUES('" + parishoner_id + "','" + ps.Key + "','" + ps.Value + "','pious_societies');");
                }
            }


            MessageBox.Show("Parishioner Registration successfully completed","Registration Status");
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbOrganisation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStation.SelectedIndex >= 0)
            {
                string organisation_id = cmbOrganisation.SelectedValue.ToString();
                string station_id = cmbStation.SelectedValue.ToString();
                //MessageBox.Show("org id:"+organisation_id +", station id:"+station_id);
                Sql.fiil_CBO("SELECT * FROM `societies` WHERE `organisation_id`='" + organisation_id + "' AND `station_id`='" + station_id + "';", cmbSociety);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAddress.Clear();
            txtOthernames.Clear();
            txtSurname.Clear();
            dtpDOB.Value = DateTime.Now;
            picPassport.Image = Properties.Resources.index;
            rdFemale.Checked = false;
            rdMale.Checked = false;
            cmbOrganisation.SelectedIndex = 0;
            cmbStation.SelectedIndex = 0;
            listPiousSocieties.ClearSelected();
            listOtherGroups.ClearSelected();
            listSacrament.ClearSelected();
            passport = "";
            txtPhoneNo.Clear();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
