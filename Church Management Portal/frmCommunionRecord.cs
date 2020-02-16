using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Church_Management_Portal
{
    public partial class frmCommunionRecord : Form
    {

        SQLConfig Sql = new SQLConfig();
        string parishioner_id = "";


        public frmCommunionRecord()
        {
            InitializeComponent();
        }
        

        private void frmCommunionRecord_Load(object sender, EventArgs e)
        {
            refresh();
            cmbSearchBy.SelectedIndex = 0;
        }

        private void refresh()
        {
            Sql.Load_DTG("select p.`parishioner_id`, p.`name` as 'Name', /* p.`address` as 'Address', */" +
                    "/* p.`gender` as 'Gender',p.`dob` as 'Date of Birth', */" +
                    "b.`date_received` AS 'Date',b.`minister` AS 'Minister',b.`venue` AS 'Venue',b.`sponsor` AS 'Sponsor'" +
                    "from `parishioners` p JOIN `communion` b on p.`parishioner_id`=b.`parishioner_id`;", dgvCommunionRegister);

            dgvCommunionRegister.Columns[0].Visible = false;
        }

        private void btnAddNewRecord_Click_1(object sender, EventArgs e)
        {
            panelAddNewParishioner.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sponsor = txtSponsor.Text;
            string venue = txtVenue.Text;
            string minister = txtMinister.Text;
            string dateReceived = dtpDate.Value.ToString("yyyy-MM-dd");

            Sql.Execute_Insert("INSERT INTO `communion`(" +
                "`parishioner_id`,`date_received`,`minister`,`venue`,`sponsor`) VALUES(" +
                "'" + parishioner_id + "','" + dateReceived + "','" + minister + "','" + venue + "','" + sponsor + "');");

            MessageBox.Show("Name successfully entered into the communion register", "Add New Communion Record");
            refresh();
        }

        private void dgvListOfParishioners_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            parishioner_id = dgvListOfParishioners.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvListOfParishioners.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rdExistingParishioner.Checked = false;
            rdNewParishioner.Checked = false;
            txtMinister.Clear();
            txtName.Clear();
            txtSponsor.Clear();
            txtVenue.Clear();
            dtpDate.Value = DateTime.Now;
        }

        private void rdNewParishioner_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNewParishioner.Checked)
            {
                MessageBox.Show("Register Parishioner to proceed", "Add New Communion Record");
                frmAddParishioner frm = new frmAddParishioner();
                frm.ShowDialog();
            }
        }

        private void rdExistingParishioner_CheckedChanged(object sender, EventArgs e)
        {
            if (rdExistingParishioner.Checked)
            {
                gbListOfParishioners.Show();
            }
            else
            {
                gbListOfParishioners.Hide();
            }
        }

        private void gbListOfParishioners_Enter(object sender, EventArgs e)
        {

        }

        private void gbListOfParishioners_VisibleChanged(object sender, EventArgs e)
        {
            if (gbListOfParishioners.Visible == true)
            {
                Sql.Load_DTG("select p.`parishioner_id`,p.`name` as 'Name',p.`address` as 'Address'," +
                    "p.`gender` as 'Gender',p.`dob` as 'Date of Birth'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`status` as 'Status' from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`;", dgvListOfParishioners);

                dgvListOfParishioners.Columns[0].Visible = false;

            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (dgvListOfParishioners.DataSource != null)
            {
                //Sql.dt.Select("SELECT * WHERE `Name` LIKE '%" + txtName.Text + "%'");
                (dgvListOfParishioners.DataSource as DataTable).DefaultView.RowFilter = "Name LIKE '%" + txtName.Text + "%'";
                dgvListOfParishioners.Refresh();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex != -1)
            {
                string searchBy = cmbSearchBy.SelectedItem.ToString();
                (dgvCommunionRegister.DataSource as DataTable).DefaultView.RowFilter = "`" + searchBy + "`" + " LIKE '%" + txtSearch.Text + "%'";
                dgvCommunionRegister.Refresh();
            }
            else
            {
                MessageBox.Show("Choose a field to use in searching to proceed");
                cmbSearchBy.Focus();
            }
        }


        private int mRow = 0;
        private Boolean newpage = true;
        private int no_of_pages = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // sets it to show '...' for long text
            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
            fmt.LineAlignment = StringAlignment.Center;
            fmt.Trimming = StringTrimming.EllipsisCharacter;
            int y = e.MarginBounds.Top;
            Rectangle rc;
            int x;
            int h = 0;
            DataGridViewRow row;



            if (newpage)
            {
                // print that the document was printed from my app
                e.Graphics.DrawString("Generated from churchms, a product of samaservices nig. ltd. ", new Font("TImes New Romans", 8, FontStyle.Italic), Brushes.Gray, new Point(y, e.MarginBounds.Left));

                if (no_of_pages == 0)
                {
                    // prints church information
                    e.Graphics.DrawString(Properties.Settings.Default.church_name, new Font("TImes New Romans", 12, FontStyle.Regular), Brushes.Black, new Point(e.MarginBounds.Left + 270, y + 10));
                    e.Graphics.DrawString(Properties.Settings.Default.church_address, new Font("TImes New Romans", 10, FontStyle.Regular), Brushes.Black, new Point(e.MarginBounds.Left + 320, y + 30));

                    e.Graphics.DrawString("Communion Register", new Font("TImes New Romans", 10, FontStyle.Regular), Brushes.Black, new Point(e.MarginBounds.Left + 320, y + 60));

                    y += 100;
                }
                else
                {
                    y += 20;
                }


                row = dgvCommunionRegister.Rows[mRow];
                x = e.MarginBounds.Left;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Visible)
                    {
                        rc = new Rectangle(x, y, cell.Size.Width, cell.Size.Height);

                        e.Graphics.FillRectangle(Brushes.LightGray, rc);
                        e.Graphics.DrawRectangle(Pens.Black, rc);

                        FormatCell(cell, fmt, rc);

                        e.Graphics.DrawString(dgvCommunionRegister.Columns[cell.ColumnIndex].HeaderText, dgvCommunionRegister.Font, Brushes.Black, rc, fmt);
                        x += rc.Width;
                        h = Math.Max(h, rc.Height);
                    }
                }
                y += h;

            }
            newpage = false;

            // now print the data for each row
            int thisNDX;
            for (thisNDX = mRow; thisNDX < dgvCommunionRegister.RowCount - 1; thisNDX++)
            {
                // no need to try to print the new row
                if (dgvCommunionRegister.Rows[thisNDX].IsNewRow) { break; }

                row = dgvCommunionRegister.Rows[thisNDX];
                x = e.MarginBounds.Left;
                h = 0;


                // print the data
                foreach (DataGridViewCell cell in row.Cells)
                {

                    if (cell.Visible)
                    {

                        rc = new Rectangle(x, y, cell.Size.Width, cell.Size.Height);


                        // SAMPLE CODE: How To setup a RowPrePaint rule
                        // if (rowsToPaint.Contains(mRow)) {
                        //    using (SolidBrush br = new SolidBrush(Color.MistyRose)){
                        //      e.Graphics.FillRectangle(br, rc);
                        //    }
                        // }

                        e.Graphics.DrawRectangle(Pens.Black, rc);

                        FormatCell(cell, fmt, rc);

                        e.Graphics.DrawString(cell.FormattedValue.ToString(), dgvCommunionRegister.Font, Brushes.Black, rc, fmt);

                        x += rc.Width;
                        h = Math.Max(h, rc.Height);
                    }

                }



                y += h;

                // next row to print
                mRow = thisNDX + 1;

                if (y + h > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    newpage = true;
                    no_of_pages += 1;
                    return;
                }
            }
        }


        private void FormatCell(DataGridViewCell cell, StringFormat fmt, Rectangle rc)
        {
            switch (dgvCommunionRegister.Columns[cell.ColumnIndex].DefaultCellStyle.Alignment)
            {
                case (DataGridViewContentAlignment.BottomRight | DataGridViewContentAlignment.MiddleRight):
                    fmt.Alignment = StringAlignment.Far;
                    rc.Offset(-1, 0);
                    break;
                case (DataGridViewContentAlignment.BottomCenter | DataGridViewContentAlignment.MiddleCenter):
                    fmt.Alignment = StringAlignment.Center;
                    break;
                default:
                    fmt.Alignment = StringAlignment.Near;
                    rc.Offset(2, 0);
                    break;
            }

        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            printRecord printDoc = new printRecord(dgvCommunionRegister, "Communion Register");
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
            usf.SaveRecord(dgvCommunionRegister);
        }
    }
}
