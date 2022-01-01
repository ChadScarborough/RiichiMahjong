using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class FourLittleWindsTwoSouthsTestHand : TestHand
    {
        public FourLittleWindsTwoSouthsTestHand()
        {
            _closedTiles = new List<TileObject>
            {
                EastWind(), EastWind(), EastWind(),
                SouthWind(), SouthWind(),
                WestWind(), WestWind(), WestWind(),
                NorthWind(), NorthWind(), NorthWind(),
                GreenDragon(), GreenDragon()
            };
        }
    }
}