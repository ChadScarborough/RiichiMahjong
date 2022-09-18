using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class ArbitraryTestHand8 : TestHand
{
    public ArbitraryTestHand8() //Should have shanten value five
    {
        _closedTiles = new List<Tile>
        {
            NineSou(), EightSou(), FiveMan(), EightPin(), GreenDragon(), SevenSou(),
            SouthWind(), SevenMan(), FivePin(), EightMan(), WhiteDragon(), ThreeSou(), TwoMan()
        };
    }
}
