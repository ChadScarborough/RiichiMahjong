using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class AllGreensTestHand : TestHand
    {
        public AllGreensTestHand()
        {
            _closedTiles = new List<TileObject>
            {
                TwoSou(), TwoSou(), TwoSou(),
                FourSou(), FourSou(), FourSou(),
                SixSou(), SixSou(), SixSou(),
                EightSou(), EightSou(),
                GreenDragon(), GreenDragon()
            };
        }
    }
}