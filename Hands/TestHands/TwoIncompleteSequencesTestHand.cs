using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands;

public class TwoIncompleteSequencesTestHand : TestHand
{
    public TwoIncompleteSequencesTestHand()
    {
        _closedTiles = new List<TileObject>
        {
            ThreeMan(), FourMan(),
            FivePin(), FivePin(), FivePin(),
            SevenSou(), SevenSou(), SevenSou(),
            NorthWind(), NorthWind(), NorthWind(),
            SevenMan(), EightMan()
        };
        //Should be one from tenpai
    }
}