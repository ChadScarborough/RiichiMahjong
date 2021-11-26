﻿using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Tiles
{
    public class WindTileFactory
    {
        public WindTileObject CreateTile(int value, Enums.Suit suit)
        {
            if(value >= ConstValues.EAST_WIND && value <= ConstValues.NORTH_WIND)
            {
                return new WindTileObject(value, suit);
            }
            throw new ArgumentException();
        }
    }
}
