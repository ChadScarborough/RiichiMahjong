using System.Collections.Generic;
using System;
using RMU.Tiles;
using RMU.Globals;
using static RMU.Globals.Algorithms.CountingSortForCollections;

namespace RMU.Shanten
{
    public class DragonTileCollection : AbstractTileCollection
    {
        public DragonTileCollection(List<TileObject> _tiles)
        {
            SetSuit();
            foreach(TileObject tile in _tiles)
            {
                if(tile.GetSuit() != Enums.DRAGON)
                {
                    throw new ArgumentException();
                }
            }
            this._tiles = _tiles;
        }

        public DragonTileCollection()
        {
            SetSuit();
            _tiles = new List<TileObject>();
        }

        protected override void SetSuit()
        {
            _suit = Enums.DRAGON;
        }

        public override AbstractTileCollection Clone()
        {
            return new DragonTileCollection(GetTiles());
        }
    }
}
