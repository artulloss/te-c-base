using Lecture.Aids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileAndDirectories.UsingTheDirectoryClass();
            //FileAndDirectories.UsingTheFileClass();
            //ReadingInFiles.ReadACharacterFile();
            //ReadingCSVFiles.ReadFile();
            //SummingUpNumbers.ReadFile();         
            ReadFileHamletAndOutputWithKatieAsFRANCISCO();
        }

        private static void ReadFileHamletAndOutputWithKatieAsFRANCISCO()
        {
           
            // Start with the file path to input
            string directory = Environment.CurrentDirectory;
            string filename = "Hamlet.txt";

            // Create the full path
            string fullPath = Path.Combine(directory, filename);

            string fullPathAbsolute = "C:\\Users\\Student\\example.txt"; //ABSOLUTE PATH

            try 
            {
                //open the file for reading
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream) //until i've reached the end of the file
                    {
                        //read each line
                        string line = sr.ReadLine();

                        //if the line contains FRANCISCO, replace it with KATIE
                        string newLine = line.Replace("FRANCISCO", "KATIE");

                        // then output to the console
                        Console.WriteLine(newLine);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("oh no! " + e.Message);
            }


        }
    }
}
