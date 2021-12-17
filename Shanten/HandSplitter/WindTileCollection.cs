using System.Collections.Generic;
using System;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten
{
    public class WindTileCollection : AbstractTileCollection
    {
        public WindTileCollection(List<TileObject> _tiles)
        {
            SetSuit();
            foreach(TileObject tile in _tiles)
            {
                if(tile.GetSuit() != Enums.WIND)
                {
                    throw new ArgumentException();
                }
            }
            this._tiles = _tiles;
        }

        public WindTileCollection()
        {
            SetSuit();
            _tiles = new List<TileObject>();
        }

        protected override void SetSuit()
        {
            _suit = Enums.WIND;
        }

        public override AbstractTileCollection Clone()
        {
            return new WindTileCollection(GetTiles());
        }
    }
}
