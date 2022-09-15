using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands;

public class SevenPairsTestHand : TestHand
{
    public SevenPairsTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), OneMan(),
            TwoPin(), TwoPin(),
            ThreeSou(), ThreeSou(),
            FiveMan(), FiveMan(),
            SixSou(), SixSou(),
            SouthWind(), SouthWind(),
            RedDragon()
        };
        //Waiting on Red Dragon
    }
}