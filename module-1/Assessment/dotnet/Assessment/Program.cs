using System;
using System.Collections.Generic;
using System.IO;
using Assessment.Classes;
using Assessment.FileReader;

namespace Assessment
{
    class Program
    {
        static void Main(string[] args) {
            TextFileReader textFileReader = new TextFileReader();
            textFileReader.ReadFile(Path.Combine(Environment.CurrentDirectory, "Data/CarInput.csv"));
            string[] lines = textFileReader.GetResult();
            List<Car> cars = new List<Car>();
            int i = 0;
            foreach (string line in lines) {
                Console.WriteLine(line);
                string[] lineArray = line.Split(",");
                cars.Add(new Car(int.Parse(lineArray[0]), lineArray[1], bool.Parse(lineArray[2])));
                Console.WriteLine(cars[i]);
                i++;
            }
        }
    }
}
