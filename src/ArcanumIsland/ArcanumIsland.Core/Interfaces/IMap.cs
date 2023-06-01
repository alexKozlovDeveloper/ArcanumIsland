using ArcanumIsland.Core.Models;
using MathBase.MultidimensionalArrays.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.Interfaces
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }

        Matrix<Cell> CellsMatrix { get; }

        Matrix<L> GetLayerMatrix<L>() where L : ILayer;
    }
}
