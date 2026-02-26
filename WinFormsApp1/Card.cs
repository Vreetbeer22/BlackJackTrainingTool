using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }

        public Card(string rank, string suit) 
        {
            Rank = rank;
            Suit = suit;
        }

        public int Value
        {
            get
            {
                if (Rank == "A") return 11;
                if (Rank == "K" || Rank == "Q" || Rank == "J") return 10;
                return int.Parse(Rank);
            }
        }
        public string Display
        {
            get { return Rank + Suit; }
        }

    }
}
