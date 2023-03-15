using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using ArcanumIsland.Core;
using ArcanumIsland.Core.Logging;
using ArcanumIsland.Core.MapGeneration;
using ArcanumIsland.Core.MapGeneration.Steps;
using MathBase.Points;
using PerlinNoise;

namespace ArcanumIsland.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();

            logger.Info("ArcanumIsland.ConsoleApp: Starting...");

            //var d1 = Vector2Extensions.BringValueToRange(10, 10);
            //var d2 = Vector2Extensions.BringValueToRange(-1, 10);
            //var d3 = Vector2Extensions.BringValueToRange(0, 10);
            //var d4 = Vector2Extensions.BringValueToRange(9, 10);
            //var d5 = Vector2Extensions.BringValueToRange(5, 10);


            var perlin = new PerlinNoiseGenerator();

            var matrix1 = perlin.GetPerlinNoiseMatrix(256, 2);

            var matrix2 = matrix1.ResizeMatrix(500, 800);

            var img1 = GetImage(matrix1);
            var img2 = GetImage(PerlinNoiseHelper.Convert(matrix2));

            img1.Save("src.png");
            img2.Save("scaled.png");

            //var mapCreator = new MapCreator();

            //mapCreator.CreateMap();

            //var stepResult = mapCreator.ProcessStep(new AltitudeStep());

            logger.Info("ArcanumIsland.ConsoleApp: Ending...");
        }

        private static Bitmap GetImage(int[][] matrix)
        {
            int width = matrix.Length;
            int height = matrix[0].Length;

            var multiplayer = 1;

            var image = new Bitmap(width * multiplayer, height * multiplayer);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color;
                    var point = matrix[x][y];

                    color = Color.FromArgb(point, point, point);

                    for (int i = 0; i < multiplayer; i++)
                    {
                        for (int j = 0; j < multiplayer; j++)
                        {
                            image.SetPixel(x * multiplayer + i, y * multiplayer + j, color);
                        }
                    }
                }
            }

            return image;
        }
    }
}