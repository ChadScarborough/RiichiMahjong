using RMU.Hand;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Yaku.Yakuman
{
    public class AllHonors : AbstractYakuman
    {
        public AllHonors()
        {
            _name = "All Honors";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            foreach(TileObject tile in hand.Listify(extraTile))
            {
                if (tile.IsHonor() == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
