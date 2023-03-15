using MathBase.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.MultidimensionalArrays
{
    public static class MatrixExtensions
    {
        public static int GetWidth<T>(this T[][] src)
        {
            var width = src.Length;

            return width;
        }

        public static int GetHeight<T>(this T[][] src)
        {
            var height = src.Select(a => a.Length).Max();

            return height;
        }

        public static M[][] Convert<T, M>(this T[][] src, Func<T, M> convertFunc)
        {
            var result = new M[src.Length][];

            for (int x = 0; x < src.Length; x++)
            {
                result[x] = new M[src[x].Length];

                for (int y = 0; y < src[x].Length; y++)
                {
                    result[x][y] = convertFunc(src[x][y]);
                }
            }

            return result;
        }

        public static T[][] TransformToMatrix<T>(this T[][] src)
        {
            var width = src.GetWidth();
            var height = src.GetHeight();

            var result = MatrixHelper.CreateEmptyMatrix<T>(width, height);

            for (int x = 0; x < src.Length; x++)
            {
                for (int y = 0; y < src[x].Length; y++)
                {
                    result[x][y] = src[x][y];
                }
            }

            return result;
        }

        public static T[][] Copy<T>(this T[][] src)
        {
            var result = new T[src.Length][];

            for (int x = 0; x < src.Length; x++)
            {
                result[x] = new T[src[x].Length];

                for (int y = 0; y < src[x].Length; y++)
                {
                    result[x][y] = src[x][y];
                }
            }

            return result;
        }

        public static bool IsOutOfMatrix<T>(this Matrix<T> matrix, Vector2 point)
        {
            if (point.X >= 0 && point.X < matrix.Width)
            {
                if (point.Y >= 0 && point.Y < matrix.Height)
                {
                    return true;
                }
            }

            return false;
        }

        #region Get Immediate Points
        public static IEnumerable<Vector2> GetImmediatePoints<T>(this Matrix<T> matrix, Vector2 point)
        {
            return Constants.ImmediatePointOffsets
                .Select(a => point.NewRelativePoint(a.x, a.y))
                .Where(a => matrix.IsOutOfMatrix(a) == false);
        }

        public static IEnumerable<Vector2> GetFullImmediatePoints<T>(this Matrix<T> matrix, Vector2 point)
        {
            return Constants.FullImmediatePointOffsets
                .Select(a => point.NewRelativePoint(a.x, a.y))
                .Where(a => matrix.IsOutOfMatrix(a) == false);
        }

        public static IEnumerable<Vector2> GetImmediatePointsMirror<T>(this Matrix<T> matrix, Vector2 point)
        {
            return Constants.ImmediatePointOffsets
                .Select(a => point.NewRelativePointMirror(a.x, a.y, matrix.Width, matrix.Height));
        }

        public static IEnumerable<Vector2> GetFullImmediatePointsMirror<T>(this Matrix<T> matrix, Vector2 point)
        {
            return Constants.FullImmediatePointOffsets
                .Select(a => point.NewRelativePointMirror(a.x, a.y, matrix.Width, matrix.Height));
        }
        #endregion
    }
}
