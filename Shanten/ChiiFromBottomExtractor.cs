using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Shanten.HandSplitter;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;


namespace RMU.Shanten
{
    public static class ChiiFromBottomExtractor
    {
        private static List<ICompleteHandComponent> _outputList;
        private static List<Tile> _tiles;
        private static TileCollection _collection;
        private static bool _foundChii;
        
        public static List<ICompleteHandComponent> ExtractChii(TileCollection collection)
        {
            InitializeLists(collection);
            if (CollectionIsInvalid()) return _outputList;

            FindChiisAndExtractThemToNewComponent();
            
            return _outputList;
        }

        private static void FindChiisAndExtractThemToNewComponent()
        {
            _foundChii = false;
            CheckForChii();
            if(_foundChii) FindChiisAndExtractThemToNewComponent();
        }

        private static void CheckForChii()
        {
            for (int i = 0; i < _tiles.Count - 2; i++)
            {
                CheckForChiiWithGivenBottomTile(i);
                if (_foundChii) break;
            }
        }

        private static void CheckForChiiWithGivenBottomTile(int i)
        {
            for (int j = i + 1; j < _tiles.Count - 1; j++)
            {
                if (AreTilesConsecutive(i, j) == false) break;
                CheckForChiiWithGivenBottomTwoTiles(i, j);
                if (_foundChii) break;
            }
        }

        private static void CheckForChiiWithGivenBottomTwoTiles(int i, int j)
        {
            for (int k = j + 1; k < _tiles.Count; k++)
            {
                if (AreTilesConsecutive(j, k) == false) break;
                if (TilesFormChii(i, j, k))
                {
                    CreateChiiComponent(i, j, k);
                }
                if (_foundChii) break;
            }
        }

        private static void CreateChiiComponent(int i, int j, int k)
        {
            _foundChii = true;
            CreateComponentAndAddComponentToOutputList(i, j, k);
            ExtractTilesFromCollection(k, j, i);
        }

        private static void CreateComponentAndAddComponentToOutputList(int i, int j, int k)
        {
            List<Tile> tileList = new List<Tile> {_tiles[i], _tiles[j], _tiles[k]};
            ICompleteHandComponent closedChii =
                CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, CLOSED_CHII);
            _outputList.Add(closedChii);
        }

        private static bool TilesFormChii(int i, int j, int k)
        {
            
            Tile oneAbove = GetTileAbove(_tiles[i]);
            Tile twoAbove = GetTileTwoAbove(_tiles[i]);
            return AreTilesEquivalent(_tiles[j], oneAbove) && AreTilesEquivalent(_tiles[k], twoAbove);
        }

        private static void ExtractTilesFromCollection(int k, int j, int i)
        {
            _collection.RemoveTile(_tiles[k]);
            _collection.RemoveTile(_tiles[j]);
            _collection.RemoveTile(_tiles[i]);
        }

        private static void InitializeLists(TileCollection collection)
        {
            _outputList = new List<ICompleteHandComponent>();
            _tiles = collection.GetTiles();
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

        private static bool AreTilesConsecutive(int lower, int upper)
        {
            if (_tiles[lower].GetValue() == _tiles[upper].GetValue() - 1)
            {
                return true;
            }

            return false;
        }
    }
}