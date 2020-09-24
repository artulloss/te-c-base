using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassesExamples.Classes
{
    public class Deck
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

        // Derived Property for Cards remaining
        public int CardCount => Cards.Count;

        public Deck()
        {
            string[] suits = { "Spades", "Hearts", "Club", "Diamonds" };
            foreach (string suit in suits)
                for (int value = 1; value < 14; value++)
                    Cards.Add(new Card(value, suit));
        }

        public Card[] Deal(int cardsToDeal = 1)
        {
            if (Cards.Count < cardsToDeal)
                return null;
            Card[] deltCards = Cards.GetRange(0, cardsToDeal).ToArray();
            Cards.RemoveRange(0, cardsToDeal);
            return deltCards;
        }

        public void Shuffle(int times)
        {
            for(int i = 0; i < times; i++)
                Shuffle();
        }

        public void Shuffle()
        {
            List<Card> topHalf = Cards.GetRange(0, CardCount / 2);
            Cards.RemoveRange(0, CardCount / 2);
            List<Card> bottomHalf = Cards.GetRange(0, CardCount / 2);
            Cards = new List<Card>();
            Random r = new Random();
            while (topHalf.Count > 0 && bottomHalf.Count > 0)
            {
                int numToTakeFromTop = r.Next(1, 5);
                if (numToTakeFromTop > topHalf.Count)
                    numToTakeFromTop = topHalf.Count;
                List<Card> takenFromTop = topHalf.GetRange(0, numToTakeFromTop);
                topHalf.RemoveRange(0, numToTakeFromTop);
                Cards.AddRange(takenFromTop);
                
                int numToTakeFromBottom = r.Next(1, 5);
                if (numToTakeFromBottom > bottomHalf.Count)
                    numToTakeFromBottom = bottomHalf.Count;
                List<Card> takenFromBottom = bottomHalf.GetRange(0, numToTakeFromBottom);
                bottomHalf.RemoveRange(0, numToTakeFromBottom);
                Cards.AddRange(takenFromBottom);
            }
            
        }
        
    }
}