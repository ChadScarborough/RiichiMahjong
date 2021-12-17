using System.Collections.Generic;
using System;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten
{
    public class SouTileCollection : AbstractTileCollection
    {
        public SouTileCollection(List<TileObject> _tiles)
        {
            SetSuit();
            foreach(TileObject tile in _tiles)
            {
                if(tile.GetSuit() != Enums.SOU)
                {
                    throw new ArgumentException();
                }
            }
            this._tiles = _tiles;
        }

        public SouTileCollection()
        {
            SetSuit();
            _tiles = new List<TileObject>();
        }

        protected override void SetSuit()
        {
            _suit = Enums.SOU;
        }

        public override AbstractTileCollection Clone()
        {
            return new SouTileCollection(GetTiles());
        }
    }
}
