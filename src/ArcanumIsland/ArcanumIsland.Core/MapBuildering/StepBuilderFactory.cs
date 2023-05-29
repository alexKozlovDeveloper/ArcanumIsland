using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering
{
    public class StepBuilderFactory
    {
        private readonly int _seed;

        public StepBuilderFactory(int seed) 
        {
            _seed = seed;
        }

        public AltitudeStepBuilder CreateAltitudeStepBuilder(int dimension, int smoothingSize) 
        {
            return new AltitudeStepBuilder(_seed, new AltitudeStepBuilderParams
            {
                Dimension = dimension,
                SmoothingSize = smoothingSize
            });
        }
    }
}
