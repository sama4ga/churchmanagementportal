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
    public partial class frmChurchDetails : Form
    {
        public frmChurchDetails()
        {
            InitializeComponent();
        }

        private void frmChurchDetails_Load(object sender, EventArgs e)
        {
            txtChurchAddress.Text = Properties.Settings.Default.church_address;
            txtChurchName.Text = Properties.Settings.Default.church_name;
            txtPassword.Text = Properties.Settings.Default.password;
            txtPort.Text = Properties.Settings.Default.port;
            txtUser.Text = Properties.Settings.Default.user;
            txtServer.Text = Properties.Settings.Default.server;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.church_name = txtChurchName.Text.ToUpper();
            Properties.Settings.Default.church_address = txtChurchAddress.Text;
            Properties.Settings.Default.password = txtPassword.Text;
            Properties.Settings.Default.port = txtPort.Text;
            Properties.Settings.Default.user = txtUser.Text;
            Properties.Settings.Default.server = txtServer.Text;
            Properties.Settings.Default.Save();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMainForm_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.user_status = "admin";
            frm.Show();
            Close();
        }
    }
}
