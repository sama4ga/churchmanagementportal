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

        private MySqlConnection con = new MySqlConnection("server="+ Properties.Settings.Default.server + ";user id="+ Properties.Settings.Default.user + ";password="+Properties.Settings.Default.password+";port="+ Properties.Settings.Default.port + ";database=churchms");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable dt;
        public DataSet ds;
        public bool result;
        usableFunction funct = new usableFunction(); 

        public void Execute_CUD(string sql, string msg_false, string msg_true)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                result = true;
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
                MessageBox.Show("An error occured while executing query\n" + ex.Message);
                result = false;
            }
            finally
            {
                con.Close(); 
            }
        }

        /// <summary>
        /// Used to insert data and return insert id
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="ParamValues">A list containing values for parameters used in the query</param>
        /// <returns>true if query is successful and false if otherwise</returns>
        public bool InsertQuery(string query, List<object>[] ParamValues, out long insertId)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Prepare();

                //if (cmd.IsPrepared) {
                cmd.Parameters.Clear();
                
                cmd.Parameters.AddRange(ParamValues);

                cmd.ExecuteNonQuery();
                insertId = cmd.LastInsertedId;
                return true;

            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while inserting the record: " + e.Message);
                insertId = 0;
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }

        }


        /// <summary>
        /// Used to updata data
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="ParamValues">A list containing values for parameters used in the query</param>
        /// <returns>true if query is successful and false if otherwise</returns>
        public bool UpdateQuery(string query, List<object>[] ParamValues)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Prepare();

                //if (cmd.IsPrepared) {
                cmd.Parameters.Clear();

                cmd.Parameters.AddRange(ParamValues);

                cmd.ExecuteNonQuery();
                return true;

            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while inserting the record: " + e.Message);
                return false;
            }
            finally
            {
                cmd.Dispose();
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
                cmd.ExecuteNonQuery();
                 
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while executing query\n" + ex.Message);
                result = false;
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

                result = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while executing query\n" + ex.Message);
                result = false;
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

                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while executing query\n" + ex.Message);
                result = false;
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

                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while executing query\n" + ex.Message);
                result = false;
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
                MessageBox.Show("An error occured while executing query\n" + ex.Message);
                result = false;
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
                cmd.ExecuteNonQuery();

                insert_id = cmd.LastInsertedId;
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while executing query\n" + ex.Message);
                result = false;
            }
            finally
            {
                con.Close();
            }
            return insert_id;
        }

        
        

      
    }
}
