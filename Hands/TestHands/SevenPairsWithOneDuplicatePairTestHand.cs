using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

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