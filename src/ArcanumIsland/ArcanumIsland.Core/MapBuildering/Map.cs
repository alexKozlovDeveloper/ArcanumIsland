using ArcanumIsland.Core.MapGeneration.Cells;
using MathBase.MultidimensionalArrays.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering
{
    public class Map : IMap
    {
        public int Width => CellsMatrix.Width;
        public int Height => CellsMatrix.Height;

        public Matrix<Cell> CellsMatrix { get; private set; }

        public Map(int height, int width)
        {
            CellsMatrix = new Matrix<Cell>(width, height);

            CellsMatrix.ForEachItem((x, y) => new Cell(x, y));
        }
    }
}
