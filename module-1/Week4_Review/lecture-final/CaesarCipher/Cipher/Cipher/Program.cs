using System;
using System.IO;
using System.Net.Security;

namespace Cipher
{
    class Program
    {
        //Added these consts at the top to prevent magic numbers
        const int STARTING_ASCII = 32;
        const int ENDING_ASCII = 126;

        //1. Prompt the user for the file to encryption.Prompt the user for the file name to save the encryption as.
        //2. Prompt the user for the number of positions to shift
        //3. "Encrypt" the file by shifting every character the number of positions to shift and save in the new file
        //4. Give the user a message that it's done.

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            string inputFileName = PromptForInput("Enter file name to encrypt: ");
            string outputFilename = PromptForInput("Enter file name to save encyrpted file as:");
            int shiftAmount = PromptForIntInput("Enter shift number: ");
            Encrypt(inputFileName, outputFilename, shiftAmount);
        }

        private void Encrypt(string inputFileName, string outputFilename, int shiftAmount)
        {
            string path = Path.Combine(inputFileName);
            //open inputFileName for reading 
            using (StreamReader sr = new StreamReader(inputFileName))
            {
                // open the output file for writing
                using (StreamWriter sw = new StreamWriter(outputFilename))
                {
                    // for every line of the input
                    while (!sr.EndOfStream)
                    {
                        //  read the line
                        string line = sr.ReadLine();

                        foreach (char c in line)
                        {

                            //   encrypt every letter. expected values are between 32 and 126
                            int encrypted = c; //if it's not in the range, don't encrypt
                            if (c >= 32 && c <= 126) 
                            {
                                //so this will allow us to rotate back around to the beginning
                                //(text[i]+s-65)%26 +65
                                int totalValidChars = ENDING_ASCII - STARTING_ASCII;
                                encrypted = (c + shiftAmount - STARTING_ASCII) % totalValidChars + STARTING_ASCII;

                            }

                            //   save to outputfile
                            sw.Write((char)encrypted); 
                        }
                    }
                }
            }
        }

        public string PromptForInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public int PromptForIntInput(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                try
                {
                    int n = int.Parse(Console.ReadLine());
                    return n;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Invalid input.");
                }
            }
          
        }
    }
}
