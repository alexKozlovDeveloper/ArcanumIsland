using ArcanumIsland.Core.MapBuildering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering.Models.Params
{
    public class AltitudeStepBuilderParam : IStepBuilderParam
    {
        public int Seed { get; set; }
        public int Dimension { get; set; }
        public int SmoothingSize { get; set; }
    }
}
