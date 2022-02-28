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
        public string user_status="";
        public string by;
        public string filter;
        public string text;        
        public string id = "";
        int parishioner_id = 0;
        int current_row_no = 0;
        SQLConfig Sql = new SQLConfig();
        usableFunction usf = new usableFunction();

        private int mRow = 0;
        private bool newpage = true;
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
                btnDeleteParishionerRecord.Hide();
            }else
            {
                groupBox3.Hide();
            }

            if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                groupBox3.Hide(); btnEditMemberDetails.Hide(); btnMarkActive.Hide(); btnMarkDead.Hide(); btnMarkInactive.Hide(); btnDeleteParishionerRecord.Hide();
            }

            refresh();
            cmbSearchBy.SelectedIndex = 0;

            txtRowNo.Text = current_row_no.ToString();
            txtRowCount.Text = current_row_no.ToString();
            if (dataGridView1.RowCount > 0)
            {
                txtRowCount.Text = (dataGridView1.RowCount).ToString();
            }


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

                 if (MessageBox.Show("Are you sure you want to delete "+ dataGridView1.CurrentRow.Cells[2].Value.ToString(),"Delete Member",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (filter == "pious_society" | filter == "other_groups")
                    {
                        Sql.Execute_Query("DELETE FROM `"+ by +"` WHERE `member_id`='"+ parishioner_id +"';");
                        if (!Sql.result) { return; }
                        Sql.Execute_Query("DELETE FROM `parishioner_groups` WHERE `parishioner_id`='" + parishioner_id + "' AND `group_code_name`='"+ by +"';");
                        if (!Sql.result) { return; }
                    }

                    MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " successfully deleted", "Delete Member");
                    refresh();

                    current_row_no = 0;
                    txtRowNo.Text = current_row_no.ToString();
                    if (dataGridView1.RowCount > 0)
                    {
                        txtRowCount.Text = (dataGridView1.RowCount).ToString();
                    }

                }
            }
        }



        private void refresh()
        {
            if (by == "all")
            {
                Sql.Load_DTG("select p.`parishioner_id`,p.`regNo` as 'Reg. No.',concat(p.`title`,' ',p.`name`) as 'Name',p.`gender` as 'Gender'," +
                    "p.`dob` as 'Date of Birth',p.`address` as 'Address',p.`phoneNo` as 'Phone Number',p.`email` as 'Email'," +
                    "soo.`state` as 'State',loo.`lga` as 'LGA',d.`diocese` as 'Diocese',p.`parishOfOrigin` as 'Parish',p.`maritalStatus` as 'Marital Status'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded',p.`status` as 'Status'"+
                    "from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`"+
                    "left join `state_of_origin` soo on soo.`state_id`=p.`stateOfOrigin`" +
                    "left join `lga_of_origin` loo on loo.`lga_id`=p.`lgaOfOrigin`" +
                    "left join `diocese` d on d.`dioceseId`=p.`dioceseOfOrigin`" +
                    "WHERE p.`status`<>'dead';", dataGridView1);
            }

            else if (filter == "sacrament")
            {
                Sql.Load_DTG("select p.`parishioner_id`,p.`regNo` as 'Reg. No.',concat(p.`title`,' ',p.`name`) as 'Name',p.`gender` as 'Gender'," +
                    "p.`dob` as 'Date of Birth',p.`address` as 'Address',p.`phoneNo` as 'Phone Number',p.`email` as 'Email'," +
                    "soo.`state` as 'State',loo.`lga` as 'LGA',d.`diocese` as 'Diocese',p.`parishOfOrigin` as 'Parish',p.`maritalStatus` as 'Marital Status'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded',p.`status` as 'Status'" +
                    "from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`" +
                    "left join `state_of_origin` soo on soo.`state_id`=p.`stateOfOrigin`" +
                    "left join `lga_of_origin` loo on loo.`lga_id`=p.`lgaOfOrigin`" +
                    "left join `diocese` d on d.`dioceseId`=p.`dioceseOfOrigin`" + 
                    "where p.`" + by + "`='true' AND p.`status`<>'dead';", dataGridView1);
            }
            else if (filter == "pious_society" || filter == "other_groups")
            {
                Sql.Load_DTG("select p.`parishioner_id`,p.`regNo` as 'Reg. No.',concat(p.`title`,' ',p.`name`) as 'Name',p.`gender` as 'Gender'," +
                    "p.`dob` as 'Date of Birth',p.`address` as 'Address',p.`phoneNo` as 'Phone Number',p.`email` as 'Email'," +
                    "soo.`state` as 'State',loo.`lga` as 'LGA',d.`diocese` as 'Diocese',p.`parishOfOrigin` as 'Parish',p.`maritalStatus` as 'Marital Status'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded',p.`status` as 'Status'" +
                    "from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`" +
                    "left join `state_of_origin` soo on soo.`state_id`=p.`stateOfOrigin`" +
                    "left join `lga_of_origin` loo on loo.`lga_id`=p.`lgaOfOrigin`" +
                    "left join `diocese` d on d.`dioceseId`=p.`dioceseOfOrigin`" +
                    "JOIN `" + by + "` b ON b.`member_id`=p.`parishioner_id`" +
                    "WHERE p.`status`<>'dead';", dataGridView1);
            }
            else if (filter != "")
            {
                Sql.Load_DTG("select p.`parishioner_id`,p.`regNo` as 'Reg. No.',concat(p.`title`,' ',p.`name`) as 'Name',p.`gender` as 'Gender'," +
                    "p.`dob` as 'Date of Birth',p.`address` as 'Address',p.`phoneNo` as 'Phone Number',p.`email` as 'Email'," +
                    "soo.`state` as 'State',loo.`lga` as 'LGA',d.`diocese` as 'Diocese',p.`parishOfOrigin` as 'Parish',p.`maritalStatus` as 'Marital Status'," +
                    "st.`name` as 'Station',so.`name` as 'Society',o.`short_name` as 'Organisation'," +
                    "p.`baptised` as 'Baptised',p.`communicant` as 'Communicant',p.`confirmed` as 'Confirmed'," +
                    "p.`wedded` as 'Wedded',p.`status` as 'Status'" +
                    "from `parishioners` p " +
                    "left join `stations` st on p.`station`=st.`station_id`" +
                    "left join `societies` so on so.`society_id`=p.`society`" +
                    "left join `organisation` o on o.`organisation_id`=p.`organisation`" +
                    "left join `state_of_origin` soo on soo.`state_id`=p.`stateOfOrigin`" +
                    "left join `lga_of_origin` loo on loo.`lga_id`=p.`lgaOfOrigin`" +
                    "left join `diocese` d on d.`dioceseId`=p.`dioceseOfOrigin`" +
                    "where p.`" + filter + "`='" + by + "' AND p.`status`<>'dead';", dataGridView1);
            }
            //else
            //{
            //    Sql.Load_DTG("SELECT * FROM `parishioners` where `" + by + "`='true';", dataGridView1);
            //}
            if (!Sql.result) { return; }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 30;
            //dataGridView1.Columns[2].Width = 100;
            //dataGridView1.Columns[3].Width = 100;
            //dataGridView1.Columns[5].Width = 80;
            //dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 120;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
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
           // Refer to cell_click event listener
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

                if (MessageBox.Show("Are you sure you want to mark " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + " as dead", "Mark Member as Dead",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmDeathDate frm = new frmDeathDate();

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Sql.Execute_Insert("INSERT INTO `death`(`parishioner_id`,`death_date`,`burial_date`) VALUES('" + parishioner_id + "','" + frm.burialDate + "','" + frm.deathDate + "');");
                        if (!Sql.result) { return; }
                        Sql.Execute_Query("UPDATE `parishioners` SET `status`='dead' WHERE `parishioner_id`='" + parishioner_id + "';");
                        if (!Sql.result) { return; }
                        MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " successfully marked as dead", "Mark Member as Dead");
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
                MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " is already inactive");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to mark " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + " as inactive", "Mark Member as Inactive", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Sql.Execute_Query("UPDATE `parishioners` SET `status`='inactive' WHERE `parishioner_id`='" + parishioner_id + "';");
                    if (!Sql.result) { return; }
                    MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " successfully marked as inactive", "Mark Member as Inactive");
                    refresh();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();

            current_row_no = 0;
            txtRowNo.Text = current_row_no.ToString();
            if (dataGridView1.RowCount > 0)
            {
                txtRowCount.Text = (dataGridView1.RowCount).ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex != -1)
            {
                string searchBy = cmbSearchBy.SelectedItem.ToString();
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "`" + searchBy + "`" + " LIKE '%" + txtSearch.Text + "%'";
                dataGridView1.Refresh();

                current_row_no = 0;
                txtRowNo.Text = current_row_no.ToString();
                if (dataGridView1.RowCount > 0)
                {
                    txtRowCount.Text = (dataGridView1.RowCount).ToString();
                }
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
                MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " is already active");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to mark " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + " as active", "Mark Member as Active", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Sql.Execute_Query("UPDATE `parishioners` SET `status`='active' WHERE `parishioner_id`='" + parishioner_id + "';");
                    if (!Sql.result) { return; }
                    MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " successfully marked as active", "Mark Member as Active");
                    refresh();
                }
            }

        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (parishioner_id != 0)
            {
                frmViewFullParishionerDetail frm = new frmViewFullParishionerDetail();
                frm.parishioner_id = parishioner_id;
                frm.Show();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            usf.SaveRecord(dataGridView1);
        }

        private void txtRowNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRowNo.Text.Trim()))
            {
                if (int.Parse(txtRowNo.Text.Trim()) > 0 && int.Parse(txtRowNo.Text.Trim()) <= dataGridView1.RowCount)
                {
                    current_row_no = int.Parse(txtRowNo.Text.Trim()) - 1;

                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[current_row_no].Selected = true;
                }

            }
        }

        private void txtRowNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if ((new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }).Contains(e.KeyChar) == false)
                {
                    e.Handled = true; 
                }
            }
        }

        private void txtRowNo_KeyUp(object sender, KeyEventArgs e)
        {
        //    if ((new int[] { 8, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105 }).Contains(e.KeyValue)) {
        //        e.Handled = true;
        //    }
        }


        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                current_row_no = dataGridView1.RowCount - 1;
                dataGridView1.ClearSelection();
                dataGridView1.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0 && current_row_no < dataGridView1.RowCount - 1)
            {
                current_row_no += 1;
                dataGridView1.ClearSelection();
                dataGridView1.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount  > 0 && current_row_no > 0)
            {
                current_row_no -= 1;
                dataGridView1.ClearSelection();
                dataGridView1.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                current_row_no = 0;
                dataGridView1.ClearSelection();
                dataGridView1.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnDeleteParishionerRecord_Click(object sender, EventArgs e)
        {
            if (parishioner_id != 0)
            {

                if (MessageBox.Show("Are you sure you want to permanently delete record of " + dataGridView1.CurrentRow.Cells[2].Value.ToString(), "Delete Parishioner Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // get all groups parishioner belongs to
                    Sql.ReadData("SELECT `group_code_name` FROM `parishioner_groups` WHERE `parishioner_id`='"+ parishioner_id +"';");
                    if (!Sql.result){ return;}
                    if (Sql.dr.HasRows)
                    {
                        string group = string.Empty;
                        while (Sql.dr.Read())
                        {
                            group = Sql.dr.GetString("group_code_name");
                            Sql.Execute_Query("DELETE FROM `"+ group +"` WHERE `parishioner_id`='" + parishioner_id + "';");
                            if (!Sql.result) { return; }
                        }
                    }
                    
                    Sql.Execute_Query("DELETE FROM `parishioners` WHERE `parishioner_id`='" + parishioner_id + "';");
                    if (!Sql.result) { return; }
                    Sql.Execute_Query("DELETE FROM `parishioner_groups` WHERE `parishioner_id`='" + parishioner_id + "';");
                    if (!Sql.result) { return; }

                    MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " successfully deleted", "Delete Parishioner Record");
                    refresh();

                    current_row_no = 0;
                    txtRowNo.Text = current_row_no.ToString();
                    if (dataGridView1.RowCount > 0)
                    {
                        txtRowCount.Text = (dataGridView1.RowCount).ToString();
                    }

                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmViewFullParishionerDetail frm = new frmViewFullParishionerDetail(parishioner_id);
            frm.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            parishioner_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (dataGridView1.RowCount > 0)
            {
                current_row_no = e.RowIndex;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }
    }
}
