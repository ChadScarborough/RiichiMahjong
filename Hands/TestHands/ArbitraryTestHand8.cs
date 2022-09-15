using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class ArbitraryTestHand8 : TestHand
    {
        public ArbitraryTestHand8() //Should have shanten value five
        {
            _closedTiles = new List<Tile>
            {
                NineSou(), EightSou(), FiveMan(), EightPin(), GreenDragon(), SevenSou(),
                SouthWind(), SevenMan(), FivePin(), EightMan(), WhiteDragon(), ThreeSou(), TwoMan()
            };
        }
    }
}
