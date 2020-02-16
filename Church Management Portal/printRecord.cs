using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Church_Management_Portal
{
    class printRecord : PrintDocument
    {
        private int mRow = 0;
        private Boolean newpage = true;
        private int no_of_pages = 0;
        private DataGridView dgv;
        private string title;


        public printRecord(DataGridView dgv, string title)
        {
            this.dgv = dgv;
            this.title = title;
        }

        public DataGridView dataGridView {
            get
            {
                return dgv;
            }
            set
            {
                this.dgv = value;
            }


        } 


        protected override void OnPrintPage( PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

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
                    Font fnt = new Font("TImes New Romans", 10, FontStyle.Regular);
                    float leading = fnt.GetHeight() + 4;

                    float startX = 0;
                    float startY = leading;
                    float offset = 10;

                    StringFormat formaCenter = new StringFormat(StringFormatFlags.NoClip);
                    formaCenter.Alignment = StringAlignment.Center;
                    SizeF layoutSize = new SizeF(e.PageBounds.Width - offset * 2, leading);
                    RectangleF layout = new RectangleF(new PointF(startX, startY + offset), layoutSize);

                    Brush brush = Brushes.Black;

                    // prints church information
                    e.Graphics.DrawString(Properties.Settings.Default.church_name, fnt, brush, layout, formaCenter);

                    offset += leading;
                    layout = new RectangleF(new PointF(startX, startY + offset), layoutSize);
                    e.Graphics.DrawString(Properties.Settings.Default.church_address, fnt, brush, layout, formaCenter);

                    offset += leading + 20;
                    layout = new RectangleF(new PointF(startX, startY + offset), layoutSize);
                    e.Graphics.DrawString(title, fnt, brush, layout, formaCenter);

                    y += 100;
                }
                else
                {
                    y += 20;
                }

                if (dgv.Rows.Count > 0)
                {

                    row = dgv.Rows[mRow];
                    x = e.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            rc = new Rectangle(x, y, cell.Size.Width, cell.Size.Height);

                            e.Graphics.FillRectangle(Brushes.LightGray, rc);
                            e.Graphics.DrawRectangle(Pens.Black, rc);

                            FormatCell(cell, fmt, rc);

                            e.Graphics.DrawString(dgv.Columns[cell.ColumnIndex].HeaderText, dgv.Font, Brushes.Black, rc, fmt);
                            x += rc.Width;
                            h = Math.Max(h, rc.Height);
                        }
                    }
                    y += h;

                    newpage = false;

                    // now print the data for each row
                    int thisNDX;
                    for (thisNDX = mRow; thisNDX < dgv.RowCount - 1; thisNDX++)
                    {
                        // no need to try to print the new row
                        if (dgv.Rows[thisNDX].IsNewRow) { break; }

                        row = dgv.Rows[thisNDX];
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

                                e.Graphics.DrawString(cell.FormattedValue.ToString(), dgv.Font, Brushes.Black, rc, fmt);

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
            }
        }


        private void FormatCell(DataGridViewCell cell, StringFormat fmt, Rectangle rc)
        {
            switch (dgv.Columns[cell.ColumnIndex].DefaultCellStyle.Alignment)
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


        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);

            mRow = 0;
            newpage = true;

            DefaultPageSettings.Landscape = true;
            DefaultPageSettings.Margins = new Margins(15, 15, 40, 15);
            DefaultPageSettings.PrinterSettings.PrintToFile = true;
        }


    }

}
