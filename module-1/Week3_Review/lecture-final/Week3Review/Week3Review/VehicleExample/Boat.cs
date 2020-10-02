using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Review.VehicleExample
{
    public class Boat : IVehicle
    {
        public bool IsFloating { get; set; } //property, no backing variable so .net does it automagically for me

        //has-a engine
        private Engine engine; //private data members/instance variables
        private int amountThrottlePushed; //private data members/instance variables

        /// <summary>
        /// constructor to initialize my instance variables
        /// </summary>
        /// 
        public Boat()
        {
            engine = new Engine();
            amountThrottlePushed = 0; 
        }

        public void Move()
        {
            //however the boat moves
            engine.IsOn = true;
            amountThrottlePushed++;
        }
    }
}
