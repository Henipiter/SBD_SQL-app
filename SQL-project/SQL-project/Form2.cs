using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string buttonText;
        private int function;
        
        public Form1 mainForm = null;
        public Form2(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
            this.ButtonsDefaultSettings(0,0);
        }
        private void ButtonsDefaultSettings(int switch1,int switch2) 
        {
            switch (switch1)
            {
                case 0:
                    this.CarButton.Enabled = false;
                    this.CarRentalButton.Enabled = false;
                    this.CarRepairShopButton.Enabled = false;
                    this.RepairButton.Enabled = false;
                    this.CustomerButton.Enabled = false;
                    this.WorkerButton.Enabled = false;
                    this.SellTransactionButton.Enabled = false;
                    this.RentTransactionButton.Enabled = false;

                    this.AddButton.Enabled = true;
                    this.DeleteButton.Enabled = true;
                    this.SearchButton.Enabled = true;
                    this.ModifyButton.Enabled = true;
                    this.ShowButton.Enabled = true;
                    break;
                case 1:
                    this.CarButton.Enabled = true;
                    this.CarRentalButton.Enabled = true;
                    this.CarRepairShopButton.Enabled = true;
                    this.RepairButton.Enabled = true;
                    this.CustomerButton.Enabled = true;
                    this.WorkerButton.Enabled = true;
                    this.SellTransactionButton.Enabled = true;
                    this.RentTransactionButton.Enabled = true;
                    if (switch2 != 1)
                        this.AddButton.Enabled = false;
                    if (switch2 != 2)
                        this.DeleteButton.Enabled = false;
                    if (switch2 != 3)
                        this.SearchButton.Enabled = false;
                    if (switch2 != 4)
                        this.ModifyButton.Enabled = false;
                    if (switch2 != 5)
                        this.ShowButton.Enabled = false;
                    break;
                default:
                    break;
            }
            
        }
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            this.buttonText = "Add";
            this.function = 0;
            this.ButtonsDefaultSettings(1, 1);
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.buttonText = "Delete";
            this.function = 1;
            this.ButtonsDefaultSettings(1, 2);
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.buttonText = "Search";
            this.function = 2;
            this.ButtonsDefaultSettings(1, 3);
        }
        private void ModifyButton_Click(object sender, EventArgs e)
        {
            this.buttonText = "Modify";
            this.function = 3;
            this.ButtonsDefaultSettings(1, 4);
        }
        private void ShowButton_Click(object sender, EventArgs e)
        {
            this.buttonText = "Show";
            this.function = 4;
            this.ButtonsDefaultSettings(1, 5);
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            mainForm.con.Close();
            mainForm.Close();
            this.Close();
        }

        private void CarButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.buttonText += " car";
            Form4 formularz = new Form4(this, this.function, this.buttonText, "Numer VIN", "Marka", "Model", "Rocznik", "Nazwa wypozyczalni"  );
           // Form3 frm = new Form3(this,this.buttonText);


            formularz.Show();
        }
        private void CarRentalButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.buttonText += " car rental";
            Form4 formularz = new Form4(this, this.function, this.buttonText, "Nazwa", "Adres");
            formularz.Show();
        }
        private void CarRepairShopButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.buttonText += " car repair shop";
            Form4 formularz = new Form4(this, this.function, this.buttonText, "Nazwa", "Adres");
            formularz.Show();
        }

        private void RepairButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.buttonText += " repair";
            Form4 formularz = new Form4(this, this.function, this.buttonText, "*Numer naprawy", "Data naprawy", "Cena robocizny", "Nazwa warsztatu", "Numer VIN");
            formularz.Show();
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.buttonText += " customer";
            Form4 formularz = new Form4(this, this.function, this.buttonText, "*ID", "Imie", "Nazwisko", "PESEL");
            formularz.Show();
        }

        private void WorkerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.buttonText += " worker";
            Form4 formularz = new Form4(this, this.function, this.buttonText, "*ID", "Imie", "Nazwisko", "Pesel", "Placa", "Nazwa wypozyczalni");
            formularz.Show();
        }

        private void SellTransactionButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.buttonText += " sell transaction";
            Form4 formularz = new Form4(this, this.function, this.buttonText, "*Numer zlecenia", "Data sprzedazy", "Cena", "Rabat", "VIN", "ID_klienta");
            formularz.Show();
        }

        private void RentTransactionButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.buttonText += " rent transaction";
            Form4 formularz = new Form4(this, this.function, this.buttonText, "*Numer zlecenia", "Cena","Data wynajmu", "Data oddania",  "VIN", "ID_klienta");

            formularz.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.ButtonsDefaultSettings(0, 5);
        }

        
    }
}
