using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Tiles
{
    public class TileFactory
    {
        private NumberTileFactory numberTileFactory = new NumberTileFactory();
        private WindTileFactory windTileFactory = new WindTileFactory();
        private DragonTileFactory dragonTileFactory = new DragonTileFactory();

        public TileObject CreateTile(int value, Enums.Suit suit)
        {
            switch (suit)
            {
                case Enums.Suit.Man:
                case Enums.Suit.Pin:
                case Enums.Suit.Sou:
                    return numberTileFactory.CreateTile(value, suit);
                case Enums.Suit.Wind:
                    return windTileFactory.CreateTile(value, suit);
                case Enums.Suit.Dragon:
                    return dragonTileFactory.CreateTile(value, suit);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
