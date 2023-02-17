using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Steps
{
    public class AltitudeStep : IStep
    {

        public AltitudeStep()
        {

        }

        public IStepResult Apply(Map map)
        {
            return new EmptyStepResult();
        }
    }
}
