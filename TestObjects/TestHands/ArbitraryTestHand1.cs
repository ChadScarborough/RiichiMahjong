using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ArbitraryTestHand1 : TestHand
{
    public ArbitraryTestHand1()
    {
        _closedTiles = new List<Tile> //Should be three from tenpai (five as standard hand, three as seven pairs)
        {
            SouthWind(), OneMan(), OneMan(), EightSou(), GreenDragon(), RedDragon(),
            FourSou(), NorthWind(), FourPin(), WestWind(), NinePin(), GreenDragon(), NorthWind()
        };
    }
}
