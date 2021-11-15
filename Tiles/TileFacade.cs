using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Tiles
{
    public class TileFacade
    {
        private TileFactory _tileFactory;
        public const int EAST = TileObject.EAST, SOUTH = TileObject.SOUTH, WEST = TileObject.WEST, NORTH = TileObject.NORTH;
        public const int GREEN = TileObject.GREEN, RED = TileObject.RED, WHITE = TileObject.WHITE;

        public TileFacade()
        {
            _tileFactory = new TileFactory();
        }

        public TileObject CreateTile(int value, TileEnums.Suit suit)
        {
            return _tileFactory.CreateTile(value, suit);
        }
    }
}
