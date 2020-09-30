using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Shapes
{
    public interface IShape
    {

        //methods are allowed to have parameters, Properties are not allowed to have parameters
        //double GetPerimeter(); //Console.WriteLine(myShape.GetPerimeter()); 
        double Perimeter { get;  }  //Console.WriteLine(myShape.Perimeter); 

        double Area { get; }

        bool IsFilled { get; }

        bool SomeRandomMethod(int someIntParameter);

    }
}
