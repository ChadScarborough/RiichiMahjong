using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class AllSimplesTestHand : TestHand
{
    public AllSimplesTestHand()
    {
        _closedTiles = new List<Tile>
        {
            TwoMan(), ThreeMan(), FourMan(),
            FivePin(), FivePin(), FivePin(),
            SixSou(), SevenSou(), EightSou(),
            TwoPin(), TwoPin(), TwoPin(),
            EightMan()
        };
    }
}
