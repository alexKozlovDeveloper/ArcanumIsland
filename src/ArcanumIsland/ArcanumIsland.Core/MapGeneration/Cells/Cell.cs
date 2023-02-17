using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapGeneration.Cells
{
    public class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public List<ICellContent> CellContents { get; private set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;

            CellContents = new List<ICellContent>();
        }

        public void AddContent(ICellContent content)
        {
            CellContents.Add(content);
        }
    }
}
