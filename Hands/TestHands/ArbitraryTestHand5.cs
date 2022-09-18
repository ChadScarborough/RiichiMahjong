using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class ArbitraryTestHand5 : TestHand
{
    public ArbitraryTestHand5() //Should have shanten value three
    {
        _closedTiles = new List<Tile>
        {
            SevenMan(), SevenSou(), SixSou(), SouthWind(), EightMan(), GreenDragon(), SixMan(),
            SevenMan(), SixSou(), FiveSou(), EightMan(), FivePin(), TwoSou()
        };
    }
}
