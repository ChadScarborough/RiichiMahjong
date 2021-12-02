using System;
using RMU.Globals;

namespace RMU.Tiles
{
    public static class NumberTileFactory
    {
        public static NumberTileObject CreateTile(int value, Enums.Suit suit)
        {
            if(value >= 1 && value <= 9)
            {
                return new NumberTileObject(value, suit);
            }
            throw new ArgumentException();
        }
    }
}
