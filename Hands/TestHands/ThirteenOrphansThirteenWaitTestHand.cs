using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class ThirteenOrphansThirteenWaitTestHand : TestHand
{
    public ThirteenOrphansThirteenWaitTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), NineMan(),
            OnePin(), NinePin(),
            OneSou(), NineSou(),
            EastWind(), SouthWind(),
            WestWind(), NorthWind(),
            GreenDragon(),
            RedDragon(),
            WhiteDragon()
        };
    }
}