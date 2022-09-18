using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class OpenWaitTestHand : TestHand
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