using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TestHands
{
    public class TwoGroupsThreePairsOneIncompleteSequenceTestHand : TestHand
    {
        public TwoGroupsThreePairsOneIncompleteSequenceTestHand()
        {
            _closedTiles = new List<Tile>
            {
                OneMan(), OneMan(), OneMan(),
                FiveSou(), FiveSou(), FiveSou(),
                SevenPin(), SevenPin(),
                EastWind(), EastWind(),
                RedDragon(), RedDragon(),
                SixMan(), SevenMan()
            };
            //Should have shanten value 1
        }
    }
}
