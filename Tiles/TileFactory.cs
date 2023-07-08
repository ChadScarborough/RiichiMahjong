using System;

namespace RMU.Tiles;

public static class TileFactory
{
    public static Tile CreateTile(int value, Suit suit)
    {
        return suit switch
        {
            WIND => CreateWindTile(value, suit),
            DRAGON => CreateDragonTile(value, suit),
            _ => CreateNumberTile(value, suit),
        };
    }

    private static WindTile CreateWindTile(int value, Suit suit)
    {
        return value is >= EAST_WIND_C and <= NORTH_WIND_C
            ? new WindTile(value, suit)
            : throw new ArgumentException("Invalid value for Wind tile");
    }

    private static DragonTile CreateDragonTile(int value, Suit suit)
    {
        return value is >= GREEN_DRAGON_C and <= WHITE_DRAGON_C
            ? new DragonTile(value, suit)
            : throw new ArgumentException("Invalid value for Dragon tile");
    }

    private static NumberTile CreateNumberTile(int value, Suit suit)
    {
        return value is >= 1 and <= 9 
            ? new NumberTile(value, suit) 
            : throw new ArgumentException("Invalid value for Number tile");
    }
}
