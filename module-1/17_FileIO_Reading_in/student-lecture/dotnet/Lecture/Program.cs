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
            SummingUpNumbers.ReadFile();
            ReplaceFile("Hamlet.txt", "FRANCISCO", "ADAM");    
        }

        private static void ReplaceFile(string file, string replace, string with)
        {
            string dir = Path.Combine(Environment.CurrentDirectory, file);
            if (!File.Exists(dir))
                throw new FileNotFoundException("Failed to read",dir);
            using (StreamReader sr = new StreamReader(dir))
                try
                {
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine()?.Replace(replace, with));
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
        }
    }
}
