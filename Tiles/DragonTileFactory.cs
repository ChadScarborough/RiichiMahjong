using System;
using RMU.Globals;

namespace RMU.Tiles
{
    public static class DragonTileFactory
    {
        public static DragonTileObject CreateTile(int value, Enums.Suit suit)
        {
            if (value >= ConstValues.GREEN_DRAGON_C && value <= ConstValues.WHITE_DRAGON_C)
            {
                return new DragonTileObject(value, suit);
            }
            throw new ArgumentException();
        }
    }
}
