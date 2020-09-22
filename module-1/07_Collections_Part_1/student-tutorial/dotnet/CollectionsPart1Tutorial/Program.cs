using System;
using System.Collections.Generic;

namespace CollectionsPart1Tutorial
{
    public class CollectionsPart1Tutorial
    {
        static void Main(string[] args)
        {

            // Step One: Declare a List

            List<int> numbers = new List<int>() {1, 2, 3, 4, 5};

            // Step Two: Add values to a List

            numbers.Add(6);
            numbers.Add(7);
            numbers.Add(8);
            numbers.Add(9);
            numbers.Add(10);

            // Step Three: Looping through a List in a for loop

            for(int i = 0; i < numbers.Count; i++)
                Console.WriteLine(numbers[i]);

            // Step Four: Remove an item

            numbers.Remove(10);


            // Step Five: Looping through List in a foreach loop

            foreach (int number in numbers)
                Console.WriteLine(number);

        }
    }
}
