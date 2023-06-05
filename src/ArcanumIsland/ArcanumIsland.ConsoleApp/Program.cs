using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using ArcanumIsland.Core;
using ArcanumIsland.Core.Logging;
using AreasCreating;
using MathBase.Points;
using PerlinNoise;
using MathBase.MultidimensionalArrays.Matrixes;
using ArcanumIsland.Core.Additionals;
using ArcanumIsland.Core.MapBuildering;
using ArcanumIsland.Core.Storing;
using ArcanumIsland.Core.Storing.Models;
using ArcanumIsland.Core.Models;
using ArcanumIsland.Core.Models.Layers;
using ArcanumIsland.Core.MapBuildering.Factoryes;
using ArcanumIsland.Core.MapBuildering.Models.Params;
using ArcanumIsland.Core.Interfaces;

namespace ArcanumIsland.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();

            logger.Info("ArcanumIsland.ConsoleApp: Starting...");

            //MakeMap(707);
            MakeTestMap(707);

            return;

            //var random = new Random(2001);


            //var perlin = new PerlinNoiseGenerator();

            //var matrix1 = perlin.GetPerlinNoiseMatrix(512, 2);
            //var matrix2 = matrix1.Copy();
            //matrix2.RadialDecrease(0.8);

            //var img1 = matrix1.ToBitmap();
            //var img2 = matrix2.ToBitmap();

            //img1.Save($"perlinOrig_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");
            //img2.Save($"radiant_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");

            //var ff1 = perlin.GetPerlinNoiseMatrix(32, 2);
            //var ff1img1 = ff1.ToBitmap();
            //ff1img1.Save($"perlin32_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");

            //var ff2 = ff1.ResizeMatrix(500, 500);
            //var ff3 = ff2.ToInt();
            //var ff2img1 = ff3.ToBitmap();
            //ff2img1.Save($"perlin32_scaled_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");
            ////return;

            //var areasCreator = new AreasCreator(2001, 250, 250);

            //areasCreator.CreateAreas(5);

            //areasCreator.FillAreas();

            //var matrix = areasCreator.GetMatrix();

            //var movedMatrix = areasCreator.MoveAreas(25);

            //var c = movedMatrix.Convert(a => 
            //{
            //    if (string.IsNullOrEmpty(a)) { return 0; }

            //    var parts = a.Split('-');
            //    return parts.Length;
            //});

            //var d = matrix.Convert(a => int.Parse(a.Replace("area_", "")));

            //var d1 = d.Copy();
            //d1.StretchOnMaximumAndMinimumValue(0, 250);
            ////var d2 = d1.ResizeMatrix(1000, 1000).Convert(a => (int)a);
            //var img = d1.ToBitmap();
            //img.Save($"areas_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");


            //var c1 = c.Copy();
            //c1.StretchOnMaximumAndMinimumValue(0, 250);
            ////var c2 = c1.ResizeMatrix(1000, 1000).Convert(a => (int)a);
            //var cimg = c1.ToBitmap();
            //cimg.Save($"areasMoved_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");


            //var smth = c1.Copy();
            //smth.Smoothing(13);

            //var smthimg = smth.ToBitmap();
            //smthimg.Save($"areasMovedSmoothing_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");

            ////var d1 = Vector2Extensions.BringValueToRange(10, 10);
            ////var d2 = Vector2Extensions.BringValueToRange(-1, 10);
            ////var d3 = Vector2Extensions.BringValueToRange(0, 10);
            ////var d4 = Vector2Extensions.BringValueToRange(9, 10);
            ////var d5 = Vector2Extensions.BringValueToRange(5, 10);


            ////var perlin = new PerlinNoiseGenerator();

            //var pp1 = perlin.GetPerlinNoiseMatrix(256, 2);

            //var pp2M = pp1.ResizeMatrix(500, 800);

            //var pp1img = pp1.ToBitmap();
            //var pp2img = pp2M.ToInt().ToBitmap();

            //pp1img.Save($"src1_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");
            //pp2img.Save($"src1_scaled_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");

            ////var mapCreator = new MapCreator();

            ////mapCreator.CreateMap();

            ////var stepResult = mapCreator.ProcessStep(new AltitudeStep());

            //logger.Info("ArcanumIsland.ConsoleApp: Ending...");
        }

        public static void MakeTestMap(int seed)
        {
            var width = 50;
            var height = 50;

            var director = new MapBuilderingDirector(width, height);
            var stepFactory = new StepBuilderFactory();

            var altitudeStep = stepFactory.CreateAltitudeStepBuilder(GetAltitudeStepBuilderParam(seed));

            var testStep = stepFactory.CreateAddLayerStepBuilder(GetTestMapStepBuilderParam<Grass>(width, height));

            director.ApplyStepBuilder(altitudeStep);

            director.ApplyStepBuilder(testStep);

            var map = director.GetMap() as Map;

            var mapStoreModel = new MapStoreModel(map);

            ModelStoringExtensions.SerializeModelToXml(mapStoreModel, @"D:\ArcanumIsland\Models\for_test_xml_map.xml");
        }

        public static void MakeMap(int seed)
        {
            var waterEdge = 100;
            var sandAltitudeRange = 15;
            var grassAltitudeRange = 85;
            //var iceAltitudeRange = 21;


            var director = new MapBuilderingDirector(25, 25);
            var stepFactory = new StepBuilderFactory();

            var altitudeStep = stepFactory.CreateAltitudeStepBuilder(GetAltitudeStepBuilderParam(seed));

            var altitudeRadialDecreaseStep = stepFactory.CreateAltitudeRadialDecreaseStepBuilder(GetAltitudeRadialDecreaseStepBuilderParam());

            var addOceanStep = stepFactory.CreateAddLayerStepBuilder(GetAddOceanLayerStepBuilderParam(waterEdge));

            var addSandStep = stepFactory.CreateAddLayerStepBuilder(GetAddLayerStepBuilderParam<Sand>(waterEdge - sandAltitudeRange, waterEdge + sandAltitudeRange));
            var addGrassStep = stepFactory.CreateAddLayerStepBuilder(GetAddLayerStepBuilderParam<Grass>(waterEdge + sandAltitudeRange, waterEdge + sandAltitudeRange + grassAltitudeRange));
            var addSnowStep = stepFactory.CreateAddLayerStepBuilder(GetAddLayerStepBuilderParam<Snow>(waterEdge + sandAltitudeRange + grassAltitudeRange, 255));

            var altitudeStepResult = director.ApplyStepBuilder(altitudeStep);

            var altitudeRadialDecreaseStepResult = director.ApplyStepBuilder(altitudeRadialDecreaseStep);

            var addOceanStepResult = director.ApplyStepBuilder(addOceanStep);

            var addSandStepResult = director.ApplyStepBuilder(addSandStep);
            var addGrassStepResult = director.ApplyStepBuilder(addGrassStep);
            var addIceStepResult = director.ApplyStepBuilder(addSnowStep);

            var map = director.GetMap() as Map;

            var mapStoreModel = new MapStoreModel(map);

            //mapStoreModel.SerializeModelToFile(@"D:\ArcanumIsland\Models\test_map.json");
            //var m = ModelStoring.DeserializeModelFromFile<Map>(@"D:\ArcanumIsland\Models\test_map.json");
            //mapStoreModel.SaveAsJson(@"D:\ArcanumIsland\Models\test_map.json");

            //var d = ModelStoring.LoadFromJson<MapStoreModel>(@"D:\ArcanumIsland\Models\test_map_[2023-05-29]_(12-07-51).json");


            ModelStoringExtensions.SerializeModelToXml(mapStoreModel, @"D:\ArcanumIsland\Models\test_xml_map.xml");





            var c = ModelStoringExtensions.DeserializeModelFromXml<MapStoreModel>(@"D:\ArcanumIsland\Models\test_xml_map.xml");

            //var m = c.GetAsMap();

            //var mapStoreModel2 = new MapStoreModel(m);

            //ModelStoringExtensions.SerializeModelToXml(mapStoreModel2, @"D:\ArcanumIsland\Models\test_xml_map2.xml");
        }

        private static AltitudeStepBuilderParam GetAltitudeStepBuilderParam(int seed)
        {
            return new AltitudeStepBuilderParam
            {
                Seed = seed,
                Dimension = 256,
                SmoothingSize = 2
            };
        }

        private static AltitudeRadialDecreaseStepBuilderParam GetAltitudeRadialDecreaseStepBuilderParam()
        {
            return new AltitudeRadialDecreaseStepBuilderParam
            {
                Speed = 2
            };
        }

        private static AddLayerStepBuilderParam<L> GetAddLayerStepBuilderParam<L>(int bottomEdge, int topEdge) where L : ILayer, new()
        {
            return new AddLayerStepBuilderParam<L>
            {
                LayerFactory = new LayerFactory<L>(),
                AddCondition = a =>
                {
                    var altitude = a.GetLayer<Altitude>();

                    if (altitude == null) { return false; }

                    if (altitude.Value >= bottomEdge && altitude.Value < topEdge)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            };
        }

        private static AddLayerStepBuilderParam<L> GetTestMapStepBuilderParam<L>(int width, int height) where L : ILayer, new()
        {
            return new AddLayerStepBuilderParam<L>
            {
                LayerFactory = new LayerFactory<L>(),
                AddCondition = a =>
                {
                    var altitude = a.GetLayer<Altitude>();

                    if (altitude == null) { return false; }

                    altitude.Value = 100.0 + altitude.Value / 10;

                    var result = false;

                    // 
                    if (a.X < width / 2 && a.Y < height / 2)
                    {
                        result = true;
                    }

                    if (a.X > width / 2 && a.Y > height / 2)
                    {
                        result = true;
                    }

                    //
                    if (a.X == a.Y)
                    {
                        result = false;
                    }

                    if (width - a.X == a.Y)
                    {
                        result = true;
                    }

                    //
                    if (width / 2 - a.X == a.Y)
                    {
                        result = false;
                    }

                    if (a.X + width / 2 == a.Y)
                    {
                        result = true;
                    }

                    if (a.X == a.Y + width / 2)
                    {
                        result = true;
                    }

                    if (width - a.X == a.Y - width / 2)
                    {
                        result = false;
                    }

                    return result;
                }
            };
        }

        private static AddLayerStepBuilderParam<Ocean> GetAddOceanLayerStepBuilderParam(int oceanAltitude)
        {
            return new AddLayerStepBuilderParam<Ocean>
            {
                LayerFactory = new OceanFactory(oceanAltitude),
                AddCondition = a =>
                {
                    var altitude = a.GetLayer<Altitude>();

                    if (altitude == null) { return false; }

                    if (altitude.Value < oceanAltitude)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            };
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