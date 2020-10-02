using System;
using Week3Review.People;
using Week3Review.VehicleExample;

namespace Week3Review
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BoatExample();
            PersonExample();

        }

        private static void PersonExample()
        {
            Console.WriteLine("**creating a person**");
            Person adam = new Person("10-02-2000");
            Console.WriteLine("Adam is " + adam.Age);
            Console.WriteLine("**creating a testaff**");
            TEStaffMember rita = new TEStaffMember();
            Console.WriteLine("**creating a teinstructor**");
            TEInstructor katie = new TEInstructor();
            Console.WriteLine("katie's name is " + katie.Name);

            Console.WriteLine("**creating a student**");
            Student s = new Student("10-02-1950"); //happy 21st birthday, student
            Console.WriteLine("student info: " + s.Name + " " + s.Age + " grade: " + s.Grade) ;
        }

        private static void BoatExample()
        {
            Boat b = new Boat(); //instantiating => use the new keyword to create an object
            b.IsFloating = true;
            Console.WriteLine("Is b floating? " + b.IsFloating);
            b.Move();

            //polymorphism allows me to declare lmv as a LandMotorVehicle on the left and create a car on the right of the =
            LandMotorVehicle lmv = new Car();
            lmv.Move(); //inheritance means a car has all of the public methods and data from LandMotorVehicle

            Car c = new Car();
            //c has everythign from LandMotorVehicle that is public
            Console.WriteLine($"Do I have to wear a helmet in the car? {c.RequiresHelmet}");

            /* how to format output examples
            Console.WriteLine("Do I have to wear a helmet in the car? {0}",c.RequiresHelmet);
            Console.WriteLine("Do I have to wear a helmet in the car? "+ c.RequiresHelmet);
            */
        }
    }
}
