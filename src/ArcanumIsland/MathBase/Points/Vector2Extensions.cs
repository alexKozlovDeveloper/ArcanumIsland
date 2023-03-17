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
        public static Vector2 NewRelativePoint(this Vector2 point, Vector2 relative)
        {
            return point.NewRelativePoint(relative.X, relative.Y);
        }

        public static Vector2 NewRelativePoint(this Vector2 point, int relativeX, int relativeY)
        {
            return new Vector2(point.X + relativeX, point.Y + relativeY);
        }

        public static Vector2 NewRelativePointMirror(this Vector2 point, Vector2 relative, int width, int height)
        {
            return point.NewRelativePointMirror(relative.X, relative.Y, width, height);
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
