using MathBase.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasCreating
{
    public class Area
    {
        public Vector2 Center { get; private set; }

        public List<Vector2> AreaPoints { get; private set; }
        public List<Vector2> ImmediatePoints { get; private set; }

        public Area(Vector2 center) 
        {
            Center = center;

            AreaPoints = new List<Vector2>();
            ImmediatePoints = new List<Vector2>();
        }

        public void AddPoint(Vector2 point) 
        {
            if (AreaPoints.Contains(point) == false) 
            {
                AreaPoints.Add(point);
            }


        }
    }
}
