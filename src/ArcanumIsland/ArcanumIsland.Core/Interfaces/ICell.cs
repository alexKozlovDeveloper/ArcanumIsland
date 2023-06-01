using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.Interfaces
{
    public interface ICell
    {
        int X { get; }
        int Y { get; }

        IList<ILayer> CellLayers { get; }
        void AddLayer(ILayer layer);
        public T GetLayer<T>();
        public bool IsContainLayer<T>();
    }
}
