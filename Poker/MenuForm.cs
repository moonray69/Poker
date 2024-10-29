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


    public partial class MenuForm : Form
    {
        string nickname;
        public MenuForm(string nickname)
        {
            InitializeComponent();
            this.nickname = nickname;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameForm f1 = new GameForm(nickname);
            f1.ShowDialog();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             CashRegister cash = new CashRegister();

            cash.ShowDialog();
            //Hide();
        }
    }
}
