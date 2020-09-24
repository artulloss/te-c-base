using ClassesExamples.Classes;
using Draw.Tool;
using System;
using System.Collections.Generic;

namespace ClassesExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");
            WoodenPencil wp = new WoodenPencil();
            //WoodenPencil.stubLength = -1; stubLength is private
            WoodenPencil.StubLength = 1;

            //wp.Length = 1;  has private set; can't do that here
            Console.WriteLine("Is my pencil a stub? " + wp.IsStub);

            WoodenPencil katiesPencil = new WoodenPencil(4, 2, "2", System.Drawing.Color.Beige, 5);
            
            WoodenPencil.ClayPercentage("4"); 

            katiesPencil.PencilDemo();

            katiesPencil.OverLoad();

            katiesPencil.OverLoad(1);

            //katiesPencil.OverLoad(2.3);

            Console.WriteLine("Katies pencil: "+katiesPencil);
            */
            Card myCard = new Card(12, "Hearts");
            myCard.Flip();

            Deck pokerDeck = new Deck();
            pokerDeck.Shuffle(7); 

            for (int i = 0; i < 25; i++)
            {
                Card c = pokerDeck.DealOne();
                c.Flip();
                Console.WriteLine(c);
            }

            Console.WriteLine("There are {0} cards left in the deck.",pokerDeck.CardCount);
        }
    }
}
