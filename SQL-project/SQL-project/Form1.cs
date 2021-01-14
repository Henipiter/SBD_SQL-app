using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace SQL_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public OracleConnection con;

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                // create connection
                con = new OracleConnection();

                // create connection string using builder
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
                ocsb.Password =  this.PasswordBox.Text.ToString();
                ocsb.UserID = this.LoginBox.Text.ToString();
                ocsb.DataSource = "admlab2.cs.put.poznan.pl:1521/dblab02_students.cs.put.poznan.pl";
                // connect
                con.ConnectionString = ocsb.ConnectionString;
                con.Open();
                MessageBox.Show("Connection established (" + con.ServerVersion + ")");
                Form2 frm = new Form2(this);
                frm.Show();
                this.Hide();
                

            }
            catch 
            {
                MessageBox.Show("error");
            }
            
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LoginBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
