using System;
using System.IO;
using System.Text;

namespace Cipher
{
    class Program
    {
        const int STARTING_ASCII = 32;
        const int ENDING_ASCII = 126;
        
        static void Main(string[] args) {
            string inputFilePath = PromptInput("Enter the full path of the file to encrypt: ", File.Exists);
            string outputFilePath = PromptInput("Enter the path of the output file: ",
                input => Directory.Exists(new FileInfo(input).Directory?.FullName));
            string shiftAmountString = PromptInput("How much should we shift it by? ", input => int.TryParse(input, out _));
            int shiftAmount = int.Parse(shiftAmountString);
            Encrypt(inputFilePath, outputFilePath, shiftAmount);
        }

        private static void Encrypt(string inputFilePath, string outputFilePath, int shiftAmount) {
            try {
                using StreamReader streamReader = new StreamReader(inputFilePath);
                using StreamWriter stringWriter = new StreamWriter(outputFilePath);
                while (!streamReader.EndOfStream) {
                    string line = streamReader.ReadLine() ?? "";
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (char c in line) {
                        int e = c;
                        if (c >= 32 && c <= 126) {
                            const int totalValidChars = ENDING_ASCII - STARTING_ASCII;
                            e = (c + shiftAmount - STARTING_ASCII) % totalValidChars + STARTING_ASCII;
                        }
                        stringBuilder.Append((char)e);
                    }
                    stringWriter.WriteLine(stringBuilder.ToString());
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
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