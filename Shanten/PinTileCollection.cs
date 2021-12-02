using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;

namespace RMU.Shanten
{
    public class PinTileCollection : AbstractTileCollection
    {
        public PinTileCollection(List<TileObject> _tiles)
        {
            this._tiles = _tiles;
        }
    }
}
