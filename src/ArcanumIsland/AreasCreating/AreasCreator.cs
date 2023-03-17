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

        public AreasCreator(int width, int height, int seed = -1)
        {
            _matrix = new Matrix<string>(width, height);

            _random = new Random(seed);

            _areas = new List<Area>();
            _areasPoints = new List<Vector2>();
            //_immediatePoints = new List<Vector2>();
           // _freePoints = GetAllPoints();
        }

        public void CreateAreas(int minCount, int maxCount)
        {
            var areasCount = _random.Next(minCount, maxCount);

            var centers = GetUniqueRandomPoints(areasCount);

            for (int i = 0; i < areasCount; i++)
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

            var d = 0;

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

                    area.AreaPoints.Add(newPoint);
                    area.ImmediatePoints.Remove(newPoint);

                    _matrix[newPoint] = area.Name;
                    d++;

                    area.ImmediatePoints.AddRange(GetImmediateFreePoints(newPoint));

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

            Console.WriteLine($"d:{d}");
        }

        public Matrix<string> GetMatrix() 
        {
            return _matrix;
        }

        public IEnumerable<Vector2> GetImmediateFreePoints(Vector2 point) 
        {
            var immediatePoints = _matrix.GetImmediatePoints(point);

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

