using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Globals;
using RMU.Algorithms;
using System.Collections.Generic;

namespace RMU.Shanten
{
    public static class PonExtractor
    {
        private static HandSorter _handSorter = new HandSorter();

        public static List<ICompleteHandComponent> ExtractPon(AbstractTileCollection collection)
        {
            List<ICompleteHandComponent> _outputList;
            List<TileObject> tiles;
            InitializeLists(collection, out _outputList, out tiles);

            FindPonsAndExtractThemToNewComponent(collection, _outputList, tiles);
            return _outputList;
        }

        private static void InitializeLists
            (AbstractTileCollection collection, out List<ICompleteHandComponent> _outputList, out List<TileObject> tiles)
        {
            _outputList = new List<ICompleteHandComponent>();
            tiles = collection.GetTiles();
            tiles = SortTiles(tiles);
        }

        private static List<TileObject> SortTiles(List<TileObject> tiles)
        {
            tiles = _handSorter.SortHand(tiles);
            return tiles;
        }

        private static void FindPonsAndExtractThemToNewComponent
            (AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles)
        {
            for (int i = collection.GetSize() - 1; i >= 2; i--)
            {
                i = CheckForPon(collection, _outputList, tiles, i);
            }
        }

        private static int CheckForPon
            (AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles, int i)
        {
            if (Functions.AreTilesEquivalent(tiles[i], tiles[i - 1], tiles[i - 2]))
            {
                ExtractTilesIntoNewCompleteHandComponentObject(collection, _outputList, tiles, i);
                i -= 2;
            }

            return i;
        }

        private static void ExtractTilesIntoNewCompleteHandComponentObject
            (AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles, int i)
        {
            TileObject t = tiles[i];
            CreateClosedPonObjectAndAddItToOutputList(_outputList, t);
            RemoveThreeCopiesOfTileFromCollection(collection, t);
        }

        private static void CreateClosedPonObjectAndAddItToOutputList(List<ICompleteHandComponent> _outputList, TileObject t)
        {
            List<TileObject> ponTiles = new List<TileObject> { t, t, t };
            ICompleteHandComponent closedPon = CreateClosedPon(ponTiles);
            _outputList.Add(closedPon);
        }

        private static ICompleteHandComponent CreateClosedPon(List<TileObject> ponTiles)
        {
            Enums.CompleteHandComponentType componentType = Enums.CLOSED_PON;
            ICompleteHandComponent closedPon = CompleteHandGroupFactory.CreateCompleteHandGroup(ponTiles, componentType);
            return closedPon;
        }

        private static void RemoveThreeCopiesOfTileFromCollection(AbstractTileCollection collection, TileObject tile)
        {
            collection.RemoveTile(tile);
            collection.RemoveTile(tile);
            collection.RemoveTile(tile);
        }
    }
}
