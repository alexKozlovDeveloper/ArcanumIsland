using MathBase.MultidimensionalArrays.Factories;
using MathBase.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.MultidimensionalArrays
{
    public static class D2ArraysExtensions
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

        public static int[][] RadialDecrease(this int[][] src, double decreaseSpeed = 2)
        {
            if (decreaseSpeed == 0) { decreaseSpeed = 1; }

            return src.ForEachItemRadial((int val, double lenghtToCenter) => 
            {
                var newVal = (1 - lenghtToCenter / decreaseSpeed) * val;

                if (newVal < 0) { newVal = 0; }

                return (int)newVal; 
            });
        }

        public static T[][] TransformTo2dArray<T>(this T[][] src)
        {
            var width = src.GetWidth();
            var height = src.GetHeight();

            var result = D2ArrayFactory.CreateEmptyMatrix<T>(width, height);

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

        //public static bool IsOutOfMatrix<T>(this Matrix<T> matrix, Vector2 point)
        //{
        //    return MatrixHelper.IsOutOfMatrix(matrix.Width, matrix.Height, point);
        //}

        //#region Get Immediate Points
        //public static IEnumerable<Vector2> GetImmediatePoints<T>(this Matrix<T> matrix, Vector2 point)
        //{
        //    return MatrixHelper.GetImmediatePoints(matrix.Width, matrix.Height, point);
        //}

        //public static IEnumerable<Vector2> GetFullImmediatePoints<T>(this Matrix<T> matrix, Vector2 point)
        //{
        //    return MatrixHelper.GetFullImmediatePoints(matrix.Width, matrix.Height, point);
        //}

        //public static IEnumerable<Vector2> GetImmediatePointsMirror<T>(this Matrix<T> matrix, Vector2 point)
        //{
        //    return MatrixHelper.GetImmediatePointsMirror(matrix.Width, matrix.Height, point);
        //}

        //public static IEnumerable<Vector2> GetFullImmediatePointsMirror<T>(this Matrix<T> matrix, Vector2 point)
        //{
        //    return MatrixHelper.GetFullImmediatePointsMirror(matrix.Width, matrix.Height, point);
        //}
        //#endregion

        public static int[][] StretchOnMaximumAndMinimumValue(this int[][] matrix, int newMin, int newMax)
        {
            var maxValue = matrix.Max(a => a.Max());
            var minValue = matrix.Min(a => a.Min());

            var result = new int[matrix.Length][];

            for (int x = 0; x < matrix.Length; x++)
            {
                result[x] = new int[matrix[x].Length];
            }

            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[x].Length; y++)
                {
                    double newValue = matrix[x][y];

                    newValue -= minValue;

                    double pos = newValue / (maxValue - minValue);

                    newValue = pos * (newMax - newMin) + newMin;

                    result[x][y] = (int)newValue;
                }
            }

            return result;
        }

        public static int[][] Sum(this int[][] m1, int[][] m2)
        {
            if (m1.Length == 0 || m2.Length == 0) { throw new NotImplementedException(); }
            if (m1[0].Length == 0 || m2[0].Length == 0) { throw new NotImplementedException(); }
            if (m1.Length != m2.Length) { throw new NotImplementedException(); }
            if (m1[0].Length != m2[0].Length) { throw new NotImplementedException(); }

            var result = new int[m1.Length][];

            for (int x = 0; x < m1.Length; x++)
            {
                result[x] = new int[m1[x].Length];

                for (int y = 0; y < m1[x].Length; y++)
                {
                    result[x][y] = m1[x][y] + m2[x][y];
                }
            }

            return result;
        }

        public static int[][] Average(this int[][] m1, int[][] m2)
        {
            if (m1.Length == 0 || m2.Length == 0) { throw new NotImplementedException(); }
            if (m1[0].Length == 0 || m2[0].Length == 0) { throw new NotImplementedException(); }
            if (m1.Length != m2.Length) { throw new NotImplementedException(); }
            if (m1[0].Length != m2[0].Length) { throw new NotImplementedException(); }

            var result = new int[m1.Length][];

            for (int x = 0; x < m1.Length; x++)
            {
                result[x] = new int[m1[x].Length];

                for (int y = 0; y < m1[x].Length; y++)
                {
                    result[x][y] = (m1[x][y] + m2[x][y]) / 2;
                }
            }

            return result;
        }

        public static int[][] Average(this IEnumerable<int[][]> items)
        {
            var result = new int[items.First().Length][];

            for (int x = 0; x < items.First().Length; x++)
            {
                result[x] = new int[items.First()[x].Length];

                for (int y = 0; y < items.First()[x].Length; y++)
                {
                    var sum = 0;

                    foreach (var item in items)
                    {
                        sum += item[x][y];
                    }

                    result[x][y] = sum / items.Count();
                }
            }

            return result;
        }

        public static int[][] Smoothing(this int[][] matrix, int size = 1)
        {
            var result = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = new int[matrix[i].Length];
            }

            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    var points = GetAdjacentXY(x, y, size, matrix.Length, matrix[0].Length, true);

                    var values = new List<int>();

                    foreach (var point in points)
                    {
                        values.Add(matrix[point.Key][point.Value]);
                    }

                    var value = (int)values.Average();

                    result[x][y] = value;
                }
            }

            return result;
        }

        private static IEnumerable<KeyValuePair<int, int>> GetAdjacentXY(int x, int y, int size, int maxX, int maxY, bool useLoopXY = false)
        {
            var points = new List<KeyValuePair<int, int>>();

            for (int i = x - size; i <= x + size; i++)
            {
                for (int j = y - size; j <= y + size; j++)
                {
                    if (useLoopXY == true)
                    {
                        var posX = (i >= 0 && i < maxX) ? i : (i < 0 ? maxX + i : i - maxX);
                        var posY = (j >= 0 && j < maxY) ? j : (j < 0 ? maxY + j : j - maxY);

                        points.Add(new KeyValuePair<int, int>(posX, posY));
                    }
                    else
                    {
                        if (i >= 0 && i < maxX && j >= 0 && j < maxY)
                        {
                            points.Add(new KeyValuePair<int, int>(i, j));
                        }
                    }
                }
            }

            return points;
        }

        public static int[][] Exponentiation(this int[][] matrix, int _maxValue)
        {
            var result = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = new int[matrix[i].Length];
            }

            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    result[x][y] = (matrix[x][y] * matrix[x][y]) / _maxValue;
                }
            }

            return result;
        }

        public static int[][] ClearTopValue(this int[][] matrix, int topEdge)
        {
            var result = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = new int[matrix[i].Length];
            }

            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    result[x][y] = matrix[x][y] <= topEdge ? matrix[x][y] : 0;
                }
            }

            return result;
        }

        public static int[][] ClearBottomValue(this int[][] matrix, int bottomEdge)
        {
            var result = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = new int[matrix[i].Length];
            }

            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    result[x][y] = matrix[x][y] >= bottomEdge ? matrix[x][y] : 0;
                }
            }

            return result;
        }

        public static int[][] IncreaseOctave(this int[][] matrix, int multiplier)
        {
            var result = new int[matrix.Length * multiplier][];

            for (int x = 0; x < matrix.Length * multiplier; x++)
            {
                result[x] = new int[matrix[0].Length * multiplier];
            }

            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    for (double a = 0; a < multiplier; a++)
                    {
                        for (double b = 0; b < multiplier; b++)
                        {
                            if (a == 0 && b == 0)
                            {
                                result[x * multiplier][y * multiplier] = matrix[x][y];
                                continue;
                            }

                            var point00 = matrix[x][y];
                            var point01 = matrix[x][(y == matrix[0].Length - 1 ? -1 : y) + 1];
                            var point10 = matrix[(x == matrix.Length - 1 ? -1 : x) + 1][y];
                            var point11 = matrix[(x == matrix.Length - 1 ? -1 : x) + 1][(y == matrix[0].Length - 1 ? -1 : y) + 1];

                            var t00 = 1 / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                            var t01 = 1 / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(multiplier - b, 2));
                            var t10 = 1 / Math.Sqrt(Math.Pow(multiplier - a, 2) + Math.Pow(b, 2));
                            var t11 = 1 / Math.Sqrt(Math.Pow(multiplier - a, 2) + Math.Pow(multiplier - b, 2));

                            var value = (point00 * t00 + point01 * t01 + point10 * t10 + point11 * t11) / (t00 + t01 + t10 + t11);

                            result[x * multiplier + (int)a][y * multiplier + (int)b] = (int)value;
                        }
                    }
                }
            }

            return result;
        }

        public static int[][] DecreaseOctave(this int[][] matrix, int multiplier)
        {
            int newWidth = matrix.Length / multiplier;
            int newHeight = matrix[0].Length / multiplier;

            var result = new int[newWidth][];

            for (int x = 0; x < newWidth; x++)
            {
                result[x] = new int[newHeight];
            }

            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    result[x][y] = matrix[x * multiplier][y * multiplier];
                }
            }

            return result;
        }
    }
}
