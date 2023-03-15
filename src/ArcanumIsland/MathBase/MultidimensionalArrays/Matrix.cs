using MathBase.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.MultidimensionalArrays
{
    public class Matrix<T>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private T[][] items;

        public Matrix(int width, int height)
        {
            Width = width;
            Height = height;

            items = MatrixHelper.CreateEmptyMatrix<T>(Width, Height);
        }

        public Matrix(T[][] src)
        {
            Width = src.GetWidth();
            Height = src.GetHeight();

            items = src.TransformToMatrix();
        }

        public T[][] GetAsArray()
        {
            return items.Copy();
        }

        public T this[int x, int y]
        {
            get
            {
                if (x >= 0 && x < Width)
                {
                    if (y >= 0 && y < Height)
                    {
                        return items[x][y];
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
                        items[x][y] = value;
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
