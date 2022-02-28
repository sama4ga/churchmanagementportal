using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Church_Management_Portal
{
    public partial class Form1 : Form
    {
        usableFunction UF = new usableFunction();
        SQLConfig Sql = new SQLConfig();
        TimeSpan timeLogin = new TimeSpan();
        public int user_id = -1;
        int maxrow = 0;
        public  string user_status;

        public Form1()
        {
            InitializeComponent();
        }

        //public Form1(int user_id)
        //{
        //    InitializeComponent();
        //    this.user_id = user_id;
        //}


        private void Form1_Load(object sender, EventArgs e)
        {
            lblChurchName.Text = Properties.Settings.Default.church_name.ToUpper();
            lblAddress.Text = Properties.Settings.Default.church_address;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.background_image) & File.Exists(Properties.Settings.Default.background_image))
            {
                this.BackgroundImage = Image.FromFile(Properties.Settings.Default.background_image);
            }
            else
            {
                this.BackgroundImage = Properties.Resources.background_image;
            }
                   
            
            // get user details
            if (user_id != -1) {
                maxrow = Sql.maxrow("SELECT * FROM `parishioners` where `parishioner_id`='"+ user_id +"';","parishioners");
                if (maxrow == 1)
                {
                    if (File.Exists(Sql.ds.Tables["parishioners"].Rows[0].Field<string>("passport")))
                    {
                        picPassport.Image = Image.FromFile(Sql.ds.Tables["parishioners"].Rows[0].Field<string>("passport"));
                    }
                    else
                    {
                        picPassport.Image = Properties.Resources.index;
                    }
                    lblUserName.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("name");
                }
                else
                {
                    picPassport.Image = Properties.Resources.index;
                    lblUserName.Text = "user";
                }

                if (user_id == 0)
                {
                    picPassport.Image = Properties.Resources.index;
                    lblUserName.Text = "user";
                }

                Properties.Settings.Default.currentLoggedInUser = user_id;
            }
            
            lblUserStatus.Text = user_status;
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM, yyyy HH:mm:ss");
            timeLogin = DateTime.Now.TimeOfDay;

            timer1.Start();
            timer1.Enabled = true;

            if (user_status.Equals("secretary", StringComparison.CurrentCultureIgnoreCase))
            {
                btnAddUser.Visible = false;
            }
            else if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnAddUser.Visible = false;
                btnAddParishioner.Enabled = false;
                btnOpenNewRecord.Enabled = false;
                btnViewSacramentRecord.Enabled = false;
            }

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
            frmViewListBy frm = new frmViewListBy();
            frm.user_status = this.user_status;
            frm.ShowDialog();
            
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
            btnViewSacramentRecord.BackColor = Color.Lime;
        }

        private void btnViewRecords_MouseLeave(object sender, EventArgs e)
        {
            btnViewSacramentRecord.BackColor = Color.Green;
            lblLabel.Text = "";
        }


        private void cmbViewRecordBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbViewRecordBy.SelectedItem.ToString())
            {
                case "Baptism":
                    frmBaptismRecord frmB = new frmBaptismRecord();
                    frmB.user_status = this.user_status;
                    frmB.ShowDialog();
                    break;
                case "Confirmation":
                    frmConfirmationRecord frmC = new frmConfirmationRecord();
                    frmC.user_status = this.user_status;
                    frmC.ShowDialog();
                    break;
                case "Communion":
                    frmCommunionRecord frmCo = new frmCommunionRecord();
                    frmCo.user_status = this.user_status;
                    frmCo.ShowDialog();
                    break;
                case "Marriage":
                    frmMarriageRecord frmM = new frmMarriageRecord();
                    frmM.user_status = this.user_status;
                    frmM.ShowDialog();
                    break;
                case "Death":
                    frmDeath frmD = new frmDeath();
                    frmD.user_status = this.user_status;
                    frmD.ShowDialog();
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
            frmViewRecords frm = new frmViewRecords();
            frm.user_status = user_status;
            frm.ShowDialog();
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
            frmViewPriests frm = new frmViewPriests();
            frm.user_status = this.user_status;
            frm.ShowDialog();
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


 #region Manage Users
        private void btnAddUser_MouseHover(object sender, EventArgs e)
        {
            lblLabel.Text = "Manage Users";
            btnAddUser.BackColor = Color.Lime;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmManageUsers());
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
                string fileType = ofd.SafeFileName.Split('.').Last();
                string newFileName = Directory.GetCurrentDirectory() + "/background_image." + fileType;
                File.Copy(ofd.FileName, newFileName,true);
                Properties.Settings.Default.background_image = newFileName;
                Properties.Settings.Default.Save();

                this.BackgroundImage = Image.FromFile(newFileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.user_id = this.user_id;
            frm.ShowDialog();
        }

        private void lblChurchName_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.Show();
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.background_image) & File.Exists(Properties.Settings.Default.background_image))
            {
                this.BackgroundImage = Image.FromFile(Properties.Settings.Default.background_image);
            }
            else
            {
                this.BackgroundImage = Properties.Resources.background_image;
            }
        }
    }
}
