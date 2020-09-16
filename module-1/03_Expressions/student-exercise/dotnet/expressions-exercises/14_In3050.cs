using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given 2 int values, return true if they are both in the range 30..40 inclusive, or they are both
         in the range 40..50 inclusive.
         In3050(30, 31) → true
         In3050(30, 41) → false
         In3050(40, 50) → true
         */
        public bool In3050(int a, int b)
        {
            return InRange(a, 30, 40) && InRange(b, 30, 40) || InRange(a, 40, 50) && InRange(b, 40, 50);
        }

        public bool InRange(int number, int min, int max)
        {
            return number >= min && number <= max;
        }

    }
}
