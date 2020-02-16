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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnChangeBackgroundPic_Click(object sender, EventArgs e)
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
                Form1 frm = new Form1(1);
                frm.BackgroundImage = Image.FromFile(ofd.FileName);
            }
        }
    }
}
