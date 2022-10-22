using RMU.Tiles;

namespace RMU.TestObjects.TestHands;

public sealed class SevenPairsWithOneDuplicatePairTestHand : TestHand
{
    public SevenPairsWithOneDuplicatePairTestHand()
    {
        _closedTiles = new List<Tile>
        {
            TwoMan(), TwoMan(),
            ThreePin(), ThreePin(),
            FourSou(), FourSou(),
            GreenDragon(), GreenDragon(),
            GreenDragon(), GreenDragon(),
            WhiteDragon(), WhiteDragon(),
            SevenMan()
        };
    }
}