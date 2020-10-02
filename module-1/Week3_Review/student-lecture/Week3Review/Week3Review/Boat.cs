namespace Week3Review
{
    public class Boat : IVehicle
    {
        public bool IsFloating { get; }

        private Engine  _engine = new Engine();
        private int _amountThrottlePushed = 0;
        
        public void Move()
        {
            
        }
    }
}