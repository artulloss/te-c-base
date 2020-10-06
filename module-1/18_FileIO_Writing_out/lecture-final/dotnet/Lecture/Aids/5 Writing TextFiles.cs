using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Aids
{
    public static class WritingTextFiles
    {
        /*
        * This method below provides sample code for printing out a message to a text file.
        */
        public static void WritingAFile()
        {
            string directory = Environment.CurrentDirectory;
            string filename = "output.txt";
            string fullPath = Path.Combine(directory, filename);

            using(StreamWriter sw = new StreamWriter(fullPath,true)) //if the file doesn't exist, create it. If it does exist, open for append
            {
                sw.WriteLine("Hello");
                sw.WriteLine("World");

                sw.Write("these ");
                sw.Write("will ");
                sw.Write(" be on the same line");

            }

            //using is a much better idean than the next 4 lines
            StreamWriter sw2 = new StreamWriter(fullPath, true);
            sw2.Write("bla");
            sw2.Flush(); //writes everything buffering in memory to the actual file
            sw2.Close(); // flush and close

            // After the using statement ends, file has now been written
            // and closed for further writing
        }

        public static void WritingAFileWithNoPath()
        {

            string fullPath = "putThisFileIntheDefaultpath.txt";

            using (StreamWriter sw = new StreamWriter(fullPath, false)) //if the file doesn't exist, create it. If it does exist, open for overwrite
            {
                sw.WriteLine("Hello");
                sw.WriteLine("World");

                sw.Flush(); //very few cases where you should actually do this

                sw.Write("these ");
                sw.Write("will ");
                sw.Write(" be on the same line");

            }

            //using is a much better idean than the next 4 lines
            StreamWriter sw2 = new StreamWriter(fullPath, true);
            sw2.Write("bla");
            sw2.Flush(); //writes everything buffering in memory to the actual file
            sw2.Close(); // flush and close

            // After the using statement ends, file has now been written
            // and closed for further writing
        }



    }
}
