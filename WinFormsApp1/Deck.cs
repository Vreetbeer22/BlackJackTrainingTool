using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Deck
    {
        private List<Card> cards;

        public int CardsLeft => cards.Count;

        public Deck()
        {
            cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                (cards[k], cards[n]) = (cards[n], cards[k]);
            }
        }

        public Card Deal()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty");
            }
            Card top = cards[0];
            cards.RemoveAt(0);
            return top;
        }

        public void Reset()
        {
            cards.Clear();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }
    }
}
