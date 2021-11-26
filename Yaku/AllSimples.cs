using RMU.Hand;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Yaku
{
    public class AllSimples : Yaku
    {

        public AllSimples()
        {
            _name = "All Simples";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            foreach (TileObject tile in hand.Listify(extraTile))
            {
                if (tile.IsHonor() || tile.IsTerminal())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
