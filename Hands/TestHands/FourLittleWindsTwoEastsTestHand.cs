using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class FourLittleWindsTwoEastsTestHand : TestHand
{
    public FourLittleWindsTwoEastsTestHand()
    {
        _closedTiles = new List<Tile>
        {
            EastWind(), EastWind(),
            SouthWind(), SouthWind(), SouthWind(),
            WestWind(), WestWind(), WestWind(),
            NorthWind(), NorthWind(), NorthWind(),
            GreenDragon(), GreenDragon()
        };
    }
}