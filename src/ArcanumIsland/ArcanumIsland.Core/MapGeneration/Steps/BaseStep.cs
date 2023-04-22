using ArcanumIsland.Core.MapGeneration.Steps.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Steps
{
    public abstract class BaseStep : IStep
    {
        public virtual string Name { get { return this.GetType().Name; } }

        public virtual IStepParams StepParams => throw new NotImplementedException();

        public virtual IStepResult Process(Map map)
        {
            throw new NotImplementedException();
        }
    }
}
