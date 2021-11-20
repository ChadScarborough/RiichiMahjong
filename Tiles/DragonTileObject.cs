using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Tiles
{
    public class DragonTileObject : TileObject
    {
        public DragonTileObject(int value, Enums.Suit suit)
        {
            this._value = value;
            this._suit = suit;
        }
    }
}
