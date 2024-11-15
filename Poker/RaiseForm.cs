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
        public int bet { get;  set; }
        public bool isAccepted { get; set; }
        private Player pc { get; set; }
        public RaiseForm(Player pc)
        {
            InitializeComponent();
            isAccepted = false;
            this.pc = pc;
           
        }
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            int pcBet = 1;
            int playerBal = Player.currentPlayer.Balance;
            if (pc.Rate> Player.currentPlayer.Rate)
            {
                pcBet = pc.Rate - Player.currentPlayer.Rate;
            }
            
            if(int.TryParse(textBox1.Text, out int a))
            {
                if (a >= pcBet && a <= playerBal)
                {
                    MessageBox.Show($"Your raise: {a}", "your bet is accepted");
                    bet = a;
                    isAccepted = true;
                    Close();
                }
                else
                {
                    MessageBox.Show($"Your bet should be from {pcBet} to {playerBal}!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("please, input correct number!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
