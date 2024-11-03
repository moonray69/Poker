using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card
    {
        //Dictionary - словник , є ключ і є значення
        public static Dictionary<Rank, string> ranks = new Dictionary<Rank, string>()
        {
            {Rank.Two,"2"},
            {Rank.Three,"3"},
            {Rank.Four,"4"},
            {Rank.Five,"5"},
            {Rank.Six,"6"},
            {Rank.Seven,"7"},
            {Rank.Eight,"8"},
            {Rank.Nine,"9"},
            {Rank.Ten,"10"},
            {Rank.Jack,"jack"},
            {Rank.Queen,"queen"},
            {Rank.King,"king"},
            {Rank.Ace,"ace"}

        };
      
        public Suit suit { get; set; }
        public Rank rank { get; set; }

        public string image {  get; set; }
        public Card(Suit suit, Rank rank, string image)
        {
            this.suit = suit;
            this.rank = rank;
            this.image = image;
        }

        public string GetImgFileName()
        {
            string rankString = ranks[rank];
            return $"{rankString}_of_{suit}.png";
        }

        public override string ToString()
        {
            return rank.ToString() + " " + suit.ToString();
        }
    }

}




