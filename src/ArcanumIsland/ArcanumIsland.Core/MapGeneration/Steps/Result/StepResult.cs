﻿using ArcanumIsland.Core.MapGeneration.Steps.Interfaces;
using MathBase.MultidimensionalArrays.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Steps.Result
{
    public class StepResult : IStepResult
    {
        public Dictionary<string, Matrix<double>> Matrixes;

        public StepResult()
        {
            Matrixes = new Dictionary<string, Matrix<double>>();
        }

        public void AddMatrix(string name, Matrix<double> matrix)
        {
            Matrixes.Add(name, matrix);
        }
    }
}
