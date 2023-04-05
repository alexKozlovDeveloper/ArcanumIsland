using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcanumIsland.Core.MapGeneration.Steps;
using ArcanumIsland.Core.MapGeneration.Steps.Interfaces;
using ArcanumIsland.Core.MapGeneration.Steps.Param;

namespace ArcanumIsland.Core.MapGeneration
{
    public class MapCreator
    {
        private Map _currentMap;
        private int _seed;

        public MapCreator(int width, int height, int seed) 
        {
            _currentMap = new Map(width, height);
            _seed = seed;
        }

        public IStepResult AddBaseAltitude(BaseAltitudeStepParams baseAltitudeParams) 
        {
            var baseAltitudeStep = new BaseBaseAltitudeStep(_seed, baseAltitudeParams);

            return baseAltitudeStep.Process(_currentMap);
        }

        public IStepResult AddTectonicPlates(TectonicPlatesStepParams tectonicPlatesParams)
        {
            var TectonicPlatesStep = new TectonicPlateStep(_seed, tectonicPlatesParams);

            return TectonicPlatesStep.Process(_currentMap);
        }

        public IStepResult AddResultAltitude(ResultAltitudeStepParams resultAltitudeParams)
        {
            var resultAltitudeStep = new ResultAltitudeStep(_seed, resultAltitudeParams);

            return resultAltitudeStep.Process(_currentMap);
        }

        public IStepResult AddOcean(OceanStepParams oceanParams)
        {
            var oceanStep = new OceanStep(_seed, oceanParams);

            return oceanStep.Process(_currentMap);
        }

        public IStepResult AddSand(SandStepParams sandParams)
        {
            var sendStep = new SandStep(_seed, sandParams);

            return sendStep.Process(_currentMap);
        }

        public IStepResult AddGrass(GrassStepParams grassParams)
        {
            var grassStep = new GrassStep(_seed, grassParams);

            return grassStep.Process(_currentMap);
        }

        public IStepResult AddSnow(SnowStepParams snowParams)
        {
            var snowStep = new SnowStep(_seed, snowParams);

            return snowStep.Process(_currentMap);
        }

        public Map GetMap() 
        {
            return _currentMap;
        }

        //public IStepResult ProcessStep(IStep step, IStepParams stepParams)
        //{
        //    return step.Process(_currentMap, stepParams);
        //}

        //public IEnumerable<IStepResult> ProcessStep(IEnumerable<IStep> steps)
        //{
        //    return new List<IStepResult>();
        //}
    }
}
