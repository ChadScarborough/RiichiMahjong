using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;

namespace RMU.Hand.TestHands
{
    public class DragonTestHand : TestHand
    {
        public DragonTestHand()
        {
            _closedTiles = new List<TileObject> 
            { 
                StandardTileList.GREEN_DRAGON.Clone(), StandardTileList.GREEN_DRAGON.Clone(), StandardTileList.GREEN_DRAGON.Clone(),
                StandardTileList.RED_DRAGON.Clone(), StandardTileList.RED_DRAGON.Clone(), StandardTileList.RED_DRAGON.Clone(),
                StandardTileList.WHITE_DRAGON.Clone(), StandardTileList.WHITE_DRAGON.Clone(), StandardTileList.WHITE_DRAGON.Clone(),
                StandardTileList.EAST_WIND.Clone(), StandardTileList.EAST_WIND.Clone(), StandardTileList.EAST_WIND.Clone(),
                StandardTileList.SOUTH_WIND.Clone()
            };
        }
    }
}
