namespace Lecture.Farming
{
    public interface ISingable
    {
        string Name { get; }

        string MakeSoundOnce();
        
        string MakeSoundTwice();
    }
}