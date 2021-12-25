using System.Collections.Generic;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten
{
    public class PairExtractor
    {
        private static List<TileObject> _tiles;
        private static List<ICompleteHandComponent> _outputList;
        private static AbstractTileCollection _collection;

        public static List<ICompleteHandComponent> ExtractPair(AbstractTileCollection collection)
        {
            InitializeLists(collection);
            if (_tiles.Count == 0) return _outputList;
            FindPairsAndExtractThemToNewComponent();
            return _outputList;
        }

        private static void InitializeLists(AbstractTileCollection collection)
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
            if (Functions.AreTilesEquivalent(_tiles[i], _tiles[i - 1]))
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
            List<TileObject> tileList = new List<TileObject> { _tiles[i], _tiles[i - 1] };
            ICompleteHandComponent pair = CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, Enums.PAIR_COMPONENT);
            _outputList.Add(pair);
        }

        private static void RemoveTwoCopiesOfTileFromCollection(int i)
        {
            _collection.RemoveTile(_tiles[i]);
            _collection.RemoveTile(_tiles[i - 1]);
        }
    }
}
