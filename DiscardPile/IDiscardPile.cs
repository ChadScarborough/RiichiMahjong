using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.DiscardPile
{
    public interface IDiscardPile
    {
        TileObject CallTile();
        void DiscardTile(TileObject tile);
        int GetDisplayedTileCount();
        int GetTotalDiscardedCount();
        List<TileObject> GetDisplayedDiscardedTiles();
    }
}