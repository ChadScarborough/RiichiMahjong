using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class ArbitraryTestHand4 : TestHand
{
    public ArbitraryTestHand4() //Should have shanten value three
    {
        _closedTiles = new List<Tile>
        {
            TwoPin(), FourMan(), TwoPin(), TwoPin(), NineSou(), EightSou(), SouthWind(),
            SevenMan(), OneSou(), FourPin(), SixMan(), EightPin(), FourMan()
        };
    }
}
