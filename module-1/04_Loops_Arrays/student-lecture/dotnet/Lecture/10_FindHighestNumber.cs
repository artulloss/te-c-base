using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureProblem
    {
        /*
         10. What code do we need to write so that we can find the highest
             number in the array randomNumbers?
             TOPIC: Looping Through Arrays
        */
        public int FindTheHighestNumber(int[] randomNumbers)
        {
            return randomNumbers.Max(); // One line solution :P
            /*
            int highest = randomNumbers[0];
            foreach (var number in randomNumbers)
                if (number > highest)
                    highest = number;
            return highest;
            */
        }
    }
}
