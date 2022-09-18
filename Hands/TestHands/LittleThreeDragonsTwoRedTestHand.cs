using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class LittleThreeDragonsTwoRedTestHand : TestHand
{
    public LittleThreeDragonsTwoRedTestHand()
    {
        _closedTiles = new List<Tile>
        {
            GreenDragon(), GreenDragon(), GreenDragon(),
            RedDragon(), RedDragon(),
            WhiteDragon(), WhiteDragon(), WhiteDragon(),
            SevenMan(), EightMan(), NineMan(),
            OneSou(), OneSou()
        };
    }
}