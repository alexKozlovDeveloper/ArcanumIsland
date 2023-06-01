using ArcanumIsland.Core.MapBuildering.Interfaces;
using MathBase.MultidimensionalArrays.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering.Models.Results
{
    public class StepBuilderResult : IStepBuilderResult
    {
        public Dictionary<string, Matrix<double>> Matrixes { get; private set; }

        public StepBuilderResult()
        {
            Matrixes = new Dictionary<string, Matrix<double>>();
        }
    }
}
