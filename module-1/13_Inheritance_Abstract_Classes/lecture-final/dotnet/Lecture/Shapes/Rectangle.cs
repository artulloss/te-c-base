using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Shapes
{
    public class Rectangle : IShape
    {
        private double _length;
        public double Length // rect.Length = -5; then it won't update the length
        { 
            get 
            { 
                return _length; 
            } 
            set 
            { 
                if (value > 0) 
                    _length = value; 
            }
        }

        public double Width { get; set; } //no way to verify that width is positive when user says rect.Width = -5; 

        public double Perimeter { get { return (Length + Width) * 2; } }

        public double Area { get { return Length * Width;  } }

        public bool IsFilled { get; set; }

        public bool SomeRandomMethod(int someIntParameter)
        {
            return true;
        }
    }
}
