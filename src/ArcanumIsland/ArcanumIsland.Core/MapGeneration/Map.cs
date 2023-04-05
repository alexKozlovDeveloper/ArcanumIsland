using ArcanumIsland.Core.MapGeneration.Cells;
using MathBase.MultidimensionalArrays.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration
{
    public class Map
    {
        public int Width { get { return CellsMatrix.Width; } }
        public int Height { get { return CellsMatrix.Height; } }

        public Matrix<Cell> CellsMatrix { get; private set; }

        public Map(int height, int width)
        {
            CellsMatrix = new Matrix<Cell>(width, height);

            CellsMatrix.ForEachItem((x, y) => new Cell(x, y));
        }

        //public Matrix<T> GetMatrixAs<T>() 
        //{
        //    return CellsMatrix.Convert(cell => 
        //    {
        //        return cell.GetCellContent<T>();
        //    });
        //}
    }
}
