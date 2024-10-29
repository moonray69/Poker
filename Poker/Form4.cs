using Microsoft.IdentityModel.Tokens;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nickname = textBox1.Text;
            string password = textBox2.Text;

            if (nickname.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                MessageBox.Show("Please enter a valid nickname or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Player? foundPlayer = Serialization.findPlayer(nickname, password);
            
            if(foundPlayer != null)
            {
                Player.currentPlayer = foundPlayer;
                Form2 f2 = new Form2(nickname);
                Hide();
                f2.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("There is no such user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            Hide();
            f5.ShowDialog();
            Show();// ховає зайві вікна

        }
    }
}
