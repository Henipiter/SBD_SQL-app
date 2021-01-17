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
        private string[] entity = { "samochody", "wypozyczalnie", "warsztaty", "naprawy", "klienci", "pracownicy_wypozyczalni", "zlecenia_sprzedazy", "zlecenia_wynajmu", "elementy_naprawiane", "elementy_naprawiane" };
        private string[] name = { "car", "car rental", "car repair shop", "repair", "customer", "worker", "sell transaction", "rent transaction","part repair","part repair" };
        private string[] deleteProcedure = { "samochod", "wypozyczalnie", "warsztat", "naprawy", "klienta", "pracownika", "zleceniesprzedzazy", "zleceniewynajmu" ,"element","element"};
        private string[] modifyProcedure = { "samochod","wypozyczalnie","warsztat","naprawe","klienta","pracownika","zleceniesprzedazy","zleceniewynajmu" };
        private int[] labels = new int[6];
        private int[] textBoxes = new int[6];
        private char[] format = new char[6];
        private bool[] key = new bool[6];
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
                if (form.Name.Length > 5 && form.Name.Substring(0, 5) == "label")
                {

                    int g = (int)Char.GetNumericValue(form.Name[5]) - 1;
                    if (g < 6)
                    {
                        this.labels[g] = k;
                        if (labels[g].Length == 0 || function == 4 || (function == 1 && g != 0))
                            ((Label)form).Visible = false;
                        else
                        {
                            this.format[g] = labels[g][1];
                            if (labels[g][0] == '*')
                                this.key[g] = true;
                            else
                                this.key[g] = false;
                            ((Label)form).Text = Char.ToString(labels[g][0])+labels[g].Substring(2);
                        }
                    }
                }
                else if (form.Name.Length > 7 && form.Name.Substring(0, 7) == "textBox")
                {
                    int g = (int)Char.GetNumericValue(form.Name[7]) - 1;
                    if (g < 6)
                    {
                        this.textBoxes[g] = k;
                        if (labels[g].Length == 0 || function == 4 || (function == 1 && g != 0)) 
                            ((TextBox)form).Visible = false;
                    }
                }
            }
            if (this.button1.Text == "Add repair" || this.button1.Text == "Add rent transaction" || this.button1.Text == "Add customer" || this.button1.Text == "Add sell transaction" || this.button1.Text == "Add worker")
            {
                this.label1.Visible = false;
                this.textBox1.Visible = false;
            }
            if (this.button1.Text == "Delete part repair") 
            {
                this.label2.Text = "Nazwa elementu";
                this.label1.Visible = false;
                this.textBox1.Visible = false;
                this.label2.Visible = true;
                this.textBox2.Visible = true;
                this.label3.Visible = false;
                this.textBox3.Visible = false;
            }
                if (this.button1.Text == "Add part repair")
            {
                this.label7.Visible = true;
                this.textBox8.Visible = true;
                this.label8.Visible = true;
                this.textBox7.Visible = true;
                this.label2.Visible = false;
                this.label3.Visible = false;
                this.textBox2.Visible = false;
                this.textBox3.Visible = false;
            }
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
        private void exceptionSevice(Exception a)
        {
           
            string code = a.Message.Substring(0, 9);
            if (code == "ORA-00001")
            {
                MessageBox.Show("Istnieje identyfikator o takiej nazwie");
            }else if (code == "ORA-21122")
            {
                MessageBox.Show("Samochod zostal juz wynajety w tym terminie");
            }
            else if (code == "ORA-21222")
            {
                MessageBox.Show("Samochod zostal juz sprzedany");
            }
            else if(code == "ORA-02291")
            {
                Control s;
                string msg = "Nie istnieje identyfikator:\n ";
                for(int i = 0; i < 6; i++)
                {
                    s = this.Controls[labels[i]];
                    if (this.key[i] && ((Label)s).Visible)
                        msg += ((Label)s).Text + " LUB\n";
                }
                msg = msg.Substring(0, msg.Length - 5);
                MessageBox.Show(msg);

            }
            else if (code == "ORA-12899")
            {
                string msg = "Zbyt duzo znakow w polu ";
                msg += a.Message.Split('"')[5];
                MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show(a.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            
            switch (this.function)
            {
                case 0:
                    OracleCommand cmd;
                    int result;
                    if ((textBox1.Text.Length > 0 == textBox1.Visible) &&
                    (textBox2.Text.Length > 0 == textBox2.Visible) &&
                    (textBox3.Text.Length > 0 == textBox3.Visible) &&
                    (textBox4.Text.Length > 0 == textBox4.Visible) &&
                    (textBox5.Text.Length > 0 == textBox5.Visible) &&
                    (textBox6.Text.Length > 0 == textBox6.Visible)) //pola wymagane są 
                    {
                        switch (this.type)
                        {
                            case 0:
                                result = 0;
                                try { result = Int32.Parse(this.textBox4.Text); }
                                catch (FormatException)
                                {
                                    MessageBox.Show("Podaj liczbe w polu 'Rocznik'");
                                    Console.WriteLine("Podaj liczbe w polu 'Rocznik'");
                                    break;
                                }
                                try
                                {
                                    if (this.textBox1.Text.Length != 17)
                                        throw new Exception();
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Numer VIN musi miec 17 znakow");
                                    break;
                                }
                                cmd = mainForm.mainForm.con.CreateCommand();
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
                                catch (Exception q)
                                {
                                    exceptionSevice(q);
                                }
                                break;
                            case 1:
                                cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowaWypozyczalnia";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vNazwa", OracleDbType.Varchar2).Value = this.textBox1.Text;
                                cmd.Parameters.Add("vAdres", OracleDbType.Varchar2).Value = this.textBox2.Text;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    CleanTextBoxes();
                                }
                                catch (Exception q)
                                {
                                    exceptionSevice(q);
                                }
                                break;
                            case 2:
                                cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowyWarsztat";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vNazwa", OracleDbType.Varchar2).Value = this.textBox1.Text;
                                cmd.Parameters.Add("vAdres", OracleDbType.Varchar2).Value = this.textBox2.Text;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    CleanTextBoxes();
                                }
                                catch (Exception q)
                                {
                                    exceptionSevice(q);
                                }
                                
                                break;

                            case 4:
                                long pesel;
                                try { pesel = Int64.Parse(this.textBox4.Text); }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj liczbe w polu 'PESEL'");
                                    break;
                                }
                                cmd = mainForm.mainForm.con.CreateCommand();
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
                                catch (Exception q)
                                {
                                    exceptionSevice(q);
                                }
                                
                                break;
                            case 5:
                                int placa;
                                try{ pesel = Int64.Parse(this.textBox4.Text); }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj liczbe w polu 'PESEL'");
                                    break;
                                }
                                try { placa = Int32.Parse(this.textBox5.Text); }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj liczbe w polu 'Placa'");
                                    break;
                                }
                                cmd = mainForm.mainForm.con.CreateCommand();
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
                                catch (Exception q)
                                {
                                    exceptionSevice(q);
                                }
                                break;
                            case 6:
                                int cena;
                                int rabat;
                                try{ cena = Int32.Parse(this.textBox3.Text); }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj liczbe w polu 'Cena'");
                                    break;
                                }
                                try { rabat = Int32.Parse(this.textBox4.Text); }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj liczbe w polu 'Rabat'");
                                    break;
                                }
                                cmd = mainForm.mainForm.con.CreateCommand();
                                DateTime dt;

                                int rok, miesiac, dzien;
                                try {
                                    rok = Int32.Parse(this.textBox2.Text.Substring(0, 4));
                                    miesiac = Int32.Parse(this.textBox2.Text.Substring(5, 2));
                                    dzien = Int32.Parse(this.textBox2.Text.Substring(8, 2));
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj odpowiedni format zapisu daty");
                                    break;
                                }
                                try
                                {
                                    dt = new DateTime(rok, miesiac, dzien, 0, 0, 0, 0);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj wlasciwa date");
                                    break;
                                }
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
                                catch (Exception q)
                                {
                                    exceptionSevice(q);
                                }
                                break;
                            case 7:
                                try { cena = Int32.Parse(this.textBox2.Text); }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj liczbe w polu 'Cena'");
                                    break;
                                }
                                int rok2, miesiac2, dzien2;
                                try
                                {
                                    rok = Int32.Parse(this.textBox3.Text.Substring(0, 4));
                                    miesiac = Int32.Parse(this.textBox3.Text.Substring(5, 2));
                                    dzien = Int32.Parse(this.textBox3.Text.Substring(8, 2));
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj odpowiedni format zapisu daty wynajmu");
                                    break;
                                }
                                try
                                {
                                    dt = new DateTime(rok, miesiac, dzien, 0, 0, 0, 0);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj wlasciwa date");
                                    break;
                                }
                                DateTime dt2;
                                try
                                {
                                    rok2 = Int32.Parse(this.textBox4.Text.Substring(0, 4));
                                    miesiac2 = Int32.Parse(this.textBox4.Text.Substring(5, 2));
                                    dzien2 = Int32.Parse(this.textBox4.Text.Substring(8, 2));
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj odpowiedni format zapisu daty wynajmu");
                                    break;
                                }
                                try
                                {
                                    dt2 = new DateTime(rok2, miesiac2, dzien2, 0, 0, 0, 0);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj wlasciwa date");
                                    break;
                                }
                                try { if (dt > dt2) throw new Exception(); }
                                catch (Exception)
                                {
                                    MessageBox.Show("Daty sie wykluczaja");
                                    break;
                                }
                                cmd = mainForm.mainForm.con.CreateCommand();
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
                                catch (Exception q)
                                {
                                    exceptionSevice(q);
                                }
                                break;
                            case 3:
                                if ((textBox1.Text.Length > 0 == textBox1.Visible) &&
                                    (textBox2.Text.Length > 0 == textBox2.Visible) &&
                                    (textBox3.Text.Length > 0 == textBox3.Visible) &&
                                    (textBox4.Text.Length > 0 == textBox4.Visible) &&
                                    (textBox5.Text.Length > 0 == textBox5.Visible) &&
                                    (textBox6.Text.Length > 0 == textBox6.Visible)) //pola wymagane są 
                                {
                                    try { cena = Int32.Parse(this.textBox3.Text); }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Podaj liczbe w polu 'Cena'");
                                        break;
                                    }
                                    try
                                    {
                                        rok = Int32.Parse(this.textBox2.Text.Substring(0, 4));
                                        miesiac = Int32.Parse(this.textBox2.Text.Substring(5, 2));
                                        dzien = Int32.Parse(this.textBox2.Text.Substring(8, 2));
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Podaj odpowiedni format zapisu daty wynajmu");
                                        break;
                                    }
                                    try
                                    {
                                        dt = new DateTime(rok, miesiac, dzien, 0, 0, 0, 0);
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Podaj wlasciwa date");
                                        break;
                                    }
                                    cmd = mainForm.mainForm.con.CreateCommand();
                                    cmd.CommandText = "nowaNaprawa1";
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("vDataNaprawy", OracleDbType.Date).Value = dt;
                                    cmd.Parameters.Add("vCenaRobocizny", OracleDbType.Decimal).Value = cena;
                                    cmd.Parameters.Add("vNazwaWarsztatu", OracleDbType.Varchar2).Value = this.textBox4.Text;
                                    cmd.Parameters.Add("vNrVIN", OracleDbType.Varchar2).Value = this.textBox5.Text;
                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                        CleanTextBoxes();
                                        this.label7.Visible = true;
                                        this.label8.Visible = true;
                                        this.textBox7.Visible = true;
                                        this.textBox8.Visible = true;
                                        this.button1.Text = "Add parts";
                                        this.type = 8;
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
                                    }
                                    catch (Exception q)
                                    {
                                        exceptionSevice(q);
                                    }
                                }
                                break;
                            case 8:
                                try { cena = Int32.Parse(this.textBox8.Text); }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj liczbe w polu 'Cena'");
                                    break;
                                }
                                cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "noweCzesci";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vNazwaElementu", OracleDbType.Varchar2).Value = this.textBox7.Text;
                                cmd.Parameters.Add("vCenaElementu", OracleDbType.Varchar2).Value = cena;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    CleanTextBoxes();
                                }
                                catch (Exception q)
                                {

                                    exceptionSevice(q);
                                }
                                break;
                            case 9:
                                try { cena = Int32.Parse(this.textBox8.Text); }
                                catch (Exception)
                                {
                                    MessageBox.Show("Podaj liczbe w polu 'Cena'");
                                    break;
                                }
                                int nrNaprawy = Int32.Parse(this.textBox1.Text);
                                cmd = mainForm.mainForm.con.CreateCommand();
                                cmd.CommandText = "nowaCzesc";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("vNrNaprawy", OracleDbType.Decimal).Value = nrNaprawy;
                                cmd.Parameters.Add("vNazwaElementu", OracleDbType.Varchar2).Value = this.textBox7.Text;
                                cmd.Parameters.Add("vCenaElementu", OracleDbType.Varchar2).Value = cena;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    CleanTextBoxes();
                                }
                                catch (Exception q)
                                {
                                    exceptionSevice(q);
                                }
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wypelnij wszystkie pola");
                    }
                    break;
                case 1:
                    if ((textBox1.Text.Length > 0 == true))
                    {

                        result = 0;
                        if (format[0] == 'N')
                        {
                            try { result = Int32.Parse(this.textBox1.Text); }
                            catch (FormatException)
                            {
                                MessageBox.Show("Podaj liczbe w identyfikatorze");
                                Console.WriteLine("Podaj liczbe w identyfikatorze");
                                break;
                            }
                        }
                        cmd = mainForm.mainForm.con.CreateCommand();
                        cmd.CommandText = "usun" + this.deleteProcedure[type];
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (format[0] == 'N')
                            cmd.Parameters.Add("vKlucz", OracleDbType.Decimal).Value = this.textBox1.Text;
                        else
                            cmd.Parameters.Add("vKlucz", OracleDbType.Varchar2).Value = this.textBox1.Text;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            CleanTextBoxes();
                        }
                        catch (Exception q)
                        {
                            exceptionSevice(q);
                        }
                        break;

                    }
                    else if (textBox2.Text.Length > 0 == true) 
                    {
                        
                        cmd = mainForm.mainForm.con.CreateCommand();
                        cmd.CommandText = "usun" + this.deleteProcedure[type];
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("vKlucz", OracleDbType.Varchar2).Value = this.textBox2.Text;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            CleanTextBoxes();
                        }
                        catch (Exception q)
                        {
                            exceptionSevice(q);
                        }
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Przynajmniej jedno pole musi byc wypelnione");
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
                                cmd2.CommandText += this.Controls[labels[i]].Text.Substring(1) + "=";
                                if (format[i] == 'V')
                                    cmd2.CommandText += "'" + this.Controls[textBoxes[i]].Text + "' and ";
                                
                                else if (format[i] == 'N')
                                    cmd2.CommandText += this.Controls[textBoxes[i]].Text + " and ";
                                else if (format[i] == 'D')
                                    cmd2.CommandText += "'"+ this.Controls[textBoxes[i]].Text.Substring(0,4) + this.Controls[textBoxes[i]].Text.Substring(5, 2) + this.Controls[textBoxes[i]].Text.Substring(8,2) + "' and ";
                            }
                        }
                        cmd2.CommandText = cmd2.CommandText.Substring(0, cmd2.CommandText.Length - 5);
                        OracleDataReader reader = cmd2.ExecuteReader();
                        if (reader.HasRows)
                        {
                            this.richTextBox1.Text = "";
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    this.richTextBox1.Text += reader.GetString(i) + "; ";
                                }
                                this.richTextBox1.Text += "\n";
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                            this.richTextBox1.Text = "Zadanych wierszy nie znaleziono";
                        }
                        reader.Close();

                    }
                    else
                    {
                        MessageBox.Show("Przynajmniej jedno pole musi byc wypelnione");
                    }
                    break;
                case 3:
                    if ((textBox1.Text.Length > 0 == textBox1.Visible) &&
                    (textBox2.Text.Length > 0 == textBox2.Visible) &&
                    (textBox3.Text.Length > 0 == textBox3.Visible) &&
                    (textBox4.Text.Length > 0 == textBox4.Visible) &&
                    (textBox5.Text.Length > 0 == textBox5.Visible) &&
                    (textBox6.Text.Length > 0 == textBox6.Visible)) //pola wymagane są 
                    {
                        result = 0;
                        cmd = mainForm.mainForm.con.CreateCommand();
                        cmd.CommandText = "modyfikuj" + this.modifyProcedure[type];
                        cmd.CommandType = CommandType.StoredProcedure;
                        Control form1, form2;
                        for (int i = 0; i < 6; i++)
                        {
                            form1 = this.Controls[labels[i]];
                            if (((Label)form1).Visible)
                            {
                                form2 = this.Controls[textBoxes[i]];
                                if (format[i] == 'V')
                                {
                                    cmd.Parameters.Add("v" + ((Label)form1).Text, OracleDbType.Varchar2).Value = ((TextBox)form2).Text;
                                }
                                else if (format[i] == 'N')
                                {
                                    try { result = Int32.Parse(((TextBox)form2).Text); }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show("Podaj liczbe w polu " + ((Label)form1).Text);
                                        Console.WriteLine("Podaj liczbe we wlasciwym polu'");
                                        break;
                                    }
                                    cmd.Parameters.Add("v" + ((Label)form1).Text, OracleDbType.Decimal).Value = result;
                                }
                                else
                                {
                                    int rok, miesiac, dzien;
                                    try
                                    {
                                        rok = Int32.Parse(((TextBox)form2).Text.Substring(0, 4));
                                        miesiac = Int32.Parse(((TextBox)form2).Text.Substring(5, 2));
                                        dzien = Int32.Parse(((TextBox)form2).Text.Substring(8, 2));
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Podaj odpowiedni format zapisu daty w polu " + ((Label)form1).Text);
                                        break;
                                    }
                                    DateTime dt;
                                    try
                                    {
                                        dt = new DateTime(rok, miesiac, dzien, 0, 0, 0, 0);
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Podaj wlasciwa date");
                                        break;
                                    }
                                    cmd.Parameters.Add("v" + ((Label)form1).Text, OracleDbType.Date).Value = dt;
                                }
                            }
                        }
                        try
                        {
                            cmd.ExecuteNonQuery();
                            CleanTextBoxes();
                        }
                        catch (Exception q)
                        {
                            exceptionSevice(q);
                        }
                    }
                    break;
                case 4:
                    OracleCommand cmd3 = mainForm.mainForm.con.CreateCommand();
                    cmd3.CommandText = "select * from " + entity[this.type];
                    OracleDataReader reader1 = cmd3.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        this.richTextBox1.Text = "";
                        while (reader1.Read())
                        {
                            for (int i = 0; i < reader1.FieldCount; i++)
                            {
                                this.richTextBox1.Text += reader1.GetString(i) + "; ";
                            }
                            this.richTextBox1.Text += "\n";
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                        this.richTextBox1.Text = "Brak wierszy";
                    }
                    reader1.Close();
                    break;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.mainForm.Show();
            this.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
