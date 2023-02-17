using System.Reflection;
using ArcanumIsland.Core;
using ArcanumIsland.Core.Logging;
using ArcanumIsland.Core.MapGeneration;
using ArcanumIsland.Core.MapGeneration.Steps;

namespace ArcanumIsland.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();

            logger.Info("ArcanumIsland.ConsoleApp: Starting...");

            var mapCreator = new MapCreator();

            mapCreator.CreateMap();

            var stepResult = mapCreator.ProcessStep(new AltitudeStep());

            logger.Info("ArcanumIsland.ConsoleApp: Ending...");
        }
    }
}