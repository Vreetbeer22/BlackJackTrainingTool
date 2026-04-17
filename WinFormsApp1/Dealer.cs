using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Dealer
    {
        public Hand Hand { get; private set; }

        public Dealer()
        {
            Hand = new Hand();
        }

        public void ReceiveCard(Card card)
        {
            Hand.AddCard(card);
        }

        public void ResetForNewRound()
        {
            Hand.Clear();
        }

        public override string ToString()
        {
            return $"Dealer: {Hand}";
        }
    }
}
