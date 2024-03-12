using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ArbitraryTestHand3 : TestHand
{
    public ArbitraryTestHand3() // Should have shanten value two
    {
        _closedTiles = new List<Tile>
        {
            OneSou(), SevenMan(), TwoSou(), SixMan(), TwoSou(), FourMan(), TwoMan(),
            OnePin(), TwoSou(), EightPin(), OnePin(), SixSou(), SixSou()
        };
    }
}
