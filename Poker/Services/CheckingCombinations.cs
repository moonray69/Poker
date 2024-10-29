using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Models;

namespace Poker
{
    public class CheckingCombinations
    {
        //Рояль флеш
        public bool isRoyalFlush(List<Card> cards)
        {
            var royalRanks = new List<Rank> { Rank.Ten, Rank.Jack, Rank.Queen, Rank.King, Rank.Ace };
            var suits = cards.GroupBy(c => c.suit); // групую картки по мастях

            foreach (var suitGroup in suits)
            {
                var cardsOfSameSuit = suitGroup.Select(c => c.rank).ToList();

                if (royalRanks.All(r => cardsOfSameSuit.Contains(r)))
                {
                    return true;
                }
            }
            return false;
        }



        //Стріт флеш перевірити чи в тій послідовності є 5 карт 
        public bool isStraightFlush(List<Card> cards)
        {
            var suits = cards.GroupBy(g => g.suit);
            foreach (var suitGroup in suits)
            {
                var ranks = suitGroup.Select(g => g.rank).OrderBy(r => r).ToList();
                if (ranks.Count == 5 && IsSequential(ranks))
                {
                    return true;
                }
            }
            return false;
        }

        //послідовність
        public bool IsSequential(List<Rank> ranks)
        {
            // Сортуємо ранги
            ranks = ranks.OrderBy(r => r).ToList();
            //orderby задает сортировку возвращаемой последовательности или вложенной последовательности (группы) в порядке возрастания или убывания. 

            // Перевіряємо послідовність
            for (int i = 0; i < ranks.Count - 1; i++)
            {
                if (ranks[i + 1] - ranks[i] != 1)
                {
                    return false;
                }
            }
            return true;
        }


        //це Каре масті
        public bool isFourOfAKind(List<Card> cards)
        {
            //return cards.GroupBy(d => d.rank).Any(d => d.Count() == 4);
            var rankGroup = cards.GroupBy(d => d.rank);
            foreach (var group in rankGroup)
            {
                if (group.ToList().Count() == 4)
                {
                    return true;
                }
            }
            return false;
        }


        //Full House
        public bool isFullHouse(List<Card> cards)
        {
            var rankGroup = cards.GroupBy(c => c.rank).ToList();
            bool hasThreeOfAKind = rankGroup.Any(group =>  group.Count() == 3);
            bool hasPair = rankGroup.Any(group => group.Count() == 2);

            return hasThreeOfAKind && hasPair;
        }

        //flash
        public bool isFlush(List<Card> cards)
        {
            var suits = cards.GroupBy(g => g.suit);
            return suits.Any(group => group.Count() == 5);
        }

        //street
        public bool isStraight(List<Card> cards)
        {
            var ranks = cards.Select(c => c.rank).ToList();
            
            return IsSequential(ranks) && cards.Count == 5;
        }

        //trips
        public bool isTrips(List<Card> cards)
        {
            var ranks = cards.GroupBy(c => c.rank);
            return ranks.Any(group => group.Count() == 3);
        }

        //TwoCouple = дві пари
        public bool isTwoCouple(List<Card> cards)
        {
            var rank = cards.GroupBy(card => card.rank);
            return rank.Count(group => group.Count() == 2) == 2;
        }

        //пара
        public bool isCouple(List<Card> cards)
        {
            var rank = cards.GroupBy((card) => card.rank);
            return rank.Count(c => c.Count() == 2) == 1;
        }

        //старша карта
        public int isSeniorCards(List<Card> cards)
        {
            var rank = cards.OrderBy(c => c.rank).ToList();
            return (int)rank[rank.Count()-1].rank;

        }

    }
}
