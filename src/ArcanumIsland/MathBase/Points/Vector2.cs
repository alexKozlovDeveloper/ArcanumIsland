using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.Points
{
    public class Vector2
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return $"{X}:{Y}".GetHashCode();
        }

        public override string ToString()
        {
            return $"[{X}:{Y}]";
        }
    }
}
