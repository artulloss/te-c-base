using System.Collections.Generic;

namespace ClassesExamples.Classes
{
    
    public class Card
    {
        public string Suit { get; }
        
        public int Value { get;  }
        
        public bool IsFaceUp { get; private set; }

        public string FaceValue  => FaceValues[Value];

        /// <summary>
        /// Constructor to create a card
        /// </summary>
        /// <param name="value">The cards value; 1-13</param>
        /// <param name="suit">The suit; Hearts, Diamonds, Clubs, Spades</param>
        public Card(int value, string suit, bool isFaceUp = true)
        {
            Value = value;
            Suit = suit;
            IsFaceUp = isFaceUp;
        }

        private static readonly Dictionary<int, string> FaceValues = new Dictionary<int, string>()
        {
            {1, "Ace" },
            {2, "Two" },
            {3, "Three" },
            {4, "Four" },
            {5, "Five" },
            {6, "Six" },
            {7, "Seven" },
            {8, "Eight" },
            {9, "Nine" },
            {10, "Ten" },
            {11, "Jack" },
            {12, "Queen" },
            {13, "King" }
        };

        public string Color => (Suit == "Hearts" || Suit == "Diamonds") ? "Red" : "Black";

        public void Flip()
        {
            IsFaceUp = !IsFaceUp;
        }

        public override string ToString()
        {
            return IsFaceUp ? $"{FaceValue} of {Suit}" : "Unknown";
        }
    }
}