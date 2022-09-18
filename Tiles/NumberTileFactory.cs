using System;

namespace RMU.Tiles;

public static class NumberTileFactory
{
    public static NumberTile CreateTile(int value, Suit suit)
    {
        return value is >= 1 and <= 9 ? new NumberTile(value, suit) : throw new ArgumentException("Invalid value for Number tile");
    }
}
