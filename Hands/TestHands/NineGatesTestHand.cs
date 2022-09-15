using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.TestHands
{
    public class NineGatesTestHand : TestHand
    {
        public NineGatesTestHand()
        {
            _closedTiles = new List<Tile> 
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
