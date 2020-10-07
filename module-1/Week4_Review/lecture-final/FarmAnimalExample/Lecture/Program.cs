using Lecture.Farming;
using System;
using System.Collections.Generic;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
           //
            // OLD MACDONALD
            //
            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");

            //ISingable sing = new ISingable(); CANNOT instantiate an interface

            // Let's try singing about a Farm Animal
            List<ISingable> itemsOnTheFarm = new List<ISingable>();
            itemsOnTheFarm.Add(new Horse());
            itemsOnTheFarm.Add(new Goat());
            itemsOnTheFarm.Add(new Elephant());
            itemsOnTheFarm.Add(new Snake());
            itemsOnTheFarm.Add(new Tractor());
            //itemsOnTheFarm.Add(new Apple()); //Apple does NOT implement the ISingable interface, we can't add it to a a list of ISingables

            // write a foreach loop to sing the verse about ever animal in the List
            foreach (ISingable item in itemsOnTheFarm)
            {
                SingTheVerse(item);
            }

            // What if we wanted to sing about other things on the farm that were 
            // singable but not farm animals?
            // Can it be done? 

            List<ISellable> yardSale = new List<ISellable>();
            foreach (ISingable item in itemsOnTheFarm)
            {
                if (item is ISellable) //just showing you...avoid this
                    yardSale.Add((ISellable)item);
            }
            yardSale.Add(new Apple());
            Dictionary<int, ISellable> yardSaleLocations = new Dictionary<int, ISellable>();
            yardSaleLocations.Add(1, new Apple()); //in stall one there are apples for sale
            yardSaleLocations.Add(2, new Elephant()); //in stall number 2 there is an elephant for sale


            //print the sellable things
            //for your exercises, you are supposed to line things up
            Console.WriteLine("Sellable stuff\n\n");
            Console.WriteLine("{0,15} {1,5}", "Name", "Price");
            foreach (ISellable item in yardSale)
            {
                Console.WriteLine("{0,-15} {1,-5:C}",item.Type, item.Price);
            }

            Console.ReadLine();
        }

        private static void SingTheVerse(ISingable item)
        {
            Console.WriteLine("And on his farm there was a " + item.Type + " ee ay ee ay oh");
            Console.WriteLine("With a " + item.MakeSoundTwice() + " here and a " + item.MakeSoundTwice() + " there");
            Console.WriteLine("Here a " + item.MakeSoundOnce() + ", there a " + item.MakeSoundOnce() + " everywhere a " + item.MakeSoundTwice());
            Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
            Console.WriteLine();
            
        }
    }
}