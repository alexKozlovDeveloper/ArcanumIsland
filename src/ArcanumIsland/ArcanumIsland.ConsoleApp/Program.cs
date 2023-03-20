using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using ArcanumIsland.Core;
using ArcanumIsland.Core.Logging;
using ArcanumIsland.Core.MapGeneration;
using ArcanumIsland.Core.MapGeneration.Steps;
using AreasCreating;
using MathBase.Points;
using PerlinNoise;
using MathBase.MultidimensionalArrays.Matrixes;
using ArcanumIsland.Core.Additionals;

namespace ArcanumIsland.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();

            logger.Info("ArcanumIsland.ConsoleApp: Starting...");

            var random = new Random(2001);


            var perlin = new PerlinNoiseGenerator();

            var matrix1 = perlin.GetPerlinNoiseMatrix(512, 2);
            var matrix2 = matrix1.Copy();
            matrix2.RadialDecrease(0.8);

            var img1 = matrix1.ToBitmap();
            var img2 = matrix2.ToBitmap();

            img1.Save($"perlinOrig_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");
            img2.Save($"radiant_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");

            var ff1 = perlin.GetPerlinNoiseMatrix(32, 2);
            var ff1img1 = ff1.ToBitmap();
            ff1img1.Save($"perlin32_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");

            var ff2 = ff1.ResizeMatrix(500, 500);
            var ff3 = ff2.ToInt();
            var ff2img1 = ff3.ToBitmap();
            ff2img1.Save($"perlin32_scaled_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");
            //return;

            var areasCreator = new AreasCreator(random, 250, 250);

            areasCreator.CreateAreas(5);

            areasCreator.FillAreas();

            var matrix = areasCreator.GetMatrix();

            var movedMatrix = areasCreator.MoveAreas(25);

            var c = movedMatrix.Convert(a => 
            {
                if (string.IsNullOrEmpty(a)) { return 0; }

                var parts = a.Split('-');
                return parts.Length;
            });

            var d = matrix.Convert(a => int.Parse(a.Replace("area_", "")));

            var d1 = d.Copy();
            d1.StretchOnMaximumAndMinimumValue(0, 250);
            //var d2 = d1.ResizeMatrix(1000, 1000).Convert(a => (int)a);
            var img = d1.ToBitmap();
            img.Save($"areas_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");


            var c1 = c.Copy();
            c1.StretchOnMaximumAndMinimumValue(0, 250);
            //var c2 = c1.ResizeMatrix(1000, 1000).Convert(a => (int)a);
            var cimg = c1.ToBitmap();
            cimg.Save($"areasMoved_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");


            var smth = c1.Copy();
            smth.Smoothing(13);

            var smthimg = smth.ToBitmap();
            smthimg.Save($"areasMovedSmoothing_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");

            //var d1 = Vector2Extensions.BringValueToRange(10, 10);
            //var d2 = Vector2Extensions.BringValueToRange(-1, 10);
            //var d3 = Vector2Extensions.BringValueToRange(0, 10);
            //var d4 = Vector2Extensions.BringValueToRange(9, 10);
            //var d5 = Vector2Extensions.BringValueToRange(5, 10);


            //var perlin = new PerlinNoiseGenerator();

            var pp1 = perlin.GetPerlinNoiseMatrix(256, 2);

            var pp2M = pp1.ResizeMatrix(500, 800);

            var pp1img = pp1.ToBitmap();
            var pp2img = pp2M.ToInt().ToBitmap();

            pp1img.Save($"src1_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");
            pp2img.Save($"src1_scaled_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");

            //var mapCreator = new MapCreator();

            //mapCreator.CreateMap();

            //var stepResult = mapCreator.ProcessStep(new AltitudeStep());

            logger.Info("ArcanumIsland.ConsoleApp: Ending...");
        }

        //private static Bitmap GetImage(int[][] matrix)
        //{
        //    int width = matrix.Length;
        //    int height = matrix[0].Length;

        //    var multiplayer = 1;

        //    var image = new Bitmap(width * multiplayer, height * multiplayer);

        //    for (int x = 0; x < width; x++)
        //    {
        //        for (int y = 0; y < height; y++)
        //        {
        //            Color color;
        //            var point = matrix[x][y];

        //            if (point < 0) { point = 0; }

        //            color = Color.FromArgb(point, point, point);

        //            for (int i = 0; i < multiplayer; i++)
        //            {
        //                for (int j = 0; j < multiplayer; j++)
        //                {
        //                    image.SetPixel(x * multiplayer + i, y * multiplayer + j, color);
        //                }
        //            }
        //        }
        //    }

        //    return image;
        //}
    }
}