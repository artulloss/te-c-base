using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public sealed class Cat : FarmAnimal
    {
        public Cat() : base("CAT")
        { }

        public override string eat()
        {
            return "mmm";
        }

        public override string MakeAwakeSoundOnce()
        {
            return "MEOW";
        }

        public override string MakeAwakeSoundTwice()
        {
            return MakeAwakeSoundOnce() + " " + MakeAwakeSoundOnce(); 
        }



    }
}
