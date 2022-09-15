using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMU.Hands.TestHands
{
    public class LittleThreeDragonsTwoRedTestHand : TestHand
    {
        public LittleThreeDragonsTwoRedTestHand()
        {
            _closedTiles = new List<Tile>
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