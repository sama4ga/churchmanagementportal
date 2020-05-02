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
    public partial class frmEditParishionerDetails : Form
    {
        usableFunction UF = new usableFunction();
        SQLConfig Sql = new SQLConfig();
        string passport = "";
        public int parishioner_id;


        public frmEditParishionerDetails()
        {
            InitializeComponent();
        }

        private void frmEditParishionerDetails_Load(object sender, EventArgs e)
        {
            Sql.fiil_CBO("SELECT * FROM `stations`;", cmbStation, "station");
            if (!Sql.result) { return; }
            Sql.fiil_CBO("SELECT `organisation_id`,`short_name` FROM `organisation`;", cmbOrganisation, "organisation");
            if (!Sql.result) { return; }
            int num_rows = Sql.maxrow("SELECT * FROM `parishioners` WHERE `parishioner_id`='" + parishioner_id + "';","parishioners");
            if (num_rows == 1)
            {
                passport = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("passport");
                if (System.IO.File.Exists(passport))
                {
                    picPassport.Image = Image.FromFile(passport);
                }
                else
                {
                    picPassport.Image = Properties.Resources.index;
                }
               string[] name = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("name").Split(new char[] { ',' });
                txtSurname.Text = name[0];
                txtOthernames.Text = name[1];
                txtAddress.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("address");
                txtPhoneNo.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("phoneNo");
                string gender = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("gender");
                if (gender.Equals("Male"))
                {
                    rdMale.Checked = true;
                }
                else
                {
                    rdFemale.Checked = true;
                }
                DateTime dob = Sql.ds.Tables["parishioners"].Rows[0].Field<DateTime>("dob");
                dtpDOB.Value = dob;
                int organisation = Sql.ds.Tables["parishioners"].Rows[0].Field<int>("organisation");
                int station = Sql.ds.Tables["parishioners"].Rows[0].Field<int>("station");
                int society = Sql.ds.Tables["parishioners"].Rows[0].Field<int>("society");
                cmbStatus.SelectedItem = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("status");
                string baptised = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("baptised");
                if (baptised == "true")
                {
                    listSacrament.SetItemChecked(0, true);
                }
                string communicant = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("communicant");
                if (communicant == "true")
                {
                    listSacrament.SetItemChecked(1, true);
                }
                string confirmed = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("confirmed");
                if (confirmed == "true")
                {
                    listSacrament.SetItemChecked(2, true);
                }
                string wedded = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("wedded");
                if (wedded == "true")
                {
                    listSacrament.SetItemChecked(3, true);
                }


                Sql.fiil_CBO("SELECT * FROM `societies` WHERE `organisation_id`='" + organisation + "' AND `station_id`='" + station + "';", cmbSociety,"society");
                if (!Sql.result) { return; }
                cmbStation.SelectedValue = station;
                cmbOrganisation.SelectedValue = organisation;
                cmbSociety.SelectedValue = society;

            }
        }
        
                       

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmViewListOfParishioners frm = new frmViewListOfParishioners();
            Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string name = txtSurname.Text.Trim() + ", " + txtOthernames.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone_no = txtPhoneNo.Text.Trim();
            string dob = dtpDOB.Value.ToString("yyyy-MM-dd");
            string station_id = cmbStation.SelectedValue.ToString();
            string organisation_id = cmbOrganisation.SelectedValue.ToString();
            string status = cmbStatus.SelectedItem.ToString();
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


            string baptism = "false";
            string confirmation = "false";
            string communion = "false";
            string married = "false";
            foreach (string sacrament in listSacrament.CheckedItems)
            {
                if (sacrament == "Baptised")
                {
                    baptism = "true";
                }
                else if (sacrament == "Confirmed")
                {
                    confirmation = "true";
                }
                else if (sacrament == "Communicant")
                {
                    communion = "true";
                }
                else if (sacrament == "Married")
                {
                    married = "true";
                }
            }

            //upload the passport
            string passpor_location = System.IO.Directory.GetCurrentDirectory() + "/passport";
            System.IO.Directory.CreateDirectory(passpor_location);
            if (!string.IsNullOrWhiteSpace(passport))
            {
                if (!System.IO.File.Exists(passport))
                {
                    passpor_location = (passpor_location + "/parishioner_" + parishioner_id + ".jpg").Replace("\\", "/");
                    System.IO.File.Copy(passport, passpor_location, true);
                    Sql.Execute_Insert("UPDATE `parishioners` SET `passport`= '" + passpor_location + "' WHERE `parishioner_id`='" + parishioner_id + "';");
                    if (!Sql.result){return;}
                }
            }


            // send the data to the database
            Sql.Execute_Insert("UPDATE `parishioners` SET `name`='" + name + "',`station`='" + station_id + "',`organisation`='" + organisation_id + "'," +
                                "`society`= '" + society_id + "',`address`= '" + address + "',`status`= '" + status + "',`gender`= '" + gender + "'," +
                                "`dob`= '" + dob + "',`baptised`= '" + baptism + "',`communicant`= '" + communion + "',`confirmed`= '" + confirmation + "'," +
                                "`wedded`= '" + married + "',`phoneNo`= '" + phone_no + "' WHERE `parishioner_id`='"+ parishioner_id +"';");

            if (Sql.result)
            {
                MessageBox.Show("Edit successful", "Update Status");
            }


           
        }

        private void cmbOrganisation_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbStation.SelectedIndex >= 0)
            {
                string organisation_id = cmbOrganisation.SelectedValue.ToString();
                string station_id = cmbStation.SelectedValue.ToString();
                Sql.fiil_CBO("SELECT * FROM `societies` WHERE `organisation_id`='" + organisation_id + "' AND `station_id`='" + station_id + "';", cmbSociety, "society");

            }
        }

        private void cmbStation_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbOrganisation.SelectedIndex >= 0)
            {
                string organisation_id = cmbOrganisation.SelectedValue.ToString();
                string station_id = cmbStation.SelectedValue.ToString();
                Sql.fiil_CBO("SELECT * FROM `societies` WHERE `organisation_id`='" + organisation_id + "' AND `station_id`='" + station_id + "';", cmbSociety,"society");
            }
        }

        private void btnLoadPassport_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "Images|*.jpeg;*.jpg;*.png";
            ofd.Title = "Choose Passport";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                passport = ofd.FileName;
                picPassport.Image = Image.FromFile(passport);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
