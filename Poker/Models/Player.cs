using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Poker.Models
{
    public class Player
    {
        public static Player currentPlayer {  get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        private int balance;
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value < 0)
                {
                    balance = 0;
                    throw new ArgumentException();
                }
                else
                {
                    balance = value;
                }
            }
        }
        public int Rate {  get; set; }

        public string Nickname { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public Card[] Cards { get; set; } = new Card[2];

        public int CurrentRate { get; set; } = 0;

        public Moves LastMove { get; set; }
    }
}
