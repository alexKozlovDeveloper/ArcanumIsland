using MathBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinNoise
{
    public static class PerlinNoiseHelper
    {
        //public static int[][] Sum(this int[][] m1, int[][] m2)
        //{
        //    if (m1.Length == 0 || m2.Length == 0) { throw new NotImplementedException(); }
        //    if (m1[0].Length == 0 || m2[0].Length == 0) { throw new NotImplementedException(); }
        //    if (m1.Length != m2.Length) { throw new NotImplementedException(); }
        //    if (m1[0].Length != m2[0].Length) { throw new NotImplementedException(); }

        //    var result = new int[m1.Length][];

        //    for (int x = 0; x < m1.Length; x++)
        //    {
        //        result[x] = new int[m1[x].Length];

        //        for (int y = 0; y < m1[x].Length; y++)
        //        {
        //            result[x][y] = m1[x][y] + m2[x][y];
        //        }
        //    }

        //    return result;
        //}

        //public static int[][] Average(this int[][] m1, int[][] m2)
        //{
        //    if (m1.Length == 0 || m2.Length == 0) { throw new NotImplementedException(); }
        //    if (m1[0].Length == 0 || m2[0].Length == 0) { throw new NotImplementedException(); }
        //    if (m1.Length != m2.Length) { throw new NotImplementedException(); }
        //    if (m1[0].Length != m2[0].Length) { throw new NotImplementedException(); }

        //    var result = new int[m1.Length][];

        //    for (int x = 0; x < m1.Length; x++)
        //    {
        //        result[x] = new int[m1[x].Length];

        //        for (int y = 0; y < m1[x].Length; y++)
        //        {
        //            result[x][y] = (m1[x][y] + m2[x][y]) / 2;
        //        }
        //    }

        //    return result;
        //}

        //public static int[][] Average(this IEnumerable<int[][]> items)
        //{
        //    var result = new int[items.First().Length][];

        //    for (int x = 0; x < items.First().Length; x++)
        //    {
        //        result[x] = new int[items.First()[x].Length];

        //        for (int y = 0; y < items.First()[x].Length; y++)
        //        {
        //            var sum = 0;

        //            foreach (var item in items)
        //            {
        //                sum += item[x][y];
        //            }

        //            result[x][y] = sum / items.Count();
        //        }
        //    }

        //    return result;
        //}

        //public static int[][] Smoothing(this int[][] matrix, int size = 1)
        //{
        //    var result = new int[matrix.Length][];

        //    for (int i = 0; i < matrix.Length; i++)
        //    {
        //        result[i] = new int[matrix[i].Length];
        //    }

        //    for (int x = 0; x < matrix.Length; x++)
        //    {
        //        for (int y = 0; y < matrix[0].Length; y++)
        //        {
        //            var points = GetAdjacentXY(x, y, size, matrix.Length, matrix[0].Length, true);

        //            var values = new List<int>();

        //            foreach (var point in points)
        //            {
        //                values.Add(matrix[point.Key][point.Value]);
        //            }

        //            var value = (int)values.Average();

        //            result[x][y] = value;
        //        }
        //    }

        //    return result;
        //}

        //private static IEnumerable<KeyValuePair<int, int>> GetAdjacentXY(int x, int y, int size, int maxX, int maxY, bool useLoopXY = false)
        //{
        //    var points = new List<KeyValuePair<int, int>>();

        //    for (int i = x - size; i <= x + size; i++)
        //    {
        //        for (int j = y - size; j <= y + size; j++)
        //        {
        //            if (useLoopXY == true)
        //            {
        //                var posX = (i >= 0 && i < maxX) ? i : (i < 0 ? maxX + i : i - maxX);
        //                var posY = (j >= 0 && j < maxY) ? j : (j < 0 ? maxY + j : j - maxY);

        //                points.Add(new KeyValuePair<int, int>(posX, posY));
        //            }
        //            else
        //            {
        //                if (i >= 0 && i < maxX && j >= 0 && j < maxY)
        //                {
        //                    points.Add(new KeyValuePair<int, int>(i, j));
        //                }
        //            }
        //        }
        //    }

        //    return points;
        //}

        //public static int[][] Exponentiation(this int[][] matrix, int _maxValue)
        //{
        //    var result = new int[matrix.Length][];

        //    for (int i = 0; i < matrix.Length; i++)
        //    {
        //        result[i] = new int[matrix[i].Length];
        //    }

        //    for (int x = 0; x < matrix.Length; x++)
        //    {
        //        for (int y = 0; y < matrix[0].Length; y++)
        //        {
        //            result[x][y] = (matrix[x][y] * matrix[x][y]) / _maxValue;
        //        }
        //    }

        //    return result;
        //}

        //public static int[][] ClearTopValue(this int[][] matrix, int topEdge)
        //{
        //    var result = new int[matrix.Length][];

        //    for (int i = 0; i < matrix.Length; i++)
        //    {
        //        result[i] = new int[matrix[i].Length];
        //    }

        //    for (int x = 0; x < matrix.Length; x++)
        //    {
        //        for (int y = 0; y < matrix[0].Length; y++)
        //        {
        //            result[x][y] = matrix[x][y] <= topEdge ? matrix[x][y] : 0;
        //        }
        //    }

        //    return result;
        //}

        //public static int[][] ClearBottomValue(this int[][] matrix, int bottomEdge)
        //{
        //    var result = new int[matrix.Length][];

        //    for (int i = 0; i < matrix.Length; i++)
        //    {
        //        result[i] = new int[matrix[i].Length];
        //    }

        //    for (int x = 0; x < matrix.Length; x++)
        //    {
        //        for (int y = 0; y < matrix[0].Length; y++)
        //        {
        //            result[x][y] = matrix[x][y] >= bottomEdge ? matrix[x][y] : 0;
        //        }
        //    }

        //    return result;
        //}

        //public static int[][] IncreaseOctave(this int[][] matrix, int multiplier)
        //{
        //    var result = new int[matrix.Length * multiplier][];

        //    for (int x = 0; x < matrix.Length * multiplier; x++)
        //    {
        //        result[x] = new int[matrix[0].Length * multiplier];
        //    }

        //    for (int x = 0; x < matrix.Length; x++)
        //    {
        //        for (int y = 0; y < matrix[0].Length; y++)
        //        {
        //            for (double a = 0; a < multiplier; a++)
        //            {
        //                for (double b = 0; b < multiplier; b++)
        //                {
        //                    if (a == 0 && b == 0)
        //                    {
        //                        result[x * multiplier][y * multiplier] = matrix[x][y];
        //                        continue;
        //                    }

        //                    var point00 = matrix[x][y];
        //                    var point01 = matrix[x][(y == matrix[0].Length - 1 ? -1 : y) + 1];
        //                    var point10 = matrix[(x == matrix.Length - 1 ? -1 : x) + 1][y];
        //                    var point11 = matrix[(x == matrix.Length - 1 ? -1 : x) + 1][(y == matrix[0].Length - 1 ? -1 : y) + 1];

        //                    var t00 = 1 / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        //                    var t01 = 1 / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(multiplier - b, 2));
        //                    var t10 = 1 / Math.Sqrt(Math.Pow(multiplier - a, 2) + Math.Pow(b, 2));
        //                    var t11 = 1 / Math.Sqrt(Math.Pow(multiplier - a, 2) + Math.Pow(multiplier - b, 2));

        //                    var value = (point00 * t00 + point01 * t01 + point10 * t10 + point11 * t11) / (t00 + t01 + t10 + t11);

        //                    result[x * multiplier + (int)a][y * multiplier + (int)b] = (int)value;
        //                }
        //            }
        //        }
        //    }

        //    return result;
        //}

        //public static int[][] DecreaseOctave(this int[][] matrix, int multiplier)
        //{
        //    int newWidth = matrix.Length / multiplier;
        //    int newHeight = matrix[0].Length / multiplier;

        //    var result = new int[newWidth][];

        //    for (int x = 0; x < newWidth; x++)
        //    {
        //        result[x] = new int[newHeight];
        //    }

        //    for (int x = 0; x < newWidth; x++)
        //    {
        //        for (int y = 0; y < newHeight; y++)
        //        {
        //            result[x][y] = matrix[x * multiplier][y * multiplier];
        //        }
        //    }

        //    return result;
        //}

        //public static int Lerp(int a, int b, int t)
        //{
        //    return a + (b - a) * t;
        //}

        //public static bool IsMultipleOfTwo(int val)
        //{
        //    return val != 0 && (val & (val - 1)) == 0;
        //}

        //public static void GetIntegerAndFractionalPart(double num, out int integer, out double fractional)
        //{
        //    integer = (int)num;
        //    fractional = num - (double)integer;
        //}

        public static double[][] ResizeMatrix(this int[][] matrix, int newWidth, int newHeight)
        {
            //var d1 = GetSquareTransitionValue(1.0, 2.0, 2.0, 10.0, 0.999, 0.999);
            //var d2 = GetSquareTransitionValue(1.0, 1.0, 1.0, 1.0, 0.999, 0.999);
            //var d3 = GetSquareTransitionValue(10.0, 2.0, 2.0, 10.0, 0.5, 0.5);
            //var d4 = GetSquareTransitionValue(1.0, 2.0, 2.0, 10.0, 0.5, 0.5);

            //var d5 = GetSquareTransitionValue(3.0, 4.0, 5.0, 6.0, 0, 0);
            //var d6 = GetSquareTransitionValue(3.0, 4.0, 5.0, 6.0, 1, 0);
            //var d7 = GetSquareTransitionValue(3.0, 4.0, 5.0, 6.0, 0, 1);
            //var d8 = GetSquareTransitionValue(3.0, 4.0, 5.0, 6.0, 1, 1);

            int width = matrix.Length;
            int height = matrix[0].Length;

            double widthStepSize = (double)width / (double)newWidth;
            double heightStepSize = (double)height / (double)newHeight;

            var newMatrix = CreateEmptyDoubleMatrix(newWidth, newHeight);

            for (int newX = 0; newX < newWidth; newX++)
            {
                var oldX = newX * widthStepSize;

                for (int newY = 0; newY < newHeight; newY++)
                {
                    var oldY = newY * heightStepSize;

                    MathHelper.GetIntegerAndFractionalPart(oldX, out int stepBaseX, out double percentX);
                    MathHelper.GetIntegerAndFractionalPart(oldY, out int stepBaseY, out double percentY);

                    var increasedStepBaseX = stepBaseX < width - 1 ? stepBaseX + 1 : 0;
                    var increasedStepBaseY = stepBaseY < height - 1 ? stepBaseY + 1 : 0;

                    var a1 = matrix[stepBaseX][stepBaseY];
                    var a2 = matrix[increasedStepBaseX][stepBaseY];
                    var b1 = matrix[stepBaseX][increasedStepBaseY];
                    var b2 = matrix[increasedStepBaseX][increasedStepBaseY];

                    var value = GetSquareTransitionValue(a1, a2, b1, b2, percentX, percentY);

                    newMatrix[newX][newY] = value;
                }
            }

            //for (double oldX = 0, newX = 0; oldX < width; oldX++, newX += widthStepSize)
            //{
            //    for (double oldY = 0, newY = 0; oldY < height; oldY++, newY += heightStepSize)
            //    {
            //        GetIntegerAndFractionalPart(newX, out int stepBaseX, out double percentX);
            //        GetIntegerAndFractionalPart(newY, out int stepBaseY, out double percentY);

            //        var a1 = matrix[stepBaseX][stepBaseY];
            //        var a2 = matrix[stepBaseX + 1][stepBaseY];
            //        var b1 = matrix[stepBaseX][stepBaseY + 1];
            //        var b2 = matrix[stepBaseX + 1][stepBaseY + 1];

            //        // var 
            //    }
            //}

            //for (double i = 0, j = 0; i <= width; i += widthStepSize, j++)
            //{
            //    GetIntegerAndFractionalPart(i, out int stepBase, out double percent);

            //    var a = matrix[stepBase][0];
            //    var b = matrix[stepBase + 1][0];

            //    var val = GetLinearTransitionValue(a, b, percent);

            //    newMatrix[(int)j][0] = (int)val;
            //}

            return newMatrix;
        }

        public static double GetLinearTransitionValue(double a, double b, double percent)
        {
            var difference = b - a;

            var step = difference * percent;

            var result = a + step;

            return result;
        }

        public static double GetSquareTransitionValue(double a1, double a2, double b1, double b2, double xPercent, double yPercent)
        {
            var r = Math.Sqrt(2);

            var a1Impact = r - Math.Sqrt(Math.Pow(xPercent, 2) + Math.Pow(yPercent, 2));
            var a2Impact = r - Math.Sqrt(Math.Pow(1 - xPercent, 2) + Math.Pow(yPercent, 2));
            var b1Impact = r - Math.Sqrt(Math.Pow(xPercent, 2) + Math.Pow(1 - yPercent, 2));
            var b2Impact = r - Math.Sqrt(Math.Pow(1 - xPercent, 2) + Math.Pow(1 - yPercent, 2));

            //var d = (a1 * (1 - a1Impact) + a2 * (1 - a2Impact) + b1 * (1 - b1Impact) + b2 * (1 - b2Impact)) 
            //    / ((1 - a1Impact) + (1 - a2Impact) + (1 - b1Impact) + (1 - b2Impact));

            //var gg = GetWeightedArithmeticMean(new[] { (3.0, 0.5), (4.0, 1.0), (5.0, 1.5) });

            //var sum = a1Impact + a2Impact + b1Impact + b2Impact;

            //var a1ImpactPercent = a1Impact / sum;
            //var a2ImpactPercent = a2Impact / sum;
            //var b1ImpactPercent = b1Impact / sum;
            //var b2ImpactPercent = b2Impact / sum;


            var d = new[] { (a1, a1Impact), (a2, a2Impact), (b1, b1Impact), (b2, b2Impact) };

            var result = GetWeightedArithmeticMean(d);


            //var impactSum = a1ImpactPercent + a2ImpactPercent + b1ImpactPercent + b2ImpactPercent;

            //var a1Percent = a1 - a1 * (a1ImpactPercent - 0.5);
            //var a2Percent = a2 - a2 * (a2ImpactPercent - 0.5);
            //var b1Percent = b1 - b1 * (b1ImpactPercent - 0.5);
            //var b2Percent = b2 - b2 * (b2ImpactPercent - 0.5);

            //var d222 = (a1Percent + a2Percent + b1Percent + b2Percent) / 4;

            //var a1NormalizedImpactPercent = a1ImpactPercent / impactSum;
            //var a2NormalizedImpactPercent = a2ImpactPercent / impactSum;
            //var b1NormalizedImpactPercent = b1ImpactPercent / impactSum;
            //var b2NormalizedImpactPercent = b2ImpactPercent / impactSum;

            //var d1 = a1ImpactPercent + a2ImpactPercent + b1ImpactPercent + b2ImpactPercent;
            //var d2 = a1NormalizedImpactPercent + a2NormalizedImpactPercent + b1NormalizedImpactPercent + b2NormalizedImpactPercent;

            //var result = a1 * a1NormalizedImpactPercent + a2 * a2NormalizedImpactPercent + b1 * b1NormalizedImpactPercent + b2 * b2NormalizedImpactPercent;

            return result;
        }

        public static double GetWeightedArithmeticMean(IEnumerable<(double value, double weight)> items)
        {
            var weightSum = items.Select(a => a.weight).Sum();

            var multiplyingValuesAndWeights = items.Select(a => a.value * a.weight).Sum();

            var result = multiplyingValuesAndWeights / weightSum;

            return result;
        }

        public static int[][] Convert(double[][] matrix) 
        {
            int width = matrix.Length;
            int height = matrix[0].Length;

            var result = CreateEmptyIntMatrix(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    result[i][j] = (int)matrix[i][j];
                }
            }

            return result;
        }

        public static double[][] CreateEmptyDoubleMatrix(int newWidth, int newHeight)
        {
            var result = new double[newWidth][];

            for (int x = 0; x < newWidth; x++)
            {
                result[x] = new double[newHeight];
            }

            return result;
        }

        public static int[][] CreateEmptyIntMatrix(int newWidth, int newHeight)
        {
            var result = new int[newWidth][];

            for (int x = 0; x < newWidth; x++)
            {
                result[x] = new int[newHeight];
            }

            return result;
        }

        //public static int[][] StretchOnMaximumAndMinimumValue(this int[][] matrix, int newMin, int newMax)
        //{
        //    var maxValue = matrix.Max(a => a.Max());
        //    var minValue = matrix.Min(a => a.Min());

        //    var result = new int[matrix.Length][];

        //    for (int x = 0; x < matrix.Length; x++)
        //    {
        //        result[x] = new int[matrix[x].Length];
        //    }

        //    for (int x = 0; x < matrix.Length; x++)
        //    {
        //        for (int y = 0; y < matrix[x].Length; y++)
        //        {
        //            double newValue = matrix[x][y];

        //            newValue -= minValue;

        //            double pos = newValue / (maxValue - minValue);

        //            newValue = pos * (newMax - newMin) + newMin;

        //            result[x][y] = (int)newValue;
        //        }
        //    }

        //    return result;
        //}
    }
}
