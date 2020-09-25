using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BetterClassExamples.Classes
{
    public class Student
    {
        //name done the old school c++ way
        private string name;
        public string GetName()
        {
            return name; 
        }
        public void SetName(string value)
        {
            name = value; 
        }

        //.NET said hey let's make this easy. Hide the backing variable and giving us the 'default' getter and setter
        public string FavColor { get; set;  }

        //age
        private int _age; //this is a backing variable, so i can do validation before i set it
        public int Age { 
            get
            {
                return _age;
            }
            set //the paramenter is always name value and is always of the datatype of the property
            {
                //code goes here
                if (value > 15 && value < 200)
                    _age = value;
            } 
        }


        //quizScores
        private List<double> _quizScores = new List<double>(); 
        public List<double> quizScores { get; private set; } //private set means only in this class

        public void AddQuizScore(double newScore)
        {
            if (newScore <= 100 && newScore >= 0 )
                _quizScores.Add(newScore);
        }

        public string ClassName { get; } //no set means i can only update this in the constructor

        public Student()
        {
            Console.WriteLine("in student constructor");
            ClassName = "C#"; 
        }
        public Student(string className)
        {
            Console.WriteLine("in student constructor that takes a paramenter");
            ClassName = className;
        }

        public Student(string className, string name)
        {
            Console.WriteLine("in student constructor that takes a paramenter");
            ClassName = className;
            this.name = name; 
        }

        public Student Duplicate()
        {
            Student s = new Student(this.ClassName, this.name);
            return s; 
        }
        
        public bool AreGradesBetterThan(Student otherStudent)
        {
            double thisQuizSum = 0;
            foreach (double s in this._quizScores)
            {
                thisQuizSum += s;
            }

            double otherQuizSum = 0;
            foreach (double s in otherStudent._quizScores)
            {
                otherQuizSum += s;
            }

            //return true if the average of this student is greater than the average of the parameter
            return (thisQuizSum / this._quizScores.Count) > (otherQuizSum / otherStudent._quizScores.Count); 

        }

        public void PrintStudentInfo()
        {
            Console.WriteLine("name {0} class {1}", this.name, this.ClassName);
        }


        public void PrintStudentInfo(bool includeGrades)
        {
            PrintStudentInfo(); 
            if (includeGrades)
            {
                Console.WriteLine("Grades" + String.Join(',', _quizScores));
            }
            
        }

        private static int maxLanguageCount = 150; 
        public static int MaxLanguageCount { 
            get
            {
                return maxLanguageCount;
            }
            set 
            {
                if (value<1000)
                    maxLanguageCount = value;
            }
        }

        //language count 
        public int LanguageCount { get; private set; } //private set and public method is one way of doing the validation

        /// <summary>
        /// Updates the LanguageCount to valid values only(0-150)
        /// </summary>
        /// <param name="count"></param>
        public void UpdateLangaugeCount(int count)
        {
            if (count > 0 && count <= maxLanguageCount)
                LanguageCount = count;
        }

        //the other way of doing the validation is to have a backing variable
        private int _langCount;
        public int LanguageCountV2
        {
            get
            {
                return _langCount;
            }
            set
            {
                if (value > 0 && value <= maxLanguageCount) //i can access static data from instance methods
                    _langCount = value;
            }
        }

        public static void PrintMaxLanguages()
        {
            //static methods can ONLY access static data
            Console.WriteLine("Max language count: " + MaxLanguageCount);

            //i CANNOT access instance data 
            //Console.WriteLine(name); 
        }
    }
}
