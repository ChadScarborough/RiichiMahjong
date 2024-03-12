using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.DiscardPile;

public interface IDiscardPile
{

    public event EventHandler OnTileDiscarded;
    public event EventHandler OnDiscardTileCalled;
    Tile CallTile();
    void DiscardTile(Tile tile);
    int GetDisplayedTileCount();
    int GetTotalDiscardedCount();
    List<Tile> GetDisplayedDiscardedTiles();
}