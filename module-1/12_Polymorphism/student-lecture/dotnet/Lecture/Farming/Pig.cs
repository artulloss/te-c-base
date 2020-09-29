namespace Lecture.Farming
{
    public class Pig : FarmAnimal
    {
        public Pig() : base("Pig") {}
        public override string MakeSoundOnce()
        {
            return "OINK";
        }

        public override string MakeSoundTwice()
        {
            return "OINK OINK";
        }
    }
}