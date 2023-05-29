using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering
{
    public class AltitudeStepBuilderParams : IStepBuilderParams
    {
        public int Dimension { get; set; }
        public int SmoothingSize { get; set; }
    }
}
