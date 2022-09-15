using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands;

public class EdgeWaitTestHand : TestHand
{
    public EdgeWaitTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), TwoMan(),
            ThreePin(), ThreePin(), ThreePin(),
            TwoSou(), ThreeSou(), FourSou(),
            NineMan(), NineMan(), NineMan(),
            SouthWind(), SouthWind()
        };
        //Waiting on Three Man
    }
}