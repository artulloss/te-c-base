using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Snake : FarmAnimal
    {
        public Snake(string name, List<string> food) : base(name, "SNAKE", food)
        { 
        }

        public override string MakeSoundOnce()
        {
            return "SSSSSS";
        }


        public override string MakeSoundTwice()
        {
            return "SSSSSS SSSSSS";
        }

        public void Squish()
        {

        }
    }
}
