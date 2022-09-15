using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class FourBigWindsTestHand : TestHand
    {
        public FourBigWindsTestHand()
        {
            _closedTiles = new List<Tile>
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