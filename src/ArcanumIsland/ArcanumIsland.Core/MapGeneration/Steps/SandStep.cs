using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using ArcanumIsland.Core.MapGeneration.Steps.Interfaces;
using ArcanumIsland.Core.MapGeneration.Steps.Param;
using ArcanumIsland.Core.MapGeneration.Steps.Result;
using PerlinNoise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Steps
{
    public class SandStep : IStep
    {
        private PerlinNoiseGenerator _noiseGenerator;
        private SandStepParams _stepParams;

        public SandStep(int seed, SandStepParams stepParams)
        {
            _noiseGenerator = new PerlinNoiseGenerator(seed);

            _stepParams = stepParams;
        }

        public IStepResult Process(Map map)
        {
            var stepResult = new StepResult();

            map.CellsMatrix.ForEachItem((x, y, cell) =>
            {
                var altitude = cell.GetCellContent<BaseAltitude>();
                var ocean = cell.GetCellContent<Ocean>();

                if (altitude == null) { return cell; }
                if (ocean != null) { return cell; }

                if (altitude.Weight >= _stepParams.BottomEdge && altitude.Weight < _stepParams.TopEdge)
                {
                    var sand = new Sand();
                    cell.AddContent(sand);
                }

                return cell;
            });

            return stepResult;
        }
    }
}
