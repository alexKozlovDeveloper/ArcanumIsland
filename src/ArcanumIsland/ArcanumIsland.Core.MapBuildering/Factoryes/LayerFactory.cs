using ArcanumIsland.Core.Interfaces;
using ArcanumIsland.Core.Models.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering.Factoryes
{
    public class LayerFactory<L> : IFactory<L>
        where L : ILayer, new()
    {
        public LayerFactory()
        {

        }

        public virtual L Create()
        {
            var layer = new L();

            return layer;
        }
    }
}
