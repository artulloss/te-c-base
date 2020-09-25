using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace BaseballApp.Classes
{
    public class BaseballPlayer
    {
        public string Name { get; set; }
        private int _numHits = 0;
        private int _atBats = 0;

        public int AtBats
        {
            get => _atBats;
            set
            {
                if(!(value >= 0))
                    throw new IndexOutOfRangeException("Times at bat must be positive");
                _atBats = value;
            }
        }

        public int NumHits
        {
            get => _numHits;
            set
            {
                if(!(value >= 0 && value <= _atBats))
                    throw new IndexOutOfRangeException("Number of hits must be positive and less or equal to the number of bats");
                _numHits = value;
            }
        }

        public double BattingAverage => (double) _numHits / _atBats;

        public string BattingAverageString => Math.Round(BattingAverage, 3).ToString(CultureInfo.CurrentCulture);
    }
}