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

        public override string eat()
        {
            return "mleh";
        }

        public override string MakeAwakeSoundOnce()
        {
            return "SSSSSS";
        }


        public override string MakeAwakeSoundTwice()
        {
            return "SSSSSS SSSSSS";
        }

        public void Squish()
        {

        }
    }
}
