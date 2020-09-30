﻿namespace AbstractExercise
{
    public class TriangleWall : Wall
    {
        public int Base { get; }
        public int Height { get; }
        
        public TriangleWall(string name, string color, int @base, int height) : base(name, color)
        {
            Base = @base;
            Height = height;
        }

        public override int GetArea()
        {
            return Base * Height / 2;
        }

        public override string ToString()
        {
            // Name (BasexHeight) triangle
            return $"{Name} ({Base}x{Height}) triangle";
        }
    }
}