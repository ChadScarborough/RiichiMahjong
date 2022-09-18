using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public sealed class TwoSidedTripletWaitTestHand : TestHand
{
    public TwoSidedTripletWaitTestHand()
    {
        _closedTiles = new List<Tile>
        {
            TwoMan(), TwoMan(), TwoMan(),
            FivePin(), FivePin(), FivePin(),
            EightSou(), EightSou(), EightSou(),
            EastWind(), EastWind(),
            WhiteDragon(), WhiteDragon()
        };
        //Waiting on East or White Dragon
    }
}