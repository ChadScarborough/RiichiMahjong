using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class PairWaitTestHand : TestHand
{
    public PairWaitTestHand()
    {
        _closedTiles = new List<Tile>
        {
            OneMan(), OneMan(), OneMan(),
            ThreePin(), ThreePin(), ThreePin(),
            FiveSou(), FiveSou(), FiveSou(),
            EightMan(), EightMan(), EightMan(),
            RedDragon()
        };
        //Waiting on another red dragon
    }
}