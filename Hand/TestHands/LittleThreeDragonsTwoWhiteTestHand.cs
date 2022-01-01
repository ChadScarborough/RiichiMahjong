using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class LittleThreeDragonsTwoWhiteTestHand : TestHand
    {
        public LittleThreeDragonsTwoWhiteTestHand()
        {
            _closedTiles = new List<TileObject>
            {
                RedDragon(), RedDragon(), RedDragon(),
                GreenDragon(), GreenDragon(), GreenDragon(),
                WhiteDragon(), WhiteDragon(),
                SevenMan(), EightMan(), NineMan(),
                OneSou(), OneSou()
            };
        }
    }
}