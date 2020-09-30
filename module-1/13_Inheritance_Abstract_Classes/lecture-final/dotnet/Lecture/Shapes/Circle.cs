using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Shapes
{
    public class Circle : IShape
    {
        //this is NOT a property because there's no {}, this is an instance variable/data member and should NOT be public
        //public double Bla; 

        /*
        private double _radius; 
        public double Radius { get { return _radius; } set { if (value>0) _radius = value; }}
        */
        public double Radius { get;  } //i don't have a way to validate what a user might set the radius to

        public Circle(double radius)
        {
            Radius = radius; 
        }
        

        //OR

        /*
        public double GetRadius()
        {
            return _radius; 
        }
         public void SetRadius(double value)
        {
            if (value>0)
             _radius=value; 
            
        }
        */


        /// <summary>
        /// derived property based on the radius
        /// </summary>
        public double Perimeter {
            get
            {
                return 2 * Radius * Math.PI; 
            }
        }

        public string Color { get; }
        /* in the background automagically
         * private string _color;
         * public string Color {get {return _color;}}
         */

        public double Area { 
            get 
            {
                return Math.PI * Math.Pow(Radius, 2); 
                //math.PI * Radius * Radius; 
            } 
        }

        public bool IsFilled { get; set; }
        /* private bool _isFilled; 
         * public boos IsFilled {get {return _isFilled}} set { _isFilled = value}}
         */

        public bool SomeRandomMethod(int someIntParameter)
        {
            return true;
        }
    }
}
