using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands;

public class ThirteenOrphansThirteenWaitTestHand : TestHand
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