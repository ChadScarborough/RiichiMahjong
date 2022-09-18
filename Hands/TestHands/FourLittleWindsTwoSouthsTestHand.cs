using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class FourLittleWindsTwoSouthsTestHand : TestHand
{
    public FourLittleWindsTwoSouthsTestHand()
    {
        _closedTiles = new List<Tile>
        {
            EastWind(), EastWind(), EastWind(),
            SouthWind(), SouthWind(),
            WestWind(), WestWind(), WestWind(),
            NorthWind(), NorthWind(), NorthWind(),
            GreenDragon(), GreenDragon()
        };
    }
}