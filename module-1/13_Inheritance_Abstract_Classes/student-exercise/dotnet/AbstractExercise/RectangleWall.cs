namespace AbstractExercise
{
    public class RectangleWall : Wall
    {
        public int Length { get; }
        public int Height { get; }
        
        public RectangleWall(string name, string color, int length, int height) : base(name, color)
        {
            Length = length;
            Height = height;
        }

        public override int GetArea()
        {
            return Length * Height;
        }

        public override string ToString()
        {
            // Name (LengthxHeight) rectangle
            return $"{Name} ({Length}x{Height}) rectangle";
        }
    }
}