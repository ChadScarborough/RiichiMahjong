using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
namespace RMU.Hands.TestHands
{
    public class ArbitraryTestHand2 : TestHand
    {
        public ArbitraryTestHand2() //Should have shanten value of four
        {
            _closedTiles = new List<TileObject>
            {
                NinePin(), OneMan(), ThreePin(), NinePin(), NineMan(), NinePin(), EightPin(),
                SevenSou(), SevenSou(), GreenDragon(), FiveSou(), RedDragon(), TwoPin()
            };
        }
    }
}
