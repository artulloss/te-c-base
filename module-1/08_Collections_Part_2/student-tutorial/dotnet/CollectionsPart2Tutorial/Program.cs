using System;
using System.Collections.Generic;

namespace CollectionsPart2Tutorial
{
    public class CollectionsPart2Tutorial
    {
        static void Main(string[] args)
        {

            // Step One: Declare a Dictionary

            Dictionary<string, int> quizScores = new Dictionary<string, int>()
            {
                {"Adam", 95},
                {"Chris", 88},
                {"Jacob", 92},
                {"Zach", 97}
            };


            // Step Two: Add items to a Dictionary

            quizScores.Add("Josh", 76);
            quizScores.Add("Brittany", 90);
            quizScores.Add("Patrick", 5);

            // Step Three: Loop through a Dictionary

            foreach (string name in quizScores.Keys)
                Console.WriteLine(name + "'s score is " + quizScores[name]);
        }
    }
}
