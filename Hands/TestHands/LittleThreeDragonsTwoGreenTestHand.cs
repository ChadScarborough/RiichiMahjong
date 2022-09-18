using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

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