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
    public partial class Form4 : Form
    {
        private int function;
        private Form2 mainForm = null;
        public Form4(Form mainF, int func, string buttonName, string label1="", string label2 = "", string label3 = "", string label4= "", string label5 = "", string label6 = "")
        {
            mainForm = mainF as Form2;
            InitializeComponent();
            this.function = func;
            this.button1.Text = buttonName;
            this.label1.Text = label1;
            this.label2.Text = label2;
            this.label3.Text = label3;
            this.label4.Text = label4;
            this.label5.Text = label5;
            this.label6.Text = label6;
            if (label1.Length == 0)
            {
                this.label1.Visible = false;
                this.textBox1.Visible = false;
            }

            if (label2.Length == 0)
            {
                this.label2.Visible = false;
                this.textBox2.Visible = false;
            }
            if (label3.Length == 0)
            {
                this.label3.Visible = false;
                this.textBox3.Visible = false;
            }
            if (label4.Length == 0)
            {
                this.label4.Visible = false;
                this.textBox4.Visible = false;
            }
            if (label5.Length == 0)
            {
                this.label5.Visible = false;
                this.textBox5.Visible = false;
            }
            if (label6.Length == 0)
            {
                this.label6.Visible = false;
                this.textBox6.Visible = false;
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("lalala");
            switch (this.function)
            {
                case 0:
                    MessageBox.Show("lalala");
                    if ((textBox1.Text.Length > 0 == textBox1.Visible ) &&
                        (textBox2.Text.Length > 0 == textBox2.Visible ) &&
                        (textBox3.Text.Length > 0 == textBox3.Visible) &&
                        (textBox4.Text.Length > 0 == textBox4.Visible) &&
                        (textBox5.Text.Length > 0 == textBox5.Visible) &&
                        (textBox6.Text.Length > 0 == textBox6.Visible)) //pola wymagane są 
                    {
                        if (this.button1.Text == "Add car"){
                            int result = 0;
                            MessageBox.Show("add");
                            try
                            {
                                result = Int32.Parse(this.textBox4.Text);
                                Console.WriteLine(result);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Unable to parse '{this.textBox4.Text}'");
                            }
                            OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                            cmd.CommandText = "nowySamochod";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("vNrVIN", OracleDbType.Varchar2).Value = this.textBox1.Text;
                            cmd.Parameters.Add("vMarka", OracleDbType.Varchar2).Value = this.textBox2.Text;
                            cmd.Parameters.Add("vModel", OracleDbType.Varchar2).Value = this.textBox3.Text;
                            cmd.Parameters.Add("vRocznik", OracleDbType.Int32).Value = result;
                            cmd.Parameters.Add("vNazwaWypozyczalni", OracleDbType.Varchar2).Value = this.textBox5.Text;

                            OracleDataAdapter da = new OracleDataAdapter(cmd);
                            cmd.ExecuteNonQuery();

                        }




                    }

                   


                        break;
                default:
                    break;
            }
        }
    }
}
