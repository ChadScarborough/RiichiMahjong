using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten
{
    public abstract class AbstractTileCollection
    {
        protected List<TileObject> _tiles;
        protected Enums.Suit _suit;

        public virtual List<TileObject> GetTiles()
        {
            return _tiles;
        }

        public void AddTile(TileObject tile)
        {
            if(tile.GetSuit() == _suit)
            {
                _tiles.Add(tile);
                return;
            }
            throw new System.ArgumentException();
        }

        public void Clear()
        {
            _tiles.Clear();
        }

        public int GetSize()
        {
            return _tiles.Count;
        }

        public void RemoveTile(TileObject tile)
        {
            foreach(TileObject t in _tiles)
            {
                if(Functions.AreTilesEquivalent(t, tile))
                {
                    _tiles.Remove(t);
                    return;
                }
            }
        }

        public abstract AbstractTileCollection Clone();

        protected abstract void SetSuit();
    }
}
