using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class TwoIncompleteSequencesTestHand : TestHand
{
    public TwoIncompleteSequencesTestHand()
    {
        _closedTiles = new List<Tile>
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