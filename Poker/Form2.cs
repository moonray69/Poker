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


    public partial class Form2 : Form
    {
        string nickname;
        public Form2(string nickname)
        {
            InitializeComponent();
            this.nickname = nickname;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(nickname);
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
