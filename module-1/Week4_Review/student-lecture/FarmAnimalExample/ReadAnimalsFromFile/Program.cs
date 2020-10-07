using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lecture.Farming;

namespace ReadAnimalsFromFile
{
    class Program
    {
        static void Main(string[] args) {
            string filePath = PromptInput("Enter the full path to the file where the farm animals are stored: ", File.Exists);
            List<FarmAnimal> adamsFarmAnimals = ProcessFile(filePath);
            foreach (FarmAnimal farmAnimal in adamsFarmAnimals) {
                Console.WriteLine($"Name: {farmAnimal.Name} Type: {farmAnimal.Type} Eats: {string.Join(", ", farmAnimal.Food.ToArray())}");
            }
        }

        private static List<FarmAnimal> ProcessFile(string filePath) {
            var animals = new List<FarmAnimal>();
            try {
                using (StreamReader streamReader = new StreamReader(filePath)) {
                    while (!streamReader.EndOfStream) {
                        string[] details = (streamReader.ReadLine() ?? "").Split('|');
                        string name = details[0];
                        string type = details[1];
                        List<string> food = details[2].Split(',').ToList();
                        switch (type) {
                            case "Elephant":
                                animals.Add(new Elephant(name, food));
                                break;
                            case "Goat":
                                animals.Add(new Goat(name, food));
                                break;
                            case "Horse":
                                animals.Add(new Horse(name, food));
                                break;
                            case "Snake":
                                animals.Add(new Snake(name, food));
                                break;
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            return animals;
        }
        
        private delegate bool CheckCondition(string input);
        
        /// <summary>
        /// Prompts user, Checks the condition on the users input, Displays error message and and reasks until valid
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="condition"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private static string PromptInput(string prompt, CheckCondition condition, string errorMessage = null)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!condition(input))
            {
                if(errorMessage != null)
                    Console.WriteLine(errorMessage);
                return PromptInput(prompt, condition, errorMessage);
            }
            return input;
        }
    }
}