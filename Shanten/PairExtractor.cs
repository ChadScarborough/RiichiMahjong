using System.Collections.Generic;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten
{
    public class PairExtractor
    {
        public static List<ICompleteHandComponent> ExtractPair(AbstractTileCollection collection)
        {
            List<ICompleteHandComponent> _outputList = new List<ICompleteHandComponent>();
            List<TileObject> tiles = collection.GetTiles();
            if (tiles.Count == 0) return _outputList;

            FindPairsAndExtractThemToNewComponent(collection, _outputList, tiles);
            return _outputList;
        }

        private static void FindPairsAndExtractThemToNewComponent
            (AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles)
        {
            for (int i = collection.GetSize() - 1; i >= 1; i--)
            {
                i = CheckForPair(collection, _outputList, tiles, i);
            }
        }

        private static int CheckForPair
            (AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles, int i)
        {
            if (Functions.AreTilesEquivalent(tiles[i], tiles[i - 1]))
            {
                ExtractPairToNewComponent(collection, _outputList, tiles, i);
                i--;
            }

            return i;
        }

        private static void ExtractPairToNewComponent
            (AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles, int i)
        {
            CreateNewPairAndAddItToOutputList(_outputList, tiles, i);
            RemoveTwoCopiesOfTileFromCollection(collection, tiles, i);
        }

        private static void CreateNewPairAndAddItToOutputList(List<ICompleteHandComponent> _outputList, List<TileObject> tiles, int i)
        {
            List<TileObject> tileList = new List<TileObject> { tiles[i], tiles[i - 1] };
            ICompleteHandComponent pair = CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, Enums.PAIR_COMPONENT);
            _outputList.Add(pair);
        }

        private static void RemoveTwoCopiesOfTileFromCollection(AbstractTileCollection collection, List<TileObject> tiles, int i)
        {
            collection.RemoveTile(tiles[i]);
            collection.RemoveTile(tiles[i - 1]);
        }
    }
}
