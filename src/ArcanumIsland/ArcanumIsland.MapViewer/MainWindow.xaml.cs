using MathBase.MultidimensionalArrays.Matrixes;
using ArcanumIsland.Core.Additionals;
using PerlinNoise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Interop;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Media.Animation;

namespace ArcanumIsland.MapViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random _rnd;
        //private BaseAltitudeStepParams _dd;

        public MainWindow()
        {
            InitializeComponent();

            _rnd = new Random(696);



           // var controller = new MapCreatingController(MainImage, SetupPanel);


            //controller.AddStep(new BaseAltitudeStep(696, new BaseAltitudeStepParams
            //{
            //    Dimension = 256,
            //    SmoothingSize = 2,
            //}));

        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {


            //var generator = new PerlinNoiseGenerator(_rnd.Next(), 255);

            //var resX = 256;
            //var resY = resX;

            //var matrix = generator.GetPerlinNoiseMatrix(resX, 4);

            //var newRexX = 500;
            //var newRexY = 300;

            //_dd = new BaseAltitudeStepParams
            //{
            //    Dimension = 256,
            //    SmoothingSize = 2,
            //};

            //Binding myBinding = new Binding("Dimension");
            //myBinding.Source = _dd;

            //mytextboxbind.SetBinding(TextBlock.TextProperty, myBinding);

            //return;

            //var gridsets = CreateStepSettingGrid<BaseAltitudeStepParams>();
            //SetupPanel.Children.Add(gridsets);

            //var mapCreator = new MapCreator(150, 150, 1984);

            //var baseAltitudeResult = mapCreator.AddBaseAltitude(new BaseAltitudeStepParams
            //{
            //    Dimension = 256,
            //    SmoothingSize = 2,
            //});

            //var tectonicPlatesResult = mapCreator.AddTectonicPlates(new TectonicPlatesStepParams
            //{
            //    Width = 250,
            //    Height = 250,
            //    AreasCount = 5,
            //});

            //var resultAltitudeResult = mapCreator.AddResultAltitude(new ResultAltitudeStepParams
            //{

            //});

            //var oceanResult = mapCreator.AddOcean(new OceanStepParams
            //{
            //    SeaLevel = 100,
            //});

            //var sandResult = mapCreator.AddSand(new SandStepParams
            //{
            //    BottomEdge = 100,
            //    TopEdge = 110,
            //});

            //var grassResult = mapCreator.AddGrass(new GrassStepParams
            //{
            //    BottomEdge = 110,
            //    TopEdge = 150,
            //});

            //var snowResult = mapCreator.AddSnow(new SnowStepParams
            //{
            //    BottomEdge = 150,
            //    TopEdge = 250,
            //});

            //var map = mapCreator.GetMap();

            //var bitmap = MapToImage(map);

            //bitmap.Save($"mapCreator_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");

            //AddImageToBitmap(resX, resY, matrix.GetAsArray());

            //var imageSource = ImageSourceFromBitmap(bitmap);

            //MainImage.Source = imageSource;


            //var baseAltitude = map.CellsMatrix.Convert(cell =>
            //{
            //    var baseAltitude = cell.GetCellContent<BaseAltitude>();

            //    if (baseAltitude == null) { return 0; }

            //    return baseAltitude.Weight;
            //});

            //var tectonicPlate = map.CellsMatrix.Convert(cell =>
            //{
            //    var tectonicPlate = cell.GetCellContent<TectonicPlate>();

            //    if (tectonicPlate == null) { return 0; }

            //    return tectonicPlate.PlateCount;
            //});

            //tectonicPlate.StretchOnMaximumAndMinimumValue(0, 250);

            //var resultAltitude = map.CellsMatrix.Convert(cell =>
            //{
            //    var resultAltitude = cell.GetCellContent<ResultAltitude>();

            //    if (resultAltitude == null) { return 0; }

            //    return resultAltitude.Weight;
            //});
            
            //baseAltitude.ToBitmap().Save($"baseAltitude_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");
            //tectonicPlate.ToBitmap().Save($"tectonicPlate_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");
            //resultAltitude.ToBitmap().Save($"resultAltitude_{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}.png");
        }

        //public void CreateStepStackPanel(object setting) 
        //{
        //    var stepStackPanel = new StackPanel();

        //    var stepMainGrid = new Grid();
        //    var stepSettingGrid = new Grid();
        //    var stepResultGrid = new StackPanel();

        //    stepStackPanel.Children.Add(stepMainGrid);
        //    stepStackPanel.Children.Add(stepSettingGrid);
        //    stepStackPanel.Children.Add(stepResultGrid);

        //}

        //public Grid CreateStepSettingGrid<T>() 
        //{
        //    var stepSettingGrid = new Grid();

        //    stepSettingGrid.ColumnDefinitions.Add(new ColumnDefinition());
        //    stepSettingGrid.ColumnDefinitions.Add(new ColumnDefinition());

        //    Type settingType = typeof(T);
        //    var properties = settingType.GetProperties();

        //    for (int i = 0; i < properties.Length; i++)
        //    {
        //        stepSettingGrid.RowDefinitions.Add(new RowDefinition());

        //        var label = new Label
        //        {
        //            Content = properties[i].Name
        //        };

        //        var texBox = new TextBox();

        //        Grid.SetRow(label, i);
        //        Grid.SetRow(texBox, i);

        //        Grid.SetColumn(label, 0);
        //        Grid.SetColumn(texBox, 1);

        //        stepSettingGrid.Children.Add(label);
        //        stepSettingGrid.Children.Add(texBox);
        //    }

        //    return stepSettingGrid;
        //}



        //public Bitmap MapToImage(Map map) 
        //{
        //    var colorMatrix = map.CellsMatrix.Convert(cell => 
        //    {
        //        if (cell.IsContainCellContent<Ocean>())
        //        {
        //            return System.Drawing.Color.FromArgb(0, 0 ,200);
        //        }

        //        if (cell.IsContainCellContent<Grass>())
        //        {
        //            return System.Drawing.Color.FromArgb(0, 200, 0);
        //        }

        //        if (cell.IsContainCellContent<Sand>())
        //        {
        //            return System.Drawing.Color.FromArgb(200, 200, 0);
        //        }

        //        if (cell.IsContainCellContent<Snow>())
        //        {
        //            return System.Drawing.Color.FromArgb(200, 200, 200);
        //        }

        //        return System.Drawing.Color.FromArgb(150, 150, 150);
        //    });

        //    return colorMatrix.ToBitmap();
        //}

        private void AddImageToBitmap(int resX, int resY, int[][] matrix) 
        {
            WriteableBitmap writableImg = new WriteableBitmap(resX, resY, 96, 96, PixelFormats.Bgr32, null);

            //lock the buffer
            writableImg.Lock();

            for (int i = 0; i < resX; i++)
            {
                for (int j = 0; j < resY; j++)
                {
                    IntPtr backbuffer = writableImg.BackBuffer;
                    //the buffer is a monodimensionnal array...
                    backbuffer += j * writableImg.BackBufferStride;
                    backbuffer += i * 4;
                    System.Runtime.InteropServices.Marshal.WriteInt32(backbuffer, matrix[i][j]);
                }
            }

            //specify the area to update
            writableImg.AddDirtyRect(new Int32Rect(0, 0, resX, resY));
            //release the buffer and show the image
            writableImg.Unlock();

            MainImage.Source = writableImg;
        }

        public ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();

            return Imaging.CreateBitmapSourceFromHBitmap(
                handle, 
                IntPtr.Zero, 
                Int32Rect.Empty, 
                BitmapSizeOptions.FromEmptyOptions()
            );
        }

        private void mytextboxbind_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var d = _dd;
        }
    }   
}
