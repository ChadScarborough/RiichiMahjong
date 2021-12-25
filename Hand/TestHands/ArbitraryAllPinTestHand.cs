using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class ArbitraryAllPinTestHand : TestHand
    {
        public ArbitraryAllPinTestHand()
        {
            _closedTiles = new List<TileObject> // Should be one from tenpai
            {
                FourPin(), TwoPin(), TwoPin(), FourPin(), NinePin(), NinePin(), SevenPin(),
                OnePin(), EightPin(), SixPin(), FivePin(), EightPin(), TwoPin()
            };
        }
    }
}
