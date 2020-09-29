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

            // Let's try singing about a Farm Animal
            List<ISingable> animals = new List<ISingable>()
                {new Horse(), new Goat(), new Pig(), new Snake(), new Elephant(), new Tractor()};

            List<ISellable> sellables = new List<ISellable>();

            // Can we swap out any animal in place here?

            foreach (ISingable animal in animals)
            {
                if (animal is FarmAnimal)
                {
                    PrintAnimal(animal);
                }
                if (!(animal is ISellable sellable)) continue;
                sellables.Add(sellable);
            }

            foreach (ISellable sellable in sellables)
            {
                Console.WriteLine(sellable.ToString() + " Price: " + sellable.Price);
            }
            

            // What if we wanted to sing about other things on the farm that were 
            // singable but not farm animals?
            // Can it be done?
        }

        public static void PrintAnimal(FarmAnimal animal)
        {
            Console.WriteLine("And on his farm there was a " + animal.Name + " ee ay ee ay oh");
            Console.WriteLine("With a " + animal.MakeSoundTwice() + " here and a " + animal.MakeSoundTwice() + " there");
            Console.WriteLine("Here a " + animal.MakeSoundOnce() + ", there a " + animal.MakeSoundOnce() + " everywhere a " + animal.MakeSoundTwice());
            Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
            Console.WriteLine();
        }
        
    }
}