using System;

namespace People
{
    public class Person
    {
        public string Name { get; }
        
        private DateTime _birthDate;

        public int Age
        {
            get
            {
                // Save today's date.
                var today = DateTime.Today;
                // Calculate the age.
                var age = today.Year - _birthDate.Year;
                // Go back to the year in which the person was born in case of a leap year
                if (_birthDate.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public Person(string name, DateTime birthDate)
        {
            Name = name;
            _birthDate = birthDate;
        }

        public Person(string name, string birthDateString)
        {
            Name = name;
            _birthDate = DateTime.Parse(birthDateString);
        }
        
    }
}