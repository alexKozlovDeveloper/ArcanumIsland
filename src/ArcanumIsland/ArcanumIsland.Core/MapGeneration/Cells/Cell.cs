using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Cells
{
    public class Cell : ICell
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public IList<ICellLayer> CellLayers { get; private set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;

            CellLayers = new List<ICellLayer>();
        }

        public void AddLayer(ICellLayer layer)
        {
            CellLayers.Add(layer);
        }

        public T GetLayer<T>() 
        {
            return (T)CellLayers.FirstOrDefault(a => a.GetType() == typeof(T));
        }

        public bool IsContainLayer<T>()
        {
            if (GetLayer<T>() != null) 
            {
                return true; 
            }

            return false;
        }
    }
}
