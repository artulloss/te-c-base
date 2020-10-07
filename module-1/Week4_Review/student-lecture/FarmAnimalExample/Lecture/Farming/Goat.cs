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

        /// <summary>
        /// The single noise the goat makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundOnce()
        {
            return "BLEAT";
        }

        /// <summary>
        /// The double noise the goat makes.
        /// </summary>
        /// <returns></returns>
        public override string MakeSoundTwice()
        {
            return "BLEAT BLEAT";
        }

    }
}
