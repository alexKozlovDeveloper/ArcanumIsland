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
    public class OceanStep : IStep
    {
        private PerlinNoiseGenerator _noiseGenerator;
        private OceanStepParams _stepParams;

        public IStepParams StepParams => _stepParams;
        public string Name { get { return GetType().Name; } }
        public OceanStep(int seed, OceanStepParams stepParams)
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

                if (altitude == null) { return cell; }

                if (altitude.Weight < _stepParams.SeaLevel) 
                {
                    var ocean = new Ocean();
                    cell.AddContent(ocean);
                }

                return cell;
            });

            return stepResult;
        }
    }
}
