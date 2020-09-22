using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string and a non-negative int n, return a larger string that is n copies of the original string.
         StringTimes("Hi", 2) → "HiHi"
         StringTimes("Hi", 3) → "HiHiHi"
         StringTimes("Hi", 1) → "Hi"
         */
        public string StringTimes(string str, int n)
        {
            StringBuilder stringBuilder = new StringBuilder(str.Length * n); // This will use less memory because we don't have to create a new string every time
            for(int i = 0; i < n; i++)
                stringBuilder.Append(str);
            return stringBuilder.ToString();
        }
    }
}
