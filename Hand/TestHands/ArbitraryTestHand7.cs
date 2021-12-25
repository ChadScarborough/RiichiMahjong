using System;
using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class ArbitraryTestHand7 : TestHand
    {
        public ArbitraryTestHand7() // Should have shanten value 5
        {
            _closedTiles = new List<TileObject>
            {
                WestWind(), FourPin(), OneMan(), WhiteDragon(), EightPin(), NinePin(), FourMan(),
                TwoSou(), SevenMan(), FiveMan(), OnePin(), NorthWind(), OnePin()
            };
        }
    }
}
