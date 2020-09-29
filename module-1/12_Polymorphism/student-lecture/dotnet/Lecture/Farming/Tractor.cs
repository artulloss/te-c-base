namespace Lecture.Farming
{
    public class Tractor : ISingable, ISellable
    {
        public string Name { get; }
        public string MakeSoundOnce()
        {
            return "BRRRRR";
        }

        public string MakeSoundTwice()
        {
            return "BRRRRR BRRRRR";
        }

        public int Price { get; set; }
    }
}