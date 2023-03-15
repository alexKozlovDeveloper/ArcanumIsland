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
    }
}
