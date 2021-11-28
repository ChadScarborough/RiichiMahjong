using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Globals
{
    public static class Math
    {
        public static int MinOfThree(int a, int b, int c)
        {
            return (int)MathF.Round(MathF.Min(a, MathF.Min(b, c)));
        }
    }
}
