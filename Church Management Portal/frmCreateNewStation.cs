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
    public partial class frmCreateNewStation : Form
    {

        usableFunction UF = new usableFunction();
        SQLConfig Sql = new SQLConfig();


        public frmCreateNewStation()
        {
            InitializeComponent();
        }

        private void btnStationPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "Images|*.jpeg;*.jpg;*.png";
            ofd.Title = "Choose Passport";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStationPic.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Sql.Execute_CUD("INSERT INTO `stations`(`name`,`address`,`date_established`) VALUES('"+ txtName.Text +"','" + txtAddress.Text +"','" + dtpCreationDate.Value.ToString("yyyy-MM-dd") +"');", "Could not create station", "Station successfully created");
        }
    }
}
