using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace Church_Management_Portal
{
    public partial class frmViewFullParishionerDetail : Form
    {
        public int parishioner_id = 0;
        SQLConfig Sql = new SQLConfig();
        usableFunction usf = new usableFunction();
        //MySqlDataReader dr;

        public frmViewFullParishionerDetail(int pId = 0)
        {
            InitializeComponent();
            parishioner_id = pId;
        }

        private void frmViewFullParishionerDetail_Load(object sender, EventArgs e)
        {
            Sql.ReadData("SELECT p.`regNo`,concat(p.`title`,' ',p.`name`) as 'name',p.`address`,p.`phoneNo`," +
                    "p.`email`,st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`status`,p.`gender`,p.`dob`,loo.`lga`,p.`nextOfKInPhone`," +
                    "p.`passport` as 'Passport',p.`occupation`,p.`spouseName`," +
                    "d.`diocese`,p.`parishOfOrigin`,p.`nextOfKinName`,p.`nextOfKinAddress`," +
                    "p.`baptised`,p.`communicant`,p.`confirmed`," +
                    "p.`wedded`,soo.`state`,p.`maritalStatus` "+
                    "from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`" +
                    "left join `state_of_origin` soo on soo.`state_id`=p.`stateOfOrigin`" +
                    "left join `lga_of_origin` loo on loo.`lga_id`=p.`lgaOfOrigin`" +
                    "left join `diocese` d on d.`dioceseId`=p.`dioceseOfOrigin`" +
                    "WHERE p.`parishioner_id`='" +parishioner_id+"';");
            if (Sql.dr.HasRows)
            {
                while (Sql.dr.Read())
                {
                    lblName.Text = Sql.dr.GetString("name");
                    lblEmail.Text = Sql.dr.GetString("email");
                    lblAddress.Text = Sql.dr.GetString("address");
                    lblBaptised.Text = Sql.dr.GetString("baptised");
                    lblCommunicant.Text = Sql.dr.GetString("communicant");
                    lblPhoneNo.Text = Sql.dr.GetString("phoneNo");
                    lblStation.Text = Sql.dr.GetString("Station");
                    lblSociety.Text = Sql.dr.GetString("Society");
                    lblOrganisation.Text = Sql.dr.GetString("Organisation");
                    string passport = Sql.dr.GetString("passport");
                    if (passport != "0" && System.IO.File.Exists(passport))
                    {
                        picPassport.Image = Image.FromFile(passport);
                    }
                    string maritalStatus = Sql.dr.GetString("maritalStatus");
                    lblMaritalStatus.Text = maritalStatus;
                    if (maritalStatus == "Single")
                    {
                        lblSpouseName.Hide();
                        lblSpouseNameLabel.Hide();
                    }
                    lblSpouseName.Text = Sql.dr.GetString("spouseName");
                    lblNextOfKinPhone.Text = Sql.dr.GetString("nextOfKinPhone");
                    lblNexOfKin.Text = Sql.dr.GetString("nextOfKinName");
                    lblNextOfKinAddress.Text = Sql.dr.GetString("nextOfKinAddress");
                    lblStateOfOrigin.Text = Sql.dr.GetString("state");
                    lblLGAOfOrigin.Text = Sql.dr.GetString("lga");
                    lblWedded.Text = Sql.dr.GetString("wedded");
                    lblConfirmed.Text = Sql.dr.GetString("confirmed");
                    lblStatus.Text = Sql.dr.GetString("status");
                    lblOccupation.Text = Sql.dr.GetString("occupation");
                    lblDOB.Text = Sql.dr.GetString("dob");
                    lblParishOfOrigin.Text = Sql.dr.GetString("parishOfOrigin");
                    lblDioceseOfOrigin.Text = Sql.dr.GetString("diocese");
                    lblRegNo.Text = "Parishioner_" + Sql.dr.GetString("regNo");
                    lblGender.Text = Sql.dr.GetString("gender");
                }
            }
            else
            {
                MessageBox.Show("No record found","View Parishioner Detail");
                Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditParishionerDetails frm = new frmEditParishionerDetails();
            frm.parishioner_id = parishioner_id;
            frm.ShowDialog();
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnViewParishionerGroups_Click(object sender, EventArgs e)
        {
            frmViewParishionerGroups frm = new frmViewParishionerGroups();
            frm.parishioner_id = parishioner_id;
            frm.ShowDialog();
            Close();
        }
    }
}
