using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands;

public class ThirteenOrphansSingleWaitTestHand : TestHand
{
    public ThirteenOrphansSingleWaitTestHand()
    {
        _closedTiles = new List<TileObject>
        {
            OneMan(), NineMan(),
            OnePin(), NinePin(),
            OneSou(), NineSou(),
            EastWind(), SouthWind(),
            WestWind(), NorthWind(),
            GreenDragon(),
            RedDragon(),
            RedDragon()
        };
        //Waiting on White Dragon
    }
}