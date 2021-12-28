using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using static RMU.Globals.Enums;

namespace RMU.Shanten
{
    public static class ConsecutiveTaatsuExtractor
    {
        private static List<TileObject> _tiles;
        private static List<ICompleteHandComponent> _outputList;
        private static TileCollection _collection;

        public static List<ICompleteHandComponent> ExtractConsecutiveTaatsu(TileCollection collection)
        {
            InitializeLists(collection);
            if (CollectionIsInvalid()) return _outputList;
            CheckCollectionForConsecutiveTaatus();
            return _outputList;
        }

        private static void CheckCollectionForConsecutiveTaatus()
        {
            for (int i = _collection.GetSize() - 1; i >= 1; i--)
            {
                TileObject tileBelow = Functions.GetTileBelow(_tiles[i]);
                CheckForConsecutiveTaatsu(ref i, tileBelow);
            }
        }

        private static void InitializeLists(TileCollection collection)
        {
            _tiles = collection.GetTiles();
            _outputList = new List<ICompleteHandComponent>();
            _collection = collection;
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

        private static void CheckForConsecutiveTaatsu(ref int i, TileObject tileBelow)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if(TilesFormConsecutiveTaatsu(ref i, j, tileBelow)) break;
            }
        }

        private static bool TilesFormConsecutiveTaatsu(ref int i, int j, TileObject tileBelow)
        {
            if (Functions.AreTilesEquivalent(tileBelow, _tiles[j]))
            {
                List<TileObject> tileList = new List<TileObject> { _tiles[j], _tiles[i] };
                ExtractTilesToNewConsecutiveTaatsuComponent(i, j, tileList);
                i -= 1;
                return true;
            }
            return false;
        }

        private static void ExtractTilesToNewConsecutiveTaatsuComponent(int i, int j, List<TileObject> tileList)
        {
            if (ConsecutiveTaatsuContainsTerminalTile(i, j))
            {
                CreateConsecutiveTaatsu(i, j, tileList, INCOMPLETE_SEQUENCE_EDGE_WAIT);
                return;
            }
            CreateConsecutiveTaatsu(i, j, tileList, INCOMPLETE_SEQUENCE_OPEN_WAIT);
        }

        private static bool ConsecutiveTaatsuContainsTerminalTile(int i, int j)
        {
            return _tiles[i].GetValue() == 9 || _tiles[j].GetValue() == 1;
        }

        private static void CreateConsecutiveTaatsu(int i, int j, List<TileObject> tileList, CompleteHandComponentType componentType)
        {
            ICompleteHandComponent consecutiveTaatsu = CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, componentType);
            _outputList.Add(consecutiveTaatsu);
            ExtractTiles(i, j);
        }

        private static void ExtractTiles(int i, int j)
        {
            _collection.RemoveTile(_tiles[i]);
            _collection.RemoveTile(_tiles[j]);
        }
    }
}
