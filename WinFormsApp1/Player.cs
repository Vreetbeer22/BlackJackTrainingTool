using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Player
    {
        public string Name { get; private set; }
        public Hand Hand { get; private set; }

        public bool IsStanding { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        public void ReceiveCard(Card card)
        {
            Hand.AddCard(card);
        }

        public void Stand()
        {
            IsStanding = true;
        }

        public void ResetForNewRound()
        {
            Hand.Clear();
            IsStanding = false;
        }

        public void ClearHand()
        {
            Hand.Clear();
            IsStanding = false;
        }

        public override string ToString()
        {
            return $"{Name}: {Hand}";
        }
    }
}
