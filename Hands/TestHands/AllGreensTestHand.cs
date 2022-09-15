using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class AllGreensTestHand : TestHand
    {
        public AllGreensTestHand()
        {
            _closedTiles = new List<Tile>
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