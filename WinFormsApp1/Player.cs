using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Player
    {
        public string Name { get; private set; }
        public Hand Hand { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        public void ReceiveCard(Card card)
        {
            Hand.AddCard(card);
        }

        public void ClearHand()
        {
            Hand.Clear();
        }

        public override string ToString()
        {
            return $"{Name}: {Hand}";
        }
    }
}
