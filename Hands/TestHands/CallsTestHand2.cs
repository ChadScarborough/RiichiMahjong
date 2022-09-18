using System.Collections.Generic;
using RMU.Tiles;
using RMU.Wall;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class CallsTestHand2 : TestHand
    {
        public CallsTestHand2()
        {
            _closedTiles = new List<Tile>
            {
                ThreeMan(), ThreeMan(),
                ThreeSou(), FourSou(), SixSou(), SevenSou(),
                SevenPin(), SevenPin()
            };
        }
    }
}