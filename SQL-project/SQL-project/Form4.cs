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
        private int type;
        private string[] operators = { "Add", "Delete", "Search", "Modify", "Show" };
        private string[] entity = { "samochody", "wypozyczalnie", "warsztaty", "naprawy", "klienci", "pracownicy_wypozyczalni", "zlecenia_sprzedazy", "zlecenia_wynajmu"};
        private string[] name = { "car", "car rental", "car repair shop", "repair", "customer", "worker", "sell transaction", "rent transaction" };
        private int[] labels = new int[6];
        private int[] textBoxes = new int[6];
        private char[] format = new char[6];
        private Form2 mainForm = null;
        public Form4(Form mainF, int func, int type, string[] labels)
        {
            mainForm = mainF as Form2;
            InitializeComponent();
            this.function = func;
            this.type = type;
            this.button1.Text = operators[func]+" "+name[type];
           
            Control form;
            for (int k=0; k < this.Controls.Count; k++) 
            {
                form = this.Controls[k];
                if (form.Name.Length>5 && form.Name.Substring(0,5) == "label")
                {
                    int g = (int)Char.GetNumericValue(form.Name[5]) -1;
                    this.labels[g] = k;
                    if (labels[g].Length == 0 || function == 4)
                        ((Label)form).Visible = false;
                    else
                    {
                        this.format[g] = labels[g][0];
                        ((Label)form).Text = labels[g].Substring(1);
                    }
                }
                else if (form.Name.Length > 7 && form.Name.Substring(0, 7) == "textBox")
                {
                    int g = (int)Char.GetNumericValue(form.Name[7]) - 1;
                    this.textBoxes[g] = k;
                    if (labels[g].Length == 0 || function == 4)
                        ((TextBox)form).Visible = false;
                }
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
            

            switch (this.function)
            {
                case 0:
                    if ((textBox1.Text.Length > 0 == textBox1.Visible) &&
                    (textBox2.Text.Length > 0 == textBox2.Visible) &&
                    (textBox3.Text.Length > 0 == textBox3.Visible) &&
                    (textBox4.Text.Length > 0 == textBox4.Visible) &&
                    (textBox5.Text.Length > 0 == textBox5.Visible) &&
                    (textBox6.Text.Length > 0 == textBox6.Visible)) //pola wymagane są 
                    {
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
                    }
                    break;
                case 1:
                    if ((textBox1.Text.Length > 0 == true) ||
                    (textBox2.Text.Length > 0 == true) ||
                    (textBox3.Text.Length > 0 == true) ||
                    (textBox4.Text.Length > 0 == true) ||
                    (textBox5.Text.Length > 0 == true) ||
                    (textBox6.Text.Length > 0 == true))

                    {
                        OracleCommand cmd2 = mainForm.mainForm.con.CreateCommand();
                        cmd2.CommandText = "delete from " + entity[this.type] + " where ";
                        int c = cmd2.CommandText.Length;
                        for (int i = 0; i < 6; i++)
                        {
                            if (this.Controls[textBoxes[i]].Text.Length > 0)
                            {
                                cmd2.CommandText += this.Controls[labels[i]].Text + "=";
                                if (format[i] == 'N')
                                    cmd2.CommandText += this.Controls[textBoxes[i]].Text + "and ";
                                else
                                    cmd2.CommandText += "'" + this.Controls[textBoxes[i]].Text + "' and ";
                            }
                        }
                        cmd2.CommandText = cmd2.CommandText.Substring(0, cmd2.CommandText.Length - 4);
                        OracleDataReader reader = cmd2.ExecuteReader();
                        if (reader.HasRows)
                            while (reader.Read())
                                this.richTextBox1.Text += "\t " + reader.GetString(0) + "\t " + reader.GetString(1) + "\t "
                                    + reader.GetString(2) + "\t " + reader.GetString(3) + "\t " + reader.GetString(4) + "\t " + reader.GetString(5) + "\r\n";

                        else
                            Console.WriteLine("No rows found.");
                        reader.Close();

                    }
                    break;

                case 2:
                    if ((textBox1.Text.Length > 0 == true) ||
                    (textBox2.Text.Length > 0 == true) ||
                    (textBox3.Text.Length > 0 == true) ||
                    (textBox4.Text.Length > 0 == true) ||
                    (textBox5.Text.Length > 0 == true) ||
                    (textBox6.Text.Length > 0 == true))

                    {
                        OracleCommand cmd2 = mainForm.mainForm.con.CreateCommand();
                        cmd2.CommandText = "select * from " + entity[this.type] + " where ";
                        int c = cmd2.CommandText.Length;
                        for(int i=0; i < 6; i++)
                        {
                            if (this.Controls[textBoxes[i]].Text.Length>0)
                            {
                                cmd2.CommandText += this.Controls[labels[i]].Text + "=";
                                if (format[i] == 'N')
                                    cmd2.CommandText += this.Controls[textBoxes[i]].Text + ",";
                                else
                                    cmd2.CommandText += "'" + this.Controls[textBoxes[i]].Text + "',";
                            }
                        }
                        cmd2.CommandText = cmd2.CommandText.Substring(0, cmd2.CommandText.Length - 1);
                        OracleDataReader reader = cmd2.ExecuteReader();
                        if (reader.HasRows)
                            while (reader.Read())
                                this.richTextBox1.Text += "\t " + reader.GetString(0) + "\t " + reader.GetString(1) + "\t "
                                   + reader.GetString(2) + "\t " + reader.GetString(3) + "\t " + reader.GetString(4) + "\t " + reader.GetString(5) + "\r\n";
                        else
                            Console.WriteLine("No rows found.");
                        reader.Close();

                    }
                    break;

                case 4:
                    OracleCommand cmd3 = mainForm.mainForm.con.CreateCommand();
                    cmd3.CommandText = "select * from " + entity[this.type];
                    OracleDataReader reader1 = cmd3.ExecuteReader();
                    if (reader1.HasRows)
                        while (reader1.Read())
                            this.richTextBox1.Text += "\t " + reader1.GetString(0) + "\t " + reader1.GetString(1) + "\t "
                                   + reader1.GetString(2) + "\t " + reader1.GetString(3) + "\t " + reader1.GetString(4) + "\t " + reader1.GetString(5) + "\r\n";
                    else
                        Console.WriteLine("No rows found.");
                    reader1.Close();
                    break;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.mainForm.Show();
            this.Close();
        }
    }
}
