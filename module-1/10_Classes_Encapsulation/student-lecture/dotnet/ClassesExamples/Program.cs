using System;
using System.ComponentModel;
using ClassesExamples.Classes;

namespace ClassesExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Card queen = new Card(12, "Hearts", false); 
            Console.WriteLine(queen);
            Card king = new Card(13, "Spades", true); 
            Console.WriteLine(king);
            
            Deck deck = new Deck();

            Console.WriteLine("Our cards");
            foreach (Card card in deck.Cards)
                Console.WriteLine(card);

            // deck.Shuffle(7); // Shuffle is wrong, didn't have time to copy katies
            
            Card[] cardsDelt = deck.Deal(9);

            Console.WriteLine("Cards Delt");
            
            foreach (Card card in cardsDelt)
                Console.WriteLine(card);

            Console.WriteLine("Cards after dealing");

            foreach (Card card in deck.Cards)
                Console.WriteLine(card);

        }
    }
}