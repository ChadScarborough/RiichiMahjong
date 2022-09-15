using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class FourLittleWindsTwoWestsTestHand : TestHand
    {
        public FourLittleWindsTwoWestsTestHand()
        {
            _closedTiles = new List<Tile>
            {
                EastWind(), EastWind(), EastWind(),
                SouthWind(), SouthWind(), SouthWind(),
                WestWind(), WestWind(),
                NorthWind(), NorthWind(), NorthWind(),
                GreenDragon(), GreenDragon()
            };
        }
    }
}