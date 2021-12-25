using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;
using RMU.Hand.CompleteHands.CompleteHandComponents;

namespace RMU.Shanten
{
    public static class NonconsecutiveTaatsuExtractor
    {
        public static List<ICompleteHandComponent> ExtractNonconsecutiveTaatsu(AbstractTileCollection collection)
        {
            List<TileObject> _tiles = collection.GetTiles();
            if (_tiles.Count == 0) return new List<ICompleteHandComponent>();
            if (_tiles[0].IsHonor()) return new List<ICompleteHandComponent>();
            List<ICompleteHandComponent> _outputList = new List<ICompleteHandComponent>();

            for (int i = collection.GetSize() - 1; i >= 1; i--)
            {
                TileObject tileTwoBelow = Functions.GetTileTwoBelow(_tiles[i]);
                for(int j = i - 1; j >= 0; j--)
                {
                    if(Functions.AreTilesEquivalent(tileTwoBelow, _tiles[j]))
                    {
                        List<TileObject> tileList = new List<TileObject> { _tiles[j], _tiles[i] };
                        ICompleteHandComponent nonconsecutiveTaatsu = CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, Enums.INCOMPLETE_SEQUENCE_CLOSED_WAIT);
                        _outputList.Add(nonconsecutiveTaatsu);
                        collection.RemoveTile(_tiles[i]);
                        collection.RemoveTile(_tiles[j]);
                        i--;
                        break;
                    }
                }
            }
            return _outputList;
        }
    }
}
