using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExamples.Classes
{
    public class Card
    {

        /// <summary>
        /// the card suit
        /// </summary>
        public string Suit { get;  }

        /// <summary>
        /// the numeric value for the card
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// bool if the card is face up or not. we'll also add a flip method to toggle it
        /// </summary>
        public bool IsFaceUp { get; private set;  }

        public void Flip()
        {
            //flip the card over. if IsFaceUp was true, make it false. If IsFaceUp was false, make it true
            IsFaceUp = !IsFaceUp; 
        }

        /// <summary>
        /// the string representation of the value; derived property that returns a string based on the numeric Value
        /// </summary>
        public string FaceValue
        {
            get
            {
                return faceValues[Value];
            }
        }

        /// <summary>
        /// Derived property that returns the color based on the suit
        /// </summary>
        public string Color
        {
            get
            {
                if (Suit=="Hearts" || Suit=="Diamonds")
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            }
        }

        /// <summary>
        /// Constructor to create a card
        /// </summary>
        /// <param name="value">the value the card represents, appropriate values are 1-13</param>
        /// <param name="suit">the suit of the card ("Hearts","Diamonds","Spades","Clubs")</param>
        public Card(int value, string suit)
        {
            Suit = suit;
            Value = value;
            IsFaceUp = false; //not really needed, because bools default to false
        }

        public override string ToString()
        {
            if (IsFaceUp)
                return FaceValue + " of " + Suit;
            return "Back of the Card";
        }

        private static readonly Dictionary<int, string> faceValues = new Dictionary<int, string>()
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
    }
}
