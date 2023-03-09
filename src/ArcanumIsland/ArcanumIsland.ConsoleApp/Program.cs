using System.Reflection;
using ArcanumIsland.Core;
using ArcanumIsland.Core.Logging;
using ArcanumIsland.Core.MapGeneration;
using ArcanumIsland.Core.MapGeneration.Steps;
using PerlinNoise;

namespace ArcanumIsland.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();

            logger.Info("ArcanumIsland.ConsoleApp: Starting...");

            var perlin = new PerlinNoiseGenerator();

            var matrix1 = perlin.GetPerlinNoiseMatrix(16, 3);

            var matrix2 = matrix1.ResizeMatrix(20, 20);

            //var mapCreator = new MapCreator();

            //mapCreator.CreateMap();

            //var stepResult = mapCreator.ProcessStep(new AltitudeStep());

            logger.Info("ArcanumIsland.ConsoleApp: Ending...");
        }
    }
}