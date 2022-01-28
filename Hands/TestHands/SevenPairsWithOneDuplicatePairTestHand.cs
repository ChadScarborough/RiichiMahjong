using System.Collections.Generic;
using static RMU.Globals.StandardTileList;
using RMU.Tiles;

namespace RMU.Hands.TestHands;

public class SevenPairsWithOneDuplicatePairTestHand : TestHand
{
    public SevenPairsWithOneDuplicatePairTestHand()
    {
        _closedTiles = new List<TileObject>
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