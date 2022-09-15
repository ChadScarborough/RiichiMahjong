using System;
using RMU.Globals;

namespace RMU.Tiles
{
    public static class TileFactory
    {
        public static Tile CreateTile(int value, Enums.Suit suit)
        {
            switch (suit)
            {
                case Enums.MAN:
                case Enums.PIN:
                case Enums.SOU:
                    return NumberTileFactory.CreateTile(value, suit);
                case Enums.WIND:
                    return WindTileFactory.CreateTile(value, suit);
                case Enums.DRAGON:
                    return DragonTileFactory.CreateTile(value, suit);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
