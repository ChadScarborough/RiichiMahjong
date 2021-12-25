using System;
using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class ArbitraryTestHand3 : TestHand
    {
        public ArbitraryTestHand3() // Should have shanten value two
        {
            _closedTiles = new List<TileObject>
            {
                OneSou(), SevenMan(), TwoSou(), SixMan(), TwoSou(), FourMan(), TwoMan(),
                OnePin(), TwoSou(), EightPin(), OnePin(), SixSou(), SixSou()
            };
        }
    }
}
