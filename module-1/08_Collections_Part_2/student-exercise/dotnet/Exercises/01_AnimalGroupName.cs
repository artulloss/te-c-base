using System;
using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given the name of an animal, return the name of a group of that animal
         * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").
         *
         * The animal name should be case insensitive so "elephant", "Elephant", and
         * "ELEPHANT" should all return "herd".
         *
         * If the name of the animal is not found, null, or empty, return "unknown".
         *
         * Rhino -> Crash
         * Giraffe -> Tower
         * Elephant -> Herd
         * Lion -> Pride
         * Crow -> Murder
         * Pigeon -> Kit
         * Flamingo -> Pat
         * Deer -> Herd
         * Dog -> Pack
         * Crocodile -> Float
         *
         * AnimalGroupName("giraffe") → "Tower"
         * AnimalGroupName("") -> "unknown"
         * AnimalGroupName("walrus") -> "unknown"
         * AnimalGroupName("Rhino") -> "Crash"
         * AnimalGroupNamohhe("rhino") -> "Crash"
         * AnimalGroupName("elephants") -> "unknown"
         *
         */
        public string AnimalGroupName(string animalName)
        {
            animalName = animalName == null ? "" : animalName.ToLower();
            Console.WriteLine(animalName);
            Dictionary<string, string> animalGroupNames = new Dictionary<string, string>(10)
            {
                {"rhino", "Crash"},
                {"giraffe", "Tower"},
                {"elephant", "Herd"},
                {"lion", "Pride"},
                {"crow", "Murder"},
                {"pigeon", "Kit"},
                {"flamingo", "Pat"},
                {"deer", "Herd"},
                {"dog", "Pack"},
                {"crocodile", "Float"},
            };
            return animalGroupNames.ContainsKey(animalName) ? animalGroupNames[animalName] : "unknown";
        }
    }
}
