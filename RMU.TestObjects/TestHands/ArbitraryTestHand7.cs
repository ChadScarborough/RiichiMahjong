using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ArbitraryTestHand7 : TestHand
{
    public ArbitraryTestHand7() // Should have shanten value 5
    {
        _closedTiles = new List<Tile>
        {
            WestWind(), FourPin(), OneMan(), WhiteDragon(), EightPin(), NinePin(), FourMan(),
            TwoSou(), SevenMan(), FiveMan(), OnePin(), NorthWind(), OnePin()
        };
    }
}
