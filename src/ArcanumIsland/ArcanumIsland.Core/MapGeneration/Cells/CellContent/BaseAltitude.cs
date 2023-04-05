using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Cells.CellContent
{
    public class BaseAltitude : ICellContent
    {
        public double Weight { get; set; }

        public BaseAltitude(double weight)
        {
            Weight = weight;
        }
    }
}
