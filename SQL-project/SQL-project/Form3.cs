using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
namespace SQL_project
{
    public partial class Form3 : Form
    {
        private Form2 mainForm = null;
        public Form3(Form callingForm,string buttontext)
        {
            mainForm = callingForm as Form2;

            InitializeComponent();
            this.FunctionButton.Text = buttontext;
        }

        private void FunctionButton_Click(object sender, EventArgs e)
        {
            //mainForm.Show();
            //OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
            //cmd.CommandText= "nowyWarsztat";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("PARAM1", OracleDbType.Varchar2).Value = "xdddd2";
            //cmd.Parameters.Add("PARAM2", OracleDbType.Varchar2).Value = "adddr2";

            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            //cmd.ExecuteNonQuery();
            //this.Close();
            OracleCommand cmd2 = mainForm.mainForm.con.CreateCommand();
            cmd2.CommandText = "select * from warsztaty";
            OracleDataReader reader = cmd2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.textBox1.Text+= "nazwa: "+reader.GetString(0)+" adres: "+reader.GetString(1)+"\r\n";
                    //Console.WriteLine("{0}\t{1}", reader.GetString(0),reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
