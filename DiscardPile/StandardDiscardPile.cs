using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.DiscardPile
{
    public class StandardDiscardPile : IDiscardPile
    {
        private readonly Globals.DataStructures.Stack<TileObject> _displayedDiscardedTiles;
        private readonly List<TileObject> _allDiscardedTiles;

        public StandardDiscardPile()
        {
            _displayedDiscardedTiles = new Globals.DataStructures.Stack<TileObject>();
            _allDiscardedTiles = new List<TileObject>();
        }

        public void DiscardTile(TileObject tile)
        {
            _displayedDiscardedTiles.Push(tile);
            _allDiscardedTiles.Add(tile);
        }

        public TileObject CallTile()
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
    }
}
