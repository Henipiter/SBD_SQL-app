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
    public partial class Form5 : Form
    {
        public Form2 mainForm = null;
        public Form5(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as Form2;
        }
        private void callFunction(string nameFunction, string argument)
        {
            if (argument.Length > 0)
            {
                argument = "'" + argument + "'";
            }
            if (nameFunction.Length == 0)
            {
                MessageBox.Show("Uzupelnij pole");
                return;
            }
            OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
            //select ilenaprawdanysamochod('aaaaaaaaaaaaaaaaa') from dual;
            cmd.CommandText = "select "+nameFunction+"("+argument+") from dual" ;
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                this.ResultBox.Text = "";
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        this.ResultBox.Text += reader.GetString(i) + "; ";
                    }
                    this.ResultBox.Text += "\n";
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
                this.ResultBox.Text = "Brak wierszy";
            }
            reader.Close();
        }

        private void CountCarsButton_Click(object sender, EventArgs e)
        {
            string func = "ilesamochodow";
            string arg = this.textBox1.Text;
            callFunction(func, arg);
        }

        private void CountRepairButton_Click(object sender, EventArgs e)
        {
            string func = "ilenaprawdanysamochod";
            string arg = this.textBox1.Text;
            callFunction(func, arg);
        }

        private void CountCarCosts_Click(object sender, EventArgs e)
        {
            string func = "lacznykoszt";
            string arg = this.textBox1.Text;
            callFunction(func, arg);
        }

        private void CountCarEarnings_Click(object sender, EventArgs e)
        {
            string func = "lacznyzyskzwynajmu";
            string arg = this.textBox1.Text;
            callFunction(func, arg);
        }

        private void CountCarValue_Click(object sender, EventArgs e)
        {
            string func = "ilezarobil";
            string arg = this.textBox1.Text;
            callFunction(func, arg);
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
