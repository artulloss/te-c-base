using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Review.People
{
    public class Student : Person
    {
        public int Grade { get; set; }
        public Student(string birthday):base(birthday)
        {
            this.Name = "the student";
        }
    }
}
