namespace Week3Review
{
    public abstract class LandMotorVehicle
    {
        private Engine _engine = new Engine();
        public int NumberOfWheels { get; }
        
        public bool RequiresHelmet => NumberOfWheels < 4;

        private int _amountGassPedle;

        public LandMotorVehicle(int numberOfWheels)
        {
            NumberOfWheels = numberOfWheels;
        }
    }
}