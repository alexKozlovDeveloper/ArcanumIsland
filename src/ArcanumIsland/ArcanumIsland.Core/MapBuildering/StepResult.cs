using ArcanumIsland.Core.MapGeneration.Steps.Interfaces;
using MathBase.MultidimensionalArrays.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering
{
    public class StepResult : IStepBuilderResult
    {
        public Dictionary<string, Matrix<double>> Matrixes { get; private set; }

        public StepResult()
        {
            Matrixes = new Dictionary<string, Matrix<double>>();
        }
    }
}
