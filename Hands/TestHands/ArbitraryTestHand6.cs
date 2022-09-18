using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class ArbitraryTestHand6 : TestHand
{
    public ArbitraryTestHand6() //Should have shanten value four (5 standard, 4 seven pairs)
    {
        _closedTiles = new List<Tile>
        {
            TwoSou(), SixMan(), EightSou(), FiveSou(), ThreeSou(), EightPin(), ThreePin(),
            SixSou(), ThreeSou(), GreenDragon(), NinePin(), WestWind(), NinePin()
        };
    }
}
