using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
namespace RMU.Hands.TestHands
{
    public class LittleThreeDragonsTwoGreenTestHand : TestHand
    {
        public LittleThreeDragonsTwoGreenTestHand()
        {
            _closedTiles = new List<TileObject>
            {
                GreenDragon(), GreenDragon(),
                RedDragon(), RedDragon(), RedDragon(),
                WhiteDragon(), WhiteDragon(), WhiteDragon(),
                SevenMan(), EightMan(), NineMan(),
                OneSou(), OneSou()
            };
        }
    }
}