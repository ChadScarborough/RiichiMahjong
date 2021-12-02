using System;
using RMU.Globals;

namespace RMU.Tiles
{
    public static class WindTileFactory
    {
        public static WindTileObject CreateTile(int value, Enums.Suit suit)
        {
            if(value >= ConstValues.EAST_WIND && value <= ConstValues.NORTH_WIND)
            {
                return new WindTileObject(value, suit);
            }
            throw new ArgumentException();
        }
    }
}
