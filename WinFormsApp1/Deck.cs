using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Deck
    {
        private List<Card> cards = new List<Card>();
        private int currentIndex = 0;

        private static string[] Ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private static string[] Suits = { "♠", "♥", "♦", "♣" };

        public Deck()
        {
            foreach (string suit in Suits)
                foreach (string rank in Ranks)
                    cards.Add(new Card(rank, suit));
        }
        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                int j = rnd.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
            currentIndex = 0;
        }
        public Card Deal()
        {
            return cards[currentIndex++];
        }
        public int Remaining
        {
            get { return cards.Count -  currentIndex; }
        }
    }
}
