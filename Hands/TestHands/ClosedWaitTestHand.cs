using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands;

public class ClosedWaitTestHand : TestHand
{
    public ClosedWaitTestHand()
    {
        _closedTiles = new List<TileObject>
        {
            FourMan(), FourMan(), FourMan(),
            FiveSou(), SixSou(), SevenSou(),
            TwoPin(), TwoPin(), TwoPin(),
            OneMan(), OneMan(),
            FourPin(), SixPin()
        };
        //Waiting on Five Pin
    }
}