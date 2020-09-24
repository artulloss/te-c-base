using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExamples.Classes
{
    public class Deck
    {
        /// <summary>
        /// Represents the cards that are in the deck
        /// Private so outside classes can't modify the contents
        /// </summary>
        private List<Card> Cards { get; set; } = new List<Card>(); //i can create this object HERE or in the constructor

        /// <summary>
        /// derived property for how many cards are in teh deck
        /// </summary>
        public int CardCount { 
            get 
            { 
                return Cards.Count; 
            } 
        }

        /// <summary>
        /// Add the 52 cards to the Cards list/deck
        /// </summary>
        public Deck()
        {
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
            foreach(string suit in suits)//for every suit
            {
                //add all of the values from 1 to 13
                for (int value=1; value<=13; value++)
                {
                    Card c = new Card(value, suit);
                    Cards.Add(c);
                }
            }
        }


       /// <summary>
       /// Returns the top card from the deck. Returns NULL if the deck is empty
       /// </summary>
       /// <returns></returns>
        public Card DealOne()
        {
            if (Cards.Count == 0)
                return null; 

            //take a card off the top of the deck
            Card dealt = Cards[0];

            //remove it from the deck
            Cards.RemoveAt(0);

            //return it 
            return dealt; 
        }

       public void Shuffle(int numTimes)
        {
            for (int i=0; i<numTimes; i++)
            {
                Shuffle(); 
            }
        }


        //shuffle
        public void Shuffle()
        {
            //take the deck
            //divide it in half
            List<Card> topHalf = Cards.GetRange(0, CardCount / 2);
            Cards.RemoveRange(0, CardCount / 2);
            List<Card> bottomHalf = Cards.GetRange(0, CardCount);
            Cards = new List<Card>(); //this is now empty 

            //repeat until both halves are out of cards
            Random r = new Random();
            while (topHalf.Count > 0 && bottomHalf.Count > 0)
            {
                // take random 1-5 cards from the first half
                int numToTakeFromTop = r.Next(1, 5);
                if (numToTakeFromTop > topHalf.Count)
                {
                    numToTakeFromTop = topHalf.Count; 
                }
                List<Card> takenFromTop = topHalf.GetRange(0, numToTakeFromTop);
                topHalf.RemoveRange(0, numToTakeFromTop);
                Cards.AddRange(takenFromTop);


                // take random 1-5 cards from teh second half
                int numToTakeFromBottom= r.Next(1, 5);
                if (numToTakeFromBottom > bottomHalf.Count)
                {
                    numToTakeFromBottom = bottomHalf.Count;
                }
                List<Card> takenFromBottom = bottomHalf.GetRange(0, numToTakeFromBottom);
                bottomHalf.RemoveRange(0, numToTakeFromBottom);
                Cards.AddRange(takenFromBottom);
            }
        }
    }
}
