using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            /*REVIEW ON EXPRESSIONS */
            int someNumber = 5;
            //mod examples
            //mod will always give me the remainder
            int remainderOf100DivBy3 = 100 % 3;
            //is a multiple of something
            bool isEven = someNumber % 2 == 0;
            bool isMultipleOfThree = someNumber % 3 == 0;

            //if someNumber is a multiple of 4 print mult of 4
            if (someNumber % 4 == 0)
            {
                Console.WriteLine("mult of 4");
            }

            //if a is positive and b is negative or vice versa
            int a = 5;
            int b = -1;
            if ((a > 0) ^ (b > 0))
            {
                //do something
            }

            //ternary operator
            int count = 18;
            string description = "Count: " + count + " student" /* s here or no? */ ;
            //Count: 1 student;
            //Count: 2 students;
            string description2 = "Count: " + count + " student" + ((count == 1) ? "" : "s");
            Console.WriteLine("Count: " + count + " student" + ((count == 1) ? "" : "s"));

            //arrays

            //declaration
            //datatype[] identifier;
            int[] array;
            //array[0] = 1; error unassigned

            //initialize
            //identifier = new datatype[size]; 


            //1. Creating an array of integers
            int size = 4;
            int[] quizScores = new int[size];
            quizScores[0] = 100;
            quizScores[1] = 80;
            quizScores[2] = 85;
            quizScores[3] = 90;

            int sum = quizScores[0] + quizScores[1] + quizScores[2] + quizScores[3];
            quizScores[0] = quizScores[0] + 5;

            //the first element of quizScores?
            //quizScores[0];
            //last element
            //quizScores[3];
            //quizScores[quizScores.Length - 1];

            //2. Creating an array of strings
            string[] names = new string[4] { "Josh", "David", "Craig", "Casey" };

            //3. Create an array of characters that hold "Tech Elevator"        
            char[] letters = { 'T', 'e', 'c', 'h', ' ', 'E', 'l', 'e', 'v', 'a', 't', 'o', 'r' };

            //4. Print out the first item in each array
            Console.WriteLine("First quiz score is " + quizScores[0]);
            Console.WriteLine("First name is " + names[0]);
            Console.WriteLine("First letter is " + letters[0]);

            //5. Print out the 3rd item in each array
            Console.WriteLine("3rd quiz score is " + quizScores[2]);
            Console.WriteLine("3rd name is " + names[2]);
            Console.WriteLine("3rd letter is " + letters[2]);

            //6. Get the length of each array
            int lengthOfQuizArray = quizScores.Length;
            Console.WriteLine("There are " + lengthOfQuizArray + " items in quiz array");

            int lengthOfNamesArray = names.Length;
            Console.WriteLine("There are " + lengthOfNamesArray + " items in names array");

            Console.WriteLine("There are " + letters.Length + " items in letters array");

            //7. Get the last index 
            //Console.WriteLine("The last index is " + quizScores.Length - 1);// doesn't compile why??
            Console.WriteLine("The last index is " + (quizScores.Length - 1));

            //8. Update the last item in each array
            quizScores[quizScores.Length - 1] = 100;
            names[names.Length - 1] = "Josh";

            int scopeExample = 1;
            if (true)
            {
                int smallScope = 1;
                Console.WriteLine(scopeExample);
            }
            //Console.WriteLine(smallScope); smallScope is out of scope and causes a compile error

            /* FOR LOOPS */
            //syntax 
            // for (initialization condition ; loop-continuation-condition ; end of loop action) NO SEMICOLON
            //{
            //    some code here 
            //}

            // i++ is the same as i += 1 and the same as i = i + 1
            Console.WriteLine("FOR LOOP FUN");

            for (int i=0; i < quizScores.Length; i++)
            {
                Console.WriteLine(quizScores[i]); 
            }

            //Write a for loop to print every name in the names array            
            for (int i = 0; i < names.Length; i++) 
            {
                Console.Write("at index " + i);
                Console.WriteLine(names[i]); 
            }


            //print hello world 10x
            for (int i = 0; i < 10; i++)
                Console.WriteLine("hello world");

            int sumOfAll = 0; 
            //sum of all integers 0 through 100 that are divisible by 3 or 5
            for (int i=0; i< 100; i++)
            {
                if (i%3==0 || i%5==0)
                    sumOfAll += i; 
            }

            //infinite loops
            //for ( ; ; );

            //while
            //while (continuation condition) NO SEMICOLON
            //{ stuff }
            //sum of all integers 0 through 100 that are divisible by 3 or 5
            int j = 0;
            while (j<100)
            {
                if (j % 3 == 0 || j % 5 == 0)
                    sumOfAll += j;
                j++;
            }

            //break and continue

            //break - breaks completely out of the loop
            //continue - breaks out of this iteration does the end of loop action and checks if it should continue
            for (int i=0; i<15; i++)
            {
                if (i % 3 == 0)
                {
                    continue;
                }
                Console.WriteLine(i);
                
            }

            Console.WriteLine("using break;");
            for (int i = 1; i < 15; i++)
            {
                if (i % 3 == 0)
                {
                    break;
                }
                Console.WriteLine(i);

            }

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
