using ArcanumIsland.Core.Interfaces;
using ArcanumIsland.Core.MapBuildering.Models.Params;
using ArcanumIsland.Core.MapBuildering.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering.StepBuilders
{
    public class AddLayerStepBuilder<L> : StepBuilderBase<AddLayerStepBuilderParam<L>, EmptyStepBuilderResult>
            where L : ILayer
    {
        public AddLayerStepBuilder(AddLayerStepBuilderParam<L> stepParams) : base(stepParams)
        {

        }

        public override EmptyStepBuilderResult Aplly(IMap map)
        {
            map.CellsMatrix.ForEachItem((x, y, cell) =>
            {
                if (_stepParams.AddCondition(cell) == true)
                {
                    var layer = _stepParams.LayerFactory.Create();

                    cell.AddLayer(layer);
                }

                return cell;
            });

            return new EmptyStepBuilderResult();
        }
    }
}
