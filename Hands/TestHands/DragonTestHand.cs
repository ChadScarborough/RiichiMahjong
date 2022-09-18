using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

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
