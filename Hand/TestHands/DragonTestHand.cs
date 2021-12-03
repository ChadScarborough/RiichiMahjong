using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;
using RMU.Algorithms;

namespace RMU.Hand.TestHands
{
    public class DragonTestHand : TestHand
    {
        public DragonTestHand()
        {
            _closedTiles = new List<TileObject>();
            _handSorter = new HandSorter();
            SetTileValues();
            SetTileSuits();
            FillHand();
        }

        private void SetTileSuits()
        {
            _tileSuits = new List<Enums.Suit>
            {
                Enums.DRAGON, Enums.DRAGON, Enums.DRAGON,
                Enums.DRAGON, Enums.DRAGON, Enums.DRAGON,
                Enums.DRAGON, Enums.DRAGON, Enums.DRAGON,
                Enums.WIND, Enums.WIND, Enums.WIND,
                Enums.WIND
            };
        }

        private void SetTileValues()
        {
            _tileValues = new List<int>
            {
                ConstValues.GREEN_DRAGON, ConstValues.GREEN_DRAGON, ConstValues.GREEN_DRAGON,
                ConstValues.RED_DRAGON, ConstValues.RED_DRAGON, ConstValues.RED_DRAGON,
                ConstValues.WHITE_DRAGON, ConstValues.WHITE_DRAGON, ConstValues.WHITE_DRAGON,
                ConstValues.EAST_WIND, ConstValues.EAST_WIND, ConstValues.EAST_WIND,
                ConstValues.SOUTH_WIND
            };
        }
    }
}
