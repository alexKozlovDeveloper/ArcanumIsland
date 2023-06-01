using ArcanumIsland.Core.Interfaces;
using ArcanumIsland.Core.MapBuildering.Models.Params;
using ArcanumIsland.Core.MapBuildering.Models.Results;
using ArcanumIsland.Core.Models.Layers;
using MathBase.MultidimensionalArrays.Matrixes;
using PerlinNoise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering.StepBuilders
{
    public class AltitudeRadialDecreaseStepBuilder : StepBuilderBase<AltitudeRadialDecreaseStepBuilderParam, EmptyStepBuilderResult>
    {
        public AltitudeRadialDecreaseStepBuilder(AltitudeRadialDecreaseStepBuilderParam stepParams) : base(stepParams)
        {

        }

        public override EmptyStepBuilderResult Aplly(IMap map)
        {
            var altitudeMatrix = map.GetLayerMatrix<Altitude>();

            var altitudeValueMatrix = altitudeMatrix.Convert(a => a.Value);

            altitudeValueMatrix.RadialDecrease(_stepParams.Speed);

            map.CellsMatrix.ForEachItem((x, y, cell) =>
            {
                var altitude = cell.GetLayer<Altitude>();

                if (altitude == null) { return cell; }

                altitude.Value = altitudeValueMatrix[x, y];

                return cell;
            });

            return new EmptyStepBuilderResult();
        }
    }
}
