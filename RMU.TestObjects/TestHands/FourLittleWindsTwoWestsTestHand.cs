using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class FourLittleWindsTwoWestsTestHand : TestHand
{
    public FourLittleWindsTwoWestsTestHand()
    {
        _closedTiles = new List<Tile>
        {
            EastWind(), EastWind(), EastWind(),
            SouthWind(), SouthWind(), SouthWind(),
            WestWind(), WestWind(),
            NorthWind(), NorthWind(), NorthWind(),
            GreenDragon(), GreenDragon()
        };
    }
}