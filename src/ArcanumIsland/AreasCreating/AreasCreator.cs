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

        public AreasCreator(int seed = -1) 
        {
            _random = new Random(seed);
        }

        public void CreateAreas(int width, int height) 
        {


        }
    }
}

