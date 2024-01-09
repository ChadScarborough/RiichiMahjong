using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class CallsTestHand : TestHand
{
    public CallsTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), TwoMan(), FourMan(), FiveMan(),
            FiveSou(), FiveSou(),
            SevenPin(), SevenPin(), SevenPin()
        };
    }
}