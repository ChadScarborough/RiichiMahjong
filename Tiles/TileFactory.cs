using System;

namespace RMU.Tiles;

public static class TileFactory
{
    public static Tile CreateTile(int value, Suit suit)
    {
        return suit switch
        {
            MAN or PIN or SOU => NumberTileFactory.CreateTile(value, suit),
            WIND => WindTileFactory.CreateTile(value, suit),
            DRAGON => DragonTileFactory.CreateTile(value, suit),
            _ => throw new ArgumentException("Invalid suit"),
        };
    }
}
