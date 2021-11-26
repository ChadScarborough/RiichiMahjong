using RMU.Hand;
using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku
{
    public class WhiteDragon : Yaku
    {
        private readonly string _name;
        private readonly int _value;
        private IGetNameBehaviour getNameBehaviour;
        private IGetValueBehaviour getValueBehaviour;
        private int counter;

        public WhiteDragon()
        {
            _name = "White Dragon";
            _value = 1;
            getNameBehaviour = new StandardGetNameBehaviour();
            getValueBehaviour = new StandardGetValueBehaviour();
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
            Enums.Suit tileSuit = tile.GetSuit();
            int tileValue = tile.GetValue();
            bool sameSuit = tileSuit == Enums.Suit.Dragon;
            bool sameValue = tileValue == ConstValues.WHITE_DRAGON;
            return sameSuit && sameValue;
        }

        public override string GetName()
        {
            return getNameBehaviour.GetName(_name);
        }

        public override int GetValue()
        {
            return getValueBehaviour.GetValue(_value);
        }
    }
}
