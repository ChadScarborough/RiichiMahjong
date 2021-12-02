using RMU.Hand;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku
{
    public class WhiteDragon : AbstractYaku
    {
        private int counter;

        public WhiteDragon()
        {
            _name = "White Dragon";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }
        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            counter = 0;
            List<TileObject> tiles = hand.Listify(extraTile);

            foreach (TileObject tile in tiles)
            {
                CheckIfWhiteDragon(tile);
            }
            return counter >= 3;
        }

        private void CheckIfWhiteDragon(TileObject tile)
        {
            if (IsTileWhiteDragon(tile))
            {
                counter++;
            }
        }

        private bool IsTileWhiteDragon(TileObject tile)
        {
            return Functions.AreTilesEquivalent(tile, StandardTileList.WHITE_DRAGON);
        }
    }
}
