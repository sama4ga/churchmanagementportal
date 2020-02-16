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
    public partial class frmViewRecords : Form
    {
        public frmViewRecords()
        {
            InitializeComponent();
        }

        private void btnOrganisation_Click(object sender, EventArgs e)
        {
            frmViewOrganisations frm = new frmViewOrganisations();
            frm.ShowDialog();
        }

        private void btnSociety_Click(object sender, EventArgs e)
        {
            frmViewSocieties frm = new frmViewSocieties();
            frm.ShowDialog();
        }

        private void btnPiousSociety_Click(object sender, EventArgs e)
        {
            frmViewPiousSocieties frm = new frmViewPiousSocieties();
            frm.ShowDialog();
        }

        private void btnOtherGroups_Click(object sender, EventArgs e)
        {
            frmViewOtherGroups frm = new frmViewOtherGroups();
            frm.ShowDialog();
        }

        private void btnStation_Click(object sender, EventArgs e)
        {
            frmViewStations frm = new frmViewStations();
            frm.ShowDialog();
        }
    }
}
