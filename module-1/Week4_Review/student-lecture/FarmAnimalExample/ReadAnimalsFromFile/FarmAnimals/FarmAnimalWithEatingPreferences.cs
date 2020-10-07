using System.Collections.Generic;
using Lecture.Farming;

namespace ReadAnimalsFromFile.FarmAnimals
{
    public class FarmAnimalWithEatingPreferences : FarmAnimal
    {
        public FarmAnimalWithEatingPreferences(string name, string type, List<string> food) : base(name, type, food) {
        }
    }
}