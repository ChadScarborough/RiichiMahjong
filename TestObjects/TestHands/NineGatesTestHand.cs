using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

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
