using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Shanten
{
    public abstract class AbstractTileCollection
    {
        protected List<TileObject> _tiles;

        public virtual List<TileObject> GetCollection()
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
    }
}
