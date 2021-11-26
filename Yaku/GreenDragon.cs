using RMU.Hand;
using System;
using System.Collections.Generic;
using System.Text;
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
            Enums.Suit tileSuit = tile.GetSuit();
            int tileValue = tile.GetValue();
            bool sameSuit = tileSuit == Enums.Suit.Dragon;
            bool sameValue = tileValue == ConstValues.GREEN_DRAGON;
            return sameSuit && sameValue;
        }
    }
}
