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

        string stationPic = string.Empty;

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
                stationPic = ofd.FileName;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Enter name of station to continue");txtName.Focus();return;
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                MessageBox.Show("Enter address of station to continue"); txtAddress.Focus(); return;
            }

            List<string> param = new List<string>();
            param.Add(txtName.Text.Trim());
            param.Add(txtAddress.Text.Trim());
            param.Add(dtpCreationDate.Value.ToString("yyyy-MM-dd"));

            long station_id = 0;
            Sql.InsertQuery("INSERT INTO `stations`(`name`,`address`,`date_established`) VALUES(@1,@2,@3);", param, out station_id);
            if (!Sql.result) { return; }

            //upload the passport
            string passpor_location = System.IO.Directory.GetCurrentDirectory() + "/station_pics";
            System.IO.Directory.CreateDirectory(passpor_location);
            if (!string.IsNullOrWhiteSpace(stationPic))
            {
                passpor_location = (passpor_location + "/station" + station_id + ".jpg").Replace("\\", "/");
                System.IO.File.Copy(stationPic, passpor_location, false);
                Sql.Execute_Query("UPDATE `stations` SET `picture`='" + passpor_location + "' WHERE `station_id`='" + station_id + "';");
                if (!Sql.result) { return; }
            }

            MessageBox.Show("Station successfully created", "Create New Station");
        }
    }
}
