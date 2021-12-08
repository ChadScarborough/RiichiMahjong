using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Hand.TestHands
{
    public class AllSimplesTestHand : TestHand
    {
        public AllSimplesTestHand()
        {
            _closedTiles = new List<TileObject> 
            { 
                StandardTileList.TWO_MAN.Clone(), StandardTileList.THREE_MAN.Clone(), StandardTileList.FOUR_MAN.Clone(),
                StandardTileList.FIVE_PIN.Clone(), StandardTileList.FIVE_PIN.Clone(), StandardTileList.FIVE_PIN.Clone(),
                StandardTileList.SIX_SOU.Clone(), StandardTileList.SEVEN_SOU.Clone(), StandardTileList.EIGHT_SOU.Clone(),
                StandardTileList.TWO_PIN.Clone(), StandardTileList.TWO_PIN.Clone(), StandardTileList.TWO_PIN.Clone(),
                StandardTileList.EIGHT_MAN.Clone()
            };
        }
    }
}
