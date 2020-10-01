using System;

namespace AbstractExercise
{
    public class SquareWall : RectangleWall
    {
        public int SideLength // Not required but probably a good thing to have
        {
            get
            {
                if (Length != Height)
                {
                    throw new Exception("Length and Height must be equivalent!");
                }
                return Length;
            }
        }
        
        public SquareWall(string name, string color, int sideLength) : base(name, color, sideLength, sideLength) {}

        public override string ToString()
        {
            return $"{Name} ({SideLength}x{SideLength}) square";
        }
    }
}