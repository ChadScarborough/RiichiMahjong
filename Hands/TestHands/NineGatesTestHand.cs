using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class NineGatesTestHand : TestHand
{
    public NineGatesTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), OneMan(), OneMan(),
            TwoMan(), ThreeMan(), FourMan(),
            FiveMan(), SixMan(), SevenMan(),
            EightMan(), NineMan(), NineMan(),
            NineMan()
        };
    }
}
