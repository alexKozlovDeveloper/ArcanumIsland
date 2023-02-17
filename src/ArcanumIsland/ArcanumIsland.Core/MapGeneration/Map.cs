using ArcanumIsland.Core.MapGeneration.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration
{
    public class Map
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public List<List<Cell>> Cells { get; private set; }

        public Map(int height, int width)
        {
            Height = height;
            Width = width;

            Cells = new List<List<Cell>>(Height);

            foreach (var row in Cells)
            {
                //  row
            }
        }

    }
}
