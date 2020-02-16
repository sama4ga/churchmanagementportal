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
    public partial class frmDeath : Form
    {

        SQLConfig sql = new SQLConfig();
        int parishioner_id = 0;

        public frmDeath()
        {
            InitializeComponent();
        }

        private void frmDeath_Load(object sender, EventArgs e)
        {
            sql.Load_DTG("select p.`parishioner_id`,p.`name` as 'Name',p.`address` as 'Address'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`gender` as 'Gender',p.`dob` as 'Date of Birth',d.`death_date` as 'Date of Death',d.`burial_date` as 'Burial Date'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded' from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation` "+
                    "JOIN `death` d ON d.`parishioner_id`=p.`parishioner_id`;", dgvDeathList);
            dgvDeathList.Columns[0].Visible = false;
        }

        private void dgvDeathList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            parishioner_id = int.Parse(dgvDeathList.Rows[e.RowIndex].Cells[0].Value.ToString());

            dtpDeathDate.Value = (DateTime)dgvDeathList.Rows[e.RowIndex].Cells["Date of Death"].Value;

            if (!string.IsNullOrEmpty(dgvDeathList.Rows[e.RowIndex].Cells["Burial Date"].Value.ToString()))
            {
                dtpBurialDate.Value = (DateTime)dgvDeathList.Rows[e.RowIndex].Cells["Burial Date"].Value;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sql.Execute_Query("UPDATE `death` SET `death_date`='"+ dtpDeathDate.Value.ToString("yyyy-MM-dd") + "',`burial_date`='" + dtpBurialDate.Value.ToString("yyyy-MM-dd") +"' WHERE `parishioner_id`='" + parishioner_id +"';");
            MessageBox.Show("Update Successful","Update Death Record");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dgvDeathList.DataSource as DataTable).DefaultView.RowFilter = "`Name`" + " LIKE '%" + txtSearch.Text + "%'";
            dgvDeathList.Refresh();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printRecord printDoc = new printRecord(dgvDeathList, "Confirmation Register");
            //PrintDocument printDoc = printDocument1;
            //printDoc.DefaultPageSettings.Margins = new Margins(15, 15, 40, 15);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDoc;

            if (ppd.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        usableFunction usf = new usableFunction();
        private void btnExport_Click(object sender, EventArgs e)
        {
            usf.SaveRecord(dgvDeathList);
        }
    }
}
