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
    public partial class Form5 : Form
    {
        public Form2 mainForm = null;
        public Form5(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as Form2;
        }

        private void CountCarsButton_Click(object sender, EventArgs e)
        {

        }

        private void CountRepairButton_Click(object sender, EventArgs e)
        {

        }

        private void CountCarCosts_Click(object sender, EventArgs e)
        {

        }

        private void CountCarEarnings_Click(object sender, EventArgs e)
        {

        }

        private void CountCarValue_Click(object sender, EventArgs e)
        {

        }

        private void PopularCarsButton1_Click(object sender, EventArgs e)
        {

        }

        private void Top5carsButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
