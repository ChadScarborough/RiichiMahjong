using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class ArbitraryTestHand9 : TestHand
{
    public ArbitraryTestHand9() //Should have shanten value three
    {
        _closedTiles = new List<Tile>
        {
            SouthWind(), FiveMan(), ThreeSou(), FourMan(), SevenMan(), EightPin(), FivePin(),
            TwoSou(), TwoSou(), TwoPin(), ThreePin(), TwoSou(), SixMan()
        };
    }
}
