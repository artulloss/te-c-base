using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Review
{
    public class Person
    {
        //name
        public string Name { get; set; }

        //birthday
        private DateTime birthday;
        

        //derive the age from the birthday
        public int Age 
        { 
            get 
            {
                //figure out the age from the birthday
                int numYears = DateTime.Now.Year - birthday.Year;
                //account for if the birthday has passed by or not. Today is 10/2/2020
                //if i was born 10/1/2019 then i am 1,  numYears is 1
                //if is was born 10/3/2019 then i haven't had my birthday yet but numYears is 1 and should be zero
                if (birthday.DayOfYear > DateTime.Now.DayOfYear) //if your birth day hasn't happend yet then subtract 1 from the numYears
                    numYears--;

                return numYears; 

            }
        }

        public Person(DateTime birthday)
        {
            this.birthday = birthday;
            Console.WriteLine("in the dt constructor for person ");
        }

        public Person(string strBirthday)
        {
            this.birthday = DateTime.Parse(strBirthday);
            Console.WriteLine("in the string constructor for person ");
        }

        public Person()
        {
            Console.WriteLine("in the no-arg constructor for person");
            birthday = DateTime.Now.AddDays(-1); //default is you were born yesterday
            Name = "unknown";
        }
    }
}
