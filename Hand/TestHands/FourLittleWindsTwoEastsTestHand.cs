using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class FourLittleWindsTwoEastsTestHand : TestHand
    {
        public FourLittleWindsTwoEastsTestHand()
        {
            _closedTiles = new List<TileObject>
            {
                EastWind(), EastWind(),
                SouthWind(), SouthWind(), SouthWind(),
                WestWind(), WestWind(), WestWind(),
                NorthWind(), NorthWind(), NorthWind(),
                GreenDragon(), GreenDragon()
            };
        }
    }
}