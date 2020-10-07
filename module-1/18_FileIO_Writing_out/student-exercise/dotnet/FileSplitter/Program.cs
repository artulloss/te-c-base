using System;
using System.Collections.Generic;
using System.IO;

namespace FileSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is closer to what it says to do in the homework imo but it's better to have it work for any file
            //string path = PromptInput("Where is the input file (please include the path to the file)? ", 
            //    input => File.Exists(input + "\\input.txt"),
            //    "Please enter a directory containing input.txt") + "/input.txt";
            
            string path = PromptInput("Enter the full path of the file: ",
                File.Exists, "File not found.");
            
            string linesOfTextString = PromptInput("How many lines of text (max) should there be in the split files? ",
                input => int.TryParse(input, out int i) && i > 0, "Please enter a positive number");
            int linesOfTextPerFile = int.Parse(linesOfTextString); // We already know its good, no need to test
            
            string dir = PromptInput("Enter the directory of the output: ",
                Directory.Exists, "Directory not found.");
            
            Queue<string> lines = new Queue<string>();

            int lineCount;
            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    lines.Enqueue(streamReader.ReadLine());
                } 
                lineCount = lines.Count;
                Console.WriteLine($"The input file has {lineCount} lines of text.\n");
            }
            
            Console.WriteLine("Each file that is created should have a sequential number assigned to it.\n");
            int numOfFiles = (int) Math.Ceiling(lineCount / (double) linesOfTextPerFile);
            string fileNameWithExtension = Path.GetFileName(path);
            Console.WriteLine($"For a {lineCount} line input file \"{fileNameWithExtension}\", this produces {numOfFiles}.\n");
            
            Console.WriteLine("**GENERATING OUTPUT**\n");
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);
            for(int i = 1; i <= numOfFiles; i++)
            {
                using (StreamWriter streamWriter = new StreamWriter($"{dir}{Path.DirectorySeparatorChar}{fileNameWithoutExtension}-{i}{extension}"))
                {
                    
                    Console.WriteLine($"Generating {fileNameWithoutExtension}-{i}{extension}");
                    for (int j = 0; j < linesOfTextPerFile; j++)
                    {
                        if (lines.Count != 0)
                        {
                            // I decided to be extra and remove the extra line at the end of them
                            if (linesOfTextPerFile - 1 == j)
                            {
                                streamWriter.Write(lines.Dequeue());
                                continue;
                            } 
                            streamWriter.WriteLine(lines.Dequeue());
                        }
                    }
                }
            }
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
