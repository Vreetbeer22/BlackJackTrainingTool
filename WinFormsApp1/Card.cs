using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    public enum Rank
    {
        ACE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING

    }
    public enum Suit 
    {
        HEARTS,
        DIAMONDS,
        SPADES,
        CLUBS
    }


    internal class Card
    {
        Rank rank;
        int value;
        Suit suit;
        bool isFaceDown;

        public int Value
        {
            get
            {
                if (rank >= Rank.TEN) return 10;
                if (rank == Rank.ACE) return 11;
                return (int)rank + 1;
            }
        }

        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public void Flip()
        {
            isFaceDown = !isFaceDown;
        }

        public override string ToString()
        {
            return rank.ToString() + " OF " + suit.ToString();
        }
    }
}
