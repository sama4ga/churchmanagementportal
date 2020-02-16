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
    public partial class frmViewListOfParishioners : Form
    {
        public string by;
        public string filter;
        public string text;        
        public string id = "";
        int parishioner_id = 0;
        SQLConfig Sql = new SQLConfig();
        usableFunction usf = new usableFunction();

        private int mRow = 0;
        private Boolean newpage = true;
        private int no_of_pages = 0;
        string title = "";

        public frmViewListOfParishioners()
        {
            InitializeComponent();
        }

        private void frmViewListOfParishioners_Load(object sender, EventArgs e)
        {
            this.Text = "View List of Parishioners - " + text;
            if (filter == "pious_society" | filter == "other_groups")
            {
                groupBox3.Show();
            }
            else
            {
                groupBox3.Hide();
            }
            refresh();
            cmbSearchBy.SelectedIndex = 0;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            
            if (parishioner_id != 0)
            {                

                 if (MessageBox.Show("Are you sure you want to delete "+ dataGridView1.CurrentRow.Cells[1].Value.ToString(),"Delete Member",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (filter == "pious_society" | filter == "other_groups")
                    {
                        Sql.Execute_Query("DELETE FROM `"+ by +"` WHERE `member_id`='"+ parishioner_id +"';");
                        Sql.Execute_Query("DELETE FROM `parishioner_groups` WHERE `parishioner_id`='" + parishioner_id + "' AND `group_code_name`='"+ by +"';");
                    }

                    MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " successfully deleted", "Delete Member");
                    refresh();

                }
            }
        }



        private void refresh()
        {
            if (by == "all")
            {
                Sql.Load_DTG("select p.`parishioner_id`,p.`name` as 'Name',p.`address` as 'Address',p.`phoneNo` as 'Phone Number'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`status` as 'Status',p.`gender` as 'Gender',p.`dob` as 'Date of Birth'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded' from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`"+
                    "WHERE p.`status`<>'dead';", dataGridView1);
            }

            else if (filter == "sacrament")
            {
                //Sql.Load_DTG("SELECT * FROM `parishioners` p JOIN `" + by + "` b ON b.`parishioner_id`=p.`parishioner_id`;", dataGridView1);
                Sql.Load_DTG("select p.`parishioner_id`, p.`name` as 'Name',p.`address` as 'Address',p.`phoneNo` as 'Phone Number'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`status` as 'Status',p.`gender` as 'Gender',p.`dob` as 'Date of Birth'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded' from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`" +
                    "where p.`" + by + "`='true' AND p.`status`<>'dead';", dataGridView1);
            }
            else if (filter == "pious_society" || filter == "other_groups")
            {
                Sql.Load_DTG("select p.`parishioner_id`, p.`name` as 'Name',p.`address` as 'Address',p.`phoneNo` as 'Phone Number'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`status` as 'Status',p.`gender` as 'Gender',p.`dob` as 'Date of Birth'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded' from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`" +
                    "JOIN `" + by + "` b ON b.`member_id`=p.`parishioner_id`" +
                    "WHERE p.`status`<>'dead';", dataGridView1);
            }
            else if (filter != "")
            {
                Sql.Load_DTG("select p.`parishioner_id`, p.`name` as 'Name',p.`address` as 'Address',p.`phoneNo` as 'Phone Number'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`status` as 'Status',p.`gender` as 'Gender',p.`dob` as 'Date of Birth'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded' from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`" +
                    "where p.`" + filter + "`='" + by + "' AND p.`status`<>'dead';", dataGridView1);
            }
            //else
            //{
            //    Sql.Load_DTG("SELECT * FROM `parishioners` where `" + by + "`='true';", dataGridView1);
            //}

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
        }

        private void btnEditMemberDetails_Click(object sender, EventArgs e)
        {
            frmEditParishionerDetails frm = new frmEditParishionerDetails();
            if (parishioner_id != 0)
            {
                frm.parishioner_id = parishioner_id;
                frm.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            parishioner_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            frmAddNewMember frm = new frmAddNewMember();
           
            frm.group_codename = by;
            frm.group_longname = text;
            frm.group_type = filter;
            frm.Show();
    }

        private void btnMarkDead_Click(object sender, EventArgs e)
        {
            if (parishioner_id != 0)
            {

                if (MessageBox.Show("Are you sure you want to mark " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + " as dead", "Mark Member as Dead",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmDeathDate frm = new frmDeathDate();

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Sql.Execute_Insert("INSERT INTO `death`(`parishioner_id`,`death_date`,`burial_date`) VALUES('" + parishioner_id + "','" + frm.burialDate + "','" + frm.deathDate + "');");
                        Sql.Execute_Query("UPDATE `parishioners` SET `status`='dead' WHERE `parishioner_id`='" + parishioner_id + "';");
                        MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " successfully marked as dead", "Mark Member as Dead");
                        refresh();
                    }

                    

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnMarkInactive_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[7].Value.ToString().Equals("Inactive"))
            {
                MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " is already inactive");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to mark " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + " as inactive", "Mark Member as Inactive", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Sql.Execute_Query("UPDATE `parishioners` SET `status`='inactive' WHERE `parishioner_id`='" + parishioner_id + "';");
                    MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " successfully marked as inactive", "Mark Member as Inactive");
                    refresh();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex != -1)
            {
                string searchBy = cmbSearchBy.SelectedItem.ToString();
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "`" + searchBy + "`" + " LIKE '%" + txtSearch.Text + "%'";
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Choose a field to use in searching to proceed");
                cmbSearchBy.Focus();
            }
            
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex != -1)
            {
                string searchBy = cmbSearchBy.SelectedItem.ToString();
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "`" + searchBy + "`" + " LIKE '%" + txtSearch.Text + "%'";
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Choose a field to use in searching to proceed");
                cmbSearchBy.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (text == "All")
            {
                title = "List of All Parishioners";
            }
            else
            {
                title = "List of Memebrs in " + text;
            }

            printRecord printDoc = new printRecord(dataGridView1,title);
            //PrintDocument printDoc = printDocument1;
            //printDoc.DefaultPageSettings.Margins =new  Margins(15, 15, 40, 15);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDoc;

            if (ppd.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

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

                    e.Graphics.DrawString(title, new Font("TImes New Romans", 10, FontStyle.Regular), Brushes.Black, new Point(e.MarginBounds.Left + 320, y + 60));

                    y += 100;
                }
                else
                {
                    y += 20;
                }


                row = dataGridView1.Rows[mRow];
                x = e.MarginBounds.Left;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Visible)
                    {
                        rc = new Rectangle(x, y, cell.Size.Width, cell.Size.Height);

                        e.Graphics.FillRectangle(Brushes.LightGray, rc);
                        e.Graphics.DrawRectangle(Pens.Black, rc);

                        FormatCell(cell, fmt, rc);

                        e.Graphics.DrawString(dataGridView1.Columns[cell.ColumnIndex].HeaderText, dataGridView1.Font, Brushes.Black, rc, fmt);
                        x += rc.Width;
                        h = Math.Max(h, rc.Height);
                    }
                }
                y += h;

            }
            newpage = false;

            // now print the data for each row
            int thisNDX;
            for (thisNDX = mRow; thisNDX < dataGridView1.RowCount - 1; thisNDX++)
            {
                // no need to try to print the new row
                if (dataGridView1.Rows[thisNDX].IsNewRow) { break; }

                row = dataGridView1.Rows[thisNDX];
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

                        e.Graphics.DrawString(cell.FormattedValue.ToString(), dataGridView1.Font, Brushes.Black, rc, fmt);

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
            switch (dataGridView1.Columns[cell.ColumnIndex].DefaultCellStyle.Alignment)
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

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            mRow = 0;
            newpage = true;
        }

        private void btnMarkActive_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[7].Value.ToString().Equals("Active"))
            {
                MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " is already active");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to mark " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + " as active", "Mark Member as Active", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Sql.Execute_Query("UPDATE `parishioners` SET `status`='active' WHERE `parishioner_id`='" + parishioner_id + "';");
                    MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " successfully marked as active", "Mark Member as Active");
                    refresh();
                }
            }

        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            frmViewParishionerDetails frm = new frmViewParishionerDetails();
            if (parishioner_id != 0)
            {
                frm.parishioner_id = parishioner_id;
                frm.Show();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            usf.SaveRecord(dataGridView1);
        }
    }
}
