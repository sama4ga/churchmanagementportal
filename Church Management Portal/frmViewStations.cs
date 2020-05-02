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
            Sql.fiil_listBox("UPDATE `stations` SET                                             "+
                "`name`='"+ txtName.Text + "',                                                  S"+
                "`address`='" + txtAddress.Text + "',                                           "+
                "`date_established`='" + dtpDateEstablished.Value.ToString("yyyy-MM-dd") + "'   "+
                "WHERE `station_id`='" + station_id + "';", listStations);
            MessageBox.Show("Record successfully updated", "VIew Station Record");
            refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + listStations.SelectedItem.ToString(), "Delete Stations", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Sql.fiil_listBox("DELETE FROM `stations` WHERE `station_id`='" + station_id + "';", listStations);
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
