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
    class dgvPrinter : PrintDocument
    {

        private int mRow = 0;
        private Boolean newpage = true;
        private DataGridView dgv;
        private Font Font { get; set; }

        public dgvPrinter(DataGridView dgv)
        {
            this.dgv = dgv;
        }


        public DataGridView datagridview
        {
            get
            {

                return this.dgv;
            }
            set
            {

                this.dgv = value;
            }
        }



        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            //this.OnPrintPage(e);

            // sets it to show '...' for long text
            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
            fmt.LineAlignment = StringAlignment.Center;
            fmt.Trimming = StringTrimming.EllipsisCharacter;
            int y = e.MarginBounds.Top;
            Rectangle rc;
            int x;
            int h = 0;
            DataGridViewRow row;

            //Variables
             int intCurrentChar;       //static
            int intPrintAreaHeight, intPrintAreaWidth, intMarginLeft, intMarginTop;

            //Set printing area boundaries and margin coordinates
            intPrintAreaHeight = DefaultPageSettings.PaperSize.Height - DefaultPageSettings.Margins.Top - DefaultPageSettings.Margins.Bottom;
            intPrintAreaWidth = DefaultPageSettings.PaperSize.Width - DefaultPageSettings.Margins.Left - DefaultPageSettings.Margins.Right;
            intMarginLeft = DefaultPageSettings.Margins.Left;     //X
            intMarginTop = DefaultPageSettings.Margins.Top;   //Y
                                                              // If Landscape set, swap printing height/width
            if (DefaultPageSettings.Landscape) {
                int intTemp;
                intTemp = intPrintAreaHeight;
                intPrintAreaHeight = intPrintAreaWidth;
                intPrintAreaWidth = intTemp;
            }

            // Calculate total number of lines
            int intLineCount = (int)(intPrintAreaHeight / Font.Height);

            // Initialise rectangle printing area
            RectangleF rectPrintingArea = new RectangleF(intMarginLeft, intMarginTop, intPrintAreaWidth, intPrintAreaHeight);

            // Initialise StringFormat class, for text layout
            StringFormat objSF = new StringFormat(StringFormatFlags.LineLimit);

            // Figure out how many lines will fit into rectangle
            int intLinesFilled, intCharsFitted;
            //e.Graphics.MeasureString((dgv, Font, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, intCharsFitted, intLinesFilled);

            // print the title of the document


            // print the header text for a new page
            //   use a grey bg just like the control
            if (newpage) {
                row = dgv.Rows[mRow];
                x = e.MarginBounds.Left;
                foreach (DataGridViewCell cell in row.Cells) {
                    // since we are printing the control's view,
                    // skip invisible columns
                    if (cell.Visible) {
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

            }
            newpage = false;

            // now print the data for each row
            int thisNDX;
            for (thisNDX = mRow; thisNDX < dgv.RowCount - 1; thisNDX++) {
                // no need to try to print the new row
                if (dgv.Rows[thisNDX].IsNewRow) { break; }

                row = dgv.Rows[thisNDX];
                x = e.MarginBounds.Left;
                h = 0;


                // print the data
                foreach (DataGridViewCell cell in row.Cells) {

                    if (cell.Visible) {

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

                if (y + h > e.MarginBounds.Bottom) {
                    e.HasMorePages = true;
                    newpage = true;
                    return;
                }
            }
        }


        protected override void OnBeginPrint(PrintEventArgs e) {

            mRow = 0;
            newpage = true;

            // Sets the default font
            if (Font == null) {
                Font = new Font("Times New Roman", 12);
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



        public int UpgradeZeros( int Input) { //ByVal
         // Upgrades all zeros to ones
        // - used as opposed to defunct IIF or messy If statements
        if (Input == 0) {
                return 1;
        }else{
                return Input;
        }
    }

    }
}
