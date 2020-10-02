using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Review.VehicleExample
{
    public class Car : LandMotorVehicle
    {
        public Car() : base(4)
        {
            //NumberOfWheels = 4; no setter on the property
            //numberOfWheels = 4; this data member is private
        }


    }
}
