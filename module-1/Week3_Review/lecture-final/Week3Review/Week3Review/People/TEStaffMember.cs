using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Review.People
{
    public class TEStaffMember : Person
    {
        public TEStaffMember()  //since we don't explicityly call :base(), it automatically calls the parent no-arg constructor first
        {
            Console.WriteLine("in te staff member constructor");
        }
    }
}
