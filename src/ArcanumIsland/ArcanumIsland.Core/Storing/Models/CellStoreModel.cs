using ArcanumIsland.Core.MapGeneration.Cells;
using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArcanumIsland.Core.Storing.Models
{
    [XmlInclude(typeof(Altitude))]
    public class CellStoreModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CellLayerStoreModel[] CellLayers { get; set; }

        public CellStoreModel() { }

        public CellStoreModel(ICell cell) 
        {
            X = cell.X;
            Y = cell.Y;

            CellLayers = new CellLayerStoreModel[cell.CellLayers.Count];

            for (int i = 0; i < cell.CellLayers.Count; i++)
            {
                CellLayers[i] = new CellLayerStoreModel(cell.CellLayers[i]);
            }
        }
    }
}
