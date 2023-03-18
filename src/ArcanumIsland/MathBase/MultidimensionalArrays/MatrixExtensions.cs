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

        public static T[][] ForEachItem<T>(this T[][] src, Func<T, T> func)
        {
            var result = new T[src.Length][];

            for (int x = 0; x < src.Length; x++)
            {
                result[x] = new T[src[x].Length];

                for (int y = 0; y < src[x].Length; y++)
                {
                    result[x][y] = func(src[x][y]);
                }
            }

            return result;
        }

        public static T[][] ForEachItemRadial<T>(this T[][] src, Func<T, double, T> func)
        {
            var result = new T[src.Length][];

            var center = new Vector2(src.GetWidth() / 2, src.GetHeight() / 2);
            var radius = center.GetLength();

            for (int x = 0; x < src.Length; x++)
            {
                result[x] = new T[src[x].Length];

                for (int y = 0; y < src[x].Length; y++)
                {
                    var bassedVector = new Vector2(x - center.X, y - center.Y);

                    var lenghtToCenter = bassedVector.GetLength();

                    var persent = lenghtToCenter / radius;

                    result[x][y] = func(src[x][y], persent);
                }
            }

            return result;
        }

        public static int[][] RadialDecrease(this int[][] src, double decreaseSpeed = 1)
        {
            if (decreaseSpeed == 0) { decreaseSpeed = 1; }

            return src.ForEachItemRadial((int val, double lenghtToCenter) => 
            {
                var newVal = (1 - lenghtToCenter / decreaseSpeed) * val;

                return (int)newVal; 
            });
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
            return MatrixHelper.IsOutOfMatrix(matrix.Width, matrix.Height, point);
        }

        #region Get Immediate Points
        public static IEnumerable<Vector2> GetImmediatePoints<T>(this Matrix<T> matrix, Vector2 point)
        {
            return MatrixHelper.GetImmediatePoints(matrix.Width, matrix.Height, point);
        }

        public static IEnumerable<Vector2> GetFullImmediatePoints<T>(this Matrix<T> matrix, Vector2 point)
        {
            return MatrixHelper.GetFullImmediatePoints(matrix.Width, matrix.Height, point);
        }

        public static IEnumerable<Vector2> GetImmediatePointsMirror<T>(this Matrix<T> matrix, Vector2 point)
        {
            return MatrixHelper.GetImmediatePointsMirror(matrix.Width, matrix.Height, point);
        }

        public static IEnumerable<Vector2> GetFullImmediatePointsMirror<T>(this Matrix<T> matrix, Vector2 point)
        {
            return MatrixHelper.GetFullImmediatePointsMirror(matrix.Width, matrix.Height, point);
        }
        #endregion
    }
}
