using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ArbitraryAllPinTestHand : TestHand
{
    public ArbitraryAllPinTestHand()
    {
        _closedTiles = new List<Tile> // Should be one from tenpai
        {
            FourPin(), TwoPin(), TwoPin(), FourPin(), NinePin(), NinePin(), SevenPin(),
            OnePin(), EightPin(), SixPin(), FivePin(), EightPin(), TwoPin()
        };
    }
}
