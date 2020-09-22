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
         Given a string, return a string made of the chars at indexes 0,1, 4,5, 8,9 ... so "kittens" yields "kien".
         AltPairs("[ki]tt[en]") → "kien"
         AltPairs("[Ch]oc[ol]at[e]") → "Chole"
         AltPairs("CodingHorror") → "Congrr"
         */
        public string AltPairs(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int countOfPairs = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if(countOfPairs == 2)
                {
                    countOfPairs = 0;
                    i++;
                    continue;
                }

                stringBuilder.Append(str[i]);
                countOfPairs++;
            }

            return stringBuilder.ToString();
        }
    }
}
