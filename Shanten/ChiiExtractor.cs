using System.Collections.Generic;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Globals;
using static RMU.Globals.Enums;

namespace RMU.Shanten
{
    public static class ChiiExtractor
    {
        private static List<ICompleteHandComponent> _outputList;
        private static List<TileObject> _tiles;
        private static TileCollection _collection;

        public static List<ICompleteHandComponent> ExtractChii(TileCollection collection)
        {
            InitializeLists(collection);
            if (CollectionIsInvalid()) return _outputList;
            FindChiisAndExtractThemToNewComponent();
            return _outputList;
        }

        private static bool CollectionIsInvalid()
        {
            if (_tiles.Count == 0) return true;
            return CollectionIsWindCollection() || CollectionIsDragonCollection();
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
                CheckForChiiContainingTwoGivenTiles(ref i, ref j);
            }
        }

        private static void CheckForChiiContainingTwoGivenTiles( ref int i, ref int j)
        {
            for (int k = j - 1; k >= 0; k--)
            {
                if (CheckForChiiContainingThreeGivenTiles(ref i, ref j, k)) break;
            }
        }

        private static bool CheckForChiiContainingThreeGivenTiles(ref int i, ref int j, int k)
        {
            TileObject oneBelow = Functions.GetTileBelow(_tiles[i]);
            TileObject twoBelow = Functions.GetTileTwoBelow(_tiles[i]);
            return CheckForChii(ref i, ref j, k, oneBelow, twoBelow);
        }

        private static bool CheckForChii(ref int i, ref int j, int k, TileObject oneBelow, TileObject twoBelow)
        {
            if (twoBelow == null) return true;
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

        private static bool TilesFormChii(int j, int k, TileObject oneBelow, TileObject twoBelow)
        {
            return Functions.AreTilesEquivalent(oneBelow, _tiles[j]) && Functions.AreTilesEquivalent(twoBelow, _tiles[k]);
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
            List<TileObject> tileList = new List<TileObject> { _tiles[k], _tiles[j], _tiles[i] };
            return CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, CLOSED_CHII);
        }

        private static void InitializeLists(TileCollection collection)
        {
            _outputList = new List<ICompleteHandComponent>();
            _tiles = collection.GetTiles();
            _collection = collection;
        }
    }
}
