using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.Points
{
    public class Vector2 // : IComparable<Vector2>
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
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"[{X}:{Y}]";
        }

        //public int CompareTo(Vector2? other)
        //{
        //    if (this.ToString() == other.ToString()) 
        //    {
        //        return 0;
        //    }

        //    if (this.X > other.X)
        //    {
        //        return 1;
        //    }
        //    else if (this.X < other.X)
        //    {
        //        return -1;
        //    }
        //    else 
        //    {
        //        if (this.Y > other.Y)
        //        {
        //            return 1;
        //        }
        //        else if (this.Y < other.Y)
        //        {
        //            return -1;
        //        }
        //        else 
        //        {
        //            return 0;
        //        }
        //    }
        //}

        public override bool Equals(object? other)
        {
            var otherVector2 = other as Vector2;

            if (this.X == otherVector2.X && this.Y == otherVector2.Y) 
            {
                return true;
            }

            return false;
        }
    }
}
