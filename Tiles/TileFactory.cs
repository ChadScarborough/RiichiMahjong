using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Tiles
{
    public class TileFactory
    {
        private NumberTileFactory numberTileFactory = new NumberTileFactory();
        private WindTileFactory windTileFactory = new WindTileFactory();
        private DragonTileFactory dragonTileFactory = new DragonTileFactory();

        public TileObject CreateTile(int value, TileEnums.Suit suit)
        {
            switch (suit)
            {
                case TileEnums.Suit.Man:
                case TileEnums.Suit.Pin:
                case TileEnums.Suit.Sou:
                    return numberTileFactory.CreateTile(value, suit);
                case TileEnums.Suit.Wind:
                    return windTileFactory.CreateTile(value, suit);
                case TileEnums.Suit.Dragon:
                    return dragonTileFactory.CreateTile(value, suit);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
