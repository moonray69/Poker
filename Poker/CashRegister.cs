﻿using Poker.Models;
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
            double amount = Convert.ToDouble(textBox1.Text);

            double convert = 10.0;

            double chips = amount / convert;

            Player.currentPlayer.Balance += (int)chips;
            textBox2.Text = chips.ToString();
            MessageBox.Show($"{chips} chips have been added to your balance.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Передаем сумму фишек в Form1

            textBox2.Text = chips.ToString();
            //mainForm.updateBalanceChips(Player.currentPlayer.Balance);
        }
    }
}