using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Church_Management_Portal
{
    class usableFunction
    {

        public void showFrm(Form frm)
        {
            frm.Show();
        }


        public void showFrmD(Form frm)
        {
            frm.ShowDialog();
        }


        public void clearTxt(Control container)
        {
            try
            {
                //'for each txt as control in this(object).control
                foreach (Control txt in container.Controls)
                {
                    //conditioning the txt as control by getting it's type.
                    //the type of txt as control must be textbox.
                    if (txt is TextBox)
                    {
                        //if the object(textbox) is present. The result is, the textbox will be cleared.
                        txt.Text = "";
                    }
                    if (txt is RichTextBox)
                    {
                        txt.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string checkOption(CheckBox chk)
        {
            string yesno;

            if (chk.Checked)
            {
                yesno = "Yes";
            }
            else
            {
                yesno = "No";
            }
            return yesno;
        }

        //        Public Sub checkOption(ByVal chk As CheckBox, ByRef yesno As String)
        //    If chk.CheckState = CheckState.Checked Then
        //        yesno = "Yes"
        //    Else
        //        yesno = "No"
        //    End If
        //End Sub



        //initialize the validating method
        static Regex Valid_Name = StringOnly();
        static Regex Valid_Contact = NumbersOnly();
        static Regex Valid_Password = ValidPassword();
        static Regex Valid_Email = Email_Address();
        private string timetableFilename;



        //Method for validating email address
        private static Regex Email_Address()
        {
            string Email_Pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(Email_Pattern, RegexOptions.IgnoreCase);
        }


        //Method for string validation only
        private static Regex StringOnly()
        {
            string StringAndNumber_Pattern = "^[a-zA-Z]";

            return new Regex(StringAndNumber_Pattern, RegexOptions.IgnoreCase);
        }


        //Method for numbers validation only
        private static Regex NumbersOnly()
        {
            string StringAndNumber_Pattern = "^[0-9]*$";

            return new Regex(StringAndNumber_Pattern, RegexOptions.IgnoreCase);
        }


        //Method for password validation only
        private static Regex ValidPassword()
        {
            string Password_Pattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$";

            return new Regex(Password_Pattern, RegexOptions.IgnoreCase);
        }


        public void ResponsiveDtg(DataGridView dtg)
        {
            dtg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        /// <summary>
        /// Used to encrypt a password
        /// </summary>
        /// <param name="password">password to be encrypted</param>
        /// <returns></returns>
        public string EncryptPassword(string password)
        {
            return password;
        }

        public void SaveRecord(DataGridView dgv)
        {
            //DirectoryInfo dir = Directory.CreateDirectory(Computer.FileSystem.SpecialDirectories.MyDocuments + "/Timetables");

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".csv";
            sfd.AddExtension = true;
            //sfd.InitialDirectory = FileSystem.SpecialDirectories.MyDocuments + "/Timetables";
            sfd.RestoreDirectory = true;
            sfd.Title = "Choose filename for the record";
            sfd.Filter = "ALL FIles|*.*|CSV|*.csv";
            sfd.FilterIndex = 2;           
        

            //timetableFilename = "timetable" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".csv"

            StringBuilder Data  = new StringBuilder();
            String str  = String.Empty;

            for (int index = 0; index < dgv.ColumnCount; index++) {
                if (dgv.Columns[index].Visible)
                {
                    if (index == dgv.ColumnCount - 1){
                        str += '"' + dgv.Columns[index].Name + '"'; 
                    } else{
                            str += '"' + dgv.Columns[index].Name + '"' + ","; 
                    }
                }
                
            }

            Data.AppendLine(str);
            str = String.Empty;

            for(int row = 0; row < dgv.RowCount; row++) { 

                if (dgv.Rows[row].IsNewRow) { break; }
                if (!dgv.Rows[row].Visible) { break; }

                for (int col = 0;  col < dgv.ColumnCount; col++) {
                    if (dgv.Rows[row].Cells[col].Visible)
                    {
                        if (col == dgv.ColumnCount - 1 ){
                            if (dgv.Rows[row].Cells[col].Value == null){
                                dgv.Rows[row].Cells[col].Value = "";
                            }
                            str += '"' + dgv.Rows[row].Cells[col].Value.ToString() + '"';
                        }else{
                            if (dgv.Rows[row].Cells[col].Value == null){
                                dgv.Rows[row].Cells[col].Value = "";
                            }
                            str += '"' + dgv.Rows[row].Cells[col].Value.ToString() + '"' + ",";
                        }
                    }
                }

                Data.AppendLine(str);
                str = String.Empty;
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //Save(sfd.FileName)
                timetableFilename = sfd.FileName.Split('/').Last();

                File.WriteAllText(sfd.FileName, Data.ToString(), Encoding.UTF8);
                MessageBox.Show("Record successfully exported","Export Record");
            }
       }
       
    }
}
