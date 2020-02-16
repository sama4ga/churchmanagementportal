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
    public partial class frmCreateNewRecord : Form
    {

        usableFunction UF = new usableFunction();

        public frmCreateNewRecord()
        {
            InitializeComponent();
        }        

        private void btnSociety_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmAddSociety());
        }

        private void btnPiousSociety_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmAddPiousSociety());
        }

        private void btnStation_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmCreateNewStation());
        }

        private void btnOrganisation_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmAddOrganisation());
        }

        private void btnOtherGroups_Click(object sender, EventArgs e)
        {
            UF.showFrmD(new frmAddOtherGroups());
        }
    }
}
