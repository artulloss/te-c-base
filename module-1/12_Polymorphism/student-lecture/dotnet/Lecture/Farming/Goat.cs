namespace Lecture.Farming
{
    public class Goat : FarmAnimal, ISellable
    {
        public int Price { get; set; } = 5;
        public Goat() : base("GOAT") {}

        public override string MakeSoundOnce()
        {
            return "BLEAT";
        }

        public override string MakeSoundTwice()
        {
            return "BLEAT BLEAT";
        }
    }
}