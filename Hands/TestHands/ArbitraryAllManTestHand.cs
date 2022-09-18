using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class ArbitraryAllManTestHand : TestHand
{
    public ArbitraryAllManTestHand()
    {
        _closedTiles = new List<Tile> //Should be in tenpai
        {
            NineMan(), FourMan(), SevenMan(), SixMan(), ThreeMan(), FiveMan(),
            OneMan(), SevenMan(), TwoMan(), FourMan(), EightMan(), FourMan(), SevenMan()
        };
    }
}
