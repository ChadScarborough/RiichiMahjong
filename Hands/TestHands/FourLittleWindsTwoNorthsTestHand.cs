using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class FourLittleWindsTwoNorthsTestHand : TestHand
    {
        public FourLittleWindsTwoNorthsTestHand()
        {
            _closedTiles = new List<Tile>
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