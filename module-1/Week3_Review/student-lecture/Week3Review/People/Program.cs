using System;

namespace People
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonExample();
        }

        public static void PersonExample()
        {
            Person adam = new Person("Adam", new DateTime(2000, 10, 2));
            Console.WriteLine($"{adam.Name} is {adam.Age}");
        }
    }
}