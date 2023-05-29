using ArcanumIsland.Core.MapGeneration.Cells;
using MathBase.MultidimensionalArrays.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }

        Matrix<Cell> CellsMatrix { get; }
    }
}
