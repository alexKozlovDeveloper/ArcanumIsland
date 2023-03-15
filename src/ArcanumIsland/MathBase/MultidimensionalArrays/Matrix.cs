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

        #region Get Immediate Points
        public IEnumerable<Vector2> GetImmediatePoints(Vector2 point)
        {
            var immediatePoints = new List<Vector2> 
            {
                point.NewRelativePoint(1, 0), // right
                point.NewRelativePoint(0, 1), // bottom
                point.NewRelativePoint(-1, 0), // left
                point.NewRelativePoint(0, -1), // top
            };

            var result = immediatePoints.Where(a => IsOutOfMatrix(a) == false);

            return result;
        }

        public IEnumerable<Vector2> GetFullImmediatePoints(Vector2 point)
        {
            var immediatePoints = new List<Vector2>
            {
                point.NewRelativePoint(1, 0), // right
                point.NewRelativePoint(0, 1), // bottom
                point.NewRelativePoint(-1, 0), // left
                point.NewRelativePoint(0, -1), // top

                point.NewRelativePoint(1, 1), // right-bottom
                point.NewRelativePoint(-1, -1), // left-top
                point.NewRelativePoint(1, -1), // right-top
                point.NewRelativePoint(-1, 1), // left-bottom
            };

            var result = immediatePoints.Where(a => IsOutOfMatrix(a) == false);

            return result;
        }

        public IEnumerable<Vector2> GetImmediatePointsMirror(Vector2 point)
        {
            var immediatePoints = new List<Vector2>
            {
                point.NewRelativePointMirror(1, 0, Width, Height), // right
                point.NewRelativePointMirror(0, 1, Width, Height), // bottom
                point.NewRelativePointMirror(-1, 0, Width, Height), // left
                point.NewRelativePointMirror(0, -1, Width, Height), // top
            };

            var result = immediatePoints.Where(a => IsOutOfMatrix(a) == false);

            return result;
        }

        public IEnumerable<Vector2> GetFullImmediatePointsMirror(Vector2 point)
        {
            var immediatePoints = new List<Vector2>
            {
                point.NewRelativePointMirror(1, 0, Width, Height), // right
                point.NewRelativePointMirror(0, 1, Width, Height), // bottom
                point.NewRelativePointMirror(-1, 0, Width, Height), // left
                point.NewRelativePointMirror(0, -1, Width, Height), // top

                point.NewRelativePointMirror(1, 1, Width, Height), // right-bottom
                point.NewRelativePointMirror(-1, -1, Width, Height), // left-top
                point.NewRelativePointMirror(1, -1, Width, Height), // right-top
                point.NewRelativePointMirror(-1, 1, Width, Height), // left-bottom
            };

            var result = immediatePoints.Where(a => IsOutOfMatrix(a) == false);

            return result;
        }
        #endregion

        public bool IsOutOfMatrix(Vector2 point) 
        {
            if (point.X >= 0 && point.X < Width) 
            {
                if (point.Y >= 0 && point.Y < Height)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
