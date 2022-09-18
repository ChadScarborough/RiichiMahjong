using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.DiscardPile;

public interface IDiscardPile
{
    Tile CallTile();
    void DiscardTile(Tile tile);
    int GetDisplayedTileCount();
    int GetTotalDiscardedCount();
    List<Tile> GetDisplayedDiscardedTiles();
}