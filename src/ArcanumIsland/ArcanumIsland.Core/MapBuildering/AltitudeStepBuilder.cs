using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using ArcanumIsland.Core.MapGeneration.Steps.Interfaces;
using ArcanumIsland.Core.MapGeneration.Steps.Result;
using PerlinNoise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathBase.MultidimensionalArrays.Matrixes;

namespace ArcanumIsland.Core.MapBuildering
{
    public class AltitudeStepBuilder : StepBuilderBase<AltitudeStepBuilderParams, StepResult>
    {
        public AltitudeStepBuilder(int seed, AltitudeStepBuilderParams stepParams) : base(seed, stepParams) 
        {

        }

        public override StepResult Aplly(IMap map)
        {
            var altitudeMatrix = GetAltitudeMatrix(map.Width, map.Height);

            map.CellsMatrix.ForEachItem((x, y, cell) =>
            {
                var altitude = new Altitude(altitudeMatrix[x, y]);

                cell.AddLayer(altitude);

                return cell;
            });

            var stepResult = new StepResult();

            stepResult.Matrixes.Add("altitudeMatrix", altitudeMatrix);

            return stepResult;
        }

        private Matrix<double> GetAltitudeMatrix(int width, int height) 
        {
            var noiseGenerator = new PerlinNoiseGenerator(_seed);

            var altitudeMatrixRawInt = noiseGenerator.GetPerlinNoiseMatrix(_stepParams.Dimension, _stepParams.SmoothingSize);
            var altitudeMatrixRaw = altitudeMatrixRawInt.ToDouble();
            var altitudeMatrix = altitudeMatrixRaw.ResizeMatrix(width, height);

            return altitudeMatrix;
        }
    }
}
