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


        public frmMarriageRecord()
        {
            InitializeComponent();
        }

        private void frmMarriageRecord_Load(object sender, EventArgs e)
        {
            refresh();
        }


        private void refresh()
        {
            Sql.Load_DTG("SELECT `groom_name` AS 'Groom\\'s Name',`groom_parent` AS 'Groom\\'s Parent',`groom_village` AS 'Groom\\'s Village',"+
               "`bride_name` AS 'Bride\\'s Name',`bride_parent` AS 'Bride\\'s Parent',`bride_village` AS 'Bride\\'s Village'," +
               "`sponsor` AS 'Sponsor',`minister` AS 'Witness',`venue` AS 'Venue',`date_received` AS 'Date Received' FROM `matrimony`; ", dgvMarriageRegister);
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
            Sql.Execute_Insert("INSERT INTO `matrimony`("+
                "`groom_name`,`groom_parent`,`groom_village`,`bride_name`,`bride_parent`,`bride_village` ,  "+
               "`sponsor`,`minister`,`venue`,`date_received`                                    "+
               ") VALUES(                                                                                   "+
               "'"+ txtGroomName.Text + "','" + txtGroomParent.Text + "','" + txtGroomVillage.Text + "',    "+
               "'" + txtBrideName.Text + "','" + txtBrideParent.Text + "','" + txtBrideVillage.Text + "',   "+
               "'" + txtSponsor.Text + "','" + txtWitness.Text + "','" + txtVenue.Text + "','"+ dtpDate.Value.ToString("yyyy-MM-dd") +"' );");
            MessageBox.Show("Record successfully added","View Marriage Record");
            refresh();
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
    }
}
