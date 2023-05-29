using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Cells
{
    public interface ICell
    {
        int X { get; }
        int Y { get; }

        IList<ICellLayer> CellLayers { get; }
        void AddLayer(ICellLayer layer);
        public T GetLayer<T>();
        public bool IsContainLayer<T>();
    }
}
