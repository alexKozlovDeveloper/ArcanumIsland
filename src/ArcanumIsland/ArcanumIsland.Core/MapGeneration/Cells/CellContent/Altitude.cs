using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Cells.CellContent
{
    internal class Altitude : ICellContent
    {
        public int Weight { get; private set; }

        public Altitude(int weight)
        {
            Weight = weight;
        }
    }
}
