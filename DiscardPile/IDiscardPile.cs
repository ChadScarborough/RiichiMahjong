using RMU.Tiles;

namespace RMU.DiscardPile
{
    public interface IDiscardPile
    {
        TileObject CallTile();
        void DiscardTile(TileObject tile);
        int GetDisplayedTileCount();
        int GetTotalDiscardedCount();
    }
}