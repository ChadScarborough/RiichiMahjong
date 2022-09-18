using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class FourBigWindsTestHand : TestHand
{
    public FourBigWindsTestHand()
    {
        _closedTiles = new List<Tile>
        {
            EastWind(), EastWind(), EastWind(),
            SouthWind(), SouthWind(), SouthWind(),
            WestWind(), WestWind(), WestWind(),
            NorthWind(), NorthWind(), NorthWind(),
            GreenDragon()
        };
    }
}