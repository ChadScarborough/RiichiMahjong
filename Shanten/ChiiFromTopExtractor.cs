using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Shanten.HandSplitter;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Shanten;

public static class ChiiFromTopExtractor
{
    private static List<ICompleteHandComponent> _outputList;
    private static List<Tile> _tiles;
    private static TileCollection _collection;

    private static readonly object chiiLock = new();

    public static List<ICompleteHandComponent> ExtractChii(TileCollection collection)
    {
        lock (chiiLock)
        {
            InitializeLists(collection);
            if (CollectionIsInvalid())
            {
                return _outputList;
            }

            FindChiisAndExtractThemToNewComponent();
            return _outputList;
        }
    }

    private static bool CollectionIsInvalid()
    {
        return _tiles.Count == 0 || CollectionIsWindCollection() || CollectionIsDragonCollection();
    }

    private static bool CollectionIsDragonCollection()
    {
        return _collection.GetSuit() == DRAGON;
    }

    private static bool CollectionIsWindCollection()
    {
        return _collection.GetSuit() == WIND;
    }

    private static void FindChiisAndExtractThemToNewComponent()
    {
        for (int i = _collection.GetSize() - 1; i >= 2; i--)
        {
            CheckForChiiContainingGivenTile(ref i);
        }
    }

    private static void CheckForChiiContainingGivenTile(ref int i)
    {
        for (int j = i - 1; j >= 1; j--)
        {
            if (AreTilesConsecutive(j, i) == false)
            {
                break;
            }

            CheckForChiiContainingTwoGivenTiles(ref i, ref j);
        }
    }

    private static void CheckForChiiContainingTwoGivenTiles(ref int i, ref int j)
    {
        for (int k = j - 1; k >= 0; k--)
        {
            if (AreTilesConsecutive(k, j) == false)
            {
                break;
            }

            if (CheckForChiiContainingThreeGivenTiles(ref i, ref j, k))
            {
                break;
            }
        }
    }

    private static bool CheckForChiiContainingThreeGivenTiles(ref int i, ref int j, int k)
    {
        Tile oneBelow = GetTileBelow(_tiles[i]);
        Tile twoBelow = GetTileTwoBelow(_tiles[i]);
        return CheckForChii(ref i, ref j, k, oneBelow, twoBelow);
    }

    private static bool CheckForChii(ref int i, ref int j, int k, Tile oneBelow, Tile twoBelow)
    {
        if (twoBelow == null)
        {
            return true;
        }

        if (TilesFormChii(j, k, oneBelow, twoBelow))
        {
            ExtractTilesIntoNewCompleteHandComponentObject(i, j, k);
            SetNewCounterValues(ref i, ref j);
            return true;
        }
        return false;
    }

    private static void SetNewCounterValues(ref int i, ref int j)
    {
        i -= 3;
        j = i;
    }

    private static bool TilesFormChii(int j, int k, Tile oneBelow, Tile twoBelow)
    {
        return AreTilesEquivalent(oneBelow, _tiles[j]) && AreTilesEquivalent(twoBelow, _tiles[k]);
    }

    private static void ExtractTilesIntoNewCompleteHandComponentObject(int i, int j, int k)
    {
        ICompleteHandComponent closedChii = CreateClosedChii(i, j, k);
        _outputList.Add(closedChii);
        RemoveTilesFromCollection(i, j, k);
    }

    private static void RemoveTilesFromCollection(int i, int j, int k)
    {
        _collection.RemoveTile(_tiles[i]);
        _collection.RemoveTile(_tiles[j]);
        _collection.RemoveTile(_tiles[k]);
    }

    private static ICompleteHandComponent CreateClosedChii(int i, int j, int k)
    {
        List<Tile> tileList = new() { _tiles[k], _tiles[j], _tiles[i] };
        return CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, CLOSED_CHII);
    }

    private static void InitializeLists(TileCollection collection)
    {
        _outputList = new List<ICompleteHandComponent>();
        _tiles = collection.GetTiles();
        _collection = collection;
    }

    private static bool AreTilesConsecutive(int lower, int upper)
    {
        return _tiles[lower].GetValue() >= _tiles[upper].GetValue() - 1;
    }
}
