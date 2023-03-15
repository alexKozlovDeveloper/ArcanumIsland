using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase.Ranges
{
    public static class RangeExtensions
    {
        public static int BringValueToRange(int val, int width)
        {
            var result = val;

            var count = Math.Abs(val / width);

            if (val < 0)
            {
                result += width * (count + 1);
            }
            else
            {
                result -= width * count;
            }

            return result;
        }
    }
}

