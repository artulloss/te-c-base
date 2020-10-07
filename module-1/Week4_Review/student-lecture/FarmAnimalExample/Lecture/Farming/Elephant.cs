using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Elephant : FarmAnimal, ISellable
    {
        public decimal Price { get; }

        //decimal ISellable.Price => throw new NotImplementedException();

        public Elephant(string name, List<string> food) : base(name, "ELEPHANT", food)
        {
            Price = 5000.50M; 
        }

        public override string MakeSoundOnce()
        {
            return "TRUMPET";
        }

        public override string MakeSoundTwice()
        {
            return "TRUMPET TRUMPET";
        }
    }
}
