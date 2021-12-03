using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;
using RMU.Hand.CompleteHands.CompleteHandComponents;

namespace RMU.Shanten
{
    public static class ConsecutiveTaatsuExtractor
    {
        public static List<ICompleteHandComponent> ExtractConsecutiveTaatsu(AbstractTileCollection collection)
        {
            List<TileObject> tiles = collection.GetTiles();
            List<ICompleteHandComponent> _outputList = new List<ICompleteHandComponent>();

            for(int i = collection.GetSize() - 1; i >= 1; i--)
            {
                TileObject tileBelow = Functions.GetTileBelow(tiles[i]);
                i = CheckForConsecutiveTaatsu(collection, tiles, _outputList, i, tileBelow);
            }
            return _outputList;
        }

        private static int CheckForConsecutiveTaatsu(AbstractTileCollection collection, List<TileObject> tiles, List<ICompleteHandComponent> _outputList, int i, TileObject tileBelow)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (Functions.AreTilesEquivalent(tileBelow, tiles[j]))
                {
                    List<TileObject> tileList = new List<TileObject> { tiles[j], tiles[i] };
                    ExtractTilesToNewConsecutiveTaatsuComponent(collection, tiles, _outputList, i, j, tileList);
                    i--;
                    break;
                }
            }

            return i;
        }

        private static void ExtractTilesToNewConsecutiveTaatsuComponent(AbstractTileCollection collection, List<TileObject> tiles, List<ICompleteHandComponent> _outputList, int i, int j, List<TileObject> tileList)
        {
            if (tiles[i].GetValue() == 9 || tiles[j].GetValue() == 1)
            {
                CreateConsecutiveTaatsu(collection, tiles, _outputList, i, j, tileList, Enums.INCOMPLETE_SEQUENCE_EDGE_WAIT);
            }
            CreateConsecutiveTaatsu(collection, tiles, _outputList, i, j, tileList, Enums.INCOMPLETE_SEQUENCE_OPEN_WAIT);
        }

        private static void CreateConsecutiveTaatsu(AbstractTileCollection collection, List<TileObject> tiles, List<ICompleteHandComponent> _outputList, int i, int j, List<TileObject> tileList, Enums.CompleteHandComponentType componentType)
        {
            ICompleteHandComponent consecutiveTaatsu = CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, componentType);
            _outputList.Add(consecutiveTaatsu);
            collection.RemoveTile(tiles[j]);
            collection.RemoveTile(tiles[i]);
        }
    }
}
