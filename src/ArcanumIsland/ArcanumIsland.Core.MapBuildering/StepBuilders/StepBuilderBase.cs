using ArcanumIsland.Core.Interfaces;
using ArcanumIsland.Core.MapBuildering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering.StepBuilders
{
    public abstract class StepBuilderBase<TParameters, TResult>
        where TParameters : IStepBuilderParam
        where TResult : IStepBuilderResult
    {
        protected readonly TParameters _stepParams;

        public StepBuilderBase(TParameters stepParams)
        {
            _stepParams = stepParams;
        }

        public abstract TResult Aplly(IMap map);
    }
}
