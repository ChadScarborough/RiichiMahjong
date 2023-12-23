using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.DiscardPile;

public sealed class StandardDiscardPile : IDiscardPile
{
    private readonly Globals.DataStructures.Stack<Tile> _displayedDiscardedTiles;
    private readonly List<Tile> _allDiscardedTiles;

    public event EventHandler OnDiscardPileChanged;

    public StandardDiscardPile()
    {
        _displayedDiscardedTiles = new Globals.DataStructures.Stack<Tile>();
        _allDiscardedTiles = new List<Tile>();
    }

    public void DiscardTile(Tile tile)
    {
        _displayedDiscardedTiles.Push(tile);
        _allDiscardedTiles.Add(tile);
        OnDiscardPileChanged?.Invoke(this, EventArgs.Empty);
    }

    public Tile CallTile()
    {
        Tile t = _displayedDiscardedTiles.Pop();
        OnDiscardPileChanged?.Invoke(this, EventArgs.Empty);
        return t;
    }

    public int GetDisplayedTileCount()
    {
        return _displayedDiscardedTiles.GetSize();
    }

    public int GetTotalDiscardedCount()
    {
        return _allDiscardedTiles.Count;
    }

    public List<Tile> GetDisplayedDiscardedTiles()
    {
        List<Tile> outputList = new();
        foreach (Tile tile in _displayedDiscardedTiles)
        {
            outputList.Add(tile);
        }
        return outputList;
    }
}
