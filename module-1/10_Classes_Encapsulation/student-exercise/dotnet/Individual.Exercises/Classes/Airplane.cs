namespace Individual.Exercises.Classes
{
    public class Airplane
    {
        public string PlaneNumber { get; private set; }
        public int TotalFirstClassSeats { get; private set; }
        public int BookedFirstClassSeats { get; private set; }
        public int AvailableFirstClassSeats => TotalFirstClassSeats - BookedFirstClassSeats;
        public int TotalCoachSeats { get; private set; }
        public int BookedCoachSeats { get; private set; }
        public int AvailableCoachSeats => TotalCoachSeats - BookedCoachSeats;

        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {
            PlaneNumber = planeNumber;
            TotalFirstClassSeats = totalFirstClassSeats;
            TotalCoachSeats = totalCoachSeats;
        }
        
        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            if (forFirstClass && AvailableFirstClassSeats >= totalNumberOfSeats)
            {
                BookedFirstClassSeats += totalNumberOfSeats;
                return true;
            }
            if (!forFirstClass && AvailableCoachSeats >= totalNumberOfSeats)
            {
                BookedCoachSeats += totalNumberOfSeats;
                return true;
            }
            return false;
        }
    }
}
