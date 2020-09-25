using BetterClassExamples.Classes;
using System;
using System.Collections.Generic;

namespace BetterClassExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Student amy = new Student();
            amy.SetName("amy");
            amy.Age = 21;
            amy.FavColor = "green";
            /* we can't access private things for student outside of the student class
            amy._age = 22;
            amy.QuizScores = new List<double> { 100, 100, 100 };
            amy.QuizScores.Add(100);
            */

            Student brian = new Student();
            Student zach = new Student();
            zach.SetName("zach");
            Student chris = new Student(".NET");
            chris.SetName("chris");

            chris.PrintStudentInfo();
            zach.PrintStudentInfo(true);

            //chris.LanguageCount = 5; FORBIDDEN - private set;
            chris.UpdateLangaugeCount(5);
            zach.LanguageCountV2 = 5;
            int chrisLearnedLangugaes = 200;
            if (chrisLearnedLangugaes > Student.MaxLanguageCount)
                Console.WriteLine("no way! i'm not saving that");
            else
                chris.UpdateLangaugeCount(chrisLearnedLangugaes);


            Student.MaxLanguageCount = 200;
            zach.SetName("test");

            Console.Write("are chris's grades better than zach's? "+ chris.AreGradesBetterThan(zach)); 
        }
    }
}
