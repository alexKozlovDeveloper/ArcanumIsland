using MathBase.Ranges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.Points
{
    public static class Vector2Extensions
    {
        public static Vector2 NewRelativePoint(this Vector2 point, int relativeX, int relativeY)
        {
            return new Vector2(point.X + relativeX, point.Y + relativeY);
        }

        public static Vector2 NewRelativePointMirror(this Vector2 point, int relativeX, int relativeY, int width, int height)
        {
            var newX = point.X + relativeX;
            var newY = point.Y + relativeY;

            newX = RangeHelper.BringValueToRange(newX, width);
            newY = RangeHelper.BringValueToRange(newY, height);

            return new Vector2(newX, newY);
        }
    }
}
