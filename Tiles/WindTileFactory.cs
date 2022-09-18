using System;

namespace RMU.Tiles;

public static class WindTileFactory
{
    public static WindTile CreateTile(int value, Suit suit)
    {
        return value is >= EAST_WIND_C and <= NORTH_WIND_C
            ? new WindTile(value, suit)
            : throw new ArgumentException("Invalid value for Wind tile");
    }
}
