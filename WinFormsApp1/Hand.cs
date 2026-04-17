using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Hand
    {
        private List<Card> cards;

        public int CardCount => cards.Count;

        public Hand()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void Clear()
        {
            cards.Clear();
        }

        public int CalculateValue()
        {
            int total = 0;
            int aceCount = 0;

            foreach (Card card in cards)
            {
                total += card.Value;
                if (card.Value == 11)
                {
                    aceCount++;
                }
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }

        public override string ToString()
        {
            if (cards.Count == 0)
            {
                return "Empty hand";
            }
            return string.Join(", ", cards) + $" (Value: {CalculateValue()})";
        }

    }
}