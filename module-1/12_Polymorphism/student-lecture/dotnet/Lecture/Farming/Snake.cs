namespace Lecture.Farming
{
    public class Snake : FarmAnimal
    {
        public Snake() : base("Snake") {}

        public override string MakeSoundOnce()
        {
            return "SSSSS";
        }

        public override string MakeSoundTwice()
        {
            return "SSSSS SSSSS";
        }
    }
}