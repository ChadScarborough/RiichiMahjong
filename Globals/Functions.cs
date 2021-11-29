﻿using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;

namespace RMU.Globals
{
    public static class Functions
    {
        public static int MinOfThree(int a, int b, int c)
        {
            return (int)MathF.Round(MathF.Min(a, MathF.Min(b, c)));
        }

        public static bool TilesAreEquivalent(TileObject tile1, TileObject tile2)
        {
            Enums.Suit suit1 = tile1.GetSuit();
            Enums.Suit suit2 = tile2.GetSuit();
            int value1 = tile1.GetValue();
            int value2 = tile2.GetValue();
            bool sameSuit = suit1 == suit2;
            bool sameValue = value1 == value2;
            return sameSuit && sameValue;
        }
    }
}
