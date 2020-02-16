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
    public partial class Form1 : Form
    {
        usableFunction UF = new usableFunction();
        SQLConfig Sql = new SQLConfig();
        TimeSpan timeLogin = new TimeSpan();
        int user_id = 0;
        int maxrow = 0;
        public  string user_status;

        public Form1(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
        }
                

        private void Form1_Load(object sender, EventArgs e)
        {
            lblChurchName.Text = Properties.Settings.Default.church_name.ToUpper();
            lblAddress.Text = Properties.Settings.Default.church_name;
            //this.BackgroundImage = Properties.Resources.background_image;        
            
            // get user details
            if (user_id != 0) {
                maxrow = Sql.maxrow("SELECT * FROM `parishioners` where `parishioner_id`='"+ user_id +"';","parishioners");
                if (maxrow == 1)
                {
                    if (System.IO.File.Exists(Sql.ds.Tables["parishioners"].Rows[0].Field<string>("passport")))
                    {
                        picPassport.Image = Image.FromFile(Sql.ds.Tables["parishioners"].Rows[0].Field<string>("passport"));
                    }
                    else
                    {
                        picPassport.Image = Properties.Resources.index;
                    }
                    lblUserName.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("name");
                    lblUserStatus.Text = user_status;
                }
                else
                {
                    picPassport.Image = Properties.Resources.index;
                    lblUserName.Text = "user";
                    lblUserStatus.Text = user_status;
                }
            }


            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM, yyyy HH:mm:ss");
            timeLogin = DateTime.Now.TimeOfDay;

            timer1.Start();
            timer1.Enabled = true;

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {

        }

  #region View List
        private void btnViewList_MouseHover(object sender, EventArgs e)
        {
            lblLabel.Text = "View List of Parishioners";
            btnViewList.BackColor = Color.Lime;
        }

        private void btnViewList_MouseLeave(object sender, EventArgs e)
        {
            btnViewList.BackColor = Color.Green;
            lblLabel.Text = "";
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            UF.showFrmD( new frmViewListBy());
            
        }
        #endregion


 #region Open New Record

        private void btnOpenNewRecord_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmCreateNewRecord());
        }

        private void btnOpenNewRecord_MouseHover(object sender, EventArgs e)
        {
            lblLabel.Text = "Open New Record";
            btnOpenNewRecord.BackColor = Color.Lime;
        }

        private void btnOpenNewRecord_MouseLeave(object sender, EventArgs e)
        {
            btnOpenNewRecord.BackColor = Color.Green;
            lblLabel.Text = "";
        }

 #endregion


  #region Add Parishioner
        private void btnAddParishioner_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmAddParishioner());
        }

        private void btnAddParishioner_MouseHover(object sender, EventArgs e)
        {
            lblLabel.Text = "Add New Parishioner";
            btnAddParishioner.BackColor = Color.Lime;
        }

        private void btnAddParishioner_MouseLeave(object sender, EventArgs e)
        {
            btnAddParishioner.BackColor = Color.Green;
            lblLabel.Text = "";
        }
  #endregion
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeSinceLogin.Text = DateTime.Now.Subtract(timeLogin).ToString("HH:mm:ss");
        }
        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UF.showFrm(new frmLogin());
            this.Hide();
        }

 #region View Records
        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            if (panelViewRecordBy.Visible)
            {
                panelViewRecordBy.Visible = false;
            }
            else
            {
                panelViewRecordBy.Visible = true;
            }
        }

        private void btnViewRecords_MouseHover(object sender, EventArgs e)
        {
            lblLabel.Text = "View Register of Sacraments";
            btnViewRecords.BackColor = Color.Lime;
        }

        private void btnViewRecords_MouseLeave(object sender, EventArgs e)
        {
            btnViewRecords.BackColor = Color.Green;
            lblLabel.Text = "";
        }


        private void cmbViewRecordBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbViewRecordBy.SelectedItem.ToString())
            {
                case "Baptism":
                    UF.showFrmD(new frmBaptismRecord());
                    break;
                case "Confirmation":
                    UF.showFrmD(new frmConfirmationRecord());
                    break;
                case "Communion":
                    UF.showFrmD(new frmCommunionRecord());
                    break;
                case "Marriage":
                    UF.showFrmD(new frmMarriageRecord());
                    break;
                case "Death":
                    UF.showFrmD(new frmDeath());
                    break;

                default:
                    break;
            }
        }

        #endregion


 #region View Records
        private void btnViewRecord_MouseHover(object sender, EventArgs e)
        {
            lblLabel.Text = "View Records";
            btnViewRecord.BackColor = Color.Lime;
        }

        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmViewRecords());
        }

        private void btnViewRecord_MouseLeave(object sender, EventArgs e)
        {
            btnViewRecord.BackColor = Color.Green;
            lblLabel.Text = "";
        }

 #endregion
       

 #region Priests

        private void btnPriests_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmViewPriests());
        }

        private void btnPriests_MouseHover(object sender, EventArgs e)
        {
            lblLabel.Text = "View Priests";
            btnPriests.BackColor = Color.Lime;
        }

        private void btnPriests_MouseLeave(object sender, EventArgs e)
        {
            btnPriests.BackColor = Color.Green;
            lblLabel.Text = "";
        }
 #endregion


 #region Add User
        private void btnAddUser_MouseHover(object sender, EventArgs e)
        {
            lblLabel.Text = "Add New User";
            btnAddUser.BackColor = Color.Lime;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmAddNewUser());
        }

        private void btnAddUser_MouseLeave(object sender, EventArgs e)
        {
            btnAddUser.BackColor = Color.Green;
            lblLabel.Text = "";
        }
 #endregion
      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBackgroundPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Choose Background Image",
                Filter = "Picture Files(.jpeg;.jpg;.png;.gif)|*.jpeg;*.jpg;*.png;*.gif",
                CheckFileExists = true,
                CheckPathExists = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.BackgroundImage = Image.FromFile(ofd.FileName);
            }
        }
    }
}
