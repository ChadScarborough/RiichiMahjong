using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Hand.TestHands
{
    public class NineGatesTestHand : TestHand
    {
        public NineGatesTestHand()
        {
            _closedTiles = new List<TileObject> 
            { 
                StandardTileList.ONE_MAN.Clone(), StandardTileList.ONE_MAN.Clone(), StandardTileList.ONE_MAN.Clone(),
                StandardTileList.TWO_MAN.Clone(), StandardTileList.THREE_MAN.Clone(), StandardTileList.FOUR_MAN.Clone(),
                StandardTileList.FIVE_MAN.Clone(), StandardTileList.SIX_MAN.Clone(), StandardTileList.SEVEN_MAN.Clone(),
                StandardTileList.EIGHT_MAN.Clone(), StandardTileList.NINE_MAN.Clone(), StandardTileList.NINE_MAN.Clone(),
                StandardTileList.NINE_MAN.Clone()
            };
        }
    }
}
