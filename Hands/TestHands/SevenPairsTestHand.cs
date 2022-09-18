using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class SevenPairsTestHand : TestHand
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