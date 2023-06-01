using ArcanumIsland.Core.Models.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.MapBuildering.Factoryes
{
    public class OceanFactory : LayerFactory<Ocean>
    {
        private int _oceanAltitude;

        public OceanFactory(int oceanAltitude) 
        {
            _oceanAltitude = oceanAltitude;
        }

        public override Ocean Create()
        {
            var ocean = new Ocean();

            ocean.Value = _oceanAltitude;

            return ocean;
        }
    }
}
