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
        public string user_status = "";

        public frmDeath()
        {
            InitializeComponent();
        }

        private void frmDeath_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("secretary", StringComparison.CurrentCultureIgnoreCase) || user_status.Equals("admin", StringComparison.CurrentCultureIgnoreCase))
            {
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }
            refresh();
            
        }

        private void refresh()
        {
            sql.Load_DTG("select p.`parishioner_id`,p.`name` as 'Name',p.`address` as 'Address'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`gender` as 'Gender',p.`dob` as 'Date of Birth',d.`death_date` as 'Date of Death',d.`burial_date` as 'Burial Date'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded' from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation` " +
                    "JOIN `death` d ON d.`parishioner_id`=p.`parishioner_id`;", dgvDeathList);
            if (!sql.result) { return; }
            dgvDeathList.Columns[0].Visible = false;

            current_row_no = 0;
            txtRowNo.Text = current_row_no.ToString();
            if (dgvDeathList.RowCount > 0)
            {
                txtRowCount.Text = (dgvDeathList.RowCount).ToString();
            }
        }

        private void dgvDeathList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            parishioner_id = int.Parse(dgvDeathList.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (dgvDeathList.RowCount > 0)
            {
                current_row_no = e.RowIndex;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }

            dtpDeathDate.Value = (DateTime)dgvDeathList.Rows[e.RowIndex].Cells["Date of Death"].Value;

            if (!string.IsNullOrEmpty(dgvDeathList.Rows[e.RowIndex].Cells["Burial Date"].Value.ToString()))
            {
                dtpBurialDate.Value = (DateTime)dgvDeathList.Rows[e.RowIndex].Cells["Burial Date"].Value;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sql.Execute_Query("UPDATE `death` SET `death_date`='"+ dtpDeathDate.Value.ToString("yyyy-MM-dd") + "',`burial_date`='" + dtpBurialDate.Value.ToString("yyyy-MM-dd") +"' WHERE `parishioner_id`='" + parishioner_id +"';");
            if (!sql.result) { return; }
            MessageBox.Show("Update Successful","Update Death Record");
            refresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dgvDeathList.DataSource as DataTable).DefaultView.RowFilter = "`Name`" + " LIKE '%" + txtSearch.Text + "%'";
            dgvDeathList.Refresh();

            current_row_no = 0;
            txtRowNo.Text = current_row_no.ToString();
            if (dgvDeathList.RowCount > 0)
            {
                txtRowCount.Text = (dgvDeathList.RowCount).ToString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printRecord printDoc = new printRecord(dgvDeathList, "Death Register");
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
        private int current_row_no;

        private void btnExport_Click(object sender, EventArgs e)
        {
            usf.SaveRecord(dgvDeathList);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvDeathList.RowCount > 0)
            {
                current_row_no = dgvDeathList.RowCount - 1;
                dgvDeathList.ClearSelection();
                dgvDeathList.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvDeathList.RowCount > 0 && current_row_no < dgvDeathList.RowCount - 1)
            {
                current_row_no += 1;
                dgvDeathList.ClearSelection();
                dgvDeathList.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvDeathList.RowCount > 0 && current_row_no > 0)
            {
                current_row_no -= 1;
                dgvDeathList.ClearSelection();
                dgvDeathList.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvDeathList.RowCount > 0)
            {
                current_row_no = 0;
                dgvDeathList.ClearSelection();
                dgvDeathList.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void txtRowNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRowNo.Text.Trim()))
            {
                if (int.Parse(txtRowNo.Text.Trim()) > 0 && int.Parse(txtRowNo.Text.Trim()) <= dgvDeathList.RowCount)
                {
                    current_row_no = int.Parse(txtRowNo.Text.Trim()) - 1;

                    dgvDeathList.ClearSelection();
                    dgvDeathList.Rows[current_row_no].Selected = true;
                }

            }
        }

        private void txtRowNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDeathList.RowCount > 0)
            {
                if ((new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }).Contains(e.KeyChar) == false)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
