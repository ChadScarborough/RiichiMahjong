using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

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