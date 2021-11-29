using RMU.Hand;
using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku
{
    public class RedDragon : AbstractYaku
    {
        private int counter;

        public RedDragon()
        {
            _name = "Red Dragon";
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
                CheckIfRedDragon(tile);
            }
            return counter >= 3;
        }

        private void CheckIfRedDragon(TileObject tile)
        {
            if (IsTileRedDragon(tile))
            {
                counter++;
            }
        }

        private bool IsTileRedDragon(TileObject tile)
        {
            return Functions.AreTilesEquivalent(tile, StandardTileList.RED_DRAGON);
        }
    }
}
