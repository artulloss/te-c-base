using System;

namespace  BaseballApp
{
    public class Player
    {
        private readonly string _name;
        private readonly short _timesAtBat;
        private readonly short _numberOfHits;
        public Player(string name, short timesAtBat, short numberOfHits)
        {
            this._name = name;
            this._timesAtBat = timesAtBat;
            this._numberOfHits = numberOfHits;
        }

        public string GetName()
        {
            return _name;
        }

        public short GetTimesAtBat()
        {
            return _timesAtBat;
        }

        public short GetNumberOfHits()
        {
            return _numberOfHits;
        }
    }
    
}