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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Balance { get; set; }


        public string Nickname { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public Card[] Cards { get; set; } = new Card[2];

        public int CurrentRate { get; set; } = 0;

        public Moves LastMove { get; set; }

        //Player()
        //{
        //    Name = "";
        //    Surname = "";
        //    Email = "";
        //    Nickname = "";
        //    Phone = "";
        //    Password = "";
        //}

        //Player(string name, string surname, string email, string nickname, string phone, string password)
        //{
        //    Name = name;
        //    Surname = surname;
        //    Email = email;
        //    Nickname = nickname;
        //    Phone = phone;
        //    Password = password;
        //}



    }
}
