using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using ArcanumIsland.Core.MapGeneration.Steps.Interfaces;
using ArcanumIsland.Core.MapGeneration.Steps.Param;
using ArcanumIsland.Core.MapGeneration.Steps.Result;
using MathBase.MultidimensionalArrays.Matrixes;
using PerlinNoise;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Steps
{
    //public class ResultAltitudeStep : IStep
    //{
    //    private PerlinNoiseGenerator _noiseGenerator;
    //    private ResultAltitudeStepParams _stepParams;

    //    public IStepParams StepParams => _stepParams;
    //    public string Name { get { return GetType().Name; } }
    //    public ResultAltitudeStep(int seed, ResultAltitudeStepParams stepParams)
    //    {
    //        _noiseGenerator = new PerlinNoiseGenerator(seed);

    //        _stepParams = stepParams;
    //    }

    //    public IStepResult Process(Map map)
    //    {
    //        var stepResult = new StepResult();

    //        var baseAltitudeMatrix = map.CellsMatrix.Convert(cell =>
    //        {
    //            var baseAltitude = cell.GetCellContent<BaseAltitude>();

    //            if (baseAltitude == null) { return 0; }

    //            return baseAltitude.Weight;
    //        });

    //        var tectonicPlateMatrix = map.CellsMatrix.Convert(cell =>
    //        {
    //            var baseAltitude = cell.GetCellContent<TectonicPlate>();

    //            if (baseAltitude == null) { return 0; }

    //            return baseAltitude.PlateCount;
    //        });

    //        tectonicPlateMatrix.StretchOnMaximumAndMinimumValue(0, 250);
    //        tectonicPlateMatrix.Smoothing(3);

    //        var resultAltitudeMatrix = new Matrix<double>(map.CellsMatrix.Size);

    //        resultAltitudeMatrix.ForEachItem((x, y) =>
    //        {
    //            return baseAltitudeMatrix[x, y] + tectonicPlateMatrix[x, y];
    //        });

    //        resultAltitudeMatrix.StretchOnMaximumAndMinimumValue(0, 250);

    //        //var altitudeMatrixRaw = _noiseGenerator.GetPerlinNoiseMatrix(_stepParams.Dimension, _stepParams.SmoothingSize);

    //        //var altitudeMatrix = altitudeMatrixRaw.ResizeMatrix(map.Width, map.Height);

    //        map.CellsMatrix.ForEachItem((x, y, cell) =>
    //        {
    //            var resultAltitude = new ResultAltitude() { Weight = resultAltitudeMatrix[x, y] };

    //            cell.AddContent(resultAltitude);

    //            return cell;
    //        });

    //        //stepResult.AddMatrix("altitudeMatrix", altitudeMatrix);

    //        return stepResult;
    //    }
    //}
}
