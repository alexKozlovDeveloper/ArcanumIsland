using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.Randomization
{
    public static class RandomHelper
    {
        public static T GetRandomItem<T>(this IList<T> items, Random random)
        {
            var index = random.Next(items.Count);

            return items[index];
        }
    }
}
