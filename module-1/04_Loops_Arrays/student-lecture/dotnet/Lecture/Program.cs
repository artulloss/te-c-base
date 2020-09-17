using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
               //1. Use a for-loop to print "Hello World" 10 times

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hello World");
            }

            Console.WriteLine("After this is recursive");
            recursiveHelloWorldTenTimes();

        }

        static void recursiveHelloWorldTenTimes(int iteration = 0)
        {
            Console.WriteLine("Hello World");
            if (iteration == 9)
                return;
            recursiveHelloWorldTenTimes(iteration + 1);
        }

    }
}
