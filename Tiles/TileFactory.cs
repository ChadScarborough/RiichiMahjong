using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Tiles
{
    public static class TileFactory
    {
        public static TileObject CreateTile(int value, Enums.Suit suit)
        {
            switch (suit)
            {
                case Enums.Suit.Man:
                case Enums.Suit.Pin:
                case Enums.Suit.Sou:
                    return NumberTileFactory.CreateTile(value, suit);
                case Enums.Suit.Wind:
                    return WindTileFactory.CreateTile(value, suit);
                case Enums.Suit.Dragon:
                    return DragonTileFactory.CreateTile(value, suit);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
