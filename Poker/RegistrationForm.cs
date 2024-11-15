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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string surname = surnameTextBox.Text;
            string email = emailTextBox.Text;
            string nickname = nicknameTextBox.Text;
            string phone = phonenumberTextBox.Text;
            string password = passwordTextBox.Text;

            if (name == "" || surname == "" || email == "" || nickname == "" ||
                phone == "" || password == "")
            {
                MessageBox.Show("You missed a field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!email.Contains("@") || !email.EndsWith(".com"))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Player player = new Player
            {
                Name = name,
                Surname = surname,
                Email = email,
                Nickname = nickname,
                Password = password,
                Phone = phone
            };

            bool isSaved = Serialization.SaveData(player);

            if (isSaved)
            {
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("This nickname is already taken. Please choose a different one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

