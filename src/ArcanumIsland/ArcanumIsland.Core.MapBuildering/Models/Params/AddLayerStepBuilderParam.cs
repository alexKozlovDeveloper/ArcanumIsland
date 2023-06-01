using ArcanumIsland.Core.Interfaces;
using ArcanumIsland.Core.MapBuildering.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering.Models.Params
{
    public class AddLayerStepBuilderParam<L> : IStepBuilderParam
    {
        public IFactory<L> LayerFactory { get; set; }
        public Func<ICell, bool> AddCondition { get; set; }
    }
}
