using System;

namespace Fibonacci
{
    /// <summary>
    /// Program should look like this
    /// Please enter the Fibonacci number: 25
    ///
    /// 0, 1, 1, 2, 3, 5, 8, 13, 21
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the Fibonacci number: ");
            if (!int.TryParse(Console.ReadLine(), out int number) || number < 0)
            {
                Console.WriteLine("Please enter a positive number.");
                Main(args);
                return;
            }
            Console.Write("\n");
            int sum = 0;
            int lastSum = 0;
            int secondToLastSum = 1;
            while (sum < number)
            {
                Console.Write(sum + " ");
                sum = lastSum + secondToLastSum;
                secondToLastSum = lastSum;
                lastSum = sum;
            }
        }
    }
}
