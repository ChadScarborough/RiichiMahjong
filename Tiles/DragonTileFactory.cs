using System;

namespace RMU.Tiles;

public static class DragonTileFactory
{
    public static DragonTile CreateTile(int value, Suit suit)
    {
        return value is >= GREEN_DRAGON_C and <= WHITE_DRAGON_C
            ? new DragonTile(value, suit)
            : throw new ArgumentException("Invalid value for Dragon tile");
    }
}
