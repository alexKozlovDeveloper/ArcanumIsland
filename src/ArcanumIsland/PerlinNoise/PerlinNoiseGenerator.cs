using MathBase;
using MathBase.MultidimensionalArrays.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinNoise
{
    public class PerlinNoiseGenerator
    {
        private readonly Random _random;

        private readonly int _maxValue;

        public PerlinNoiseGenerator(int seed = -1, int maxValue = 255)
        {
            _random = new Random(seed);

            _maxValue = maxValue;
        }

        /// <summary>
        /// Return a perlin noise int matrix with setted dimension (dimension must be a multiple of two)
        /// </summary>
        /// <param name="dimension">Dimension, must be a multiple of two</param>
        /// <returns></returns>
        public Matrix<int> GetPerlinNoiseMatrix(int dimension, int smoothingSize)
        {
            if (MathHelper.IsMultipleOfTwo(dimension) == false)
            {
                throw new NotSupportedException("Dimension must be a multiple of two [2, 4, 8, 16, 32, 64 ...].");
            }

            var matrixes = new List<Matrix<int>>();

            for (int i = 2; i < dimension; i *= 2)
            {
                var m = GetRandomMatrix(i, i);

                m = m.IncreaseOctave(dimension / i);

                matrixes.Add(m);
            }

            var sum = matrixes.Average();

            //sum = sum.StretchOnMaximumAndMinimumValue(0, _maxValue)
            //    .Smoothing(smoothingSize);

            sum.StretchOnMaximumAndMinimumValue(0, _maxValue);
            sum.Smoothing(smoothingSize);

            return sum;
        }

        //private int[][] GetPerlinNoiseMatrix_experimental(int width, int height)
        //{
        //    var matrixes = new List<int[][]>();

        //    var origin = GetRandomMatrix(width, height);

        //    matrixes.Add(origin);

        //    for (int i = width / 2; i >= 2; i /= 2)
        //    {
        //        var m = origin.DecreaseOctave(i);
        //        var m2 = m.IncreaseOctave(i);

        //        matrixes.Add(m2);
        //    }

        //    var sum = matrixes.Average();

        //    return sum.Smoothing();
        //}

        /// <summary>
        /// Get matrix with random values
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <returns></returns>
        public Matrix<int> GetRandomMatrix(int width, int height)
        {
            var result = new Matrix<int>(width, height);

            result.ForEachItem(() => _random.Next(0, _maxValue));

            return result;
        }
    }
}
