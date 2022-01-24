using System;
using RMU.Globals;

namespace RMU.Tiles
{
    public static class WindTileFactory
    {
        public static WindTileObject CreateTile(int value, Enums.Suit suit)
        {
            if(value is >= ConstValues.EAST_WIND_C and <= ConstValues.NORTH_WIND_C)
            {
                return new WindTileObject(value, suit);
            }
            throw new ArgumentException();
        }
    }
}
