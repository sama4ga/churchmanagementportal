using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace Church_Management_Portal
{
    class SQLConfig
    {

        private MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=maurice5782;port=3308;database=churchms");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable dt;
        public DataSet ds;
        int result;
        usableFunction funct = new usableFunction(); 

        public void Execute_CUD(string sql, string msg_false, string msg_true)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();

                //if(result > 0)
                //{
                    MessageBox.Show(msg_true);
                //}
                //else
                //{
                //    MessageBox.Show(msg_false);
                //} 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close(); 
            }
        }


        public void Execute_Query(string sql)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        public void Load_DTG(string sql,DataGridView dtg)
        {
            try
            {
                //con.Open();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd = new MySqlCommand(sql,con);
                da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                ds = new DataSet();

                    
                da.Fill(dt);
                ds.Tables.Add(dt);

                dtg.DataSource = dt;
               
                funct.ResponsiveDtg(dtg);
                dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                da.Dispose();
                con.Close();
                cmd.Dispose();
            }

        }

        public void fiil_listBox(string sql, ListBox listBox, string name="")
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                cmd = new MySqlCommand(sql,con);
                da = new MySqlDataAdapter(cmd);
                dt = new DataTable(name);
                ds = new DataSet();

                da.Fill(dt);
                ds.Tables.Add(dt);

                listBox.DataSource = dt;
                listBox.DisplayMember = dt.Columns[1].ColumnName;
                listBox.ValueMember = dt.Columns[0].ColumnName;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
                cmd.Dispose();
            }

        }


        public void fiil_CBO(string sql, ComboBox cbo,string name="")
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open(); 
                } 

                cmd = new MySqlCommand(sql,con);
                da = new MySqlDataAdapter(cmd);
                dt = new DataTable(name);
                ds = new DataSet();

                
                da.Fill(dt);
                ds.Tables.Add(dt);

                cbo.ValueMember = dt.Columns[0].ColumnName;
                cbo.DisplayMember = dt.Columns[1].ColumnName;
                cbo.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }

        }


        public void combo(string sql, ComboBox cbo,string name="")
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                cmd = new MySqlCommand(sql,con);
                da = new MySqlDataAdapter(cmd);
                dt = new DataTable(name);
                ds = new DataSet();

                da.Fill(dt);
                ds.Tables.Add(dt);

                cbo.Items.Clear();
                cbo.Text = "Select";
                foreach(DataRow r in dt.Rows)
                {
                    cbo.Items.Add(r.Field<string>(0));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }

        }
        
        public int maxrow(string sql,string name="")
        {
            int maxrow = 0;
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                cmd = new MySqlCommand(sql,con);
                da = new MySqlDataAdapter(cmd);
                dt = new DataTable(name);
                ds = new DataSet();
                
                da.Fill(dt);
                ds.Tables.Add(dt);

                maxrow = dt.Rows.Count;


                da.Dispose();
            }
            catch (Exception ex)
            {
                //if (ex.HResult == -2147467259)
                //{
                //    Process p = new Process();
                //    p.StartInfo.FileName = "msiexec.exe";
                //    p.StartInfo.Arguments = string.Format(" /q/log install.txt /i" +
                //                                            context.Parameters["TARGETDIR"].ToString() +
                //                                            "MYSQL_SETUP.exe"+
                //                                            " datadir=\C:\\Program")
                //}
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return maxrow;
        }


        public long Execute_Insert(string sql)
        {
            long insert_id = 0;
            try
            {
                con.Open();
                cmd = new MySqlCommand(sql,con);
                result = cmd.ExecuteNonQuery();

                insert_id = cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return insert_id;
        }

        
        public void autocomplete(string sql,TextBox txt)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();


                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);

                txt.AutoCompleteCustomSource.Clear();
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;

                foreach (DataRow r in dt.Rows)
                {
                    txt.AutoCompleteCustomSource.Add(r.Field<string>(0));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }

        public void autonumber(string AUTOKEY, TextBox txt)
        {
            try
            {

                if (con.State != ConnectionState.Open)
                {
                    con.Open(); 
                }
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();


                cmd.Connection = con;
                cmd.CommandText = "SELECT concat(`STRT`, `END`) FROM `tblautonumber` WHERE `DESCRIPTION`='" + AUTOKEY + "'";
                da.SelectCommand = cmd;
                da.Fill(dt);

                txt.Text = DateTime.Now.ToString("yyyy") + dt.Rows[0].Field<string>(0);
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }

        public void trans_autonumber(string AUTOKEY, Label txt)
        {
            try
            {

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                dt = new DataTable();


                cmd.Connection = con;
                cmd.CommandText = "SELECT concat(`STRT`, `END`) FROM `tblautonumber` WHERE `DESCRIPTION`='" + AUTOKEY + "'";
                da.SelectCommand = cmd;
                da.Fill(dt);

                txt.Text = DateTime.Now.ToString("yyyy") + dt.Rows[0].Field<string>(0);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }
        public void update_Autonumber(string id)
        { 
            Execute_Query("UPDATE `tblautonumber` SET `END`=`END`+`INCREMENT` WHERE `DESCRIPTION`='" + id + "'");
        }

      
    }
}
