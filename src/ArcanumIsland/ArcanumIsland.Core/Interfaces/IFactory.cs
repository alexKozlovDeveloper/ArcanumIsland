using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.Interfaces
{
    public interface IFactory<T>
    {
        T Create();
    }
}
