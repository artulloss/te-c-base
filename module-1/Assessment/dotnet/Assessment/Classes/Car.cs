using System;

namespace Assessment.Classes
{
    public class Car
    {
        public int Year { get; }
        public string Make { get; }
        public bool IsClassicCar { get; }
        public int Age { get; }

        public Car(int year, string make, bool isClassicCar) {
            Year = year;
            Make = make;
            IsClassicCar = isClassicCar;
            Age = DateTime.Now.Year - Year;
        }

        public bool NeedsECheck(int yearToCheck) {
            bool carHasEvenYear = Year % 2 == 0;
            bool yearToCheckIsEven = yearToCheck % 2 == 0;
            if (Age < 4 || Age > 25 || IsClassicCar) // Exemptions
                return false;
            return carHasEvenYear && yearToCheckIsEven || !carHasEvenYear && !yearToCheckIsEven;
        }

        public override string ToString() {
            return $"CAR - {Year} - {Make}";
        }
    }
}