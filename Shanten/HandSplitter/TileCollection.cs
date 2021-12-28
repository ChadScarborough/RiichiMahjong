using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten
{
    public class TileCollection
    {
        private List<TileObject> _tiles;
        private Enums.Suit _suit;

        public TileCollection(Enums.Suit suit)
        {
            _tiles = new List<TileObject>();
            SetSuit(suit);
        }

        public TileCollection(Enums.Suit suit, List<TileObject> tiles)
        {
            SetSuit(suit);
            _tiles = new List<TileObject>();
            foreach(TileObject tile in tiles)
            {
                AddTile(tile);
            }
        }

        public virtual List<TileObject> GetTiles()
        {
            return _tiles;
        }

        public void AddTile(TileObject tile)
        {
            if(tile.GetSuit() == this.GetSuit())
            {
                _tiles.Add(tile.Clone());
                return;
            }
            throw new System.ArgumentException();
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

        public TileCollection Clone()
        {
            TileCollection tc = new TileCollection(_suit);
            foreach(TileObject tile in GetTiles())
            {
                tc.AddTile(tile);
            }
            return tc;
        }

        private void SetSuit(Enums.Suit suit)
        {
            _suit = suit;
        }

        public Enums.Suit GetSuit()
        {
            return _suit;
        }
    }
}
