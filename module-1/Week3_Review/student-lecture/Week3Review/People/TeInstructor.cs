using System;

namespace People
{
    public class TeInstructor : TeStaffMember
    {
        public TeInstructor(string name, DateTime birthDate) : base(name, birthDate)
        {
        }

        public TeInstructor(string name, string birthDateString) : base(name, birthDateString)
        {
        }
    }
}