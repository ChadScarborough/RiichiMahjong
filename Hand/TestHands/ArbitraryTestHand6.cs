using System;
using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class ArbitraryTestHand6 : TestHand
    {
        public ArbitraryTestHand6() //Should have shanten value five
        {
            _closedTiles = new List<TileObject> 
            {
                TwoSou(), SixMan(), EightSou(), FiveSou(), ThreeSou(), EightPin(), ThreePin(),
                SixSou(), ThreeSou(), GreenDragon(), NinePin(), WestWind(), NinePin()
            };
        }
    }
}
