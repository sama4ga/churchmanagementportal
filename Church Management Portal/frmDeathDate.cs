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
    public partial class frmDeathDate : Form
    {
        public string burialDate;
        public string deathDate;

        public frmDeathDate()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkNotYetBuried.Checked == true)
            {
                burialDate = "";
            }
            else
            {
                burialDate = dtpBurialDate.Value.ToString("yyyy-MM-dd");
            }

            deathDate = dtpDeathDate.Value.ToString("yyyy-MM-dd");

            Close();


        }

        private void chkNotYetBuried_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotYetBuried.CheckState == CheckState.Unchecked)
            {
                dtpBurialDate.Show();
                label1.Show();
            }
            else
            {
                dtpBurialDate.Hide();
                label1.Hide();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
