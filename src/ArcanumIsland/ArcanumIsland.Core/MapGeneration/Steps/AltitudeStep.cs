using PerlinNoise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Steps
{
    public class AltitudeStep : IStep
    {
        private PerlinNoiseGenerator _generator;

        public AltitudeStep()
        {
            _generator = new PerlinNoiseGenerator(99, 255);
        }

        public IStepResult Apply(Map map)
        {


            return new EmptyStepResult();
        }
    }
}
