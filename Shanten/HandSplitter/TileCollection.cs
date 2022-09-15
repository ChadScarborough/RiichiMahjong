using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten.HandSplitter
{
    public class TileCollection
    {
        private List<Tile> _tiles;
        private Enums.Suit _suit;

        public TileCollection(Enums.Suit suit)
        {
            _tiles = new List<Tile>();
            SetSuit(suit);
        }

        public TileCollection(Enums.Suit suit, List<Tile> tiles)
        {
            SetSuit(suit);
            _tiles = new List<Tile>();
            foreach(Tile tile in tiles)
            {
                AddTile(tile);
            }
        }

        public virtual List<Tile> GetTiles()
        {
            return _tiles;
        }

        public void AddTile(Tile tile)
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

        public void RemoveTile(Tile tile)
        {
            foreach(Tile t in _tiles)
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
            foreach(Tile tile in GetTiles())
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
