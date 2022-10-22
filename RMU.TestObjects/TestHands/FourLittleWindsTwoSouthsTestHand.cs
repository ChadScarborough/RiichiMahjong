using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

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