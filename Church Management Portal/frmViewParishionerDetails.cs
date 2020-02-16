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
    public partial class frmViewParishionerDetails : Form
    {
        usableFunction UF = new usableFunction();
        SQLConfig Sql = new SQLConfig();
        public int parishioner_id = 0;

        public frmViewParishionerDetails()
        {
            InitializeComponent();
        }

        private void frmViewParishionerDetails_Load(object sender, EventArgs e)
        {
            int num_rows = Sql.maxrow("SELECT p.`name`,p.`address`,p.`phoneNo`,p.`gender`,p.`dob`, "+
                                      " p.`status`,p.`baptised`,p.`communicant`, "+
                                      " p.`confirmed`,p.`wedded`,p.`passport`,o.`short_name` as 'organisation', " +
                                      " so.`name` as 'society', s.`name` as 'station' " +
                                      " FROM `parishioners` p " + 
                                      " LEFT JOIN `stations` s ON p.`station`=s.`station_id` "+
                                      " LEFT JOIN `organisation` o ON p.`organisation`=o.`organisation_id` " +
                                      " LEFT JOIN `societies` so ON p.`society`=so.`society_id` " +
                                      " WHERE `parishioner_id`='" + parishioner_id + "';", "parishioners");
            if (num_rows == 1)
            {
                string passport = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("passport");
                if (System.IO.File.Exists(passport))
                {
                    picPassport.Image = Image.FromFile(passport);
                }
                else
                {
                    picPassport.Image = Properties.Resources.index;
                }
                string[] name = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("name").Split(new char[] { ',' });
                txtSurname.Text = name[0];
                txtOthernames.Text = name[1];
                txtAddress.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("address");
                txtPhoneNo.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("phoneNo");
                txtGender.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("gender");                
                txtDOB.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<DateTime>("dob").ToString();
                txtOrganisation.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("organisation");
                txtStation.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("station");
                txtSociety.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("society");
                txtStatus.Text = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("status");
                string baptised = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("baptised");
                if (baptised == "true")
                {
                    listSacrament.SetItemChecked(0, true);
                }
                string communicant = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("communicant");
                if (communicant == "true")
                {
                    listSacrament.SetItemChecked(1, true);
                }
                string confirmed = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("confirmed");
                if (confirmed == "true")
                {
                    listSacrament.SetItemChecked(2, true);
                }
                string wedded = Sql.ds.Tables["parishioners"].Rows[0].Field<string>("wedded");
                if (wedded == "true")
                {
                    listSacrament.SetItemChecked(3, true);
                }
                

            }



            num_rows = Sql.maxrow("SELECT * FROM `parishioner_groups` WHERE `parishioner_id`='" + parishioner_id + "';", "groups");
            if (num_rows > 0)
            {
                foreach (DataRow item in Sql.ds.Tables["groups"].Rows)
                {
                    if (item.Field<string>("group_type") == "other_groups")
                    {
                        listOtherGroups.Items.Add(item.Field<string>("group_name"));
                    }
                    else
                    {
                        listPiousSocieties.Items.Add(item.Field<string>("group_name"));
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmViewListOfParishioners frm = new frmViewListOfParishioners();
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            btnPrint.Visible = false;
            this.FormBorderStyle = FormBorderStyle.None;

           // CaptureScreen();

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument1;
            preview.ShowDialog();

            btnBack.Visible = true;
            btnPrint.Visible = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            CaptureScreen();
            e.Graphics.DrawImage(bitmap, 15, e.MarginBounds.Top);
        }
    }
}
