using MathBase.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.MultidimensionalArrays
{
    public static class MatrixHelper
    {
        public static T[][] CreateEmptyMatrix<T>(int width, int height)
        {
            var result = new T[width][];

            for (int x = 0; x < width; x++)
            {
                result[x] = new T[height];
            }

            return result;
        }

        public static bool IsOutOfMatrix(int width, int height, Vector2 point)
        {
            if (point.X >= 0 && point.X < width)
            {
                if (point.Y >= 0 && point.Y < height)
                {
                    return false;
                }
            }

            return true;
        }

        #region Get Immediate Points
        public static IEnumerable<Vector2> GetImmediatePoints(int width, int height, Vector2 point)
        {
            return Constants.ImmediatePointOffsets
                .Select(a => point.NewRelativePoint(a.x, a.y))
                .Where(a => IsOutOfMatrix(width, height, a) == false);
        }

        public static IEnumerable<Vector2> GetFullImmediatePoints(int width, int height, Vector2 point)
        {
            return Constants.FullImmediatePointOffsets
                .Select(a => point.NewRelativePoint(a.x, a.y))
                .Where(a => IsOutOfMatrix(width, height, a) == false);
        }

        public static IEnumerable<Vector2> GetImmediatePointsMirror(int width, int height, Vector2 point)
        {
            return Constants.ImmediatePointOffsets
                .Select(a => point.NewRelativePointMirror(a.x, a.y, width, height));
        }

        public static IEnumerable<Vector2> GetFullImmediatePointsMirror(int width, int height, Vector2 point)
        {
            return Constants.FullImmediatePointOffsets
                .Select(a => point.NewRelativePointMirror(a.x, a.y, width, height));
        }
        #endregion
    }
}
