using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceProcess;

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
        public MySqlDataReader dr;
        usableFunction funct = new usableFunction();
        private string uid = Properties.Settings.Default.user;
        private string password = Properties.Settings.Default.password;
        private string server = Properties.Settings.Default.server;
        private string port = Properties.Settings.Default.port;
        private string database = "churchms";

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
        /// <param name="insertId">Returns the id of the last inserted data</param>
        /// <returns>true if query is successful and false if otherwise</returns>
        public bool InsertQuery(string query, List<string> ParamValues, out long insertId)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Prepare();

                //if (cmd.IsPrepared) {
                cmd.Parameters.Clear();

                int count = 1;
                foreach (var item in ParamValues)
                {
                    string paramName = "@" + count;
                    cmd.Parameters.AddWithValue(paramName, item);
                    count++;
                }

                cmd.ExecuteNonQuery();
                insertId = cmd.LastInsertedId;
                result = true;
                return true;

            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while inserting the record: " + e.Message);
                insertId = 0;
                result = false;
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
        public bool UpdateQuery(string query, List<string> ParamValues)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Prepare();

                //if (cmd.IsPrepared) {
                cmd.Parameters.Clear();

                int count = 1;
                foreach (var item in ParamValues)
                {
                    string paramName = "@" + count;
                    cmd.Parameters.AddWithValue(paramName, item);
                    count++;
                }

                cmd.ExecuteNonQuery();
                result = true;
                return true;

            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while updating the record: " + e.Message);
                result = false;
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
                result = true;

                da.Dispose();
            }
            catch (MySqlException e)
            {
                if (e.Number ==1042) //  MySqlErrorCode.UnableToConnectToHost
                {
                    ServiceController controller = new ServiceController();

                    controller.MachineName = ".";
                    controller.ServiceName = "MySQL80";

                    // Start the service
                    controller.Start();

                    //// Stop the service
                    //controller.Stop();
                }
                //MessageBox.Show(e.Message + " Code:" + e.ErrorCode + " Number:"+e.Number+" Source:"+e.Source);
                result = false;
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

        
        public void ReadData(string sql)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while reading data\n" + ex.Message);
                result = false;
            }
            finally
            {
                //con.Close();
            }
        }

      
    }
}
