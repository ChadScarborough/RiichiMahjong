using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class ArbitraryTestHand5 : TestHand
    {
        public ArbitraryTestHand5() //Should have shanten value three
        {
            _closedTiles = new List<Tile>
            {
                SevenMan(), SevenSou(), SixSou(), SouthWind(), EightMan(), GreenDragon(), SixMan(),
                SevenMan(), SixSou(), FiveSou(), EightMan(), FivePin(), TwoSou()
            };
        }
    }
}
