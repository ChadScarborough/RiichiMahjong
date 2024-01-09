using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class DragonTestHand : TestHand
{
    public DragonTestHand()
    {
        _closedTiles = new List<Tile>
        {
            GreenDragon(), GreenDragon(), GreenDragon(),
            RedDragon(), RedDragon(), RedDragon(),
            WhiteDragon(), WhiteDragon(), WhiteDragon(),
            EastWind(), EastWind(), EastWind(),
            SouthWind()
        };
    }
}
