﻿using System;
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
    public partial class frmConfirmationRecord : Form
    {

        SQLConfig Sql = new SQLConfig();
        string parishioner_id = "";
        public string user_status = "";


        public frmConfirmationRecord()
        {
            InitializeComponent();
        }

        private void frmConfirmationRecord_Load(object sender, EventArgs e)
        {
            if (user_status.Equals("secretary", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDelete.Visible = false; btnEditRecord.Visible = false;
            }
            else if (user_status.Equals("user", StringComparison.CurrentCultureIgnoreCase))
            {
                btnDelete.Visible = false; btnEditRecord.Visible = false; btnAddNewRecord.Visible = false;
            }
            refresh();
            cmbSearchBy.SelectedIndex = 0;
        }

        private void refresh() {
            Sql.Load_DTG("select p.`parishioner_id`,p.`name` as 'Name', /* p.`address` as 'Address', */" +
                    "/* p.`gender` as 'Gender',p.`dob` as 'Date of Birth', */" +
                    "b.`date_received` AS 'Date',b.`minister` AS 'Minister',b.`venue` AS 'Venue',b.`sponsor` AS 'Sponsor'" +
                    "from `parishioners` p JOIN `confirmation` b on p.`parishioner_id`=b.`parishioner_id`;", dgvConfirmationRegister);
            if (!Sql.result) { return; }
            dgvConfirmationRegister.Columns[0].Visible = false;

            current_row_no = 0;
            txtRowNo.Text = current_row_no.ToString();
            if (dgvConfirmationRegister.RowCount > 0)
            {
                txtRowCount.Text = (dgvConfirmationRegister.RowCount).ToString();
            }
        }


        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            gbAddNewRecord.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rdExistingParishioner.Checked == false & rdNewParishioner.Checked == false)
            {
                MessageBox.Show("Choose one method to identify the parishioner (either as existing or new)", "Add New Parishioner");
            }
            else if (int.Parse(parishioner_id) <= 0)
            {
                MessageBox.Show("You must choose a parishioner to proceed", "Add New Parishioner");
            }
            else
            {
                string sponsor = txtSponsor.Text;
                string venue = txtVenue.Text;
                string minister = txtMinister.Text;
                string dateReceived = dtpDate.Value.ToString("yyyy-MM-dd");

                Sql.Execute_Insert("INSERT INTO `confirmation`(" +
                    "`parishioner_id`,`date_received`,`minister`,`venue`,`sponsor`) VALUES(" +
                    "'" + parishioner_id + "','" + dateReceived + "','" + minister + "','" + venue + "','" + sponsor + "');");
                if (!Sql.result) { return; }
                MessageBox.Show("Name successfully entered into the confirmation register", "Add New Confirmation Record");
                refresh();
            }
        }

        private void dgvListOfParishioners_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >-1)
            {
                parishioner_id = dgvListOfParishioners.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvListOfParishioners.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
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
                MessageBox.Show("Register Parishioner to proceed", "Add New Confirmation Record");
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
                if (!Sql.result) { return; }
                dgvListOfParishioners.Columns[0].Visible = false;

            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
            //if (dgvListOfParishioners.DataSource != null)
            //{
            //    //Sql.ds.Tables[0].Select("Name LIKE '%" + txtName.Text + "%'");
            //    (dgvListOfParishioners.DataSource as DataTable).DefaultView.RowFilter = "Name LIKE '%" + txtName.Text + "%'";
            //    dgvListOfParishioners.Refresh();
            //}
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex != -1)
            {
                string searchBy = cmbSearchBy.SelectedItem.ToString();
                (dgvConfirmationRegister.DataSource as DataTable).DefaultView.RowFilter = "`" + searchBy + "`" + " LIKE '%" + txtSearch.Text + "%'";
                dgvConfirmationRegister.Refresh();

                current_row_no = 0;
                txtRowNo.Text = current_row_no.ToString();
                if (dgvConfirmationRegister.RowCount > 0)
                {
                    txtRowCount.Text = (dgvConfirmationRegister.RowCount).ToString();
                }
            }
            else
            {
                MessageBox.Show("Choose a field to use in searching to proceed", "Confirmation Register");
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

                    e.Graphics.DrawString("Confirmation Register", new Font("TImes New Romans", 10, FontStyle.Regular), Brushes.Black, new Point(e.MarginBounds.Left + 320, y + 60));

                    y += 100;
                }
                else
                {
                    y += 20;
                }


                row = dgvConfirmationRegister.Rows[mRow];
                x = e.MarginBounds.Left;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Visible)
                    {
                        rc = new Rectangle(x, y, cell.Size.Width, cell.Size.Height);

                        e.Graphics.FillRectangle(Brushes.LightGray, rc);
                        e.Graphics.DrawRectangle(Pens.Black, rc);

                        FormatCell(cell, fmt, rc);

                        e.Graphics.DrawString(dgvConfirmationRegister.Columns[cell.ColumnIndex].HeaderText, dgvConfirmationRegister.Font, Brushes.Black, rc, fmt);
                        x += rc.Width;
                        h = Math.Max(h, rc.Height);
                    }
                }
                y += h;

            }
            newpage = false;

            // now print the data for each row
            int thisNDX;
            for (thisNDX = mRow; thisNDX < dgvConfirmationRegister.RowCount - 1; thisNDX++)
            {
                // no need to try to print the new row
                if (dgvConfirmationRegister.Rows[thisNDX].IsNewRow) { break; }

                row = dgvConfirmationRegister.Rows[thisNDX];
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

                        e.Graphics.DrawString(cell.FormattedValue.ToString(), dgvConfirmationRegister.Font, Brushes.Black, rc, fmt);

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
            switch (dgvConfirmationRegister.Columns[cell.ColumnIndex].DefaultCellStyle.Alignment)
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
            printRecord printDoc = new printRecord(dgvConfirmationRegister,"Confirmation Register");
            //PrintDocument printDoc = printDocument1;
            //printDoc.DefaultPageSettings.Margins = new Margins(15, 15, 40, 15);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDoc;

            if (ppd.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        usableFunction usf = new usableFunction();
        private int current_row_no;

        private void btnExport_Click(object sender, EventArgs e)
        {
            usf.SaveRecord(dgvConfirmationRegister);
        }

        private void dgvListOfParishioners_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                parishioner_id = dgvListOfParishioners.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvListOfParishioners.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
        }
        
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgvListOfParishioners.DataSource != null)
            {
                //Sql.ds.Tables[0].Select("Name LIKE '%" + txtName.Text + "%'");
                (dgvListOfParishioners.DataSource as DataTable).DefaultView.RowFilter = "Name LIKE '%" + txtName.Text + "%'";
                dgvListOfParishioners.Refresh();
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            gbEditRecord.Visible = true;
        }

        private void dgvConfirmationRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            parishioner_id = dgvConfirmationRegister.CurrentRow.Cells[0].Value.ToString();
            if (dgvConfirmationRegister.RowCount > 0)
            {
                current_row_no = e.RowIndex;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }

            if (gbEditRecord.Visible)
            {
                txtNameUpdate.Text = dgvConfirmationRegister.CurrentRow.Cells["Name"].Value.ToString();
                txtVenueUpdate.Text = dgvConfirmationRegister.CurrentRow.Cells["Venue"].Value.ToString();
                txtSponsorUpdate.Text = dgvConfirmationRegister.CurrentRow.Cells["Sponsor"].Value.ToString();
                txtMinisterUpdate.Text = dgvConfirmationRegister.CurrentRow.Cells["Minister"].Value.ToString();
                dtpDateUpdate.Value = (DateTime)dgvConfirmationRegister.CurrentRow.Cells["Date"].Value;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sponsor = txtSponsorUpdate.Text;
            string venue = txtVenueUpdate.Text;
            string minister = txtMinisterUpdate.Text;
            string dateReceived = dtpDateUpdate.Value.ToString("yyyy-MM-dd");

            Sql.Execute_Query("UPDATE `confirmation` SET `date_received`='" + dateReceived + "'," +
                "`minister`='" + minister + "',`venue`='" + venue + "',`sponsor`='" + sponsor + "'" +
                "WHERE `parishioner_id`='" + parishioner_id + "';");
            if (!Sql.result) { return; }
            MessageBox.Show("Record successfully updated in the confirmation register", "Update confirmation Record");

            refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvConfirmationRegister.CurrentRow != null)
            {
                string name = dgvConfirmationRegister.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show("Are you sure you want to delete record of " + name + " from the confirmation register", "Delete confirmation Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Sql.Execute_Query("DELETE FROM `confirmation` WHERE `parishioner_id`='" + parishioner_id + "';");
                    if (!Sql.result) { return; }
                    MessageBox.Show("Record of " + name + " successfully deleted.");
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvConfirmationRegister.RowCount > 0)
            {
                current_row_no = dgvConfirmationRegister.RowCount - 1;
                dgvConfirmationRegister.ClearSelection();
                dgvConfirmationRegister.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvConfirmationRegister.RowCount > 0 && current_row_no < dgvConfirmationRegister.RowCount - 1)
            {
                current_row_no += 1;
                dgvConfirmationRegister.ClearSelection();
                dgvConfirmationRegister.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvConfirmationRegister.RowCount > 0 && current_row_no > 0)
            {
                current_row_no -= 1;
                dgvConfirmationRegister.ClearSelection();
                dgvConfirmationRegister.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvConfirmationRegister.RowCount > 0)
            {
                current_row_no = 0;
                dgvConfirmationRegister.ClearSelection();
                dgvConfirmationRegister.Rows[current_row_no].Selected = true;
                txtRowNo.Text = (current_row_no + 1).ToString();
            }
        }

        private void txtRowNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRowNo.Text.Trim()))
            {
                if (int.Parse(txtRowNo.Text.Trim()) > 0 && int.Parse(txtRowNo.Text.Trim()) <= dgvConfirmationRegister.RowCount)
                {
                    current_row_no = int.Parse(txtRowNo.Text.Trim()) - 1;

                    dgvConfirmationRegister.ClearSelection();
                    dgvConfirmationRegister.Rows[current_row_no].Selected = true;
                }

            }
        }

        private void txtRowNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvConfirmationRegister.RowCount > 0)
            {
                if ((new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }).Contains(e.KeyChar) == false)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
