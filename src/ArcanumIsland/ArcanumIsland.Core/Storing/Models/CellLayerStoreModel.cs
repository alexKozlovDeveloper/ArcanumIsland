using ArcanumIsland.Core.MapGeneration.Cells.CellContent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.Storing.Models
{
    public class CellLayerStoreModel
    {
        public string Name { get; set; }

        public string Json { get; set; }

        public CellLayerStoreModel() { }

        public CellLayerStoreModel(ICellLayer layer) 
        {
            var type = layer.GetType();
            Name = type.Name;

            Json = JsonConvert.SerializeObject(layer);
        }

        public ICellLayer GetAsCellLayer() 
        {
            var dict = ModelStoringExtensions.FindCellLayerTypes().ToDictionary(a => a.Name, a => a);

            if (dict.ContainsKey(Name)) 
            {
                var layer = JsonConvert.DeserializeObject(Json, dict[Name]) as ICellLayer;

                return layer;
            }

            return null;
        }
    }
}
