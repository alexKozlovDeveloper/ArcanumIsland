using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBase
{
    public static class MathHelper
    {
        public static int Lerp(int a, int b, int t)
        {
            return a + (b - a) * t;
        }

        public static bool IsMultipleOfTwo(int val)
        {
            return val != 0 && (val & (val - 1)) == 0;
        }

        public static void GetIntegerAndFractionalPart(double num, out int integer, out double fractional)
        {
            integer = (int)num;
            fractional = num - (double)integer;
        }
    }
}
