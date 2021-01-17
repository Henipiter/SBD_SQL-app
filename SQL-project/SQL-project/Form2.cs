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
        private int function;
        private int type;
        
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
                    this.cancelButton.Enabled = false;
                    this.PartButton.Enabled = false;

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
                    this.cancelButton.Enabled = true;
                    this.PartButton.Enabled = true;
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
            this.function = 0;
            this.ButtonsDefaultSettings(1, 1);
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.function = 1;
            this.ButtonsDefaultSettings(1, 2);
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.function = 2;
            this.ButtonsDefaultSettings(1, 3);
        }
        private void ModifyButton_Click(object sender, EventArgs e)
        {
            this.function = 3;
            this.ButtonsDefaultSettings(1, 4);
        }
        private void ShowButton_Click(object sender, EventArgs e)
        {
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
           // this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.type = 0;
            string[] labels = { "*VNumer_VIN", " VMarka", " VCModel", " NRocznik", "*VNazwa_wypozyczalni_posiadajacej", ""};
            Form4 formularz = new Form4(this, this.function, this.type, labels);
            formularz.Show();
        }
        private void CarRentalButton_Click(object sender, EventArgs e)
        {
           // this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.type = 1;
            string[] labels = { "*VNazwa", " VAdres", "", "", "", "" };
            Form4 formularz = new Form4(this, this.function, this.type, labels);
            formularz.Show();
        }
        private void CarRepairShopButton_Click(object sender, EventArgs e)
        {
          //  this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.type = 2;
            string[] labels = { "*VNazwa_warsztatu", " VAdres_warsztanu", "", "", "", "" };
            Form4 formularz = new Form4(this, this.function, this.type, labels);
            formularz.Show();
        }

        private void RepairButton_Click(object sender, EventArgs e)
        {
           // this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.type = 3;
            string[] labels = { "*NNr_naprawy", " DData_naprawy", " NCena_robocizny", "*VNazwa_warsztatu_naprawiajacego", "*VNr_VIN_naprawianego_samochodu", "" };
            Form4 formularz = new Form4(this, this.function, this.type, labels);
            formularz.Show();
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
           // this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.type = 4;
            string[] labels = {"*NID_klienta", " VImie_klienta", " VNazwisko_klienta", " NPESEL_klienta", "", "", "" };
            Form4 formularz = new Form4(this, this.function, this.type, labels);
            formularz.Show();
        }

        private void WorkerButton_Click(object sender, EventArgs e)
        {
           // this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.type = 5;
            string[] labels = {"*NID_pracownika", " VImie_pracownika", " VNazwisko_pracownika", " NPesel_pracownika", " NPlaca", "*VNazwa_wypozyczalni" };
            Form4 formularz = new Form4(this, this.function, this.type, labels);
            formularz.Show();
        }

        private void SellTransactionButton_Click(object sender, EventArgs e)
        {
           // this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.type = 6;
            string[] labels = { "*NNr_zlecenia_sprzedazy", " DData_sprzedazy", " NCena", " NPrzyznany_Rabat", "*VNr_VIN_sprzedawanego_samochodu", "*NID_klienta_kupujacego" };
            Form4 formularz = new Form4(this, this.function, this.type, labels);
            formularz.Show();
        }

        private void RentTransactionButton_Click(object sender, EventArgs e)
        {
           // this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.type = 7;
            string[] labels = { "*NNr_zlecenia_wynajmu", " NCena", " DData_wynajmu", " DData_oddania", "*VNr_VIN_wynajmowanego_samochodu", "*NID_klienta_wynajmujacego" };
            Form4 formularz = new Form4(this, this.function, this.type, labels);
            formularz.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.ButtonsDefaultSettings(0, 5);
        }

        private void PartButton_Click(object sender, EventArgs e)
        {
           // this.Hide();
            this.ButtonsDefaultSettings(0, 5);
            this.type = 9;
            string[] labels = { "*NNumer_naprawy", "*VNazwa_elementu", " NCena", "", "", "" };
            Form4 formularz = new Form4(this, this.function, this.type, labels);
            formularz.Show();
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5(this);
            frm.Show();
        }
    }
}
