using System;
using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class ArbitraryTestHand9 : TestHand
    {
        public ArbitraryTestHand9() //Should have shanten value three
        {
            _closedTiles = new List<TileObject>
            {
                SouthWind(), FiveMan(), ThreeSou(), FourMan(), SevenMan(), EightPin(), FivePin(),
                TwoSou(), TwoSou(), TwoPin(), ThreePin(), TwoSou(), SixMan()
            };
        }
    }
}
