using System.Collections.Generic;
using RMU.Tiles;
using RMU.Wall;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class CallsTestHand : TestHand
    {
        public CallsTestHand()
        {
            _closedTiles = new List<Tile>
            {
                OneMan(), TwoMan(), FourMan(), FiveMan(),
                FiveSou(), FiveSou(),
                SevenPin(), SevenPin(), SevenPin()
            };
        }
    }
}