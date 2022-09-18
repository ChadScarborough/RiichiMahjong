using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class LittleThreeDragonsTwoWhiteTestHand : TestHand
{
    public LittleThreeDragonsTwoWhiteTestHand()
    {
        _closedTiles = new List<Tile>
        {
            RedDragon(), RedDragon(), RedDragon(),
            GreenDragon(), GreenDragon(), GreenDragon(),
            WhiteDragon(), WhiteDragon(),
            SevenMan(), EightMan(), NineMan(),
            OneSou(), OneSou()
        };
    }
}