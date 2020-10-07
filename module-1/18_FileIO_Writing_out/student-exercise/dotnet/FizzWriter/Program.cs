using System;
using System.IO;

namespace FizzWriter
{
    class Program
    {
        static void Main(string[] args) {
            // Will put it in dotnet folder if you run the FizzWriter.csproj from the
            // directory with the solution using dotnet run --project FizzWriter/FizzWriter.csproj
            using (StreamWriter streamWriter = new StreamWriter("FizzBuzz.txt"))
            {
                for (int i = 1; i <= 300; i++)
                {
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        streamWriter.WriteLine("FizzBuzz");
                    }
                    else if (i.ToString().Contains('3') || i % 3 == 0)
                    {
                        streamWriter.WriteLine("Fizz");
                    }
                    else if(i.ToString().Contains('5') || i % 5 == 0)
                    {
                        streamWriter.WriteLine("Buzz");
                    }
                    else
                    {
                        streamWriter.WriteLine(i);
                    }
                }
                Console.WriteLine("FizzBuzz.txt has been created.");
            }
        }
    }
}
