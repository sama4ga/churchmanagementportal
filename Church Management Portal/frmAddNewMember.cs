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
    public partial class frmAddNewMember : Form
    {
        SQLConfig Sql = new SQLConfig();
        public string group_codename;
        public string group_longname;
        public string group_type;

        public frmAddNewMember()
        {
            InitializeComponent();
        }

        private void frmAddNewMember_Load(object sender, EventArgs e)
        {
            this.Text = "Add members to " + group_longname;
            Sql.Load_DTG("select p.`parishioner_id`, p.`name` as 'Name',p.`address` as 'Address'," +
                   "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                   "p.`status` as 'Status',p.`gender` as 'Gender',p.`dob` as 'Date of Birth'," +
                   "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                   "p.`wedded` as 'Wedded' from `parishioners` p " +
                   "left join `stations` st on p.`station`=st.`station_id`" +
                   "left join `societies` so on so.`society_id`=p.`society`" +
                   "left join `organisation` o on o.`organisation_id`=p.`organisation`" +
                   "LEFT JOIN `" + group_codename + "` b ON b.`member_id`=p.`parishioner_id`"+
                   "WHERE p.`status`<>'dead';", dataGridView1);

            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //int parishionerId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (dataGridView1.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int parishionerId = int.Parse(row.Cells[0].Value.ToString());

                    Sql.maxrow("SELECT * FROM `" + group_codename + "` WHERE `member_id`='" + parishionerId + "';","check");
                    if (Sql.ds.Tables["check"].Rows.Count > 0)
                    {
                        MessageBox.Show("Parishioner is already a member of "+ group_longname);
                    }
                    else
                    {
                        Sql.Execute_Insert("INSERT INTO `" + group_codename + "`(`member_id`) VALUES('" + parishionerId + "');");
                        Sql.Execute_Insert("INSERT INTO `parishioner_groups`(`parishioner_id`,`group_code_name`,`group_name`,`group_type`) VALUES('" + parishionerId + "','" + group_codename + "','" + group_longname + "','" + group_type + "');");
                        MessageBox.Show("Parishioner successfully added to " + group_longname);
                    }

                }

            }



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //DataGridViewCell() match = (from DataGridViewRow row in dataGridView1.Rows from DataGridViewCell cell in row.Cells select cell where cstr(cell.formattedvalue).equals(txtSearch.Text)).toarray();
            //DataGridViewCell() match = (from DataGridViewRow row in dataGridView1.Rows from DataGridViewCell cell in row.Cells select  cell where cstr(cell.formattedvalue).contains(txtSearch.text))).toarray();
           (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Name LIKE '%" + txtSearch.Text + "%'";  // Sql.ds.Tables[0]
            dataGridView1.Refresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Name LIKE LIKE '%" + txtSearch.Text + "%'";  // Sql.ds.Tables[0]
            dataGridView1.Refresh();
        }
    }
}
