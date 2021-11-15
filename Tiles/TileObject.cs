using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Tiles
{
    public abstract class TileObject
    {
        protected int _value;
        protected TileEnums.Suit _suit;
        public const int EAST = 1, SOUTH = 2, WEST = 3, NORTH = 4;
        public const int GREEN = 1, RED = 2, WHITE = 3;

        public int GetValue()
        {
            return _value;
        }

        public TileEnums.Suit GetSuit()
        {
            return _suit;
        }
    }
}
