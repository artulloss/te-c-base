using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*Review datatypes*/
            float myFloat = 3.2F;
            float myFloat2 = (float)3.2;

            decimal myDecimal = 3.2M;

            long myLong = 5;
            int myInt = (int)myLong;

            double myDouble = (double)myInt / 2;
            double doubleA = 1;

            int newInt = (int)doubleA;

            /*expressions and statements*/
            int x = 5 + 1;

            //int area = lenght * width;
            x++;

            //comparison operators ==, !=, < , <=, >, >=
            int value = 7;
            bool isEven = value % 2 == 0;
            bool isBig = value > 10;

            //logical operators &&(and - sides are true)  || (OR at least one side is true)  ^ (XOR exactly one side is true)
            bool isBigAndEven = isEven && isBig;
            bool anotherTest = isEven && myDouble <= 100 || newInt < 5 ;

            bool isWeekday = true; //pretend this is a calculation
            bool onVacation = true;
            double minutesPastNine = 10;
            int age = 20;
            bool isTeenager = age < 20 && age >= 13; 
            // !isTeenager is the same as isTeenager==false
            bool shouldWakeUp = isWeekday && !onVacation && (minutesPastNine > 0 && !isTeenager ) ;

            bool a = true;
            bool b = false;

            bool c = (a && b) || isWeekday;

            if (c)
            {
                Console.WriteLine("c is true;");
                Console.WriteLine("C is true again");
                int inTheIf = 1; 
                if (isTeenager)
                {
                    int isTeenagerInt = 5;
                    Console.WriteLine("C is true and isTeenager is true;");
                }
                else if (onVacation)
                {
                    Console.WriteLine("C is true, isTeenager is false, and onVacation is true;");
                }
                //Console.WriteLine(isTeenagerInt);
            }
            else
            {
                Console.WriteLine("C is false;");
            }

            Console.WriteLine(SumOfThreeInts(1, 5, 6)); 


        }

        static int SumOfThreeInts(int a, int b, int c)
        {
            return a + b + c; 
        }

        static string returnAString(int a, int b, int c)
        {
  
            if (a < 10)
                return null;

            return "value";

        }
    }
}
