using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return a new string made of every other char starting with the first, so "Hello" yields "Hlo".
         StringBits("Hello") → "Hlo"
         StringBits("Hi") → "H"
         StringBits("Heeololeo") → "Hello"
         */
        public string StringBits(string str)
        {
            // [0] 1 [2] 3 [4] 5 Length (6 + 1) / 2 = 3
            // [0] 1 [2] 3 [4] Length (5 + 1) / 2 = 3
            StringBuilder stringBuilder = new StringBuilder((str.Length + 1) / 2);
            for (int i = 0; i < str.Length; i++)
            {
                if(i % 2 == 0) 
                    stringBuilder.Append(str[i]);
            }
            return stringBuilder.ToString();
        }
    }
}
