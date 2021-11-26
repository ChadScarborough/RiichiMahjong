using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Tiles
{
    public class NumberTileObject : TileObject
    {
        public NumberTileObject(int value, Enums.Suit suit)
        {
            this._value = value;
            this._suit = suit;
        }

        public override bool IsTerminal()
        {
            return _value == 1 || _value == 9;
        }

        public override bool IsHonor()
        {
            return false;
        }
    }
}
