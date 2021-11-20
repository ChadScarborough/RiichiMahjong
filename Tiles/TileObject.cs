using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Tiles
{
    public abstract class TileObject
    {
        protected int _value;
        protected Enums.Suit _suit;
        public const int EAST = 1, SOUTH = 2, WEST = 3, NORTH = 4;
        public const int GREEN = 1, RED = 2, WHITE = 3;

        public int GetValue()
        {
            return _value;
        }

        public Enums.Suit GetSuit()
        {
            return _suit;
        }
    }
}
