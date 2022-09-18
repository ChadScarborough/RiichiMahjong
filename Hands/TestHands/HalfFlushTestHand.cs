using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class HalfFlushTestHand : TestHand
{
    public HalfFlushTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), OneMan(), OneMan(),
            TwoMan(), ThreeMan(), FourMan(),
            SevenMan(), EightMan(), NineMan(),
            EastWind(), EastWind(), EastWind(),
            RedDragon()
        };
    }
}
