using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.DiscardPile
{
    public class StandardDiscardPile : IDiscardPile
    {
        private DataStructures.Stack<TileObject> _displayedDiscardedTiles;
        private List<TileObject> _allDiscardedTiles;

        public StandardDiscardPile()
        {
            _displayedDiscardedTiles = new DataStructures.Stack<TileObject>(30);
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
