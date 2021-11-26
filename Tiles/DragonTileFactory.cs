﻿using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Tiles
{
    public class DragonTileFactory
    {
        public DragonTileObject CreateTile(int value, Enums.Suit suit)
        {
            if (value >= ConstValues.GREEN_DRAGON && value <= ConstValues.WHITE_DRAGON)
            {
                return new DragonTileObject(value, suit);
            }
            throw new ArgumentException();
        }
    }
}
