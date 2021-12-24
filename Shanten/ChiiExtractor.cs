using System.Collections.Generic;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Shanten
{
    public static class ChiiExtractor
    {
        public static List<ICompleteHandComponent> ExtractChii(AbstractTileCollection collection)
        {
            List<ICompleteHandComponent> _outputList;
            List<TileObject> tiles;
            InitializeLists(collection, out _outputList, out tiles);

            FindChiisAndExtractThemToNewComponent(collection, _outputList, tiles);
            return _outputList;
        }

        private static void FindChiisAndExtractThemToNewComponent
            (AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles)
        {
            for (int i = collection.GetSize() - 1; i >= 2; i--)
            {
                i = CheckForChiiContainingGivenTile(collection, _outputList, tiles, i);
            }
        }

        private static int CheckForChiiContainingGivenTile(AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles, int i)
        {
            for (int j = i - 1; j >= 1; j--)
            {
                CheckForChiiContainingTwoGivenTiles(collection, _outputList, tiles, ref i, ref j);
            }
            return i;
        }

        private static void CheckForChiiContainingTwoGivenTiles(AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles, ref int i, ref int j)
        {
            for (int k = j - 1; k >= 0; k--)
            {
                TileObject oneBelow = Functions.GetTileBelow(tiles[i]);
                TileObject twoBelow = Functions.GetTileTwoBelow(tiles[i]);
                if (TilesFormChii(tiles, j, k, oneBelow, twoBelow))
                {
                    ExtractTilesIntoNewCompleteHandComponentObject(collection, _outputList, tiles, i, j, k);
                    i -= 3;
                    j = i;
                    break;
                }
            }
        }

        private static bool TilesFormChii(List<TileObject> tiles, int j, int k, TileObject oneBelow, TileObject twoBelow)
        {
            return Functions.AreTilesEquivalent(oneBelow, tiles[j]) && Functions.AreTilesEquivalent(twoBelow, tiles[k]);
        }

        private static void ExtractTilesIntoNewCompleteHandComponentObject
            (AbstractTileCollection collection, List<ICompleteHandComponent> _outputList, List<TileObject> tiles, int i, int j, int k)
        {
            ICompleteHandComponent closedChii = CreateClosedChii(tiles, i, j, k);
            _outputList.Add(closedChii);
            RemoveTilesFromCollection(collection, tiles, i, j, k);
        }

        private static void RemoveTilesFromCollection(AbstractTileCollection collection, List<TileObject> tiles, int i, int j, int k)
        {
            collection.RemoveTile(tiles[i]);
            collection.RemoveTile(tiles[j]);
            collection.RemoveTile(tiles[k]);
        }

        private static ICompleteHandComponent CreateClosedChii(List<TileObject> tiles, int i, int j, int k)
        {
            List<TileObject> tileList = new List<TileObject> { tiles[k], tiles[j], tiles[i] };
            return CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, Enums.CLOSED_CHII);
        }

        private static void InitializeLists
            (AbstractTileCollection collection, out List<ICompleteHandComponent> _outputList, out List<TileObject> tiles)
        {
            _outputList = new List<ICompleteHandComponent>();
            tiles = collection.GetTiles();
        }
    }
}
