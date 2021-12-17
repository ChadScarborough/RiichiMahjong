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
            List<TileObject> tiles = collection.GetTiles();
            List<ICompleteHandComponent> _outputList = new List<ICompleteHandComponent>();

            for (int i = collection.GetSize() - 1; i >= 1; i--)
            {
                TileObject tileTwoBelow = Functions.GetTileTwoBelow(tiles[i]);
                for(int j = i - 1; j >= 0; j--)
                {
                    if(Functions.AreTilesEquivalent(tileTwoBelow, tiles[j]))
                    {
                        List<TileObject> tileList = new List<TileObject> { tiles[j], tiles[i] };
                        ICompleteHandComponent nonconsecutiveTaatsu = CompleteHandComponentFactory.CreateCompleteHandComponent(tileList, Enums.INCOMPLETE_SEQUENCE_CLOSED_WAIT);
                        _outputList.Add(nonconsecutiveTaatsu);
                        collection.RemoveTile(tiles[j]);
                        collection.RemoveTile(tiles[i]);
                        i--;
                        break;
                    }
                }
            }
            return _outputList;
        }
    }
}
