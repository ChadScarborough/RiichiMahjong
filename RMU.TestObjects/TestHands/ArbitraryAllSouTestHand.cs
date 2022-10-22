using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ArbitraryAllSouTestHand : TestHand
{
    public ArbitraryAllSouTestHand()
    {
        _closedTiles = new List<Tile> //Should be tenpai
        {
            SixSou(), TwoSou(), OneSou(), ThreeSou(), TwoSou(), TwoSou(), SixSou(),
            SevenSou(), SixSou(), FiveSou(), TwoSou(), SevenSou(), NineSou()
        };
    }
}
