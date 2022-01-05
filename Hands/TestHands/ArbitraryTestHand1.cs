using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class ArbitraryTestHand1 : TestHand
    {
        public ArbitraryTestHand1()
        {
            _closedTiles = new List<TileObject> ///Should be Five from tenpai
            {
                SouthWind(), OneMan(), OneMan(), EightSou(), GreenDragon(), RedDragon(),
                FourSou(), NorthWind(), FourPin(), WestWind(), NinePin(), GreenDragon(), NorthWind()
            };
        }
    }
}
