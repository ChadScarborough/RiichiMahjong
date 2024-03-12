using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

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