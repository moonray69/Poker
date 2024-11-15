using Poker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class CashRegister : Form
    {
        public CashRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Перевірка на коректне введення суми
            if (!double.TryParse(textBox1.Text, out double amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a positive amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double convert = 10.0;

            int chips = (int)(amount / convert);

            // Обчислюємо новий баланс
            double newBalance = Player.currentPlayer.Balance + chips;

            if (newBalance < 0)
            {
                MessageBox.Show("Error: Balance cannot be negative.", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Player.currentPlayer.Balance += chips;
            

            textBox2.Text = chips.ToString();
            MessageBox.Show($"{chips} chips have been added to your balance.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox2.Text = chips.ToString();
        }
    }
}
