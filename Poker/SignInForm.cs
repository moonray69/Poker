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
    public partial class SignInForm : Form
    {
        public SignInForm()
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
                MenuForm f2 = new MenuForm(nickname);
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
            RegistrationForm f5 = new RegistrationForm();
            Hide();
            f5.ShowDialog();
            Show();

        }
    }
}
