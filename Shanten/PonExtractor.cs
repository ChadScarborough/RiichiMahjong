using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;
using RMU.Shanten.HandSplitter;

namespace RMU.Shanten
{
    public static class PonExtractor
    {
        private static List<ICompleteHandComponent> _outputList;
        private static List<TileObject> _tiles;
        private static TileCollection _collection;

        public static List<ICompleteHandComponent> ExtractPon(TileCollection collection)
        {
            InitializeLists(collection);
            if (_tiles.Count == 0) return _outputList;
            FindPonsAndExtractThemToNewComponent();
            return _outputList;
        }

        private static void InitializeLists(TileCollection collection)
        {
            _outputList = new List<ICompleteHandComponent>();
            _tiles = collection.GetTiles();
            _collection = collection;
        }

        private static void FindPonsAndExtractThemToNewComponent()
        {
            for (int i = _collection.GetSize() - 1; i >= 2; i--)
            {
                CheckForPon(ref i);
            }
        }

        private static void CheckForPon(ref int i)
        {
            if (Functions.AreTilesEquivalent(_tiles[i], _tiles[i - 1], _tiles[i - 2]))
            {
                ExtractTilesIntoNewCompleteHandComponentObject(i);
                i -= 2;
            }
        }

        private static void ExtractTilesIntoNewCompleteHandComponentObject(int i)
        {
            TileObject tile = _tiles[i];
            CreateClosedPonObjectAndAddItToOutputList(tile);
            RemoveThreeCopiesOfTileFromCollection(tile);
        }

        private static void CreateClosedPonObjectAndAddItToOutputList(TileObject tile)
        {
            List<TileObject> ponTiles = new List<TileObject> { tile.Clone(), tile.Clone(), tile.Clone() };
            ICompleteHandComponent closedPon = CreateClosedPon(ponTiles);
            _outputList.Add(closedPon);
        }

        private static ICompleteHandComponent CreateClosedPon(List<TileObject> ponTiles)
        {
            Enums.CompleteHandComponentType componentType = Enums.CLOSED_PON;
            ICompleteHandComponent closedPon = CompleteHandGroupFactory.CreateCompleteHandGroup(ponTiles, componentType);
            return closedPon;
        }

        private static void RemoveThreeCopiesOfTileFromCollection(TileObject tile)
        {
            _collection.RemoveTile(tile);
            _collection.RemoveTile(tile);
            _collection.RemoveTile(tile);
        }
    }
}
