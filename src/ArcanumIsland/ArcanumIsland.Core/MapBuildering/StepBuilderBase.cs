using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering
{
    public abstract class StepBuilderBase<TParameters, TResult>
        where TParameters : IStepBuilderParams
        where TResult : IStepBuilderResult
    {
        protected readonly TParameters _stepParams;
        protected readonly int _seed;

        public StepBuilderBase(int seed, TParameters stepParams)
        {
            _seed = seed;
            _stepParams = stepParams;
        }

        public abstract TResult Aplly(IMap map);
    }
}
