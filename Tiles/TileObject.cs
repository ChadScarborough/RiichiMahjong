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
        public const int 
            EAST = ConstValues.EAST_WIND, 
            SOUTH = ConstValues.SOUTH_WIND, 
            WEST = ConstValues.WEST_WIND, 
            NORTH = ConstValues.NORTH_WIND;
        public const int 
            GREEN = ConstValues.GREEN_DRAGON, 
            RED = ConstValues.RED_DRAGON, 
            WHITE = ConstValues.WHITE_DRAGON;

        public int GetValue()
        {
            return _value;
        }

        public Enums.Suit GetSuit()
        {
            return _suit;
        }

        public abstract bool IsTerminal();
        public abstract bool IsHonor();
    }
}
