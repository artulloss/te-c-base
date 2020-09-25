using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballApp.Classes
{
    public class BaseballPlayer
    {
        public string Name { get; set; }

        public int JerseyNumber { get; set; }

        //either have the batting average as a property OR we can have the num hits and times at Bat and batting average is derived
        private int _atBats = 0;
        public int AtBats
        {
            get
            {
                return _atBats;
            }
            set
            {
                if (value > 0)
                    _atBats = value;
            }
        }

        private int _numHits = 0; 
        public int NumHits { 
            get
            {
                return _numHits;
            }
            set 
            {
                if (value>=0 && value <= _atBats)
                    _numHits = value;
            }
        }

        //batting average
        public double BattingAverage
        {
            get
            {
                return (double)_numHits / _atBats; 
            }
        }
        public string BattingAverageString
        {
            get
            {
                //if the batting average is .33333333333 then i want to return ".333"
                return Math.Round(BattingAverage, 3).ToString();
            }
        }
    }
}
