using System;
using System.IO;
using Lecture.Aids;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {

            //LoopingCollectionToWriteFile.LoopingADictionaryToWriteAFile();
            Console.WriteLine(Environment.CurrentDirectory);
            var files = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.GetFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
            BinaryImageManipulator.ReadFileIn();
        }
    }
}
