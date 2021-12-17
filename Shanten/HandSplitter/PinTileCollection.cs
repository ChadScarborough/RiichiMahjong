using System.Collections.Generic;
using System;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten
{
    public class PinTileCollection : AbstractTileCollection
    {
        public PinTileCollection(List<TileObject> _tiles)
        {
            SetSuit();
            foreach(TileObject tile in _tiles)
            {
                if(tile.GetSuit() != Enums.PIN)
                {
                    throw new ArgumentException();
                }
            }
            this._tiles = _tiles;
        }

        protected override void SetSuit()
        {
            _suit = Enums.PIN;
        }

        public override AbstractTileCollection Clone()
        {
            return new PinTileCollection(GetTiles());
        }

        public PinTileCollection()
        {
            SetSuit();
            _tiles = new List<TileObject>();
        }
    }
}
