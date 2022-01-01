using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class FourBigWindsTestHand : TestHand
    {
        public FourBigWindsTestHand()
        {
            _closedTiles = new List<TileObject>
            {
                EastWind(), EastWind(), EastWind(),
                SouthWind(), SouthWind(), SouthWind(),
                WestWind(), WestWind(), WestWind(),
                NorthWind(), NorthWind(), NorthWind(),
                GreenDragon()
            };
        }
    }
}