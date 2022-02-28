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
    public partial class frmViewStations : Form
    {

        SQLConfig Sql = new SQLConfig();
        public string user_status = "";
        string station_id = "";

        public frmViewStations()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewStations_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDelete.Hide(); groupBox2.Hide();
            }
            refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<string> param = new List<string>();
            param.Add(txtName.Text.Trim());
            param.Add(txtAddress.Text.Trim());
            param.Add(dtpDateEstablished.Value.ToString("yyyy-MM-dd"));
            param.Add(station_id);

            Sql.UpdateQuery("UPDATE `stations` SET `name`=@1,`address`=@2,`date_established`=@3 WHERE `station_id`=@4;", param);
            MessageBox.Show("Record successfully updated", "VIew Station Record");
            refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + txtName.Text, "Delete Stations", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Sql.Execute_Query("DELETE FROM `stations` WHERE `station_id`='" + station_id + "';");
                MessageBox.Show("Record successfully deleted", "VIew Station Record");
                refresh();
            }
        }

        private void listStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            station_id = listStations.SelectedValue.ToString();
            txtName.Text = Sql.ds.Tables["stations"].Rows[listStations.SelectedIndex].ItemArray[1].ToString();
            txtAddress.Text = Sql.ds.Tables["stations"].Rows[listStations.SelectedIndex].ItemArray[3].ToString();
            dtpDateEstablished.Value = Sql.ds.Tables["stations"].Rows[listStations.SelectedIndex].Field<DateTime>(2);
        }

        private void refresh()
        {
            Sql.fiil_listBox("SELECT * FROM `stations`;",listStations,"stations");
        }
    }
}
