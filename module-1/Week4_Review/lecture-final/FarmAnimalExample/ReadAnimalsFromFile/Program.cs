using Lecture.Farming;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace ReadAnimalsFromFile
{
    class Program
    {

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();

        }

        private void Run()
        {

            //Open the file for reading
            string current = Environment.CurrentDirectory;
            string fullName = Path.Combine(current, "FarmAnimalsFood.txt");

            List<FarmAnimal> katiesFarm = ProcessInputFile(fullName);

            //print out the info
        }

        private  List<FarmAnimal> ProcessInputFile(string inFileName)
        { 
          
            List<FarmAnimal> animals = new List<FarmAnimal>( );
            //open file for reading
            using (StreamReader sr = new StreamReader(inFileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] details = line.Split("|");

                    //create a farm animal for every line
                    //name | type|comma delimited list of what it eats

                    //details[0] => name, details[1] => type, details[2] => comma delimited listof food
                    FarmAnimal newAnimal; //declare up here so it's scoped to the while loop
                    switch (details[1])
                    {
                        case "Elephant": newAnimal = new Elephant(); break;
                        case "Goat": newAnimal = new Goat(); break;
                        case "Horse": newAnimal = new Horse(); break;
                        case "Snake": newAnimal = new Snake(); break;
                        default: newAnimal = new Elephant(); break;
                    }

                    
                    newAnimal.Name = details[0];
                    string[] food = details[2].Split(",");
                    foreach(string f in food)
                    {
                        newAnimal.Food.Add(f);
                    }
                    animals.Add(newAnimal);
                    
                }
            }
            return animals;
        }
    }
}
