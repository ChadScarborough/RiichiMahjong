using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Tiles
{
    public class WindTileFactory
    {
        public WindTileObject CreateTile(int value, Enums.Suit suit)
        {
            if(value >= TileObject.EAST && value <= TileObject.NORTH)
            {
                return new WindTileObject(value, suit);
            }
            throw new ArgumentException();
        }
    }
}
