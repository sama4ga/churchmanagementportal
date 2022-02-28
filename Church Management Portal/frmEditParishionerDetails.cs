using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Sql.fiil_CBO("SELECT `dioceseId`,`diocese` FROM `diocese` ORDER BY `diocese` asc;", cmbDioceseOfOrigin, "diocese");
            if (!Sql.result) { return; }
            Sql.fiil_CBO("SELECT `state_id`,`state` FROM `state_of_origin`;", cmbStateOfOrigin, "states");
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

                string maritalStatus = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("maritalStatus");
                if (maritalStatus.Equals("Single"))
                {
                    rdSingle.Checked = true;
                }
                else if(maritalStatus.Equals("Married"))
                {
                    rdMarried.Checked = true;
                }
                else if (maritalStatus.Equals("Widow"))
                {
                    rdWidow.Checked = true;
                }
                else if (maritalStatus.Equals("Widower"))
                {
                    rdWidower.Checked = true;
                }

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
                txtSpouseName.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("spouseName");
                txtEmail.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("email");
                txtNextOfKinAddress.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("nextOfKinAddress");
                txtNextOfKinName.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("nextOfKinName");
                txtNextofKinPhone.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("nextOfKinPhone");
                txtParishOfOrigin.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("parishOfOrigin");
                txtOccupation.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("occupation");
                txtTitle.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("title");
                txtWhatCanYouDo.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("whatCanYouDo");
                cmbStatus.SelectedItem = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("status");
                int state_id = Sql.ds.Tables["parishioners"].Rows[0].Field<int>("stateOfOrigin");
                int lga_id = Sql.ds.Tables["parishioners"].Rows[0].Field<int>("lgaOfOrigin");
                int diocese = Sql.ds.Tables["parishioners"].Rows[0].Field<int>("dioceseOfOrigin");

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

                cmbStateOfOrigin.SelectedValue = state_id;
                cmbStation.SelectedValue = station;
                cmbOrganisation.SelectedValue = organisation;
                cmbDioceseOfOrigin.SelectedValue = diocese; ;
                
                Sql.fiil_CBO("SELECT `lga_id`,`lga` FROM `lga_of_origin` WHERE `state_id`='" + state_id + "';", cmbLGAOfOrigin);
                if (!Sql.result) { return; }
                cmbLGAOfOrigin.SelectedValue = lga_id;

                Sql.fiil_CBO("SELECT * FROM `societies` WHERE `organisation_id`='" + organisation + "' AND `station_id`='" + station + "';", cmbSociety, "society");
                if (!Sql.result) { return; }
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
            string title = txtTitle.Text.Trim();
            string whatCanYouDo = txtWhatCanYouDo.Text.Trim();
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

            string spouseName = txtSpouseName.Text;
            string maritalStatus = "";
            if (rdWidow.Checked)
            {
                maritalStatus = "Widow";
            }
            else if (rdWidower.Checked)
            {
                maritalStatus = "Widower";
            }
            else if (rdDivorced.Checked)
            {
                maritalStatus = "Divorced";
            }
            else if (rdSingle.Checked)
            {
                maritalStatus = "Single";
                spouseName = "";
            }
            else if (rdMarried.Checked)
            {
                maritalStatus = "Married";
            }

            string email = txtEmail.Text;
            if (!string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[\w!#$%&'*+/=?`{|}~^-]+(?:\.[\w!#$%&'*+/=?`{|}~^-]+)*@(?:[A-Z0-9-]+\.)+[A-Z]{2,6}$"))
            {
                MessageBox.Show("Invalid email supplied", "Add Parishioner");
                txtEmail.SelectAll(); txtEmail.Focus(); return;
            }
            string occupation = txtOccupation.Text;
            string lgaOfOrigin = cmbLGAOfOrigin.SelectedValue.ToString();
            string stateOfOrigin = cmbStateOfOrigin.SelectedValue.ToString();
            string dioceseOfOrigin = cmbDioceseOfOrigin.SelectedValue.ToString();
            string parishOfOrigin = txtParishOfOrigin.Text;
            string nextOfKinName = txtNextOfKinName.Text;
            string nextOfKinAddress = txtNextOfKinAddress.Text;
            string nextOfKinPhone = txtNextofKinPhone.Text;
            if (!string.IsNullOrWhiteSpace(nextOfKinPhone) && !Regex.IsMatch(nextOfKinPhone, @"([\+\d]{2,3}|0){1}[\d]{10}$"))
            {
                MessageBox.Show("Invalid next of kin phone number supplied", "Add Parishioner");
                txtNextofKinPhone.SelectAll(); txtNextofKinPhone.Focus(); return;
            }

            //upload the passport
            string passpor_location = System.IO.Directory.GetCurrentDirectory() + "/passport";
            System.IO.Directory.CreateDirectory(passpor_location);
            if (!string.IsNullOrWhiteSpace(passport))
            {
                if (!System.IO.File.Exists(passport) && passport != "0")
                {
                    passpor_location = (passpor_location + "/parishioner_" + parishioner_id + ".jpg").Replace("\\", "/");
                    System.IO.File.Copy(passport, passpor_location, true);
                }
                else
                {
                    passpor_location = "";
                }
            }


            // send the data to the database
            List<string> param = new List<string>();
            param.Add(name);param.Add(station_id);param.Add(organisation_id);param.Add(society_id);param.Add(address);
            param.Add(status);param.Add(gender);param.Add(dob);param.Add(baptism);param.Add(communion);param.Add(confirmation);
            param.Add(married);param.Add(phone_no);param.Add(passpor_location);param.Add(occupation);param.Add(spouseName);
            param.Add(email);param.Add(maritalStatus);param.Add(lgaOfOrigin);param.Add(stateOfOrigin);param.Add(dioceseOfOrigin);
            param.Add(parishOfOrigin);param.Add(nextOfKinName);param.Add(nextOfKinAddress);param.Add(nextOfKinPhone);
            param.Add(title); param.Add(whatCanYouDo);  param.Add(parishioner_id.ToString());
            Sql.UpdateQuery("UPDATE `parishioners` SET `name`=@1,`station`=@2,`organisation`=@3," +
                                "`society`= @4,`address`= @5,`status`= @6,`gender`= @7," +
                                "`dob`= @8,`baptised`= @9,`communicant`= @10,`confirmed`= @11," +
                                "`wedded`= @12,`phoneNo`= @13,`passport`= @14,"+
                                "`occupation`= @15,`spouseName`= @16,`email`= @17,`maritalStatus`= @18,`lgaOfOrigin`= @19,"+
                                "`stateOfOrigin`= @20,`dioceseOfOrigin`= @21,`parishOfOrigin`= @22," +
                                "`nextOfKinName`= @23,`nextOfKinAddress`= @24,`nextOfKinPhone`=@25,`title`=@26,`whatCanYouDo`=@27 " +
                                "WHERE `parishioner_id`= @28;", param);

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

        private void txtOthernames_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbStateOfOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStateOfOrigin.SelectedIndex >= 0)
            {
                string state_id = cmbStateOfOrigin.SelectedValue.ToString();
                Sql.fiil_CBO("SELECT `lga_id`,`lga` FROM `lga_of_origin` WHERE `state_id`='" + state_id + "';", cmbLGAOfOrigin);
                if (!Sql.result) { return; }
            }
        }

        private void rdSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSingle.Checked)
            {
                txtSpouseName.Hide();
                lblSpouseName.Hide();
            }
            else
            {
                txtSpouseName.Show();
                lblSpouseName.Show();
            }
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

    }
}
