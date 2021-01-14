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
            if ((textBox1.Text.Length > 0 == textBox1.Visible) &&
                        (textBox2.Text.Length > 0 == textBox2.Visible) &&
                        (textBox3.Text.Length > 0 == textBox3.Visible) &&
                        (textBox4.Text.Length > 0 == textBox4.Visible) &&
                        (textBox5.Text.Length > 0 == textBox5.Visible) &&
                        (textBox6.Text.Length > 0 == textBox6.Visible)) //pola wymagane są 
            {

                switch (this.function)
                {
                    case 0:
                        if (this.button1.Text == "Add car")
                        {
                            int result = 0;
                            try
                            {
                                result = Int32.Parse(this.textBox4.Text);
                                OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowySamochod";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vNazwa", OracleDbType.Varchar2).Value = this.textBox1.Text;
                                cmd.Parameters.Add("vAdres", OracleDbType.Varchar2).Value = this.textBox2.Text;
                                cmd.Parameters.Add("vModel", OracleDbType.Varchar2).Value = this.textBox3.Text;
                                cmd.Parameters.Add("vRocznik", OracleDbType.Decimal).Value = result;
                                cmd.Parameters.Add("vNazwaWypozyczalni", OracleDbType.Varchar2).Value = this.textBox5.Text;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Podaj liczbe w polu 'Rocznik'");
                            }



                        }
                        else if (this.button1.Text == "Add car rental")
                        {
                            OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                            cmd.CommandText = "nowaWypozyczalnia";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("vNazwa", OracleDbType.Varchar2).Value = this.textBox1.Text;
                            cmd.Parameters.Add("vAdres", OracleDbType.Varchar2).Value = this.textBox2.Text;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                        else if (this.button1.Text == "Add car repair shop")
                        {
                            OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                            cmd.CommandText = "nowyWarsztat";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("vNazwa", OracleDbType.Varchar2).Value = this.textBox1.Text;
                            cmd.Parameters.Add("vAdres", OracleDbType.Varchar2).Value = this.textBox2.Text;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }

                        else if (this.button1.Text == "Add repair")
                        {
                            //TO DO
                        }
                        else if (this.button1.Text == "Add customer")
                        {
                            try
                            {
                                int pesel = Int32.Parse(this.textBox3.Text);
                                OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowyKlient";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vImie", OracleDbType.Varchar2).Value = this.textBox1.Text;
                                cmd.Parameters.Add("vNazwisko", OracleDbType.Varchar2).Value = this.textBox2.Text;
                                cmd.Parameters.Add("vPesel", OracleDbType.Decimal).Value = pesel;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            
                        }
                        else if (this.button1.Text == "Add worker")
                        {
                            try
                            {
                                int pesel = Int32.Parse(this.textBox3.Text);
                                int placa = Int32.Parse(this.textBox4.Text);
                                OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowyPracownik";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vImie", OracleDbType.Varchar2).Value = this.textBox1.Text;
                                cmd.Parameters.Add("vNazwisko", OracleDbType.Varchar2).Value = this.textBox2.Text;
                                cmd.Parameters.Add("vPesel", OracleDbType.Decimal).Value = pesel;
                                cmd.Parameters.Add("vPlaca", OracleDbType.Decimal).Value = placa;
                                cmd.Parameters.Add("vNazwaWypozyczalni", OracleDbType.Varchar2).Value = this.textBox5.Text;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        else if (this.button1.Text == "Add sell transaction")
                        {
                            int cena = Int32.Parse(this.textBox2.Text);
                            int rabat = Int32.Parse(this.textBox3.Text);
                            OracleCommand cmd = mainForm.mainForm.con.CreateCommand();

                            DateTime dt = new DateTime(2012, 5, 7, 12, 23, 22, 0);


                            
                            cmd.CommandText = "noweZlecenieSprzedazy";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("vDataSprzedazy", OracleDbType.Date).Value = dt;

                            cmd.Parameters.Add("vCena", OracleDbType.Decimal).Value = cena;
                            cmd.Parameters.Add("vRabat", OracleDbType.Decimal).Value = rabat;
                            cmd.Parameters.Add("vNrVIN", OracleDbType.Varchar2).Value = this.textBox4.Text;
                            cmd.Parameters.Add("vIDklienta", OracleDbType.Varchar2).Value = this.textBox5.Text;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }

                        else if (this.button1.Text == "Add rent transaction")
                        {
                            int cena = Int32.Parse(this.textBox1.Text);
                            OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                            cmd.CommandText = "noweZlecenieWynajmu";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("vCena", OracleDbType.Decimal).Value = cena;
                            cmd.Parameters.Add("vDataWynajmu", OracleDbType.Date).Value = this.textBox2.Text;
                            cmd.Parameters.Add("vDataOddania", OracleDbType.Date).Value = this.textBox3.Text;
                            cmd.Parameters.Add("vNrVIN", OracleDbType.Varchar2).Value = this.textBox4.Text;
                            cmd.Parameters.Add("vIDklienta", OracleDbType.Varchar2).Value = this.textBox5.Text;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }







                        break;
                    case 2:

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
