﻿using ArcanumIsland.Core.MapBuildering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Steps.Interfaces
{
    public interface IStep
    {
        IStepParams StepParams { get; }
        string Name { get; }
        IStepResult Process(Map map);
    }
}
