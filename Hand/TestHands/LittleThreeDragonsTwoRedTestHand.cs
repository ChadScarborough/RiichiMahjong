using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hand.TestHands
{
    public class LittleThreeDragonsTwoRedTestHand : TestHand
    {
        public LittleThreeDragonsTwoRedTestHand()
        {
            _closedTiles = new List<TileObject>
            {
                GreenDragon(), GreenDragon(), GreenDragon(),
                RedDragon(), RedDragon(),
                WhiteDragon(), WhiteDragon(), WhiteDragon(),
                SevenMan(), EightMan(), NineMan(),
                OneSou(), OneSou()
            };
        }
    }
}