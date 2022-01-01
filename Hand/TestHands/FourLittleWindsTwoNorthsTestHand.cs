using System.Collections.Generic;
using static RMU.Globals.StandardTileList;
using RMU.Tiles;

namespace RMU.Hand.TestHands
{
    public class FourLittleWindsTwoNorthsTestHand : TestHand
    {
        public FourLittleWindsTwoNorthsTestHand()
        {
            _closedTiles = new List<TileObject>
            {
                EastWind(), EastWind(), EastWind(),
                SouthWind(), SouthWind(), SouthWind(),
                WestWind(), WestWind(), WestWind(),
                NorthWind(), NorthWind(),
                GreenDragon(), GreenDragon()
            };
        }
    }
}