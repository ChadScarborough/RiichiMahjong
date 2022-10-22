using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class LittleThreeDragonsTwoGreenTestHand : TestHand
{
    public LittleThreeDragonsTwoGreenTestHand()
    {
        _closedTiles = new List<Tile>
        {
            GreenDragon(), GreenDragon(),
            RedDragon(), RedDragon(), RedDragon(),
            WhiteDragon(), WhiteDragon(), WhiteDragon(),
            SevenMan(), EightMan(), NineMan(),
            OneSou(), OneSou()
        };
    }
}