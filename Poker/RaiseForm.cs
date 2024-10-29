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
    public partial class RaiseForm : Form
    {
        public int bet { get; private set; }
        public RaiseForm()
        {
            InitializeComponent();
            int ballance = Player.currentPlayer.Balance;

            if(ballance < 50)
            {
                button4.Enabled=false;
            }
            if (ballance < 25)
            {
                button3.Enabled=false;
            }
            if (ballance < 10)
            {
                button2.Enabled=false;
            }

            if (ballance < 5)
            {
                button1.Enabled = false;
                MessageBox.Show("You don`t have enough money for the raise bet");
            }
        }
        //5
        private void button1_Click(object sender, EventArgs e)
        {
            bet = 5;
            Close();
        }
        //10
        private void button2_Click(object sender, EventArgs e)
        {
            bet = 10;
            Close();
        }
        //25
        private void button3_Click(object sender, EventArgs e)
        {
            bet = 25;
            Close();
        }
        //50
        private void button4_Click(object sender, EventArgs e)
        {
            bet = 50;
            Close();
        }

        //private void button_Click(object sender, EventArgs e)
        //{
        //    Button b = (Button)sender;
        //    bet = int.Parse(b.Text);
        //    Close();
        //}
    }
}
