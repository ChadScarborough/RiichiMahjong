using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class ArbitraryAllSouTestHand : TestHand
    {
        public ArbitraryAllSouTestHand()
        {
            _closedTiles = new List<TileObject> //Should be tenpai
            {
                SixSou(), TwoSou(), OneSou(), ThreeSou(), TwoSou(), TwoSou(), SixSou(),
                SevenSou(), SixSou(), FiveSou(), TwoSou(), SevenSou(), NineSou()
            };
        }
    }
}
