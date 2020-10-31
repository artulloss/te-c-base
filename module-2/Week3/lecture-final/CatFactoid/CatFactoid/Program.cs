using System;

namespace CatFactoid
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiService api = new ApiService("https://catfact.ninja/fact");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Press 0 to exit, anything else for another cat fact");
            string input = Console.ReadLine();
            while(input!="0")
            {
                //show a catfact
                Console.WriteLine(api.GetRandomCatFact());

                //prompt again
                Console.WriteLine("Press 0 to exit, anything else for another cat fact");
                input = Console.ReadLine();

            }
        }
    }
}
