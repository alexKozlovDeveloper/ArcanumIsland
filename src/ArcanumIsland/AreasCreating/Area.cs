using MathBase.MultidimensionalArrays;
using MathBase.Points;
using MathBase.Randomization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasCreating
{
    public class Area
    {
        public string Name { get; private set; }
        public Vector2 Center { get; private set; }

        public List<Vector2> AreaPoints { get; private set; }
        public List<Vector2> ImmediatePoints { get; set; }

        private int _width;
        private int _height;

        private Random _random;

        public Area(string name, Vector2 center, int matrixWidth, int matrixHeight, Random random)
        {
            Name = name;
            Center = center;

            _width = matrixWidth;
            _height = matrixHeight;

            _random = random;

            AreaPoints = new List<Vector2>();
            ImmediatePoints = new List<Vector2>();
        }

        public void AddPoint(Vector2 point)
        {
            //if (AreaPoints.Contains(point) == false)
            //{
            //    AreaPoints.Add(point);
            //}

            //if (ImmediatePoints.Contains(point))
            //{
            //    ImmediatePoints.Remove(point);
            //}

            //var immediatePoints = MatrixHelper.GetImmediatePoints(_width, _height, point);

            //foreach (var item in immediatePoints)
            //{
            //    if (ImmediatePoints.Contains(item) == false && AreaPoints.Contains(point) == false)
            //    {
            //        ImmediatePoints.Add(item);
            //    }
            //}
        }

        public Vector2 GetRandomImmediatePoint()
        {
            return ImmediatePoints.GetRandomItem(_random);
        }
    }
}
