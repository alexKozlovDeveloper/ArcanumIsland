using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Cells.CellContent
{
    public class Altitude : ICellContent
    {
        public double Weight { get; private set; }

        public Altitude(double weight)
        {
            Weight = weight;
        }
    }
}
