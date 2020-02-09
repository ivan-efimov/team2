using System.Drawing;

namespace thegame.Models
{
    public class Vec
    {
        public Vec(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vec(Point p)
        {
            X = p.Y;
            Y = p.X;
        }

        public readonly int X, Y;

    }
}