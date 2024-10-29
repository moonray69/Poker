using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Models;

namespace Poker
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            InitializeDeck();
        }


        //ініціалізація колоди
        private void InitializeDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    //форматована стринга
                    string image = $"images/{Card.ranks[rank]}_of_{suit.ToString().ToLower()}";
                    cards.Add(new Card(suit, rank, image));
                }
            }
        }

        //Перетасувати колоду
        public void Shuffle()
        {
            Random rnb = new Random();
            int zxc = cards.Count;

            while (zxc > 1)
            {
                zxc--;
                int k = rnb.Next(0, cards.Count);
                Card card = cards[k];
                cards[k] = cards[zxc];
                cards[zxc] = card;
            }

        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("No cards left in the deck.");
            }
            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            return drawnCard;

        }
    }
}
