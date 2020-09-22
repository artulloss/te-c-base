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
         Given a non-empty string like "Code" return a string like "CCoCodCode".
         StringSplosion("Code") → "CCoCodCode"
         StringSplosion("abc") → "aababc"
         StringSplosion("ab") → "aab"
         */
        public string StringSplosion(string str)
        {
            int length = 0;
            for (int i = 0; i < str.Length; i++)
                length += str.Substring(i).Length;
            StringBuilder stringBuilder = new StringBuilder(length);
            for (int i = 1; i < str.Length + 1; i++)
            {
                stringBuilder.Append(str.Substring(0, i));
            }
            return stringBuilder.ToString();
        }
    }
}
