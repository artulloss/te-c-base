using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Snake : FarmAnimal
    {
        public Snake() : base("SNAKE")
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
