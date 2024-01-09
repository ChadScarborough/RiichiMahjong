using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class ClosedWaitTestHand : TestHand
{
    public ClosedWaitTestHand()
    {
        _closedTiles = new List<Tile>
        {
            FourMan(), FourMan(), FourMan(),
            FiveSou(), SixSou(), SevenSou(),
            TwoPin(), TwoPin(), TwoPin(),
            OneMan(), OneMan(),
            FourPin(), SixPin()
        };
        //Waiting on Five Pin
    }
}