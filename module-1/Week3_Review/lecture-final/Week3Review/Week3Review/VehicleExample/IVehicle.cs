using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Review.VehicleExample
{
    public interface IVehicle
    {
        /// <summary>
        /// all vehicles must implement the move method, we don't care how
        /// </summary>
        void Move();
    }
}
