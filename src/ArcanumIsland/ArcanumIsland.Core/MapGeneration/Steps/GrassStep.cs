﻿using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
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
    public class GrassStep : IStep
    {
        private PerlinNoiseGenerator _noiseGenerator;
        private GrassStepParams _stepParams;

        public GrassStep(int seed, GrassStepParams stepParams)
        {
            _noiseGenerator = new PerlinNoiseGenerator(seed);

            _stepParams = stepParams;
        }

        public IStepResult Process(Map map)
        {
            var stepResult = new StepResult();

            map.CellsMatrix.ForEachItem((x, y, cell) =>
            {
                var altitude = cell.GetCellContent<Altitude>();
                var ocean = cell.GetCellContent<Ocean>();

                if (altitude == null) { return cell; }
                if (ocean != null) { return cell; }

                if (altitude.Weight >= _stepParams.BottomEdge && altitude.Weight < _stepParams.TopEdge)
                {
                    var grass = new Grass();
                    cell.AddContent(grass);
                }

                return cell;
            });

            return stepResult;
        }
    }
}
