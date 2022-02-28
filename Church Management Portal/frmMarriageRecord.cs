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
    public partial class frmMarriageRecord : Form
    {

        SQLConfig Sql = new SQLConfig();
        public string user_status = "";


        public frmMarriageRecord()
        {
            InitializeComponent();
        }

        private void frmMarriageRecord_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("secretary", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDeleteRecord.Visible = false; btnEditRecord.Visible = false; btnUpdate.Visible = false;
            }
            else if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDeleteRecord.Visible = false; btnEditRecord.Visible = false; btnUpdate.Visible = false; btnAddNewRecord.Visible = false;
            }
            refresh();
        }


        private void refresh()
        {
            Sql.Load_DTG("SELECT `marriage_id`,`groom_name` AS 'Groom\\'s Name',`groom_parent` AS 'Groom\\'s Parent',`groom_village` AS 'Groom\\'s Village',"+
               "`bride_name` AS 'Bride\\'s Name',`bride_parent` AS 'Bride\\'s Parent',`bride_village` AS 'Bride\\'s Village'," +
               "`sponsor` AS 'Sponsor',`minister` AS 'Witness',`venue` AS 'Venue',`date_received` AS 'Date Received' FROM `matrimony`; ", dgvMarriageRegister);
            if (!Sql.result) { return; }
            dgvMarriageRegister.Columns[0].Visible = false;

            current_row_no = 0;
            txtRowNo.Text = current_row_no.ToString();
            if (dgvMarriageRegister.RowCount > 0)
            {
                txtRowCount.Text = (dgvMarriageRegister.RowCount).ToString();
            }
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            panelAddNewParishioner.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBrideName.Clear();
            txtBrideParent.Clear();
            txtBrideVillage.Clear();
            txtGroomName.Clear();
            txtGroomParent.Clear();
            txtGroomVillage.Clear();
            txtSponsor.Clear();
            txtVenue.Clear();
            txtWitness.Clear();
            dtpDate.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGroomName.Text.Trim()))
            {
                MessageBox.Show("Groom's name is required");return;
            }
            if (string.IsNullOrWhiteSpace(txtGroomParent.Text.Trim()))
            {
                MessageBox.Show("Groom Parent's name is required"); return;
            }
            if (string.IsNullOrWhiteSpace(txtGroomVillage.Text.Trim()))
            {
                MessageBox.Show("Groom's  village is required"); return;
            }
            if (string.IsNullOrWhiteSpace(txtBrideName.Text.Trim()))
            {
                MessageBox.Show("Bride's name is required"); return;
            }
            if (string.IsNullOrWhiteSpace(txtBrideParent.Text.Trim()))
            {
                MessageBox.Show("Bride Parent's name is required"); return;
            }
            if (string.IsNullOrWhiteSpace(txtBrideVillage.Text.Trim()))
            {
                MessageBox.Show("Bride's village is required"); return;
            }
            if (string.IsNullOrWhiteSpace(txtSponsor.Text.Trim()))
            {
                MessageBox.Show("Sponsor's name is required"); return;
            }
            if (string.IsNullOrWhiteSpace(txtWitness.Text.Trim()))
            {
                MessageBox.Show("Minister's name is required"); return;
            }
            if (string.IsNullOrWhiteSpace(txtVenue.Text.Trim()))
            {
                MessageBox.Show("Venue name is required"); return;
            }

            List<string> param = new List<string>();
            param.Add(txtGroomName.Text.Trim());
            param.Add(txtGroomParent.Text);
            param.Add(txtGroomVillage.Text.Trim());
            param.Add(txtBrideName.Text.Trim());
            param.Add(txtBrideParent.Text.Trim());
            param.Add(txtBrideVillage.Text.Trim());
            param.Add(txtSponsor.Text.Trim());
            param.Add(txtWitness.Text.Trim());
            param.Add(txtVenue.Text.Trim());
            param.Add(dtpDate.Value.ToString("yyyy-MM-dd"));
            long insertId = 0;

            Sql.InsertQuery("INSERT INTO `matrimony`("+
                "`groom_name`,`groom_parent`,`groom_village`,`bride_name`,`bride_parent`,`bride_village` ,  "+
               "`sponsor`,`minister`,`venue`,`date_received`) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10 );",param,out insertId);
            if (!Sql.result) { return; }
            MessageBox.Show("Record successfully added","View Marriage Record");
            refresh();
            btnClear.PerformClick();
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

                    e.Graphics.DrawString("Marriage Register", new Font("TImes New Romans", 10, FontStyle.Regular), Brushes.Black, new Point(e.MarginBounds.Left + 320, y + 60));

                    y += 100;
                }
                else
                {
                    y += 20;
                }


                row = dgvMarriageRegister.Rows[mRow];
                x = e.MarginBounds.Left;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Visible)
                    {
                        rc = new Rectangle(x, y, cell.Size.Width, cell.Size.Height);

                        e.Graphics.FillRectangle(Brushes.LightGray, rc);
                        e.Graphics.DrawRectangle(Pens.Black, rc);

                        FormatCell(cell, fmt, rc);

                        e.Graphics.DrawString(dgvMarriageRegister.Columns[cell.ColumnIndex].HeaderText, dgvMarriageRegister.Font, Brushes.Black, rc, fmt);
                        x += rc.Width;
                        h = Math.Max(h, rc.Height);
                    }
                }
                y += h;

            }
            newpage = false;

            // now print the data for each row
            int thisNDX;
            for (thisNDX = mRow; thisNDX < dgvMarriageRegister.RowCount - 1; thisNDX++)
            {
                // no need to try to print the new row
                if (dgvMarriageRegister.Rows[thisNDX].IsNewRow) { break; }

                row = dgvMarriageRegister.Rows[thisNDX];
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

                        e.Graphics.DrawString(cell.FormattedValue.ToString(), dgvMarriageRegister.Font, Brushes.Black, rc, fmt);

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
            switch (dgvMarriageRegister.Columns[cell.ColumnIndex].DefaultCellStyle.Alignment)
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
            printRecord printDoc = new printRecord(dgvMarriageRegister, "Marriage Regster");
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
            usf.SaveRecord(dgvMarriageRegister);
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            dgvMarriageRegister.ReadOnly = false;
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (dgvMarriageRegister.CurrentRow != null)
            {
                string name = dgvMarriageRegister.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show("Are you sure you want to delete record of " + name + " from the marriage register", "Delete Marriage Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Sql.Execute_Query("DELETE FROM `matrimony` WHERE `marriage_id`='" + marriage_id + "';");
                    if (!Sql.result) { return; }
                    MessageBox.Show("Record of " + name + " successfully deleted.");
                    refresh();
                }
            }
        }

        string marriage_id;
        private void dgvMarriageRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            marriage_id = dgvMarriageRegister.CurrentRow.Cells[0].Value.ToString();
            if (dgvMarriageRegister.RowCount > 0)
            {
                current_row_no = e.RowIndex;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        List<string> query = new List<string>();
        private void dgvMarriageRegister_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string column = dgvMarriageRegister.Columns[e.ColumnIndex].Name.Replace("'s", "").Replace(" ","_").ToLower();
            string marriage_id = dgvMarriageRegister.Rows[e.RowIndex].Cells[0].Value.ToString();
            string new_value = dgvMarriageRegister.CurrentCell.Value.ToString();
            //MessageBox.Show(column + " - " + old_value);
            query.Add("UPDATE `matrimony` SET `"+ column +"`='"+ new_value +"' WHERE `marriage_id`='"+ marriage_id +"';");
            if (!Sql.result) { return; }
        }

        string old_value = string.Empty;
        private int current_row_no;

        private void dgvMarriageRegister_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            old_value = dgvMarriageRegister.CurrentCell.Value.ToString();
            dgvMarriageRegister.CurrentCell.Style.ForeColor = Color.Green;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (string item in query)
            {
                Sql.Execute_Query(item);
                if (!Sql.result) { return; }
            }
            MessageBox.Show("Update successful","Update Record");
            query.Clear();
            refresh();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvMarriageRegister.RowCount > 0)
            {
                current_row_no = dgvMarriageRegister.RowCount - 1;
                dgvMarriageRegister.ClearSelection();
                dgvMarriageRegister.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvMarriageRegister.RowCount > 0 && current_row_no < dgvMarriageRegister.RowCount - 1)
            {
                current_row_no += 1;
                dgvMarriageRegister.ClearSelection();
                dgvMarriageRegister.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvMarriageRegister.RowCount > 0 && current_row_no > 0)
            {
                current_row_no -= 1;
                dgvMarriageRegister.ClearSelection();
                dgvMarriageRegister.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvMarriageRegister.RowCount > 0)
            {
                current_row_no = 0;
                dgvMarriageRegister.ClearSelection();
                dgvMarriageRegister.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void txtRowNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRowNo.Text.Trim()))
            {
                if (int.Parse(txtRowNo.Text.Trim()) > 0 && int.Parse(txtRowNo.Text.Trim()) <= dgvMarriageRegister.RowCount)
                {
                    current_row_no = int.Parse(txtRowNo.Text.Trim()) - 1;

                    dgvMarriageRegister.ClearSelection();
                    dgvMarriageRegister.Rows[current_row_no].Selected = true;
                }

            }
        }

        private void txtRowNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvMarriageRegister.RowCount > 0)
            {
                if ((new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }).Contains(e.KeyChar) == false)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex != -1)
            {
                string searchBy = cmbSearchBy.SelectedItem.ToString();
                (dgvMarriageRegister.DataSource as DataTable).DefaultView.RowFilter = "`" + searchBy + "`" + " LIKE '%" + txtSearch.Text + "%'";
                dgvMarriageRegister.Refresh();

                current_row_no = 0;
                txtRowNo.Text = current_row_no.ToString();
                if (dgvMarriageRegister.RowCount > 0)
                {
                    txtRowCount.Text = (dgvMarriageRegister.RowCount).ToString();
                }
            }
            else
            {
                MessageBox.Show("Choose a field to use in searching to proceed", "Marriage Register");
                cmbSearchBy.Focus();
            }
        }
    }
}
