using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using ArcanumIsland.Core.MapGeneration.Steps.Interfaces;
using ArcanumIsland.Core.MapGeneration.Steps.Param;
using ArcanumIsland.Core.MapGeneration.Steps.Result;
using AreasCreating;
using PerlinNoise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathBase.MultidimensionalArrays.Matrixes;

namespace ArcanumIsland.Core.MapGeneration.Steps
{
    public  class TectonicPlateStep : IStep
    {
        private int _seed;

        private PerlinNoiseGenerator _noiseGenerator;
        private TectonicPlatesStepParams _stepParams;

        public IStepParams StepParams => _stepParams;
        public string Name { get { return GetType().Name; } }
        public TectonicPlateStep(int seed, TectonicPlatesStepParams stepParams)
        {
            _seed = seed;
            _noiseGenerator = new PerlinNoiseGenerator(seed);

            _stepParams = stepParams;
        }

        public IStepResult Process(Map map)
        {
            var stepResult = new StepResult();

            var areasCreator = new AreasCreator(_seed, _stepParams.Width, _stepParams.Height);

            areasCreator.CreateAreas(_stepParams.AreasCount);

            areasCreator.FillAreas();

            var matrix = areasCreator.GetMatrix();

            stepResult.AddMatrix("areas", ToDoubleMatrix(matrix));
            
            var movedMatrixRaw = areasCreator.MoveAreas(25);

           // stepResult.AddMatrix("areas", ToDoubleMatrix(movedMatrixRaw));

            var movedMatrix = movedMatrixRaw.Convert(a =>
            {
                if (string.IsNullOrEmpty(a)) { return 0; }

                var parts = a.Split('-');
                return parts.Length;
            });

            //movedMatrix.StretchOnMaximumAndMinimumValue(0, 250);

            stepResult.AddMatrix("moved areas", movedMatrix.ToDouble());

            //movedMatrix.Smoothing(_stepParams.SmoothingSize);

            var movedMatrixresized = movedMatrix.ResizeMatrix(map.Width, map.Height);

            map.CellsMatrix.ForEachItem((x, y, cell) =>
            {
                //var altitude = cell.GetCellContent<BaseAltitude>();

                //if (altitude == null) { return cell; }

                //altitude.Weight += movedMatrixresized[x, y];

                var tectonicPlate = new TectonicPlate { PlateCount = movedMatrixresized[x, y] };

                cell.AddContent(tectonicPlate);

                return cell;
            });


            return stepResult;
        }

        public Matrix<double> ToDoubleMatrix(Matrix<string> matrix) 
        {
            var idsMatrix = matrix.Convert(a => int.Parse(a.Replace("area_", "")));

            idsMatrix.StretchOnMaximumAndMinimumValue(0, 250);

            return idsMatrix.ToDouble();
        }
    }
}
