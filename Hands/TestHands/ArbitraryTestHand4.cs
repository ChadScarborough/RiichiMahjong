using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class ArbitraryTestHand4 : TestHand
    {
        public ArbitraryTestHand4() //Should have shanten value three
        {
            _closedTiles = new List<TileObject>
            {
                TwoPin(), FourMan(), TwoPin(), TwoPin(), NineSou(), EightSou(), SouthWind(),
                SevenMan(), OneSou(), FourPin(), SixMan(), EightPin(), FourMan()
            };
        }
    }
}
