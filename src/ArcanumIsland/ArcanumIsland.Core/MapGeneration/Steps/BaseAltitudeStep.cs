using ArcanumIsland.Core.MapBuildering;
using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using ArcanumIsland.Core.MapGeneration.Steps.Interfaces;
using ArcanumIsland.Core.MapGeneration.Steps.Param;
using ArcanumIsland.Core.MapGeneration.Steps.Result;
using MathBase.MultidimensionalArrays.Matrixes;
using PerlinNoise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Steps
{
    //public class BaseAltitudeStep : IStep
    //{
    //    private PerlinNoiseGenerator _noiseGenerator;
    //    private BaseAltitudeStepParams _stepParams;

    //    public IStepParams StepParams => _stepParams;
    //    public string Name { get { return GetType().Name; } }

    //    public BaseAltitudeStep(int seed, BaseAltitudeStepParams stepParams)
    //    {
    //        _noiseGenerator = new PerlinNoiseGenerator(seed);

    //        _stepParams = stepParams;
    //    }

    //    public IStepResult Process(Map map)
    //    {
    //        var stepResult = new StepResult();

    //        //var altitudeMatrixRaw = _noiseGenerator.GetPerlinNoiseMatrix(_stepParams.Dimension, _stepParams.SmoothingSize);

    //        //var altitudeMatrix = altitudeMatrixRaw.ResizeMatrix(map.Width, map.Height);

    //        //map.CellsMatrix.ForEachItem((x, y, cell) =>
    //        //{
    //        //    var altitude = new BaseAltitude(altitudeMatrix[x, y]);

    //        //    cell.AddContent(altitude);

    //        //    return cell;
    //        //});

    //        //stepResult.AddMatrix("altitudeMatrix", altitudeMatrix);

    //        return stepResult;
    //    }
    //}
}
