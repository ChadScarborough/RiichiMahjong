using RMU.Tiles;

namespace RMU.Shanten.HandSplitter;

public sealed class TileCollection
{
    private readonly List<Tile> _tiles;
    private Suit _suit;

    public TileCollection(Suit suit)
    {
        _tiles = new List<Tile>();
        SetSuit(suit);
    }

    public TileCollection(Suit suit, List<Tile> tiles)
    {
        SetSuit(suit);
        _tiles = new List<Tile>();
        foreach (Tile tile in tiles)
        {
            AddTile(tile);
        }
    }

    public List<Tile> GetTiles()
    {
        return _tiles;
    }

    public void AddTile(Tile tile)
    {
        if (tile.GetSuit() == GetSuit())
        {
            _tiles.Add(tile.Clone());
            return;
        }
        throw new System.ArgumentException("Invalid suit");
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
        foreach (Tile t in _tiles)
        {
            if (AreTilesEquivalent(t, tile))
            {
                _ = _tiles.Remove(t);
                return;
            }
        }
    }

    public TileCollection Clone()
    {
        TileCollection tc = new(_suit);
        foreach (Tile tile in GetTiles())
        {
            tc.AddTile(tile);
        }
        return tc;
    }

    private void SetSuit(Suit suit)
    {
        _suit = suit;
    }

    public Suit GetSuit()
    {
        return _suit;
    }
}
