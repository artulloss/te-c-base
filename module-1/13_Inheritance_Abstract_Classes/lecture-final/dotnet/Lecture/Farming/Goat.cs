using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Goat : FarmAnimal, ISellable
    {
        public decimal Price { get; } = 50M;

        public Goat() : base("GOAT")
        {
        }

        public override string eat()
        {
            return "baaaa";
        }

        /// <summary>
        /// The single noise the goat makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeAwakeSoundOnce()
        {
            return "BLEAT";
        }

        /// <summary>
        /// The double noise the goat makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeAwakeSoundTwice()
        {
            return "BLEAT BLEAT";
        }

    }
}
