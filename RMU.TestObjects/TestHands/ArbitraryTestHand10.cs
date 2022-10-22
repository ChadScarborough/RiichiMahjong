using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ArbitraryTestHand10 : TestHand
{
    public ArbitraryTestHand10() //Should have shanten value three
    {
        _closedTiles = new List<Tile>
        {
            SevenMan(), FiveSou(), FivePin(), NineSou(), SevenPin(), NinePin(), NineMan(),
            FiveSou(), EightPin(), TwoSou(), WestWind(), EightMan(), SevenMan()
        };
    }
}
