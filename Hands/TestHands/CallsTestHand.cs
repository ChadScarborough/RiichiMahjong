using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class CallsTestHand : TestHand
{
    public CallsTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), TwoMan(), FourMan(), FiveMan(),
            FiveSou(), FiveSou(),
            SevenPin(), SevenPin(), SevenPin()
        };
    }
}