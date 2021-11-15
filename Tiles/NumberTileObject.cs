using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Tiles
{
    public class NumberTileObject : TileObject
    {
        public NumberTileObject(int value, TileEnums.Suit suit)
        {
            this._value = value;
            this._suit = suit;
        }
    }
}
