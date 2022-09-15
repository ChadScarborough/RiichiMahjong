using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands;

public class OpenWaitTestHand : TestHand
{
    public OpenWaitTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), TwoMan(), ThreeMan(),
            FourMan(), FiveMan(), SixMan(),
            ThreeSou(), FourSou(), FiveSou(),
            EightPin(), EightPin(),
            TwoPin(), ThreePin()
        };
        //Waiting on a One Pin or Four Pin
    }
}