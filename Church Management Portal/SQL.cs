using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Church_Management_Portal
{
    class SQL
    {
        private MySqlConnection con = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private MySqlDataReader dr;
        public DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private string uid = Properties.Settings.Default.user;
        private string password = Properties.Settings.Default.password;
        private string server = Properties.Settings.Default.server;
        private string port = Properties.Settings.Default.port;
        private string database = "churchms";

        /// <summary>
        /// Opens a connection to the mysql database using default parameters
        /// </summary>
        /// <returns></returns>
        private Boolean OpenCon()
        {
            con = new MySqlConnection("server=" + server + ";user id=" + uid + ";password=" + password + ";port=" + port + ";database="+database);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                return true;
            }
            catch (MySqlException e)
            {
                if (e.Number.Equals(MySqlErrorCode.UnableToConnectToHost))
                { 
                    // try to open mysql server
                }
                MessageBox.Show("An error occurred while connecting to the database: " + e.Message);
                return false;
            }
            
        }

        /// <summary>
        /// Opens a connection to a database using parameters available in an already open connection
        /// </summary>
        /// <param name="database">Database to connect to</param>
        /// <returns></returns>
        public Boolean OpenCon( string database)
        {
            if (con != null)
            {
                con.Open();
                try
                {

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    con.ChangeDatabase(database);
                    return true;
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("An error occurred while connecting to the database: " + e.Message);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("There is no open connection to any database. Open a connection to continue");
                return false;
            }

        }

        /// <summary>
        /// Opens a connection using the parameters defined
        /// </summary>
        /// <param name="server">Server to connect to</param>
        /// <param name="username">UserId for the connection</param>
        /// <param name="password">Password associated with this UserId</param>
        /// <param name="port">Port to use for connection</param>
        /// <param name="database">Database to connect to </param>
        /// <returns>true or false</returns>
        public Boolean OpenCon(string server="localhost", string username="root", string password="",uint port=3306, string database="churchms")
        {
            MySqlConnectionStringBuilder connectionstring = new MySqlConnectionStringBuilder() {
                Port = port,
                Database = database,
                Server = server,
                Password = password,
                UserID = username
            };
            con = new MySqlConnection(connectionstring.ToString());

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while connecting to the database: " + e.Message + e.ErrorCode);
                if (MySqlErrorCode.UnableToConnectToHost.Equals(e.ErrorCode))
                {
                    MessageBox.Show("Connection error");
                }
                return false;
            }

        }

        /// <summary>
        /// Used to close any available connection to a database
        /// </summary>
        /// <returns></returns>
        private bool CloseCon()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while closing the connection to the database: " + e.Message);
                return false;
            }            
        }

        /// <summary>
        /// Used to insert data without returning id
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="ParamValues">A list containing values for parameters used in the query</param>
        /// <returns>true if query is successful and false if otherwise</returns>
        public bool InsertQuery(string query, List<object>[] ParamValues)
        {
            try
            {
                if (OpenCon())
                {
                    cmd = new MySqlCommand(query, con);
                    cmd.Prepare();

                    //if (cmd.IsPrepared) {
                    cmd.Parameters.Clear();
                    int count = 1;
                    foreach (var item in ParamValues)
                    {
                        string paramName = "@" + count;
                        cmd.Parameters.AddWithValue(paramName, item);
                        count ++;
                    }

                    cmd.ExecuteNonQuery(); 
                    return true;
                }
                else
                {
                    return false;
                }                
               
            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while inserting the record: " + e.Message);
                return false;
            }
            finally
            {
                cmd.Dispose();
                CloseCon();
            }
           
        }

        /// <summary>
        /// Used to insert query and at the same time return the id of the insertion
        /// </summary>
        /// <param name="query">string containing the query</param>
        /// <param name="ParamValues">values for parameters used in the query</param>
        /// <param name="insertId">Output which signifies the LastInsertId </param>
        /// <returns>true if query is successful and false otherwise</returns>
        public bool InsertQuery(string query, List<object>[] ParamValues, out long insertId)
        {
            try
            {
                if (OpenCon())
                {
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
                    return true;
                }
                else
                {
                    insertId = 0;
                    return false;
                }

            }
            catch (MySqlException e)
            {
                insertId = 0;
                MessageBox.Show("An error occurred while inserting the record: " + e.Message);
                return false;
            }
            finally
            {
                cmd.Dispose();
                CloseCon();
            }

        }


        /// <summary>
        /// Used to update record
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="ParamValues">A list containing values for parameters used in the query</param>
        /// <returns>true if query is successful and false othewise</returns>
        public bool UpdateQuery(string query, List<object>[] ParamValues)
        {
            try
            {
                if (OpenCon())
                {
                    cmd = new MySqlCommand(query, con);
                    cmd.Prepare();

                    //if (cmd.IsPrepared) {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(ParamValues);

                    cmd.ExecuteNonQuery(); 
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while updating the record: "+ e.Message);
                return false;
            }
            finally
            {
                cmd.Dispose();
                CloseCon();
            }

        }

        /// <summary>
        /// Executes query against a database
        /// </summary>
        /// <param name="query">query string</param>
        /// <returns>true if query is successful and false othewise</returns>
        public bool ExecuteQuery(string query)
        {
            try
            {
                if (OpenCon())
                {
                    cmd = new MySqlCommand(query, con);                    
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while executing the query: " + e.Message);
                return false;
            }
            finally
            {
                cmd.Dispose();
                CloseCon();
            }
        }

        /// <summary>
        /// Reads data
        /// </summary>
        /// <param name="query">string holding the query</param>
        /// <param name="datasetName">string to assign name to the dataset that holds this record</param>
        /// <returns></returns>
        public bool ReadData(string query, string datasetName="")
        {
            try
            {
                if (OpenCon())
                {
                    cmd = new MySqlCommand(query, con);
                    //dr = cmd.ExecuteReader();
                    da = new MySqlDataAdapter(cmd);
                    dt = new DataTable(datasetName);
                    ds = new DataSet(datasetName);

                    da.Fill(dt);
                    ds.Tables.Add(dt);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("An error occurred while reading the data: " + e.Message);
                return false;
            }
            finally
            {
                da.Dispose();
                cmd.Dispose();
                CloseCon();
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\MySqlBackup.sql"; // + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!");
            }
        }

    }
}
