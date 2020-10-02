using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Review.VehicleExample
{
    public abstract class LandMotorVehicle : IVehicle
    {
        //cars, trucks, motorcycles

        // engine, number of wheels, gas pedal
        private Engine engine = new Engine();

        private int numberOfWheels; //NOT A PROPERTY, just a private data member
        public int NumberOfWheels { get { return numberOfWheels; } } //this IS a property with a backing variable

        /// <summary>
        /// a helmet is required if there are 3 wheels or less 
        /// </summary>
        public bool RequiresHelmet { get { return numberOfWheels < 4; } } //this is a DERIVED property

        private int amountGasPedalPushed; // i can set the initial value here or in the constructor

        public LandMotorVehicle(int numberOfWheels)
        {
            this.numberOfWheels = numberOfWheels;
            amountGasPedalPushed = 0; 
        }

        public void Move()
        {
            engine.IsOn = true;
            amountGasPedalPushed++;
        }
    }
}
