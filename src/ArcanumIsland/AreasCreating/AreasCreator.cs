using MathBase.Matrixes;
using MathBase.MultidimensionalArrays;
using MathBase.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasCreating
{
    public class AreasCreator
    {
        private readonly Random _random;

        private readonly Matrix<string> _matrix;

        private List<Area> _areas;

        public int Width => _matrix.Width;
        public int Height => _matrix.Height;

        private List<Vector2> _areasPoints;
        //private List<Vector2> _immediatePoints;
        //private List<Vector2> _freePoints;

        public AreasCreator(Random random, int width, int height, int seed = -1)
        {
            _matrix = new Matrix<string>(width, height);

            _random = random;

            _areas = new List<Area>();
            _areasPoints = new List<Vector2>();
            //_immediatePoints = new List<Vector2>();
           // _freePoints = GetAllPoints();
        }

        public void CreateAreas(int count)
        {
            var centers = GetUniqueRandomPoints(count);

            for (int i = 0; i < count; i++)
            {
                //var center = GetRandomFreePoint();

                var area = new Area($"area_{i}", centers[i], Width, Height, _random);

                _areas.Add(area);

                //area.AreaPoints.Add(center);

                //var immediatePoints = _matrix.GetImmediatePoints(center);

                //area.ImmediatePoints.AddRange(immediatePoints);
                //_immediatePoints.AddRange(immediatePoints);
            }

            //_immediatePoints = _immediatePoints.Distinct().ToList();
        }

        private List<Vector2> GetAllPoints()
        {
            var result = new List<Vector2>();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    result.Add(new Vector2(x, y));
                }
            }

            return result;
        }

        //private Vector2 GetRandomFreePoint()
        //{
        //    var index = _random.Next(0, _freePoints.Count);

        //    var point = _freePoints[index];

        //    _freePoints.Remove(point);

        //    return _freePoints[index];
        //}

        public void FillAreas()
        {
            //while (_freePoints.Count > 0 || _immediatePoints.Count > 0)
            //{
            //    foreach (var area in _areas)
            //    {

            //    }
            //}

            //var d = 0;

            do
            {
                foreach (var area in _areas)
                {
                    Vector2 newPoint = null;

                    if (area.AreaPoints.Count == 0)
                    {
                        newPoint = area.Center;
                    }
                    else
                    {
                        if (area.ImmediatePoints.Count == 0) { continue; }

                        newPoint = area.GetRandomImmediatePoint();
                    }

                    //if (newPoint.ToString() == "[7:46]") 
                    //{
                    //    var f = new Vector2(7, 46);

                    //    var f1 = area.ImmediatePoints.Contains(newPoint);
                    //    var f2 = area.ImmediatePoints.Contains(f);
                    //    var f3 = f == newPoint;
                    //}

                    //if (area.AreaPoints.Contains(newPoint)) 
                    //{
                    
                    //}

                    //var str = _matrix[newPoint];

                    area.AreaPoints.Add(newPoint);
                    area.ImmediatePoints.RemoveAll(a => a.Equals(newPoint));//  (newPoint);

                    _matrix[newPoint] = area.Name;
                    //d++;

                    area.ImmediatePoints.AddRange(GetImmediateFreePoints(newPoint));

                    //if (area.ImmediatePoints.Contains(new Vector2(7, 46)) && area.Name == "area_0") 
                    //{
                    
                    //}

                    //area.ImmediatePoints = area.ImmediatePoints.Distinct().ToList();

                    foreach (var item in _areas)
                    {
                        if (item != area)
                        {
                            item.ImmediatePoints.Remove(newPoint);
                        }
                    }
                }
            }
            while (_areas.Where(a => a.ImmediatePoints.Count > 0).Count() > 0);

            //Console.WriteLine($"d:{d}");
        }

        public Matrix<string> MoveAreas(int distance) 
        {
            var resultMatrix = new Matrix<string>(Width, Height);

            foreach (var area in _areas) 
            {
                var x = _random.Next(distance * 2) - distance;
                var y = _random.Next(distance * 2) - distance;

                var motionVector = new Vector2(x, y);

                foreach (var point in area.AreaPoints)
                {
                    var newPoint = point.NewRelativePointMirror(motionVector, Width, Height);

                    if (resultMatrix.IsOutOfMatrix(newPoint) == false)
                    {
                        var str = resultMatrix[newPoint];

                        if (string.IsNullOrEmpty(str) == false) 
                        {
                            if (str.Contains(area.Name))
                            {

                            }
                        }

                        resultMatrix[newPoint] += $"{area.Name}-";
                    }
                    else 
                    {
                    
                    }
                }
            }

            return resultMatrix;
        }

        public Matrix<string> GetMatrix() 
        {
            return _matrix;
        }

        public IEnumerable<Vector2> GetImmediateFreePoints(Vector2 point) 
        {
            var immediatePoints = _matrix.GetImmediatePointsMirror(point);

            var result = immediatePoints.Where(a => string.IsNullOrEmpty(_matrix[a]));

            return result;
        }

        public List<Vector2> GetUniqueRandomPoints(int count) 
        {
            var result = new List<Vector2>();

            while (result.Count < count) 
            {
                var x = _random.Next(Width);
                var y = _random.Next(Height);

                var point = new Vector2(x, y);

                if (result.Contains(point) == false) 
                {
                    result.Add(point);
                }
            }

            return result;
        }
    }
}

