using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcanumIsland.Core.Interfaces;
using ArcanumIsland.Core.MapBuildering.Models.Params;
using ArcanumIsland.Core.MapBuildering.StepBuilders;

namespace ArcanumIsland.Core.MapBuildering.Factoryes
{
    public class StepBuilderFactory
    {
        public StepBuilderFactory()
        {

        }

        public AltitudeStepBuilder CreateAltitudeStepBuilder(AltitudeStepBuilderParam param)
        {
            return new AltitudeStepBuilder(param);
        }

        public AltitudeRadialDecreaseStepBuilder CreateAltitudeRadialDecreaseStepBuilder(AltitudeRadialDecreaseStepBuilderParam param)
        {
            return new AltitudeRadialDecreaseStepBuilder(param);
        }

        public AddLayerStepBuilder<L> CreateAddLayerStepBuilder<L>(AddLayerStepBuilderParam<L> param) where L : ILayer
        {
            return new AddLayerStepBuilder<L>(param);
        }
    }
}
