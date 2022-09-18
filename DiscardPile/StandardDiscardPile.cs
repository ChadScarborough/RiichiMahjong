using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.DiscardPile;

public sealed class StandardDiscardPile : IDiscardPile
{
    private readonly Globals.DataStructures.Stack<Tile> _displayedDiscardedTiles;
    private readonly List<Tile> _allDiscardedTiles;

    public StandardDiscardPile()
    {
        _displayedDiscardedTiles = new Globals.DataStructures.Stack<Tile>();
        _allDiscardedTiles = new List<Tile>();
    }

    public void DiscardTile(Tile tile)
    {
        _displayedDiscardedTiles.Push(tile);
        _allDiscardedTiles.Add(tile);
    }

    public Tile CallTile()
    {
        return _displayedDiscardedTiles.Pop();
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
