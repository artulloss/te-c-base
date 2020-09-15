using System;
using System.Reflection.PortableExecutable;

namespace Variables_And_Datatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */
            //datatype nameofvar;
            //datatype nameofvar = initialvalue

            //variable names can't be keywords and can't start with a number - RULE
            //variable names should be named with camel case and be descriptive - this is a CONVENTION
            //int 1num = 1; ERROR
            int x = 1; //annoying but will run
            //int class = 1; ERROR

            /*
		    1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.
		    */
            int numberOfExercises;
            numberOfExercises = 26;

            //int numberOfExercises = 26; //declare and initialize all in one line

            Console.WriteLine("numberOfExercises is set to "+ numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half = 0.5;

            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name = "TechElevator\n\nis great";

            Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            int seasonsOfFirefly = 1;

            //Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage = "C#";

            //Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */
            double pi = 3.1416;

            //Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */
            string myName = "Katie";
            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            int numMouseButtons = 5;

            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            int percentBatteryLeft = 65;

            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int difference = 121 - 27;

            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double sum;
            sum = 12.3 + 32.1;

            /*
            12. Create a string that holds your full name.
            */
            string fullName = "Katie Dwyer";

            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string greeting = "Hello, " + fullName;

            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            fullName = fullName + " Esquire";

            /*
            15. Now do the same as exercise 14, but use the += operator.
            */
            fullName += " Esquire";

            /*Implicit Casting Example*/
            double wholeNumber = 5;
            
            //narrowing
            int doubleVal = (int)5.8;
            Console.WriteLine(doubleVal);

            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            string movieTitle = "Saw " + 2;
            Console.WriteLine(movieTitle);

            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */
            movieTitle += 0;
            Console.WriteLine(movieTitle);

            /*
            18. What is 4.4 divided by 2.2?
            */
            double result = 4.4 / 2.2 ;
            Console.WriteLine(result);

            /*
            19. What is 5.4 divided by 2?
            */
            result = 5.4 / 2;

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            double divResult =  5 / 2; 
            Console.WriteLine(divResult);

            /*
            21. What is 5.0 divided by 2?
            */
            result  =  5.0 / 2;
            Console.WriteLine("num 21: "+result);

            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */
  
            decimal balance = (decimal) 1234.56;

            /*
            23. If I divide 5 by 2, what's my remainder?
            */
            int remainder = 5 % 2;

            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together. 
                What is the result?
            */
            int three = 3;
            int oneBillion = 1000000000;
            Console.WriteLine("number 24: "+ (three * oneBillion));

            long threeLong = 3;
            long oneBillionLong = 1000000000;
            Console.WriteLine("number 24 with longs: " + (threeLong * oneBillionLong));
            /*
            25. Create a variable that holds a boolean called doneWithExercises and
            set it to false.
            */
            bool doneWithExercises = false;

            /*
            26. Now set doneWithExercise to true.
            */
            doneWithExercises = true;

            //magic numbers
            int numSeconds = 24 * 60 * 60;

            int numHoursInDay = 24;
            int numMinutesInHour = 60;
            int numSecondsInMinute = 60;

            int numSecondsInADay = numHoursInDay * numMinutesInHour * numSecondsInMinute; 



        }
    }
}
