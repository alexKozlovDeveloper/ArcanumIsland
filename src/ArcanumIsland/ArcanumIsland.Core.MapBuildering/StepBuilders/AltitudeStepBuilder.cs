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
    public class AltitudeStepBuilder : StepBuilderBase<AltitudeStepBuilderParam, StepBuilderResult>
    {
        public AltitudeStepBuilder(AltitudeStepBuilderParam stepParams) : base(stepParams)
        {

        }

        public override StepBuilderResult Aplly(IMap map)
        {
            var altitudeMatrix = GetAltitudeMatrix(map.Width, map.Height);

            map.CellsMatrix.ForEachItem((x, y, cell) =>
            {
                var altitude = new Altitude { Value = altitudeMatrix[x, y] };

                cell.AddLayer(altitude);

                return cell;
            });

            var stepResult = new StepBuilderResult();

            stepResult.Matrixes.Add("altitudeMatrix", altitudeMatrix);

            return stepResult;
        }

        private Matrix<double> GetAltitudeMatrix(int width, int height)
        {
            var noiseGenerator = new PerlinNoiseGenerator(_stepParams.Seed);

            var altitudeMatrixRawInt = noiseGenerator.GetPerlinNoiseMatrix(_stepParams.Dimension, _stepParams.SmoothingSize);
            var altitudeMatrixRaw = altitudeMatrixRawInt.ToDouble();
            var altitudeMatrix = altitudeMatrixRaw.ResizeMatrix(width, height);

            return altitudeMatrix;
        }
    }
}
