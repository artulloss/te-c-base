using System;

namespace People
{
    public class TeStaffMember : Person
    {
        public  int Salary { get; }
        public TeStaffMember(string name, DateTime birthDate) : base(name, birthDate)
        {
        }

        public TeStaffMember(string name, string birthDateString) : base(name, birthDateString)
        {
        }
    }
}