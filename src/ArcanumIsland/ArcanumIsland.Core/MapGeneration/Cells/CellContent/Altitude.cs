using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Cells.CellContent
{
    public class Altitude : ICellLayer
    {
        public double Value { get; set; }

        public Altitude() { }

        public Altitude(double value)
        {
            Value = value;
        }        
    }
}
