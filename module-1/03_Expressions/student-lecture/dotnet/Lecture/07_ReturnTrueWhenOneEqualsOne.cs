using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {

        /*
        7. This method uses an if to check to make sure that one is equal to one.
            Make sure it returns TRUE when one equals one.
            TOPIC: Boolean Expression & Conditional Logic
        */
        public bool ReturnTrueWhenOneEqualsOne()
        {
            if (1 == 1) // Really I could just do return 1 == 1 for the whole function but apparently it's supposed to use an if statement
            {
                return 1 == 1;
            }

            return false;
        }

    }
}
