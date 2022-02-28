using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Church_Management_Portal
{
    public partial class frmViewPriests : Form
    {

        SQLConfig sql = new SQLConfig();
        int priest_id = 0;
        public string user_status = "";

        private int mRow = 0;
        private Boolean newpage = true;
        private int no_of_pages = 0;
        int current_row_no = 0;


        public frmViewPriests()
        {
            InitializeComponent();
        }

        private void frmViewPriests_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("secretary", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDelete.Visible = false; btnUpdateSelected.Visible = false;
            }
            else if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDelete.Visible = false; btnUpdateSelected.Visible = false; btnAddShow.Visible = false;
            }

            cmbType.SelectedIndex = 0;
            refresh();
        }


        private void refresh()
        {
            sql.Load_DTG("SELECT `priest_id`,`priest_name` AS 'Name',`type` AS 'Type',`date_resumed` AS 'Date Resumed',`date_left` AS 'Date Left' FROM `priests`;", dgvListOfPriests);
            if (!sql.result) { return; }
            dgvListOfPriests.Columns[0].Visible = false;

            current_row_no = 0;
            txtRowNo.Text = current_row_no.ToString();
            if (dgvListOfPriests.RowCount > 0)
            {
                txtRowCount.Text = (dgvListOfPriests.RowCount).ToString();
            }
        }

        private void btnAddShow_Click(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 1;
            gbAdd.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Enter the name of the Priest to continue","View Priests"); return;
            }

            List<string> param = new List<string>();
            param.Add(txtName.Text.Trim());
            param.Add(cmbType.SelectedItem.ToString());
            param.Add(dtpDateResumed.Value.ToString("yyyy-MM-dd"));

            long insertId = 0;
            sql.InsertQuery("INSERT INTO `priests` (`priest_name`,`type`,`date_resumed`) VALUES(@1,@2,@3);", param, out insertId);
            if (!sql.result) { return; }
            MessageBox.Show("Record successfully added","View Priests");
            refresh();
        }

        private void btnUpdateSelected_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox3.Show();
        }

        private void dgvListOfPriests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // refer to cell_click event listener
        }

        private void groupBox1_VisibleChanged(object sender, EventArgs e)
        {
            //if (groupBox1.Visible == true & dgvListOfPriests.SelectedCells.Count > 0)
            //{
            //    txtNameUpdate.Text = dgvListOfPriests.CurrentRow.Cells[1].Value.ToString();
            //    cmbTypeUpdate.SelectedValue = dgvListOfPriests.CurrentRow.Cells[2].Value.ToString().ToUpperInvariant();
            //    dtpDateResumedUpdate.Value = (DateTime)dgvListOfPriests.CurrentRow.Cells[3].Value;
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvListOfPriests.SelectedCells.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(txtNameUpdate.Text.Trim()))
                {
                    MessageBox.Show("Priest name is required");return;
                }
                if (cmbTypeUpdate.SelectedIndex  == 0)
                {
                    MessageBox.Show("Select type to proceed"); return;
                }

                List<string> param = new List<string>();
                param.Add(txtNameUpdate.Text.Trim());
                param.Add(cmbTypeUpdate.SelectedItem.ToString());
                param.Add(dtpDateResumedUpdate.Value.ToString("yyyy-MM-dd"));
                param.Add(priest_id.ToString());
                long insertId = 0;

                sql.InsertQuery("UPDATE `priests` SET `priest_name`=@1,`type`=@2,`date_resumed`=@3 WHERE `priest_id`=@4;",param,out insertId);
                if (!sql.result) { return; }
                MessageBox.Show("Record successfully updated", "View Priests");
                refresh();
            }

        }

        private void btnAddTransferDate_Click(object sender, EventArgs e)
        {
            if (dgvListOfPriests.SelectedCells.Count > 0)
            {
                sql.Execute_Insert("UPDATE `priests` SET `date_left`='" + dtpTransferDate.Value.ToString("yyyy-MM-dd") + "' WHERE `priest_id`='"+ priest_id +"';");
                if (!sql.result) { return; }
                MessageBox.Show("Record successfully updated", "View Priests");
                refresh();
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printRecord printDoc = new printRecord(dgvListOfPriests, "Historical Record of Priests");
            //PrintDocument printDoc = printDocument1;
            //printDoc.DefaultPageSettings.Margins = new Margins(15, 15, 40, 15);

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

                    e.Graphics.DrawString("Historical Record of Priests who have served in the Parish", new Font("TImes New Romans", 10, FontStyle.Regular), Brushes.Black, new Point(e.MarginBounds.Left + 320, y + 60));

                    y += 100;
                }
                else
                {
                    y += 20;
                }


                row = dgvListOfPriests.Rows[mRow];
                x = e.MarginBounds.Left;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Visible)
                    {
                        rc = new Rectangle(x, y, cell.Size.Width, cell.Size.Height);

                        e.Graphics.FillRectangle(Brushes.LightGray, rc);
                        e.Graphics.DrawRectangle(Pens.Black, rc);

                        FormatCell(cell, fmt, rc);

                        e.Graphics.DrawString(dgvListOfPriests.Columns[cell.ColumnIndex].HeaderText, dgvListOfPriests.Font, Brushes.Black, rc, fmt);
                        x += rc.Width;
                        h = Math.Max(h, rc.Height);
                    }
                }
                y += h;

            }
            newpage = false;

            // now print the data for each row
            int thisNDX;
            for (thisNDX = mRow; thisNDX < dgvListOfPriests.RowCount - 1; thisNDX++)
            {
                // no need to try to print the new row
                if (dgvListOfPriests.Rows[thisNDX].IsNewRow) { break; }

                row = dgvListOfPriests.Rows[thisNDX];
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

                        e.Graphics.DrawString(cell.FormattedValue.ToString(), dgvListOfPriests.Font, Brushes.Black, rc, fmt);

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
            switch (dgvListOfPriests.Columns[cell.ColumnIndex].DefaultCellStyle.Alignment)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dgvListOfPriests.DataSource as DataTable).DefaultView.RowFilter = "`Name`" + " LIKE '%" + txtSearch.Text + "%'";
            dgvListOfPriests.Refresh();

            current_row_no = 0;
            txtRowNo.Text = current_row_no.ToString();
            if (dgvListOfPriests.RowCount > 0)
            {
                txtRowCount.Text = (dgvListOfPriests.RowCount).ToString();
            }
        }

        usableFunction usf = new usableFunction();
        private void btnExport_Click(object sender, EventArgs e)
        {
            usf.SaveRecord(dgvListOfPriests);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            priest_id = int.Parse(dgvListOfPriests.CurrentRow.Cells[0].Value.ToString());
            string name = dgvListOfPriests.CurrentRow.Cells[1].Value.ToString();

            if (MessageBox.Show("Are you sure you want to delete record of "+ name,"Delete Priest Record", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {
                sql.Execute_Query("DELETE FROM `priests` WHERE `priest_id`='" + priest_id + "';");
                if (!sql.result) { return; }
                MessageBox.Show("Record of " + name + " successfully deleted", "Delete Priest Record");
                refresh();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvListOfPriests.RowCount > 0)
            {
                current_row_no = dgvListOfPriests.RowCount - 1;
                dgvListOfPriests.ClearSelection();
                dgvListOfPriests.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvListOfPriests.RowCount > 0 && current_row_no < dgvListOfPriests.RowCount - 1)
            {
                current_row_no += 1;
                dgvListOfPriests.ClearSelection();
                dgvListOfPriests.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvListOfPriests.RowCount > 0 && current_row_no > 0)
            {
                current_row_no -= 1;
                dgvListOfPriests.ClearSelection();
                dgvListOfPriests.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvListOfPriests.RowCount > 0)
            {
                current_row_no = 0;
                dgvListOfPriests.ClearSelection();
                dgvListOfPriests.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void txtRowNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRowNo.Text.Trim()))
            {
                if (int.Parse(txtRowNo.Text.Trim()) > 0 && int.Parse(txtRowNo.Text.Trim()) <= dgvListOfPriests.RowCount)
                {
                    current_row_no = int.Parse(txtRowNo.Text.Trim()) - 1;

                    dgvListOfPriests.ClearSelection();
                    dgvListOfPriests.Rows[current_row_no].Selected = true;
                }

            }
        }

        private void txtRowNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvListOfPriests.RowCount > 0)
            {
                if ((new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }).Contains(e.KeyChar) == false)
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvListOfPriests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            priest_id = int.Parse(dgvListOfPriests.CurrentRow.Cells[0].Value.ToString());
            if (dgvListOfPriests.RowCount > 0)
            {
                current_row_no = e.RowIndex;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }


            if (groupBox1.Visible == true)
            {
                txtNameUpdate.Text = dgvListOfPriests.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbTypeUpdate.SelectedItem = dgvListOfPriests.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtpDateResumedUpdate.Value = (DateTime)dgvListOfPriests.CurrentRow.Cells[3].Value;
            }
        }
    }
}
