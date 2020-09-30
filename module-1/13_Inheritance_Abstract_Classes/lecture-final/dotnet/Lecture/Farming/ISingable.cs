using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public interface ISingable
    {
        //everything is automatically public 

        string Name { get; }

        /// <summary>
        /// The sound the item makes
        /// </summary>
        /// <returns></returns>
        string MakeSoundOnce();

        /// <summary>
        /// the double sound the item makes
        /// </summary>
        /// <returns></returns>
        string MakeSoundTwice();
    }
}
