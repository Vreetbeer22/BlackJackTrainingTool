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
        int cardValue;
        Suit suit;
        bool isFaceDown;

        public int Value
        {
            get
            {
                if (rank >= Rank.TEN)
                {
                    cardValue = 10;
                }
                else if (rank == Rank.ACE) 
                {
                    cardValue = 11; 
                }
                else 
                {
                    cardValue = (int)rank + 1; 
                }
                return cardValue;
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
