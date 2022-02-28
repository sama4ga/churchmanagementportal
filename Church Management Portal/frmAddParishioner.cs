using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (!Sql.result) { return; }
            Sql.fiil_CBO("SELECT `organisation_id`,`short_name` FROM `organisation`;", cmbOrganisation,"organisation");
            Sql.fiil_CBO("SELECT `state_id`,`state` FROM `state_of_origin`;", cmbStateOfOrigin, "states");
            if (!Sql.result) { return; }
            Sql.fiil_CBO("SELECT `dioceseId`,`diocese` FROM `diocese` ORDER BY `diocese` asc;", cmbDioceseOfOrigin, "diocese");
            if (!Sql.result) { return; }
            //Sql.fiil_listBox("SELECT `organisation_id`,`short_name` FROM `organisation`;", listOrganisation, "organisation");
            if (!Sql.result) { return; }
            Sql.fiil_listBox("SELECT `code_name`,`name` FROM `pious_societies`;", listPiousSocieties,"pious");
            if (!Sql.result) { return; }
            Sql.fiil_listBox("SELECT `code_name`,`name` FROM `other_groups`;", listOtherGroups,"groups");
            if (!Sql.result) { return; }
            rdSingle.Checked = true;
        }



        private void cmbStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrganisation.SelectedIndex >= 0)
            {
                string organisation_id = cmbOrganisation.SelectedValue.ToString();
                string station_id = cmbStation.SelectedValue.ToString();
                //MessageBox.Show("org id:" + organisation_id + ", station id:" + station_id);
                Sql.fiil_CBO("SELECT * FROM `societies` WHERE `organisation_id`='" + organisation_id + "' AND `station_id`='" + station_id + "';", cmbSociety);
                if (!Sql.result) { return; }
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
            string title = txtTitle.Text.Trim();
            string whatCanYouDo = txtWhatCanYouDo.Text.Trim();
            string name = txtSurname.Text.Trim() + ", " + txtOthernames.Text.Trim();
            if (string.IsNullOrEmpty(txtSurname.Text.Trim()))
            {
                MessageBox.Show("Surname is a required field", "Add Parishioner");
                txtSurname.Focus(); return;                
            }

            if (string.IsNullOrEmpty(txtOthernames.Text.Trim()))
            {
                MessageBox.Show("Othernames is a required field", "Add Parishioner");
                txtOthernames.Focus(); return;                
            }
            string address = txtAddress.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address is a required field", "Add Parishioner");
                txtAddress.Focus(); return;
            }
            string dob = dtpDOB.Value.ToString("yyyy-MM-dd");
            string station_id = cmbStation.SelectedValue.ToString();
            if (string.IsNullOrEmpty(station_id))
            {
                MessageBox.Show("Choose a station to proceed", "Add Parishioner");
                cmbStation.Focus(); return;
            }
            string organisation_id = cmbOrganisation.SelectedValue.ToString();
            if (string.IsNullOrEmpty(organisation_id))
            {
                MessageBox.Show("Choose an organisation to proceed", "Add Parishioner");
                cmbOrganisation.Focus(); return;
            }
            string phone_no = txtPhoneNo.Text.Trim();
            //if (string.IsNullOrEmpty(phone_no))
            //{
            //    MessageBox.Show("Phone number is a required field", "Add Parishioner");
            //    txtPhoneNo.Focus(); return;
            //}
            if (!string.IsNullOrWhiteSpace(phone_no) && !Regex.IsMatch(phone_no,@"([\+\d]{2,3}|0){1}[\d]{10}$"))
            {
                MessageBox.Show("Invalid phone number supplied","Add Parishioner");
                txtPhoneNo.SelectAll(); txtPhoneNo.Focus(); return;
            }
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
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Choose a gender to proceed", "Add Parishioner");
                rdMale.Focus(); return;
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

            Dictionary<string,string> pious_societies = new Dictionary<string, string>();
            foreach (DataRowView selected in listPiousSocieties.CheckedItems)
            {
                pious_societies.Add(selected.Row.ItemArray[0].ToString(), selected.Row.ItemArray[1].ToString());
            }

            string baptism = "false";
            string confirmation = "false";
            string communion = "false";
            string married = "false";
            foreach (string sacrament in listSacrament.CheckedItems)
            {
               // MessageBox.Show(selected);
                if (sacrament == "Baptism")
                {
                    baptism = "true";
                }
                else if (sacrament == "Confirmation")
                {
                    confirmation = "true";
                }
                else if (sacrament == "Communion")
                {
                    communion = "true";
                }
                else if (sacrament == "Matrimony")
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

            // check if the parishioner has already been registered
            int maxrow = Sql.maxrow("SELECT parishioner_id FROM `parishioners` WHERE `name`='"+ name +"';");
            if (maxrow > 0)
            {
                DialogResult result = MessageBox.Show("A parishioner with the same name is in the database.\n\nClick Yes to continue registration, No to edit the record before registering, or Cancel to discontinue registration","Add parishioner",MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.No)
                {
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    Clear();return;
                }
            }


            // send the data to the database
            long parishoner_id = 0;
            string regNo = "";
            List<string> param = new List<string>();
            param.Add(name); param.Add(station_id); param.Add(organisation_id); param.Add(society_id);
            param.Add(address); param.Add(status); param.Add(gender); param.Add(dob); param.Add(baptism);
            param.Add(communion); param.Add(confirmation); param.Add(married); param.Add(""); param.Add(phone_no);
            param.Add(occupation); param.Add(spouseName); param.Add(email); param.Add(maritalStatus); param.Add(lgaOfOrigin);
            param.Add(stateOfOrigin); param.Add(dioceseOfOrigin); param.Add(parishOfOrigin); param.Add(nextOfKinName);
            param.Add(nextOfKinAddress); param.Add(nextOfKinPhone); param.Add(title); param.Add(whatCanYouDo);
            Sql.InsertQuery("INSERT INTO `parishioners`(`name`,`station`,`organisation`,`society`,`address`,`status`,"+
                            "`gender`,`dob`,`baptised`,`communicant`,`confirmed`,`wedded`,`passport`,`phoneNo`,`occupation`,"+
                            "`spouseName`,`email`,`maritalStatus`,`lgaOfOrigin`,`stateOfOrigin`,`dioceseOfOrigin`,`parishOfOrigin`,"+
                            "`nextOfKinName`,`nextOfKinAddress`,`nextOfKinPhone`,`title`,`whatCanYouDo`) " +
                                 "VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27);", 
                                 param, out parishoner_id);
            if (!Sql.result) { return; }

            regNo = parishoner_id.ToString();
            //upload the passport
            string passpor_location = System.IO.Directory.GetCurrentDirectory() + "/passport";
            System.IO.Directory.CreateDirectory(passpor_location);
            if (!string.IsNullOrWhiteSpace(passport))
            {
                passpor_location = ( passpor_location + "/parishioner_" + parishoner_id + ".jpg").Replace("\\","/");
                System.IO.File.Copy(passport, passpor_location, false);

            }else
            {
                passpor_location = "";
            }
            Sql.Execute_Query("UPDATE `parishioners` SET `passport`='" + passpor_location + "',`regNo`='" + regNo + "' WHERE `parishioner_id`='" + parishoner_id + "';");
            if (!Sql.result) { return; }

            // add pious societies
            if (other_groups.Count > 0)
            {
                foreach (KeyValuePair<string,string> og in other_groups)
                {
                    Sql.Execute_Query("INSERT INTO `" + og.Key + "`(`member_id`) VALUES('" + parishoner_id + "');");
                    if (!Sql.result) { return; }
                    Sql.Execute_Insert("INSERT INTO `parishioner_groups`(`parishioner_id`,`group_code_name`,`group_type`) VALUES('" + parishoner_id + "','" + og.Key + "','other_groups');");
                    if (!Sql.result) { return; }
                }
            }

            // add other_groups
            if (pious_societies.Count > 0)
            {
                foreach (KeyValuePair<string,string> ps in pious_societies)
                {
                    Sql.Execute_Query("INSERT INTO `" + ps.Key + "`(`member_id`) VALUES('" + parishoner_id + "');");
                    if (!Sql.result) { return; }
                    Sql.Execute_Insert("INSERT INTO `parishioner_groups`(`parishioner_id`,`group_code_name`,`group_type`) VALUES('" + parishoner_id + "','" + ps.Key + "','pious_societies');");
                    if (!Sql.result) { return; }
                }
            }
            
            MessageBox.Show("Parishioner Registration successfully completed\n\nRegistration Number is "+ regNo,"Registration Status");
            Clear();
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
                if (!Sql.result) { return; }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtTitle.Clear();
            txtWhatCanYouDo.Clear();
            txtAddress.Clear();
            txtOthernames.Clear();
            txtSurname.Clear();
            txtParishOfOrigin.Clear();
            txtEmail.Clear();
            dtpDOB.Value = DateTime.Now;
            picPassport.Image = Properties.Resources.index;
            rdFemale.Checked = false;
            rdMale.Checked = false;
            rdSingle.Checked = false;
            rdMarried.Checked = false;
            rdWidower.Checked = false;
            rdWidow.Checked = false;
            rdDivorced.Checked = false;
            cmbOrganisation.SelectedIndex = 0;
            cmbStation.SelectedIndex = 0;
            cmbLGAOfOrigin.SelectedIndex = 0;
            cmbStateOfOrigin.SelectedIndex = 0;
            cmbDioceseOfOrigin.SelectedIndex = 0;
            lblSpouseName.Hide();
            txtSpouseName.Clear();txtSpouseName.Hide();
            txtNextOfKinAddress.Clear();
            txtNextOfKinName.Clear();
            txtNextofKinPhone.Clear();
            txtOccupation.Clear();

            //listSacrament.ClearSelected();
            foreach (int index in listSacrament.CheckedIndices)
            {
                listSacrament.SetItemCheckState(index, CheckState.Unchecked);
            }
            //listOtherGroups.ClearSelected();
            foreach (int index in listOtherGroups.CheckedIndices)
            {
                listOtherGroups.SetItemCheckState(index, CheckState.Unchecked);
            }
            //listPiousSocieties.ClearSelected();
            foreach (int index in listPiousSocieties.CheckedIndices)
            {
                listPiousSocieties.SetItemCheckState(index, CheckState.Unchecked);
            }
            passport = "";
            txtPhoneNo.Clear();

            txtSurname.Focus();
        }


        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtPhoneNo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            //List<int> num = new List<int>();
            //num.AddRange(new int[] { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105 });
            //if (num.Contains(e.KeyValue)) {
            //    e.Handled = false;
            //}
        }

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
           
           //if ((new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }).Contains(e.KeyChar) == false)
           // {
           //     e.Handled = true;
           // }
        }

        private void listSacrament_SelectedIndexChanged(object sender, EventArgs e)
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
        
        //private void rdMarried_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdMarried.Checked)
        //    {
        //        txtSpouseName.Show();
        //        lblSpouseName.Show();
        //    }
        //}

        //private void rdWidow_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdWidow.Checked)
        //    {
        //        txtSpouseName.Show();
        //        lblSpouseName.Show();
        //    }
        //}

        //private void rdWidower_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdWidower.Checked)
        //    {
        //        txtSpouseName.Show();
        //        lblSpouseName.Show();
        //    }
        //}

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

        //private void rdDivorced_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdMarried.Checked)
        //    {
        //        txtSpouseName.Show();
        //        lblSpouseName.Show();
        //    }
        //}
    }
}
