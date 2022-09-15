using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class ArbitraryAllManTestHand : TestHand
    {
        public ArbitraryAllManTestHand()
        {
            _closedTiles = new List<Tile> //Should be in tenpai
            {
                NineMan(), FourMan(), SevenMan(), SixMan(), ThreeMan(), FiveMan(),
                OneMan(), SevenMan(), TwoMan(), FourMan(), EightMan(), FourMan(), SevenMan()
            };
        }
    }
}
