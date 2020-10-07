using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Apple : ISellable
    {
        public decimal Price { get; } = .5M;

        public string Type { get; } = "Apple";

        public string MakeSoundOnce()
        {
            return "crunch";
        }

        public string MakeSoundTwice()
        {
            return "crunch crunch";
        }
    }
}
