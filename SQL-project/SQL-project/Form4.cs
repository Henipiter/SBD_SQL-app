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
            if (this.button1.Text == "Add repair"||this.button1.Text == "Add rent transaction" || this.button1.Text == "Add customer" || this.button1.Text == "Add sell transaction" || this.button1.Text == "Add worker") 
            {
                this.label1.Visible = false;
                this.textBox1.Visible = false;
            }
            if (this.button1.Text == "Add part repair") 
            {
                this.label7.Visible = true;
                this.textBox8.Visible = true;
                this.label8.Visible = true;
                this.textBox7.Visible = true;
            }
            if (this.button1.Text == "Delete worker") 
            {
                HideLabelsAndBoxes26();
            }


        }
        private void HideLabelsAndBoxes26() 
        {
            this.label2.Visible = false;
            this.textBox2.Visible = false;
            this.label3.Visible = false;
            this.textBox3.Visible = false;
            this.label4.Visible = false;
            this.textBox4.Visible = false;
            this.label5.Visible = false;
            this.textBox5.Visible = false;
            this.label6.Visible = false;
            this.textBox6.Visible = false;
        }
        private void CleanTextBoxes() 
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
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
                                    CleanTextBoxes();
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
                                CleanTextBoxes();
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
                                CleanTextBoxes();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }

                        else if (this.button1.Text == "Add repair")
                        {
                            //TO DO
                            try
                            {
                                int cenar = Int32.Parse(this.textBox3.Text);
                                int rok, miesiac, dzien;
                                rok = Int32.Parse(this.textBox2.Text.Substring(0, 4));
                                miesiac = Int32.Parse(this.textBox2.Text.Substring(5, 2));
                                dzien = Int32.Parse(this.textBox2.Text.Substring(8, 2));
                                DateTime dt = new DateTime(rok, miesiac, dzien, 12, 23, 22, 0);
                                OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowaNaprawa1";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vDataNaprawy", OracleDbType.Date).Value = dt;
                                cmd.Parameters.Add("vCenaRobocizny", OracleDbType.Decimal).Value = cenar;
                                cmd.Parameters.Add("vNazwaWarsztatu", OracleDbType.Varchar2).Value = this.textBox4.Text;
                                cmd.Parameters.Add("vNrVIN", OracleDbType.Varchar2).Value = this.textBox5.Text;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    this.label7.Visible = true;
                                    this.label8.Visible = true;
                                    this.textBox7.Visible = true;
                                    this.textBox8.Visible = true;
                                    this.button1.Text = "Add parts";
                                    this.label1.Visible = false;
                                    this.textBox1.Visible = false;
                                    this.label2.Visible = false;
                                    this.textBox2.Visible = false;
                                    this.label3.Visible = false;
                                    this.textBox3.Visible = false;
                                    this.label4.Visible = false;
                                    this.textBox4.Visible = false;
                                    this.label5.Visible = false;
                                    this.textBox5.Visible = false;
                                    CleanTextBoxes();
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
                        else if (this.button1.Text == "Add customer")
                        {
                            try
                            {
                                int pesel = Int32.Parse(this.textBox4.Text);
                                OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowyKlient";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vImie", OracleDbType.Varchar2).Value = this.textBox2.Text;
                                cmd.Parameters.Add("vNazwisko", OracleDbType.Varchar2).Value = this.textBox3.Text;
                                cmd.Parameters.Add("vPesel", OracleDbType.Decimal).Value = pesel;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    CleanTextBoxes();
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
                                int pesel = Int32.Parse(this.textBox4.Text);
                                int placa = Int32.Parse(this.textBox5.Text);
                                OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowyPracownik";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vImie", OracleDbType.Varchar2).Value = this.textBox2.Text;
                                cmd.Parameters.Add("vNazwisko", OracleDbType.Varchar2).Value = this.textBox3.Text;
                                cmd.Parameters.Add("vPesel", OracleDbType.Decimal).Value = pesel;
                                cmd.Parameters.Add("vPlaca", OracleDbType.Decimal).Value = placa;
                                cmd.Parameters.Add("vNazwaWypozyczalni", OracleDbType.Varchar2).Value = this.textBox6.Text;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    CleanTextBoxes();
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
                            int cena = Int32.Parse(this.textBox3.Text);
                            int rabat = Int32.Parse(this.textBox4.Text);
                            OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                            int rok, miesiac, dzien;
                            rok = Int32.Parse(this.textBox2.Text.Substring(0, 4));
                            miesiac = Int32.Parse(this.textBox2.Text.Substring(5, 2));
                            dzien = Int32.Parse(this.textBox2.Text.Substring(8, 2));
                            DateTime dt = new DateTime(rok, miesiac, dzien, 12, 23, 22, 0);


                            
                            cmd.CommandText = "noweZlecenieSprzedazy";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("vDataSprzedazy", OracleDbType.Date).Value = dt;

                            cmd.Parameters.Add("vCena", OracleDbType.Decimal).Value = cena;
                            cmd.Parameters.Add("vRabat", OracleDbType.Decimal).Value = rabat;
                            cmd.Parameters.Add("vNrVIN", OracleDbType.Varchar2).Value = this.textBox5.Text;
                            cmd.Parameters.Add("vIDklienta", OracleDbType.Varchar2).Value = this.textBox6.Text;
                            try
                            {
                                cmd.ExecuteNonQuery();
                                CleanTextBoxes();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }

                        else if (this.button1.Text == "Add rent transaction")
                        {
                            int cena = Int32.Parse(this.textBox2.Text);
                            int rok, miesiac, dzien;
                            rok = Int32.Parse(this.textBox3.Text.Substring(0, 4));
                            miesiac = Int32.Parse(this.textBox3.Text.Substring(5, 2));
                            dzien = Int32.Parse(this.textBox3.Text.Substring(8, 2));
                            DateTime dt = new DateTime(rok, miesiac, dzien, 12, 23, 22, 0);

                            int rok2, miesiac2, dzien2;
                            rok2 = Int32.Parse(this.textBox4.Text.Substring(0, 4));
                            miesiac2 = Int32.Parse(this.textBox4.Text.Substring(5, 2));
                            dzien2 = Int32.Parse(this.textBox4.Text.Substring(8, 2));
                            DateTime dt2 = new DateTime(rok2, miesiac2, dzien2, 12, 23, 22, 0);

                            OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                            cmd.CommandText = "noweZlecenieWynajmu";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("vCena", OracleDbType.Decimal).Value = cena;
                            cmd.Parameters.Add("vDataWynajmu", OracleDbType.Date).Value = dt;
                            cmd.Parameters.Add("vDataOddania", OracleDbType.Date).Value = dt2;
                            cmd.Parameters.Add("vNrVIN", OracleDbType.Varchar2).Value = this.textBox5.Text;
                            cmd.Parameters.Add("vIDklienta", OracleDbType.Varchar2).Value = this.textBox6.Text;
                            try
                            {
                                cmd.ExecuteNonQuery();
                                CleanTextBoxes();
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }
                        else if (this.button1.Text == "Add parts")
                        {
                            try
                            {
                                int cenaE = Int32.Parse(this.textBox8.Text);
                                OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "noweCzesci";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vNazwaElementu", OracleDbType.Varchar2).Value = this.textBox7.Text;
                                cmd.Parameters.Add("vCenaElementu", OracleDbType.Varchar2).Value = cenaE;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    CleanTextBoxes();
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
                        else if (this.button1.Text == "Add part repair")
                        {
                            try
                            {
                                int nrNaprawy = Int32.Parse(this.textBox1.Text);
                                int cenaE = Int32.Parse(this.textBox8.Text);
                                OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowaCzesc";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vNrNaprawy", OracleDbType.Decimal).Value = nrNaprawy;
                                cmd.Parameters.Add("vNazwaElementu", OracleDbType.Varchar2).Value = this.textBox7.Text;
                                cmd.Parameters.Add("vCenaElementu", OracleDbType.Varchar2).Value = cenaE;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    CleanTextBoxes();
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







                        break;
                    case 1:
                        if (this.button1.Text == "Delete worker")
                        {
                            int ID = 0;
                            try
                            {
                                ID = Int32.Parse(this.textBox1.Text);
                                OracleCommand cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "usunpracownika";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vID", OracleDbType.Decimal).Value = ID;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    CleanTextBoxes();
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
                        break;
                    default:
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Add parts") 
            {
                this.button1.Text = "Add repair";
                this.label7.Visible = false;
                this.label8.Visible = false;
                this.textBox7.Visible = false;
                this.textBox8.Visible = false;
                this.label2.Visible = true;
                this.textBox2.Visible = true;
                this.label3.Visible = true;
                this.textBox3.Visible = true;
                this.label4.Visible = true;
                this.textBox4.Visible = true;
                this.label5.Visible = true;
                this.textBox5.Visible = true;
            }
            else 
            {
                this.Close();
                this.mainForm.Show();
            }
                
        }
    }
}
