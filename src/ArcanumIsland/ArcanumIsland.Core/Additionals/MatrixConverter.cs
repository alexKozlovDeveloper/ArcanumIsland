using MathBase.MultidimensionalArrays.Matrixes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.Additionals
{
    public static class MatrixConverter
    {
        public static Bitmap ToBitmap(this Matrix<int> matrix, int multiplier = 1)
        {
            var image = new Bitmap(matrix.Width * multiplier, matrix.Height * multiplier);

            for (int x = 0; x < matrix.Width; x++)
            {
                for (int y = 0; y < matrix.Height; y++)
                {
                    var point = matrix[x, y];

                    var color = Color.FromArgb(point, point, point);

                    for (int i = 0; i < multiplier; i++)
                    {
                        for (int j = 0; j < multiplier; j++)
                        {
                            image.SetPixel(x * multiplier + i, y * multiplier + j, color);
                        }
                    }
                }
            }

            return image;
        }
    }
}
