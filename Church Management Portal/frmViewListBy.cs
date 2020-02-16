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
    public partial class frmViewListBy : Form
    {
        Size csize = new Size(116, 74);
        int maxrows = 0;
        frmViewListOfParishioners frm;
        SQLConfig Sql = new SQLConfig();


        public frmViewListBy()
        {
            InitializeComponent();
        }
        

        private void btnAll_Click(object sender, EventArgs e)
        {
            frm = new frmViewListOfParishioners();
            frm.by = "all";
            frm.text = "All";
            frm.Show();
        }

        private void btnBaptised_Click(object sender, EventArgs e)
        {
            frm = new frmViewListOfParishioners();
            frm.by = "baptised";
            frm.filter = "sacrament";
            frm.text = "Baptised";
            frm.Show();
        }

        private void btnCommunicants_Click(object sender, EventArgs e)
        {
            frm = new frmViewListOfParishioners();
            frm.by = "communicant";
            frm.filter = "sacrament";
            frm.text = "Communicant";
            frm.Show();
        }

        private void btnConfirmed_Click(object sender, EventArgs e)
        {
            frm = new frmViewListOfParishioners();
            frm.by = "confirmed";
            frm.filter = "sacrament";
            frm.text = "Confirmed";
            frm.Show();
        }

        private void btnMarried_Click(object sender, EventArgs e)
        {
            frm = new frmViewListOfParishioners();
            frm.by = "wedded";
            frm.filter = "sacrament";
            frm.text = "Wedded";
            frm.Show();
        }

        private void frmViewListBy_Load(object sender, EventArgs e)
        {               


            // get record for organisations
            maxrows = Sql.maxrow("SELECT * FROM `organisation`","organisation");
            if (maxrows > 0)
            {

                foreach (DataRow row in Sql.ds.Tables["organisation"].Rows)
                {
                    string btnName = row.Field<string>("short_name");
                    string btnId = row.Field<int>("organisation_id").ToString();
                    Button btn = new Button();
                    btn.Name = "btn" + btnName;
                    btn.Tag = "organisation" + "/" + btnId + "/" + btnName;
                    btn.Text = btnName;
                    btn.Size = csize;
                    btn.BackColor = Color.ForestGreen;
                    flpOrganisation.Controls.Add(btn);
                    btn.Click += new System.EventHandler(this.btn_click);
                }
            }

            // get record for pious societies
            add_buttons("pious_societies", flpPiousSoc,"pious_society","");

            // get record for other groups
            add_buttons("other_groups", flpOtherGroups, "other_groups","");

            //maxrows = Sql.maxrow("SELECT * FROM `pious_societies`");
            //if (maxrows > 0)
            //{

            //    foreach (DataRow row in Sql.dt.Rows)
            //    {
            //        string btnName = row.Field<string>("name");
            //        Button btn = new Button();
            //        btn.Name = "btn" + btnName;
            //        btn.Text = btnName;
            //        btn.Size = csize;
            //        flpPiousSoc.Controls.Add(btn);
            //        btn.Click += new System.EventHandler(this.btn_click);
            //    }
            //}

            // get record for societies
            add_buttons("societies", flpSocieities,"society","society_id");

            //maxrows = Sql.maxrow("SELECT * FROM `societies`");
            //if (maxrows > 0)
            //{

            //    foreach (DataRow row in Sql.dt.Rows)
            //    {
            //        string btnName = row.Field<string>("name");
            //        Button btn = new Button();
            //        btn.Name = "btn" + btnName;
            //        btn.Text = btnName;
            //        btn.Size = csize;
            //        flpSocieities.Controls.Add(btn);
            //        btn.Click += new System.EventHandler(this.btn_click);
            //    }
            //}


            // get record for stations
            add_buttons("stations", flpStations,"station","station_id");

            //maxrows = Sql.maxrow("SELECT * FROM `stations`");
            //if (maxrows > 0)
            //{

            //    foreach (DataRow row in Sql.dt.Rows)
            //    {
            //        string btnName = row.Field<string>("name");
            //        string btnId = row.Field<string>("station_id");
            //        Button btn = new Button();
            //        btn.Name = "btn" + btnName;
            //        btn.Text = btnName;
            //        btn.Size = csize;
            //        flpStations.Controls.Add(btn);

            //        btn.Click += new System.EventHandler(this.btn_click);
            //    }
            //}
        }


        private void btn_click(object sender, EventArgs e)
        {
            frm = new frmViewListOfParishioners();
            Button btn =((Button)sender);
                        
            string filter = btn.Tag.ToString();
            //if (filter.Contains("/"))
            //{
                var split = filter.Split('/');
                frm.filter = split[0];
                frm.by = split[1];
                frm.text = split[2];
            //}
                        
            frm.Show();
        }


        private void add_buttons(string str, FlowLayoutPanel ctl,string filter,string IdQuery)
        {
            // get record for stations
            maxrows = Sql.maxrow("SELECT * FROM `"+ str +"`;",str);
            if (maxrows > 0)
            {

                foreach (DataRow row in Sql.ds.Tables[str].Rows)
                {
                    string btnName = row.Field<string>("name");
                    string btnId = string.IsNullOrWhiteSpace(IdQuery) ? "" : row.Field<int>(IdQuery).ToString();
                    Button btn = new Button();
                    btn.Name = "btn" + btnName;
                    if (filter  == "pious_society" || filter == "other_groups")
                    {
                        string code_name = row.Field<string>("code_name");
                        btn.Tag = filter + "/" + code_name + "/" + btnName;
                    }
                    else
                    {
                        btn.Tag = filter + "/" + btnId + "/" + btnName;
                    }
                    
                    btn.Text = btnName;
                    btn.Size = csize;
                    btn.BackColor = Color.ForestGreen;
                    ctl.Controls.Add(btn);

                    btn.Click += new System.EventHandler(this.btn_click);
                }
            }
        }
    }
}
