using MathBase.MultidimensionalArrays;
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

        private readonly Matrix<int> _matrix;

        public AreasCreator(int width, int height, int seed = -1) 
        {
            _random = new Random(seed);

            _matrix = new Matrix<int>(width, height);
        }

        public void CreateAreas(int minCount, int maxCount) 
        {
            var areasCount = _random.Next(minCount, maxCount);  


        }
    }
}

