using ArcanumIsland.Core.Interfaces;
using ArcanumIsland.Core.MapBuildering.Interfaces;
using ArcanumIsland.Core.MapBuildering.StepBuilders;
using ArcanumIsland.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering
{
    public class MapBuilderingDirector
    {
        private IMap _currentMap;

        public MapBuilderingDirector(int width, int height)
        {
            _currentMap = new Map(width, height);
        }

        public TResult ApplyStepBuilder<TParameters, TResult>(StepBuilderBase<TParameters, TResult> stepBuilder)
            where TParameters : IStepBuilderParam
            where TResult : IStepBuilderResult
        {
            return stepBuilder.Aplly(_currentMap);
        }

        public IMap GetMap()
        {
            return _currentMap;
        }
    }
}
