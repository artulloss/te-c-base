using System;
using System.IO;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // I am going by what it says for the example
            //2. Ask the user for the file path
            // C:\Users\Student\workspace\atulloss-c\module-1\17_FileIO_Reading_in\student-exercise\dotnet\alices_adventures_in_wonderland.txt
            Console.WriteLine("What is the fully qualified name of the file that should be searched?");
            string dir = Console.ReadLine() ?? "";
            //3. Open the file
            if (!File.Exists(dir))
            {
                Main(args);
                return;
            }
            //1. Ask the user for the search string
            string word;
            do
            {
                Console.WriteLine("What is the search word you are looking for?");
                word = Console.ReadLine();
            } while ((word ?? "") == "");

            bool? caseSensitive = null;
            do
            {
                Console.WriteLine("Should the search be case sensitive? (Y\\N)");
                string shouldBeCaseSensitive = Console.ReadLine()?.ToLower();
                if (shouldBeCaseSensitive == "y" || shouldBeCaseSensitive == "yes")
                    caseSensitive = true;
                else if (shouldBeCaseSensitive == "n" || shouldBeCaseSensitive == "no")
                    caseSensitive = false;
            } while (caseSensitive == null);

            using (StreamReader sr = new StreamReader(dir))
            {
                try
                {
                    int i = 1;
                    if (caseSensitive ?? false)
                        word = word.ToLower();
                    while (!sr.EndOfStream) //4. Loop through each line in the file
                    {
                        string line = sr.ReadLine();
                        if (caseSensitive ?? true
                            ? line?.Contains(word) ?? false
                            : line?.ToLower().Contains(word) ?? false)
                        {
                            //5. If the line contains the search string, print it out along with its line number
                            Console.WriteLine($"{i}) {line}");
                        }

                        i++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
