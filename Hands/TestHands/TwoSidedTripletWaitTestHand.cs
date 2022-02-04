using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands;

public class TwoSidedTripletWaitTestHand : TestHand
{
    public TwoSidedTripletWaitTestHand()
    {
        _closedTiles = new List<TileObject>
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