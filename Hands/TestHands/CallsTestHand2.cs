using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class CallsTestHand2 : TestHand
{
    public CallsTestHand2()
    {
        _closedTiles = new List<Tile>
        {
            ThreeMan(), ThreeMan(),
            ThreeSou(), FourSou(), SixSou(), SevenSou(),
            SevenPin(), SevenPin()
        };
    }
}