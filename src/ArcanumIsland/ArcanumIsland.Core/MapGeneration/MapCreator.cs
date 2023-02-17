using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcanumIsland.Core.MapGeneration.Steps;

namespace ArcanumIsland.Core.MapGeneration
{
    public class MapCreator
    {
        private Map _currentMap;

        public void CreateMap()
        {
            _currentMap = new Map(64, 64);
        }

        public IStepResult ProcessStep(IStep step)
        {
            if (_currentMap == null) { return null; }

            return new EmptyStepResult();
        }

        public IEnumerable<IStepResult> ProcessStep(IEnumerable<IStep> steps)
        {
            if (_currentMap == null) { return null; }

            return new List<IStepResult>();
        }
    }
}
