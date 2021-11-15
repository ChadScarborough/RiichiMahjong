using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Tiles
{
    public class WindTileObject : TileObject
    {
        public WindTileObject(int value, TileEnums.Suit suit)
        {
            this._value = value;
            this._suit = suit;
        }
    }
}
