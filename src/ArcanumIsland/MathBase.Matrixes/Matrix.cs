using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathBase.MultidimensionalArrays;
using MathBase.MultidimensionalArrays.Factories;
using MathBase.Points;

namespace MathBase.Matrixes
{
    public class Matrix<T>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private T[][] _d2Array;

        public Matrix(int width, int height)
        {
            Width = width;
            Height = height;

            _d2Array = D2ArrayFactory.CreateEmptyMatrix<T>(Width, Height);
        }

        public Matrix(T[][] src)
        {
            Width = src.GetWidth();
            Height = src.GetHeight();

            _d2Array = src.TransformTo2dArray();
        }

        public T[][] GetAsArray()
        {
            return _d2Array.Copy();
        }

        public T this[int x, int y]
        {
            get
            {
                if (x >= 0 && x < Width)
                {
                    if (y >= 0 && y < Height)
                    {
                        return _d2Array[x][y];
                    }
                }

                throw new ArgumentOutOfRangeException($"Indexes x:{x} y:{y} is out of range.");
            }
            set
            {
                if (x >= 0 && x < Width)
                {
                    if (y >= 0 && y < Height)
                    {
                        _d2Array[x][y] = value;
                    }
                }
            }
        }

        public T this[Vector2 point]
        {
            get
            {
                return this[point.X, point.Y];
            }
            set
            {
                this[point.X, point.Y] = value;
            }
        }
    }
}
