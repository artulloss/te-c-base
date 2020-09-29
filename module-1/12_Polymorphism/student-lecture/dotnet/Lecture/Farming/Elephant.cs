namespace Lecture.Farming
{
    public class Elephant : FarmAnimal
    {
        public Elephant() : base("Elephant") {}

        public override string MakeSoundOnce()
        {
            return "TRUMPET";
        }

        public override string MakeSoundTwice()
        {
            return "TRUMPET TRUMPET";
        }
    }
}