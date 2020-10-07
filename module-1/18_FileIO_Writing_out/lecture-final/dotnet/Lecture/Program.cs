using System;
using System.IO;
using Lecture.Aids;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            string regular = "this\nis\na\nstring\twith\nescape\ncharacters";
            string withAtSign = @"this\nis\na\nstring\twith\nescape\ncharacters";

            string path = @"C:\Users\Katie Dwyer\workspace\c-base\module-1\18_FileIO_Writing_out\lecture-final\dotnet\Lecture\bin\Debug\netcoreapp2.2";

            Console.WriteLine("Regular string: " + regular);
            Console.WriteLine("With @ sign: " + withAtSign);

            //HardCodePath();

            //FileAndDirectories.UsingTheDirectoryClass();

            WritingTextFiles.WritingAFile();
            WritingTextFiles.WritingAFileWithNoPath();

            PerformanceDemo.SlowPerformance();
            PerformanceDemo.FastPerformance();

            LoopingCollectionToWriteFile.LoopingADictionaryToWriteAFile();
            ReadingAndWritingFiles.OpenAndWrite();
            BinaryImageManipulator.ReadFileIn();

            FileWrite();

            Console.Write("Press enter to finish");
            Console.ReadLine();
        }

        private static void FileWrite()
        {
            string path = Environment.CurrentDirectory;
            string filename = "oneLastExample.txt";
            string fullPath = Path.Combine(path, filename);

            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                for (int i=0; i<100; i++)
                {
                    sw.WriteLine(i);
                }
            }
        }

        private static void HardCodePath()
        {
            string path = @"C:\Users\Katie Dwyer\AssetPanda";
            string fullPathToFile = Path.Combine(path, "Cohort9.csv"); 
            try
            {
                using(StreamReader sr = new StreamReader(fullPathToFile))
                {
                    //only read the first 3 lines
                    int lineNum = 0;
                    while(!sr.EndOfStream && lineNum<3)
                    {
                        Console.WriteLine(sr.ReadLine());
                        lineNum++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("oops {0}", e.Message);
            }
        }
    }
}
