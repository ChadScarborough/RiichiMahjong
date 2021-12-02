using RMU.Hand;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku
{
    public class GreenDragon : AbstractYaku
    {
        private int counter;

        public GreenDragon()
        {
            _name = "Green Dragon";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }
        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            counter = 0;
            List<TileObject> tiles = hand.Listify(extraTile);

            foreach(TileObject tile in tiles)
            {
                CheckIfGreenDragon(tile);
            }
            return counter >= 3;
        }

        private void CheckIfGreenDragon(TileObject tile)
        {
            if (IsTileGreenDragon(tile))
            {
                counter++;
            }
        }

        private bool IsTileGreenDragon(TileObject tile)
        {
            return Functions.AreTilesEquivalent(tile, StandardTileList.GREEN_DRAGON);
        }
    }
}
