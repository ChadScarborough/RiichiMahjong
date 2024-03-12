using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class AllTerminalsTestHand : TestHand
{
    public AllTerminalsTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), OneMan(), OneMan(),
            NineMan(), NineMan(), NineMan(),
            OnePin(), OnePin(), OnePin(),
            NinePin(), NinePin(), NinePin(),
            OneSou()
        };
    }
}
