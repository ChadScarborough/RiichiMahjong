using RMU.Tiles;
using RMU.Algorithms;
using RMU.Globals;
using System.Collections.Generic;

namespace RMU.Hand.TestHands
{
    public class AllTerminalsTestHand : TestHand
    {
        public AllTerminalsTestHand()
        {
            _closedTiles = new List<TileObject>
            {
                StandardTileList.ONE_MAN.Clone(), StandardTileList.ONE_MAN.Clone(), StandardTileList.ONE_MAN.Clone(),
                StandardTileList.NINE_MAN.Clone(), StandardTileList.NINE_MAN.Clone(), StandardTileList.NINE_MAN.Clone(),
                StandardTileList.ONE_PIN.Clone(), StandardTileList.ONE_PIN.Clone(), StandardTileList.ONE_PIN.Clone(),
                StandardTileList.NINE_PIN.Clone(), StandardTileList.NINE_PIN.Clone(), StandardTileList.NINE_PIN.Clone(),
                StandardTileList.ONE_SOU.Clone()
            };
        }
    }
}
