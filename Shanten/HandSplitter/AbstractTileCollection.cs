using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten
{
    public abstract class AbstractTileCollection
    {
        protected List<TileObject> _tiles;

        public virtual List<TileObject> GetTiles()
        {
            return _tiles;
        }

        public virtual void AddTile(TileObject tile)
        {
            _tiles.Add(tile);
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
    }
}
