using System;

namespace People
{
    public class Student : Person
    {
        public int Grade { get; set; }
        
        public Student(string name, DateTime birthDate) : base(name, birthDate)
        {
        }

        public Student(string name, string birthDateString) : base(name, birthDateString)
        {
        }
    }
}