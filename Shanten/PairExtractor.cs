using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Shanten.HandSplitter;
using RMU.Tiles;

namespace RMU.Shanten;

public static class PairExtractor
{
    private static List<Tile> _tiles;
    private static List<ICompleteHandComponent> _outputList;
    private static TileCollection _collection;

    private static readonly object pairLock = new();

    public static List<ICompleteHandComponent> ExtractPair(TileCollection collection)
    {
        lock (pairLock)
        {
            InitializeLists(collection);
            if (_tiles.Count == 0)
            {
                return _outputList;
            }

            FindPairsAndExtractThemToNewComponent();
            return _outputList;
        }
    }

    private static void InitializeLists(TileCollection collection)
    {
        _outputList = new List<ICompleteHandComponent>();
        _tiles = collection.GetTiles();
        _collection = collection;
    }

    private static void FindPairsAndExtractThemToNewComponent()
    {
        for (int i = _collection.GetSize() - 1; i >= 1; i--)
        {
            CheckForPair(ref i);
        }
    }

    private static void CheckForPair(ref int i)
    {
        if (AreTilesEquivalent(_tiles[i], _tiles[i - 1]))
        {
            ExtractPairToNewComponent(i);
            i--;
        }
    }

    private static void ExtractPairToNewComponent(int i)
    {
        CreateNewPairAndAddItToOutputList(i);
        RemoveTwoCopiesOfTileFromCollection(i);
    }

    private static void CreateNewPairAndAddItToOutputList(int i)
    {
        List<Tile> tileList = new() { _tiles[i], _tiles[i - 1] };
        ICompleteHandComponent pair = CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, Enums.PAIR_COMPONENT);
        _outputList.Add(pair);
    }

    private static void RemoveTwoCopiesOfTileFromCollection(int i)
    {
        _collection.RemoveTile(_tiles[i]);
        _collection.RemoveTile(_tiles[i - 1]);
    }
}
